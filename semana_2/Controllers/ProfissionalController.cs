using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using semana_2.Models;


namespace semana_2.Controllers
{

    public class ProfissionalController : Controller
    {
        private readonly DbIfContext _context;

        public ProfissionalController(DbIfContext context)
        {
            _context = context;
        }

        // GET: Profissional
        public async Task<IActionResult> Index()
        {
            var dbIfContext = _context.TbProfissionals.Include(t => t.IdCidadeNavigation).Include(t => t.IdContratoNavigation).Include(t => t.IdTipoAcessoNavigation);
            return View(await dbIfContext.ToListAsync());
        }

        // GET: Profissional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbProfissionals == null)
            {
                return NotFound();
            }

            var tbProfissional = await _context.TbProfissionals
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

        // GET: Profissional/Create
        public IActionResult Create()
        {
            ViewData["IdCidade"] = new SelectList(_context.TbCidades, "IdCidade", "Nome");
            ViewData["IdPlano"] = new SelectList(_context.TbPlanos, "IdPlano", "Nome");
            ViewData["IdTipoAcesso"] = new SelectList(_context.TbTipoAcessos, "IdTipoAcesso", "Nome");

            return View();
        }

        // POST: Profissional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create(System.ValueTuple<TbProfissional, TbContrato> model)
        public async Task<IActionResult> Create([Bind("IdProfissional,IdTipoProfissional,IdTipoAcesso,IdCidade,Nome,Cpf,CrmCrn,Especialidade,Logradouro,Numero,Bairro,Cep,Estado,Ddd1,Ddd2,Telefone1,Telefone2,Salario,IdPlano")] TbProfissional tbProfissional)
        {

            ModelState.Remove("IdUser");
            ModelState.Remove("IdContratoNavigation");
            ModelState.Remove("IdCidadeNavigation");

            if (ModelState.IsValid)
            {
                tbProfissional.IdUser = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new ArgumentNullException("Mandatory parameter user");
                // Contrato
                TbContrato contrato = new TbContrato();
                contrato.DataInicio = DateTime.UtcNow;
                contrato.DataFim = contrato.DataInicio.Value.AddMonths(1);
                contrato.IdPlano = tbProfissional.IdPlano;
                _context.Add(contrato);
                await _context.SaveChangesAsync();

                // Profissional
                tbProfissional.IdContrato = contrato.IdContrato;
                _context.Add(tbProfissional);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["IdCidade"] = new SelectList(_context.TbCidades, "IdCidade", "Nome", tbProfissional.IdCidade);
            ViewData["IdPlano"] = new SelectList(_context.TbPlanos, "IdPlano", "Nome", tbProfissional.IdPlano);
            ViewData["IdTipoAcesso"] = new SelectList(_context.TbTipoAcessos, "IdTipoAcesso", "Nome", tbProfissional.IdTipoAcesso);

            return View(tbProfissional);
        }

        // GET: Profissional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbProfissionals == null)
            {
                return NotFound();
            }

            var tbProfissional = await _context.TbProfissionals.FindAsync(id);
            if (tbProfissional == null)
            {
                return NotFound();
            }

            ViewData["IdCidade"] = new SelectList(_context.TbCidades, "IdCidade", "Nome", tbProfissional.IdCidade);
            ViewData["IdContrato"] = new SelectList(_context.TbContratos, "IdContrato", "IdContrato", tbProfissional.IdContrato);
            ViewData["IdTipoAcesso"] = new SelectList(_context.TbTipoAcessos, "IdTipoAcesso", "Nome", tbProfissional.IdTipoAcesso);
            return View(tbProfissional);
        }

        // POST: Profissional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProfissional,IdTipoProfissional,IdContrato,IdTipoAcesso,IdCidade,Nome,Cpf,CrmCrn,Especialidade,Logradouro,Numero,Bairro,Cep,Cidade,Estado,Ddd1,Ddd2,Telefone1,Telefone2,Salario")] TbProfissional tbProfissional)
        {
            if (id != tbProfissional.IdProfissional)
            {
                return NotFound();
            }

            ModelState.Remove("IdUser");
            ModelState.Remove("IdContratoNavigation");
            ModelState.Remove("IdCidadeNavigation");

            if (ModelState.IsValid)
            {
                try
                {
                    tbProfissional.IdUser = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new ArgumentNullException("Mandatory parameter user");
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

            ViewData["IdCidade"] = new SelectList(_context.TbCidades, "IdCidade", "Nome", tbProfissional.IdCidade);
            ViewData["IdContrato"] = new SelectList(_context.TbContratos, "IdContrato", "IdContrato", tbProfissional.IdContrato);
            ViewData["IdTipoAcesso"] = new SelectList(_context.TbTipoAcessos, "IdTipoAcesso", "Nome", tbProfissional.IdTipoAcesso);
            return View(tbProfissional);
        }

        // GET: Profissional/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbProfissionals == null)
            {
                return NotFound();
            }

            var tbProfissional = await _context.TbProfissionals
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

        // POST: Profissional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbProfissionals == null)
            {
                return Problem("Entity set 'DbIfContext.TbProfissionals'  is null.");
            }
            var tbProfissional = await _context.TbProfissionals.FindAsync(id);
            if (tbProfissional != null)
            {
                _context.TbProfissionals.Remove(tbProfissional);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbProfissionalExists(int id)
        {
            return (_context.TbProfissionals?.Any(e => e.IdProfissional == id)).GetValueOrDefault();
        }
    }
}
