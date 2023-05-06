// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using semana_2.Models;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace semana_2.Areas.Identity.Pages.Account
{

  public class RegisterModel : PageModel
  {
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IUserStore<IdentityUser> _userStore;
    private readonly IUserEmailStore<IdentityUser> _emailStore;
    private readonly ILogger<RegisterModel> _logger;
    private readonly IEmailSender _emailSender;
    private readonly DbIfContext _context;

    public RegisterModel(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IUserStore<IdentityUser> userStore,
        SignInManager<IdentityUser> signInManager,
        ILogger<RegisterModel> logger,
        IEmailSender emailSender,
        DbIfContext dbIfContext)
    {
      _userManager = userManager;
      _roleManager = roleManager;
      _userStore = userStore;
      _emailStore = GetEmailStore();
      _signInManager = signInManager;
      _logger = logger;
      _emailSender = emailSender;
      _context = dbIfContext;
    }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [BindProperty]
    public InputModel Input { get; set; }

    [BindProperty]
    public Models.TbProfissional TbProfissional { get; set; }

    [BindProperty]
    public Models.TbContrato TbContrato { get; set; }

    [BindProperty]
    public Models.AspNetRole Role { get; set; }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public string ReturnUrl { get; set; }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public IList<AuthenticationScheme> ExternalLogins { get; set; }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public class InputModel
    {
      /// <summary>
      ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
      ///     directly from your code. This API may change or be removed in future releases.
      /// </summary>
      [Required]
      [EmailAddress]
      [Display(Name = "Email")]
      public string Email { get; set; }

      /// <summary>
      ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
      ///     directly from your code. This API may change or be removed in future releases.
      /// </summary>
      [Required]
      [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
      [DataType(DataType.Password)]
      [Display(Name = "Password")]
      public string Password { get; set; }

      /// <summary>
      ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
      ///     directly from your code. This API may change or be removed in future releases.
      /// </summary>
      [DataType(DataType.Password)]
      [Display(Name = "Confirm password")]
      [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
      public string ConfirmPassword { get; set; }
    }

    /// <summary>
    ///     Função responsável por carregar as listas necessárias ao
    ///     cadastro de um profissional
    /// </summary>
    private void setViewData()
    {
      List<string> roles = new List<string> { "MÉDICO", "NUTRICIONISTA" };
      ViewData["IdCidade"] = new SelectList(_context.TbCidades, "IdCidade", "Nome");
      ViewData["IdPlano"] = new SelectList(_context.TbPlanos, "IdPlano", "Nome");
      ViewData["IdTipoAcesso"] = new SelectList(_context.TbTipoAcessos, "IdTipoAcesso", "Nome");
      ViewData["Role"] = new SelectList(_roleManager.Roles.Where(role => roles.Contains(role.NormalizedName)), "Name", "Name");
    }

    /// <summary>
    ///     Função responsável por retornar o formulário de criação de um usuário
    ///     sendo ele profissional ou gestor
    /// </summary>
    public async Task OnGetAsync(string returnUrl = null)
    {
      ReturnUrl = returnUrl;
      ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

      // verifica se é solicitado cadastro pra profissional especialista
      if (Request.Query["professional"] == "True")
      {
        ViewData["isProfessional"] = "True";
        setViewData();
      }
      // caso contrario define a flag como false para deixar o formulário
      // com os campos apenas de gestor
      else
      {
        ViewData["isProfessional"] = "False";
      }
    }


    /// <summary>
    ///     Função responsável por efetivar a criação de um usuário conforme dados
    ///     advindos do formulário de criação (gestor ou profissional especialista)
    /// </summary>
    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
      returnUrl ??= Url.Content("~/");
      ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

      // como a validação é automática
      // aqui é limpo para execução parcial
      ModelState.Clear();

      // verifica campos comuns para gestor ou especialista
      TryValidateModel(Input, nameof(Input));

      // se profissional especialista, tenta validar os campos próprios deste profissional
      if (Request.Query["professional"] == "True")
      {
        ViewData["isProfessional"] = "True";
        TryValidateModel(TbProfissional, nameof(TbProfissional));
        TryValidateModel(TbContrato, nameof(TbContrato));
      }

      // retira validação do campo de responsábilidade da base de dados
      ModelState.Remove("TbProfissional.IdUser");

      // verifica se os dados foram validados corretamente conforme cada profissional
      if (ModelState.IsValid)
      {
        // cria novo usuário
        var user = CreateUser();
        await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
        await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
        var result = await _userManager.CreateAsync(user, Input.Password);

        // se criação teve sucesso
        if (result.Succeeded)
        {
          _logger.LogInformation("User created a new account with password.");

          // recupera campo de identificador de usuário de responsabilidade do db
          var userId = await _userManager.GetUserIdAsync(user);

          // quando profissional especialista
          if (Request.Query["professional"] == "True")
          {
            // define papel, nutricionista ou médico, conforme preenchido em formulário
            var roleResult = await _userManager.AddToRoleAsync(user, Role.Name);

            // saving contract
            TbContrato.DataInicio = DateTime.UtcNow;
            TbContrato.DataFim = TbContrato.DataInicio.Value.AddMonths(1);
            _context.Add(TbContrato);
            await _context.SaveChangesAsync();

            // saving profissional
            TbProfissional.IdContrato = TbContrato.IdContrato;
            TbProfissional.IdUser = userId;
            _context.Add(TbProfissional);
            await _context.SaveChangesAsync();
          }

          // segue comportamento padrão do Identity
          var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
          code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
          var callbackUrl = Url.Page(
              "/Account/ConfirmEmail",
              pageHandler: null,
              values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
              protocol: Request.Scheme);

          await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
              $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

          if (_userManager.Options.SignIn.RequireConfirmedAccount)
          {
            return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
          }
          else
          {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return LocalRedirect(returnUrl);
          }
        }

        foreach (var error in result.Errors)
        {
          ModelState.AddModelError(string.Empty, error.Description);
        }
      }

      if (Request.Query["professional"] == "True")
        setViewData();

      // If we got this far, something failed, redisplay form
      return Page();
    }

    private IdentityUser CreateUser()
    {
      try
      {
        return Activator.CreateInstance<IdentityUser>();
      }
      catch
      {
        throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
            $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
            $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
      }
    }

    private IUserEmailStore<IdentityUser> GetEmailStore()
    {
      if (!_userManager.SupportsUserEmail)
      {
        throw new NotSupportedException("The default UI requires a user store with email support.");
      }
      return (IUserEmailStore<IdentityUser>)_userStore;
    }
  }
}
