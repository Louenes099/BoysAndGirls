using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoysAndGirls8.Areas.Boy.Models;
using BoysAndGirls8.Data;

namespace BoysAndGirls8.Areas.Boy.Controllers
{
    [Area("Boy")]
    public class BoyTasksController : Controller
    {
        private readonly BoysAndGirls8Context _context;

        public BoyTasksController(BoysAndGirls8Context context)
        {
            _context = context;
        }

        // GET: Boy/BoyTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.BoyTasks.ToListAsync());
        }

        // GET: Boy/BoyTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boyTask = await _context.BoyTasks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (boyTask == null)
            {
                return NotFound();
            }

            return View(boyTask);
        }

        // GET: Boy/BoyTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boy/BoyTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TaskId,Description,Location")] BoyTask boyTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boyTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boyTask);
        }

        // GET: Boy/BoyTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boyTask = await _context.BoyTasks.FindAsync(id);
            if (boyTask == null)
            {
                return NotFound();
            }
            return View(boyTask);
        }

        // POST: Boy/BoyTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TaskId,Description,Location")] BoyTask boyTask)
        {
            if (id != boyTask.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boyTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoyTaskExists(boyTask.ID))
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
            return View(boyTask);
        }

        // GET: Boy/BoyTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boyTask = await _context.BoyTasks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (boyTask == null)
            {
                return NotFound();
            }

            return View(boyTask);
        }

        // POST: Boy/BoyTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boyTask = await _context.BoyTasks.FindAsync(id);
            _context.BoyTasks.Remove(boyTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoyTaskExists(int id)
        {
            return _context.BoyTasks.Any(e => e.ID == id);
        }
    }
}
