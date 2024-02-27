using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LWEnglishPractice.Entities;
using System.Globalization;

namespace LWEnglishPractice.Controllers
{
    public class HistoriesController : Controller
    {
        private readonly ListenAndWriteContext _context;

        public HistoriesController(ListenAndWriteContext context)
        {
            _context = context;
        }

        // GET: Histories
        public async Task<IActionResult> Index()
        {
            var listenAndWriteContext = _context.History.Include(h => h.IdlearnerNavigation).Include(h => h.IdlessonNavigation);
            return View(await listenAndWriteContext.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(History history, string action)
        {
            try
            {
                string employeeEmail = Request.Cookies["HienCaCookie"];
                Learner learner = _context.Learner.Where(nv => nv.Email == employeeEmail).FirstOrDefault();



                if (learner == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    history.Idlearner = learner.Idlearner;
                    //history.Finishtime = history.Finishtime;
                   
                    DateTime now = DateTime.Now;
                    DateTime today = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                    history.Finishdate = today;
                    History h = _context.History.Where(l => l.Idlesson == history.Idlesson).Where(l => l.Idlearner == learner.Idlearner).FirstOrDefault();
                    if (h == null)
                    {
                        history.Idhistory = 0;

                        _context.Add(history);

                    }
                    else if (h != null)
                    {
                        _context.Update(history);

                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Learning", "Home", new { @id = history.Idlesson });
                }

            }
            catch
            {
                return RedirectToAction("Learning", "Home", new { @id = history.Idlesson });

            }


        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var history = await _context.History.FindAsync(id);
            _context.History.Update(history);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }
        // GET: Histories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.History
                .Include(h => h.IdlearnerNavigation)
                .Include(h => h.IdlessonNavigation)
                .FirstOrDefaultAsync(m => m.Idhistory == id);
            if (history == null)
            {
                return NotFound();
            }

            return View(history);
        }

        // GET: Histories/Create
        public IActionResult Create()
        {
            ViewData["Idlearner"] = new SelectList(_context.Learner, "Idlearner", "Email");
            ViewData["Idlesson"] = new SelectList(_context.Lesson, "Idlesson", "Lessonanme");
            return View();
        }

        // POST: Histories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idhistory,Score,Finishtime,Finishdate,Idlearner,Idlesson")] History history)
        {
            if (ModelState.IsValid)
            {
                _context.Add(history);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idlearner"] = new SelectList(_context.Learner, "Idlearner", "Email", history.Idlearner);
            ViewData["Idlesson"] = new SelectList(_context.Lesson, "Idlesson", "Lessonanme", history.Idlesson);
            return View(history);
        }

        // GET: Histories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.History.FindAsync(id);
            if (history == null)
            {
                return NotFound();
            }
            ViewData["Idlearner"] = new SelectList(_context.Learner, "Idlearner", "Email", history.Idlearner);
            ViewData["Idlesson"] = new SelectList(_context.Lesson, "Idlesson", "Lessonanme", history.Idlesson);
            return View(history);
        }

        // POST: Histories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idhistory,Score,Finishtime,Finishdate,Idlearner,Idlesson")] History history)
        {
            if (id != history.Idhistory)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(history);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoryExists(history.Idhistory))
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
            ViewData["Idlearner"] = new SelectList(_context.Learner, "Idlearner", "Email", history.Idlearner);
            ViewData["Idlesson"] = new SelectList(_context.Lesson, "Idlesson", "Lessonanme", history.Idlesson);
            return View(history);
        }

        // GET: Histories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.History
                .Include(h => h.IdlearnerNavigation)
                .Include(h => h.IdlessonNavigation)
                .FirstOrDefaultAsync(m => m.Idhistory == id);
            if (history == null)
            {
                return NotFound();
            }

            return View(history);
        }



        private bool HistoryExists(int id)
        {
            return _context.History.Any(e => e.Idhistory == id);
        }
    }
}
