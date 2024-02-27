using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LWEnglishPractice.Entities;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace LWEnglishPractice.Controllers
{
    public class LearnersController : Controller
    {
        private readonly ListenAndWriteContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;


        public LearnersController(ListenAndWriteContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }
        // GET: Learners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Learner.Where(a => a.Active == 1).ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(LearnerViewModel model, string action)
        {

            try
            {
                string uniqueFileName = UploadedFile(model);
                Learner learner = new Learner();

                try
                {


                    learner.Image = uniqueFileName;
                    learner.Idlearner = model.Idlearner;
                    learner.Fullname = model.Fullname;
                    learner.Email = model.Email;
                    learner.Password = model.Password;
                    learner.Sex = model.Sex;
                    learner.Dateofbirth = model.Dateofbirth;

                }
                catch
                {
                    return RedirectToAction(nameof(Index));

                }
                if (action.Equals("addItem"))
                {
                    learner.Idlearner = 0;
                    learner.Joindate = DateTime.Now;

                    _context.Learner.Add(learner);

                }
                else if (action.Equals("editItem"))
                {
                    learner.Active = 1;
                    learner.Joindate = model.Joindate;
                    //var learnSource = _context.Track.Where(id => id.Idtrack == learner.Idlearner).FirstOrDefault();
                    //if (learner.Image != null)
                    //{

                    //    if (learnSource.Source != null)
                    //    {
                    //        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", learnSource.Source);
                    //        System.IO.File.Delete(filePath);
                    //    }

                    //}
                    //else if (learner.Image == "")
                    //{
                    //    learner.Image = learnSource.Source;
                    //}
                    _context.Learner.Update(learner);

                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");

            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPersonalInformation(LearnerViewModel model, string action, string Image)
        {

            try
            {
                string uniqueFileName = UploadedFile(model);
                Learner learner = new Learner();

                try
                {


                    learner.Idlearner = model.Idlearner;
                    learner.Fullname = model.Fullname;
                    learner.Email = model.Email;
                    learner.Password = model.Password;
                    learner.Sex = model.Sex;
                    learner.Dateofbirth = model.Dateofbirth;
                    learner.Joindate = model.Joindate;
                    learner.Active = 1;

                }
                catch
                {
                    return RedirectToAction(nameof(Index));

                }
                if (action.Equals("info"))
                {
                    learner.Image = Image;

                    _context.Learner.Update(learner);

                }
                else if (action.Equals("editAvatar"))
                {
                    learner.Image = uniqueFileName;

                    _context.Learner.Update(learner);

                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Profile", "Home", new { @id = model.Idlearner });

            }
            catch
            {
                return RedirectToAction("Profile","Home", new { @id=model.Idlearner});

            }


        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learner = await _context.Learner.FindAsync(id);
            learner.Active = 0;
            _context.Learner.Update(learner);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }
        private string UploadedFile(LearnerViewModel model)
        {
            string uniqueFileName = null;

            if (model.Source != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Source.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Source.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        // GET: Learners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learner
                .FirstOrDefaultAsync(m => m.Idlearner == id);
            if (learner == null)
            {
                return NotFound();
            }

            return View(learner);
        }

        // GET: Learners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Learners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idlearner,Fullname,Email,Password,Image,Joindate,Dateofbirth,Sex,Active")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(learner);
        }

        // GET: Learners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learner.FindAsync(id);
            if (learner == null)
            {
                return NotFound();
            }
            return View(learner);
        }

        // POST: Learners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idlearner,Fullname,Email,Password,Image,Joindate,Dateofbirth,Sex,Active")] Learner learner)
        {
            if (id != learner.Idlearner)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnerExists(learner.Idlearner))
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
            return View(learner);
        }

        // GET: Learners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learner
                .FirstOrDefaultAsync(m => m.Idlearner == id);
            if (learner == null)
            {
                return NotFound();
            }

            return View(learner);
        }


        private bool LearnerExists(int id)
        {
            return _context.Learner.Any(e => e.Idlearner == id);
        }
    }
}
