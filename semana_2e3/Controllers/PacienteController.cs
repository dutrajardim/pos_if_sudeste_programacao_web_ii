using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using semana_2.Models;

namespace semana_2.Controllers
{

  /// <summary>
  ///     Classe responsável pelas funcionalidades utilizdas por médicos
  ///     e nutricionista para gerenciar os pacientes
  /// </summary> 
  [Authorize(Roles = "Nutricionista,Médico")]
  public class PacienteController : Controller
  {

    // Contexto dos Models para comunicação com a base de dados
    private readonly DbIfContext _context;

    // Função responsável por inicializar os parametros da classe
    public PacienteController(DbIfContext context)
    {
      _context = context;
    }


    /// <summary>
    ///     Esta função é responsável por retornar os pacientes cadastrados
    ///     pelo profissional conectado (médico/nutricionista)
    /// </summary>
    // GET: Paciente
    public async Task<IActionResult> Index()
    {
      // recupera identificador de usuário conectado e seu cadastro profissional 
      var userid = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new ArgumentNullException("Mandatory parameter user");
      var tbProfissional = await _context.TbProfissionals.Where(prof => prof.IdUser.Equals(userid)).FirstAsync();

      // consulta paciantes cadastrados pelo profissional
      var pacientes = await (from p in _context.TbPacientes
                             join m in _context.TbMedicoPacientes
                             on p.IdPaciente equals m.IdPaciente
                             where m.IdProfissional == tbProfissional.IdProfissional
                             select p).ToListAsync<TbPaciente>();

      return View(pacientes);
    }

    /// <summary>
    ///     Esta função é responsável por retornar um paciente
    ///     pela referencial de identificador único quando cadastrado pelo
    ///     profissional conectado
    /// </summary>
    private async Task<TbPaciente?> getPaciente(int id)
    {
      // recupera identificador de usuário conectado e seu cadastro profissional 
      var userid = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new ArgumentNullException("Mandatory parameter user");
      var tbProfissional = await _context.TbProfissionals.Where(prof => prof.IdUser.Equals(userid)).FirstAsync();

      // busca paciente na base de dados e retorna somentes se ele foi cadastrado pelo profissional conectado
      var tbPaciente = await _context.TbPacientes
          .Join(_context.TbMedicoPacientes, t1 => t1.IdPaciente, t2 => t2.IdPaciente, (t1, t2) => new { t1, t2 })
          .Where(t => t.t2.IdProfissional.Equals(tbProfissional.IdProfissional))
          .Select(t => t.t1)
          .Include(t => t.IdCidadeNavigation)
          .FirstOrDefaultAsync(m => m.IdPaciente == id);

      return tbPaciente;
    }

    /// <summary>
    ///     Esta função é responsável por retornar o relacionamento profissional paciente
    ///     pela referencial de identificador único do paciente
    /// </summary>
    private async Task<TbMedicoPaciente?> getMedicoPaciente(int id)
    {
      // recupera identificador de usuário conectado e seu cadastro profissional 
      var userid = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new ArgumentNullException("Mandatory parameter user");
      var tbProfissional = await _context.TbProfissionals.Where(prof => prof.IdUser.Equals(userid)).FirstAsync();

      // consulta relacção profissional paciente
      var medicoPaciente = await _context.TbMedicoPacientes.Where(t => t.IdPaciente.Equals(id) && t.IdProfissional.Equals(tbProfissional.IdProfissional)).FirstOrDefaultAsync();

      return medicoPaciente;
    }

    // GET: Paciente/Details/5
    /// <summary>
    ///     Esta função é responsável por retornar a página de detalhes de um paciente
    ///     cadastrado pelo profissional conectado
    /// </summary>
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _context.TbPacientes == null)
      {
        return NotFound();
      }

      var tbPaciente = await getPaciente((int)id);

      if (tbPaciente == null)
      {
        return NotFound();
      }

      return View(tbPaciente);
    }

    // GET: Paciente/Create
    /// <summary>
    ///     Esta função é responsável por retornar a página de criação de paciente
    ///     populando uma lista com dados de cidades
    /// </summary>
    public IActionResult Create()
    {
      ViewData["IdCidade"] = new SelectList(_context.TbCidades, "IdCidade", "Nome");
      return View();
    }

    // POST: Paciente/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    /// <summary>
    ///     Função responsável por efetivar a criação de um usuário conforme dados
    ///     advindos do formulário de criação
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IdPaciente,Nome,Rg,Cpf,DataNascimento,NomeResponsavel,Sexo,Etnia,Endereco,Bairro,IdCidade,TelResidencial,TelComercial,TelCelular,Profissao,FlgAtleta,FlgGestante")] TbPaciente tbPaciente)
    {
      try
      {
        // verifica se os dados são válidos
        if (ModelState.IsValid)
        {
          // recupera identificador de usuário conectado e seu cadastro profissional 
          var userid = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new ArgumentNullException("Mandatory parameter user");
          var tbProfissional = await _context.TbProfissionals.Where(prof => prof.IdUser.Equals(userid)).FirstAsync();

          // cadastra o paciente
          _context.Add(tbPaciente);
          await _context.SaveChangesAsync();

          // cria um relacionamento do paciente com o profissional conectado
          TbMedicoPaciente medicoPaciente = new TbMedicoPaciente();
          medicoPaciente.IdProfissional = tbProfissional.IdProfissional;
          medicoPaciente.IdPaciente = tbPaciente.IdPaciente;
          _context.Add(medicoPaciente);
          await _context.SaveChangesAsync();

          return RedirectToAction(nameof(Index));
        }
      }
      catch (Exception e)
      {
        ModelState.AddModelError("", e.Message);
      }

      ViewData["IdCidade"] = new SelectList(_context.TbCidades, "IdCidade", "Nome", tbPaciente.IdCidade);
      return View(tbPaciente);
    }

    // GET: Paciente/Edit/5
    /// <summary>
    ///     Função responsável por retornar o formulário de
    ///     edição de um paciente cadastrado
    /// </summary>
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _context.TbPacientes == null)
      {
        return NotFound();
      }

      // recupera o paciente somente se foi cadastrado pelo profissional conectado
      var tbPaciente = await getPaciente((int)id);

      if (tbPaciente == null)
      {
        return NotFound();
      }
      ViewData["IdCidade"] = new SelectList(_context.TbCidades, "IdCidade", "Nome", tbPaciente.IdCidade);
      return View(tbPaciente);
    }

    // POST: Paciente/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    /// <summary>
    ///     Função responsável por efetivar a edição de um usuário conforme dados
    ///     advindos do formulário de edição
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("IdPaciente,Nome,Rg,Cpf,DataNascimento,NomeResponsavel,Sexo,Etnia,Endereco,Bairro,IdCidade,TelResidencial,TelComercial,TelCelular,Profissao,FlgAtleta,FlgGestante")] TbPaciente tbPaciente)
    {
      if (id != tbPaciente.IdPaciente)
      {
        return NotFound();
      }

      // retorna relacionamento de profissional paciente
      var medicoPaciente = await getMedicoPaciente(id);

      // condição não esperada em uma utilização convencional do sistema
      if (medicoPaciente == null)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(tbPaciente);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!TbPacienteExists(tbPaciente.IdPaciente))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      ViewData["IdCidade"] = new SelectList(_context.TbCidades, "IdCidade", "IdCidade", tbPaciente.IdCidade);
      return View(tbPaciente);
    }

    // GET: Paciente/Delete/5
    /// <summary>
    ///     Função responsável por retornar página para remoção de 
    ///     paciente cadastrado pelo profissional conectado
    /// </summary>
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _context.TbPacientes == null)
      {
        return NotFound();
      }

      var tbPaciente = await getPaciente((int)id);

      if (tbPaciente == null)
      {
        return NotFound();
      }

      return View(tbPaciente);
    }

    // POST: Paciente/Delete/5
    /// <summary>
    ///     Função responsável por efetivar a remoção de um usuário conforme dados
    ///     advindos da página de confirmação de remoção
    /// </summary>
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      if (_context.TbPacientes == null)
      {
        return Problem("Entity set 'DbIfContext.TbPacientes'  is null.");
      }

      var tbPaciente = await _context.TbPacientes.FindAsync(id);
      var medicoPaciente = await getMedicoPaciente((int)id);

      if (tbPaciente == null || medicoPaciente == null)
      {
        return NotFound();
      }

      if (tbPaciente != null)
      {
        _context.TbMedicoPacientes.Remove(medicoPaciente);
        _context.TbPacientes.Remove(tbPaciente);
      }

      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    /// <summary>
    ///     Função responsável por verificar se um paciente existe
    /// </summary>
    private bool TbPacienteExists(int id)
    {
      return (_context.TbPacientes?.Any(e => e.IdPaciente == id)).GetValueOrDefault();
    }
  }
}
