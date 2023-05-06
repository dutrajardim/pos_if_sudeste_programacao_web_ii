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
  [Authorize(Roles = "Nutricionista,Médico")]
  public class AlimentoController : Controller
  {
    private readonly DbIfContext _context;

    public AlimentoController(DbIfContext context)
    {
      _context = context;
    }

    // GET: Alimento
    public async Task<IActionResult> Index()
    {
      return _context.TbAlimentos != null ?
                  View(await _context.TbAlimentos.ToListAsync()) :
                  Problem("Entity set 'DbIfContext.TbAlimentos'  is null.");
    }

    // GET: Alimento/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _context.TbAlimentos == null)
      {
        return NotFound();
      }

      var tbAlimento = await _context.TbAlimentos
          .FirstOrDefaultAsync(m => m.IdAlimento == id);
      if (tbAlimento == null)
      {
        return NotFound();
      }

      return View(tbAlimento);
    }

    // GET: Alimento/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Alimento/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IdAlimento,IdTipoQuantidade,Nome,Carboidrato,VitaminaA,VitaminaB")] TbAlimento tbAlimento)
    {
      if (ModelState.IsValid)
      {
        _context.Add(tbAlimento);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(tbAlimento);
    }

    // GET: Alimento/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _context.TbAlimentos == null)
      {
        return NotFound();
      }

      var tbAlimento = await _context.TbAlimentos.FindAsync(id);
      if (tbAlimento == null)
      {
        return NotFound();
      }
      return View(tbAlimento);
    }

    // POST: Alimento/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("IdAlimento,IdTipoQuantidade,Nome,Carboidrato,VitaminaA,VitaminaB")] TbAlimento tbAlimento)
    {
      if (id != tbAlimento.IdAlimento)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(tbAlimento);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!TbAlimentoExists(tbAlimento.IdAlimento))
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
      return View(tbAlimento);
    }

    // GET: Alimento/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _context.TbAlimentos == null)
      {
        return NotFound();
      }

      var tbAlimento = await _context.TbAlimentos
          .FirstOrDefaultAsync(m => m.IdAlimento == id);
      if (tbAlimento == null)
      {
        return NotFound();
      }

      return View(tbAlimento);
    }

    // POST: Alimento/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      if (_context.TbAlimentos == null)
      {
        return Problem("Entity set 'DbIfContext.TbAlimentos'  is null.");
      }
      var tbAlimento = await _context.TbAlimentos.FindAsync(id);
      if (tbAlimento != null)
      {
        _context.TbAlimentos.Remove(tbAlimento);
      }

      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool TbAlimentoExists(int id)
    {
      return (_context.TbAlimentos?.Any(e => e.IdAlimento == id)).GetValueOrDefault();
    }
  }
}
