using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using FinanceTrackerProject.Models;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using System.Data.Entity;
using System;

[Authorize]
public class SavingGoalsController : Controller
{
    private readonly ApplicationDbContext _context;

    public SavingGoalsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: SavingGoals
    public async Task<IActionResult> Index()
    {
        string userId = User.Identity.Name;
        System.Collections.Generic.List<SavingGoal> savingGoals = await _context.SavingGoals.Where(g => g.UserId == userId).ToListAsync();
        return (IActionResult)View(savingGoals);
    }

    // GET: SavingGoals/Create
    public IActionResult Create()
    {
        return (IActionResult)View();
    }

    // POST: SavingGoals/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] SavingGoal savingGoal)
    {
        if (ModelState.IsValid)
        {
            savingGoal.UserId = User.Identity.Name;
            _context.Add(savingGoal);
            _ = await _context.SaveChangesAsync();
            return (IActionResult)RedirectToAction(nameof(Index));
        }
        return (IActionResult)View(savingGoal);
    }

    // GET: SavingGoals/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        SavingGoal savingGoal = await _context.SavingGoals.FindAsync(id);
        return savingGoal == null ? NotFound() : (IActionResult)View(savingGoal);
    }

    private IActionResult NotFound()
    {
        throw new NotImplementedException();
    }

    // POST: SavingGoals/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [FromForm] SavingGoal savingGoal)
    {
        if (id != savingGoal.SavingGoalId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(savingGoal);
                _ = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavingGoalExists(savingGoal.SavingGoalId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return (IActionResult)RedirectToAction(nameof(Index));
        }
        return (IActionResult)View(savingGoal);
    }

    // GET: SavingGoals/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        SavingGoal savingGoal = await _context.SavingGoals
            .FirstOrDefaultAsync(m => m.SavingGoalId == id);
        return savingGoal == null ? NotFound() : (IActionResult)View(savingGoal);
    }

    // POST: SavingGoals/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        SavingGoal savingGoal = await _context.SavingGoals.FindAsync(id);
        _ = _context.SavingGoals.Remove(savingGoal);
        _ = await _context.SaveChangesAsync();
        return (IActionResult)RedirectToAction(nameof(Index));
    }

    private bool SavingGoalExists(int id)
    {
        return _context.SavingGoals.Any(e => e.SavingGoalId == id);
    }
}

internal class FromFormAttribute : Attribute
{
}