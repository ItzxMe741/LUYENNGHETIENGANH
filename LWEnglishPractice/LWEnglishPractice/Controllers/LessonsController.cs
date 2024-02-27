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
    public class LessonsController : Controller
    {
        private readonly ListenAndWriteContext _context;

        public LessonsController(ListenAndWriteContext context)
        {
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index()
        {
            var listenAndWriteContext = _context.Lesson.Include(l => l.IdlevelNavigation);
            return View(await listenAndWriteContext.Where(a => a.Active == 1).ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(Lesson lesson, string action)
        {
            try
            {
                if (action.Equals("addItem"))
                {
                    lesson.Idlesson = 0;
                    lesson.Datecreate = DateTime.Now;
                    _context.Add(lesson);

                }
                else if(action.Equals("editItem"))
                {
                    lesson.Active = 1;
                    _context.Update(lesson);

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
            var lesson = await _context.Lesson.FindAsync(id);
            lesson.Active = 0;
            _context.Lesson.Update(lesson);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }
        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.IdlevelNavigation)
                .FirstOrDefaultAsync(m => m.Idlesson == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            ViewData["Idlevel"] = new SelectList(_context.Level, "Idlevel", "Idlevel");
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idlesson,Lessonanme,Source,Dateuploaded,Duration,Describe,Active,Idlevel")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idlevel"] = new SelectList(_context.Level, "Idlevel", "Idlevel", lesson.Idlevel);
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            ViewData["Idlevel"] = new SelectList(_context.Level, "Idlevel", "Idlevel", lesson.Idlevel);
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idlesson,Lessonanme,Source,Dateuploaded,Duration,Describe,Active,Idlevel")] Lesson lesson)
        {
            if (id != lesson.Idlesson)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.Idlesson))
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
            ViewData["Idlevel"] = new SelectList(_context.Level, "Idlevel", "Idlevel", lesson.Idlevel);
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.IdlevelNavigation)
                .FirstOrDefaultAsync(m => m.Idlesson == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

       
        private bool LessonExists(int id)
        {
            return _context.Lesson.Any(e => e.Idlesson == id);
        }
    }
}
