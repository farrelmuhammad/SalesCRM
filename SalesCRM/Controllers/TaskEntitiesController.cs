using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesCRM.Data;
using SalesCRM.Models;
using SalesCRM.Models.Enum;

namespace SalesCRM.Controllers
{
    [Authorize]
    public class TaskEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaskEntities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Task.Include(t => t.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TaskEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var taskEntity = await _context.Task
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (taskEntity == null)
            {
                return NotFound();
            }

            return View(taskEntity);
        }

        // GET: TaskEntities/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "CustomerName");
            return View();
        }

        // POST: TaskEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,Title,Description,DueDate,Status,CustomerId,Customer")] TaskEntity taskEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "CustomerName", taskEntity.CustomerId);
            return View(taskEntity);
        }

        // GET: TaskEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var taskEntity = await _context.Task.FindAsync(id);
            if (taskEntity == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "CustomerName", taskEntity.CustomerId);
            return View(taskEntity);
        }

        // POST: TaskEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,Title,Description,DueDate,Status,CustomerId")] TaskEntity taskEntity)
        {
            if (id != taskEntity.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskEntityExists(taskEntity.TaskId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "CustomerName", taskEntity.CustomerId);
            return View(taskEntity);
        }

        // GET: TaskEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Task == null)
            {
                return NotFound();
            }

            var taskEntity = await _context.Task
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (taskEntity == null)
            {
                return NotFound();
            }

            return View(taskEntity);
        }

        // POST: TaskEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Task == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Task'  is null.");
            }
            var taskEntity = await _context.Task.FindAsync(id);
            if (taskEntity != null)
            {
                _context.Task.Remove(taskEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskEntityExists(int id)
        {
          return (_context.Task?.Any(e => e.TaskId == id)).GetValueOrDefault();
        }
    }
}
