using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LWEnglishPractice.Entities;

namespace LWEnglishPractice.Controllers
{
    public class LevelsController : Controller
    {
        private readonly ListenAndWriteContext _context;

        public LevelsController(ListenAndWriteContext context)
        {
            _context = context;
        }

        // GET: Levels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Level.Where(a => a.Active == 1).ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(Level lv, string action)
        {
            try
            {
                if (action.Equals("addItem"))
                {
                    lv.Idlevel = 0;

                    _context.Add(lv);

                }
                else if(action.Equals("editItem"))
                {
                    lv.Active = 1;

                    _context.Update(lv);

                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");

            }


        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lv = await _context.Level.FindAsync(id);
            lv.Active = 0;
            _context.Level.Update(lv);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }
        // GET: Levels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var level = await _context.Level
                .FirstOrDefaultAsync(m => m.Idlevel == id);
            if (level == null)
            {
                return NotFound();
            }

            return View(level);
        }

        // GET: Levels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Levels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idlevel,Level1,Levelname,Active")] Level level)
        {
            if (ModelState.IsValid)
            {
                _context.Add(level);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(level);
        }

        // GET: Levels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var level = await _context.Level.FindAsync(id);
            if (level == null)
            {
                return NotFound();
            }
            return View(level);
        }

        // POST: Levels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idlevel,Level1,Levelname,Active")] Level level)
        {
            if (id != level.Idlevel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(level);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LevelExists(level.Idlevel))
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
            return View(level);
        }

        // GET: Levels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var level = await _context.Level
                .FirstOrDefaultAsync(m => m.Idlevel == id);
            if (level == null)
            {
                return NotFound();
            }

            return View(level);
        }

        // POST: Levels/Delete/5


        private bool LevelExists(int id)
        {
            return _context.Level.Any(e => e.Idlevel == id);
        }
    }
}
