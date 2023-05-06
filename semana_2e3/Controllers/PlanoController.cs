using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using semana_2.Models;

namespace semana_2.Controllers
{
  [Authorize(Roles = "Gerente Geral,Gerente Nutricionista,Gerente Médico")]
  public class PlanoController : Controller
  {
    private readonly DbIfContext _context;

    public PlanoController(DbIfContext context)
    {
      _context = context;
    }

    // GET: Plano
    public async Task<IActionResult> Index()
    {
      return _context.TbPlanos != null ?
                  View(await _context.TbPlanos.ToListAsync()) :
                  Problem("Entity set 'DbIfContext.TbPlanos'  is null.");
    }

    // GET: Plano/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _context.TbPlanos == null)
      {
        return NotFound();
      }

      var tbPlano = await _context.TbPlanos
          .FirstOrDefaultAsync(m => m.IdPlano == id);
      if (tbPlano == null)
      {
        return NotFound();
      }

      return View(tbPlano);
    }

    // GET: Plano/Create
    public IActionResult Create()
    {
      return View();
    }

    // Rafael Dutra Jardim
    // POST: Plano/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IdPlano,Nome,Validade,Valor")] TbPlano tbPlano)
    {
      if (ModelState.IsValid)
      {
        _context.Add(tbPlano);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(tbPlano);
    }

    // GET: Plano/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _context.TbPlanos == null)
      {
        return NotFound();
      }

      var tbPlano = await _context.TbPlanos.FindAsync(id);
      if (tbPlano == null)
      {
        return NotFound();
      }
      return View(tbPlano);
    }

    // POST: Plano/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("IdPlano,Nome,Validade,Valor")] TbPlano tbPlano)
    {
      if (id != tbPlano.IdPlano)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(tbPlano);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!TbPlanoExists(tbPlano.IdPlano))
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
      return View(tbPlano);
    }

    // GET: Plano/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _context.TbPlanos == null)
      {
        return NotFound();
      }

      var tbPlano = await _context.TbPlanos
          .FirstOrDefaultAsync(m => m.IdPlano == id);
      if (tbPlano == null)
      {
        return NotFound();
      }

      return View(tbPlano);
    }

    // POST: Plano/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      if (_context.TbPlanos == null)
      {
        return Problem("Entity set 'DbIfContext.TbPlanos'  is null.");
      }
      var tbPlano = await _context.TbPlanos.FindAsync(id);
      if (tbPlano != null)
      {
        _context.TbPlanos.Remove(tbPlano);
      }

      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool TbPlanoExists(int id)
    {
      return (_context.TbPlanos?.Any(e => e.IdPlano == id)).GetValueOrDefault();
    }
  }
}
