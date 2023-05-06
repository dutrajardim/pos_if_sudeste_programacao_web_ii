
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using semana_2.Models;


namespace semana_2.Controllers
{

  /// <summary>
  ///     Classe responsável pelas funcionalidades utilizadas por gestores
  ///     para gerenciar os profissionais especialistas
  /// </summary> 
  [Authorize]
  public class ProfissionalController : Controller
  {

    private readonly DbIfContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public ProfissionalController(
      UserManager<IdentityUser> userManager,
      RoleManager<IdentityRole> roleManager,
      DbIfContext context)
    {
      _context = context;
      _userManager = userManager;
      _roleManager = roleManager;
    }

    /// <summary>
    ///     Esta função é responsável por retornar os niveis de acesso
    ///     que o gestor conectado tem acesso (médico, nutricionista ou geral)
    ///     baseado em seu papel
    /// </summary> 
    private async Task<HashSet<string>> getRolesAccess()
    {
      // retorna gestor conectado
      var user = await _userManager.GetUserAsync(User);

      // inicializa um Set para armazenar os acessos que serão retornados
      HashSet<string> rolesIds = new HashSet<string>();

      if (user == null)
      {
        return rolesIds;
      }

      // consulta o papel do gestor conectado
      List<string> roles = (List<string>)await _userManager.GetRolesAsync(user);

      // retorna os componentes de papel para Médico e Nutricionista conforma salvo na base de dados
      IdentityRole? medicoRole = await _roleManager.FindByNameAsync("Médico");
      IdentityRole? nutricionistaRole = await _roleManager.FindByNameAsync("Nutricionista");

      // se gestor é gerente geral retornal acesso para gestão de médicos e nutricionistas
      if (roles.Contains("Gerente Geral"))
      {
        if (medicoRole != null)
          rolesIds.Add(medicoRole.Id);
        if (nutricionistaRole != null)
          rolesIds.Add(nutricionistaRole.Id);
      }

      // se gerente médico retorna acesso para gestão de médicos
      if (roles.Contains("Gerente Médico") && medicoRole != null)
        rolesIds.Add(medicoRole.Id);

      // se gerente nutricionista retorna acesso para gestão de nutricionistas
      if (roles.Contains("Gerente Nutricionista") && nutricionistaRole != null)
        rolesIds.Add(nutricionistaRole.Id);

      return rolesIds;
    }

    /// <summary>
    ///     Função responsável por contar quantos pacientes um 
    ///     profissional tem
    /// </summary> 
    private async Task<int> countProfessionalPatients(int id)
    {
      int qtd = await _context.TbMedicoPacientes.Where(t => t.IdProfissional.Equals(id)).CountAsync();
      return qtd;
    }

    /// <summary>
    ///     Função responsável por popular o ViewBag com as listas
    ///     necessárias a edição e retorna a view
    /// </summary> 
    private IActionResult getResult(TbProfissional tbProfissional)
    {
      ViewData["IdCidade"] = new SelectList(_context.TbCidades, "IdCidade", "Nome", tbProfissional.IdCidade);
      ViewData["IdContrato"] = new SelectList(_context.TbContratos, "IdContrato", "IdContrato", tbProfissional.IdContrato);
      ViewData["IdTipoAcesso"] = new SelectList(_context.TbTipoAcessos, "IdTipoAcesso", "Nome", tbProfissional.IdTipoAcesso);
      return View("Edit", tbProfissional);
    }

    // GET: Profissional
    /// <summary>
    ///     Funçao responsável por retornar lista de profissionais
    ///     conforme acessos mapeados por getRolesAccess
    /// </summary> 
    [Authorize(Roles = "Gerente Geral,Gerente Médico,Gerente Nutricionista")]
    public async Task<IActionResult> Index()
    {
      // retorna acessos do gestor conectado mapeados de seu papel
      HashSet<string> rolesIds = await getRolesAccess();

      // seleciona os profissionais que possuem papeis para os quais o gestor tem acesso
      var dbIfContext = _context.TbProfissionals
        .Join(_context.Users, t1 => t1.IdUser, t2 => t2.Id, (t1, t2) => new { t1, t2 })
        .Join(_context.UserRoles, users => users.t2.Id, roles => roles.UserId, (users, roles) => new { users, roles })
        .Where(t => rolesIds.Contains(t.roles.RoleId))
        .Select(t => t.users.t1)
        .Include(t => t.IdCidadeNavigation)
        .Include(t => t.IdContratoNavigation)
        .Include(t => t.IdTipoAcessoNavigation);

      return View(await dbIfContext.ToListAsync());
    }

    // GET: Profissional/Details
    /// <summary>
    ///     Funçao responsável por retornar detalhes de profissional
    ///     especialista conectado
    /// </summary> 
    [Authorize(Roles = "Nutricionista,Médico")]
    public async Task<IActionResult> LoggedInDetails()
    {
      // consulta identificador de profissional conectado
      var userid = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new ArgumentNullException("Mandatory parameter user");

      // consulta dados profissionais de usuário conectado
      var tbProfissional = await _context.TbProfissionals
          .Include(t => t.IdCidadeNavigation)
          .Include(t => t.IdContratoNavigation)
          .Include(t => t.IdTipoAcessoNavigation)
          .FirstOrDefaultAsync(m => m.IdUser.Equals(userid));

      if (tbProfissional == null)
      {
        return NotFound();
      }

      return View("Details", tbProfissional);
    }

    // Get: Profissional/LoggedInEdit
    [Authorize(Roles = "Nutricionista,Médico")]
    public async Task<IActionResult> LoggedInEdit()
    {
      var userid = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new ArgumentNullException("Mandatory parameter user");

      var tbProfissional = await _context.TbProfissionals.Where(prof => prof.IdUser.Equals(userid)).FirstAsync();
      if (tbProfissional == null)
      {
        return NotFound();
      }

      return getResult(tbProfissional);
    }

    // Post: Profissional/LoggedInEdit
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Nutricionista,Médico")]
    public async Task<IActionResult> LoggedInEdit([Bind("IdProfissional,IdTipoProfissional,IdContrato,IdTipoAcesso,IdCidade,Nome,CrmCrn,Especialidade,Logradouro,Numero,Bairro,Cep,Cidade,Estado,Ddd1,Ddd2,Telefone1,Telefone2,Salario")] TbProfissional tbProfissional)
    {
      var userid = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new ArgumentNullException("Mandatory parameter user");

      var profissionalData = await _context.TbProfissionals
        .Where(t => t.IdUser.Equals(userid)).Select(t => new { t.IdProfissional, t.Cpf }).FirstAsync();

      if (profissionalData.IdProfissional != tbProfissional.IdProfissional)
      {
        return NotFound();
      }

      ModelState.Remove("IdUser");
      ModelState.Remove("Cpf");

      if (ModelState.IsValid)
      {
        try
        {
          tbProfissional.IdUser = userid;
          tbProfissional.Cpf = profissionalData.Cpf;

          _context.Update(tbProfissional);
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(LoggedInDetails));
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!TbProfissionalExists(tbProfissional.IdProfissional))
          {
            return NotFound();
          }
          else
          {
            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
          }
        }
      }

      return getResult(tbProfissional);
    }

    // GET: Profissional/Details/5
    [Authorize(Roles = "Gerente Geral,Gerente Médico,Gerente Nutricionista")]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _context.TbProfissionals == null)
      {
        return NotFound();
      }

      HashSet<string> rolesIds = await getRolesAccess();

      var tbProfissional = await _context.TbProfissionals
          .Join(_context.Users, t1 => t1.IdUser, t2 => t2.Id, (t1, t2) => new { t1, t2 })
          .Join(_context.UserRoles, users => users.t2.Id, roles => roles.UserId, (users, roles) => new { users, roles })
          .Where(t => rolesIds.Contains(t.roles.RoleId))
          .Select(t => t.users.t1)
          .Include(t => t.IdCidadeNavigation)
          .Include(t => t.IdContratoNavigation)
          .Include(t => t.IdTipoAcessoNavigation)
          .FirstOrDefaultAsync(m => m.IdProfissional == id);

      if (tbProfissional == null)
      {
        return NotFound();
      }

      return View(tbProfissional);
    }

    // GET: Profissional/Edit/5
    [Authorize(Roles = "Gerente Geral,Gerente Médico,Gerente Nutricionista")]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _context.TbProfissionals == null)
      {
        return NotFound();
      }

      HashSet<string> rolesIds = await getRolesAccess();

      var tbProfissional = await _context.TbProfissionals
        .Join(_context.Users, t1 => t1.IdUser, t2 => t2.Id, (t1, t2) => new { t1, t2 })
        .Join(_context.UserRoles, users => users.t2.Id, roles => roles.UserId, (users, roles) => new { users, roles })
        .Where(t => rolesIds.Contains(t.roles.RoleId))
        .Select(t => t.users.t1)
        .FirstOrDefaultAsync(t => t.IdProfissional.Equals(id));

      if (tbProfissional == null)
      {
        return NotFound();
      }

      return getResult(tbProfissional);
    }

    // POST: Profissional/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Gerente Geral,Gerente Médico,Gerente Nutricionista")]
    public async Task<IActionResult> Edit(int id, [Bind("IdProfissional,IdTipoProfissional,IdContrato,IdTipoAcesso,IdCidade,Nome,Cpf,CrmCrn,Especialidade,Logradouro,Numero,Bairro,Cep,Cidade,Estado,Ddd1,Ddd2,Telefone1,Telefone2,Salario")] TbProfissional tbProfissional)
    {
      if (id != tbProfissional.IdProfissional)
      {
        return NotFound();
      }

      HashSet<string> rolesIds = await getRolesAccess();

      IdentityUserRole<string>? userRole = await _context.Users
        .Join(_context.TbProfissionals, t1 => t1.Id, t2 => t2.IdUser, (t1, t2) => new { t1, t2 })
        .Join(_context.UserRoles, users => users.t1.Id, roles => roles.UserId, (users, roles) => new { users, roles })
        .Where(t => t.users.t2.IdProfissional.Equals(id))
        .Select(t => t.roles)
        .FirstOrDefaultAsync();


      ModelState.Remove("IdUser");

      if (userRole == null)
        return NotFound();

      if (!rolesIds.Contains(userRole.RoleId))
      {
        ModelState.AddModelError("", "Nível de autorizaçãon insuficiente para remover este profissional.");
        return getResult(tbProfissional);
      }

      if (ModelState.IsValid)
      {
        try
        {
          tbProfissional.IdUser = userRole.UserId;
          _context.Update(tbProfissional);
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!TbProfissionalExists(tbProfissional.IdProfissional))
          {
            return NotFound();
          }
          else
          {
            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
          }
        }
      }

      return getResult(tbProfissional);
    }

    // GET: Profissional/Delete/5
    [Authorize(Roles = "Gerente Geral,Gerente Médico,Gerente Nutricionista")]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _context.TbProfissionals == null)
      {
        return NotFound();
      }

      HashSet<string> rolesIds = await getRolesAccess();

      var tbProfissional = await _context.TbProfissionals
          .Join(_context.Users, t1 => t1.IdUser, t2 => t2.Id, (t1, t2) => new { t1, t2 })
          .Join(_context.UserRoles, users => users.t2.Id, roles => roles.UserId, (users, roles) => new { users, roles })
          .Where(t => rolesIds.Contains(t.roles.RoleId))
          .Select(t => t.users.t1)
          .Include(t => t.IdCidadeNavigation)
          .Include(t => t.IdContratoNavigation)
          .Include(t => t.IdTipoAcessoNavigation)
          .FirstOrDefaultAsync(m => m.IdProfissional == id);

      int patientsQtd = await countProfessionalPatients((int)id);

      ViewData["patientsCount"] = patientsQtd;

      if (tbProfissional == null)
      {
        return NotFound();
      }

      return View(tbProfissional);
    }

    // POST: Profissional/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Gerente Geral,Gerente Médico,Gerente Nutricionista")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      if (_context.TbProfissionals == null)
      {
        return Problem("Entity set 'DbIfContext.TbProfissionals'  is null.");
      }

      HashSet<string> rolesIds = await getRolesAccess();

      int patientsQtd = await countProfessionalPatients((int)id);

      if (patientsQtd > 0)
      {
        throw new Exception("Não é posssível remover profissional com paciente cadastrado.");
      }

      var userProfissional = await _context.TbProfissionals
        .Join(_context.Users, t1 => t1.IdUser, t2 => t2.Id, (t1, t2) => new { t1, t2 })
        .Join(_context.UserRoles, users => users.t2.Id, roles => roles.UserId, (users, roles) => new { users, roles })
        .Where(t => rolesIds.Contains(t.roles.RoleId))
        .Select(t => t.users)
        .FirstOrDefaultAsync(t => t.t1.IdProfissional.Equals(id));

      if (userProfissional != null)
      {
        _context.TbProfissionals.Remove(userProfissional.t1);
        await _context.SaveChangesAsync();
        await _userManager.DeleteAsync(userProfissional.t2);
      }

      return RedirectToAction(nameof(Index));
    }

    private bool TbProfissionalExists(int id)
    {
      return (_context.TbProfissionals?.Any(e => e.IdProfissional == id)).GetValueOrDefault();
    }
  }
}
