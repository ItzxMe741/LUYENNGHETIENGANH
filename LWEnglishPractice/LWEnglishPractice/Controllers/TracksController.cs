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
    public class TracksController : Controller
    {
        private readonly ListenAndWriteContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public TracksController(ListenAndWriteContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }
        // GET: Tracks
        public async Task<IActionResult> Index()
        {
            var listenAndWriteContext = await _context.Track.Where(a => a.Active == 1).Include(t => t.IdlessonNavigation).ToListAsync();
            return View(listenAndWriteContext);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(TrackViewModel model, string action)
        {

            try
            {
                string uniqueFileName = UploadedFile(model);
                Track track = new Track();

                try
                {


                    track.Source = uniqueFileName;
                    track.Idtrack = model.Idtrack;
                    track.Trackname = model.Trackname;
                    track.Describe = model.Describe;
                    track.Duration = model.Duration;
                    track.Idlesson = model.Idlesson;
                    track.Dateupload = model.Dateupload;

                }
                catch
                {
                    return RedirectToAction(nameof(Index));

                }
                if (action.Equals("addItem"))
                {
                    track.Idtrack = 0;

                    track.Dateupload = DateTime.Now;
                    _context.Track.Add(track);

                }
                else if (action.Equals("editItem"))
                {
                    track.Active = 1;
                    //var trackSource = _context.Track.Where(id => id.Idtrack == track.Idtrack).FirstOrDefault();
                    //if (track.Source != null)
                    //{
                       
                    //    if (trackSource.Source != null)
                    //    {
                    //        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", trackSource.Source);
                    //        System.IO.File.Delete(filePath);
                    //    }

                    //}
                    //else if (track.Source == "")
                    //{
                    //    track.Source = trackSource.Source;
                    //}

                    _context.Track.Update(track);

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
            var track = await _context.Track.FindAsync(id);
            track.Active = 0;

            _context.Track.Update(track);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }
        private string UploadedFile(TrackViewModel model)
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
        // GET: Nhanvien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhanvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrackViewModel model)
        {
            string uniqueFileName = UploadedFile(model);
            try
            {

                //copy lại nhanvien vì NhanvienViewModel không được gán bằng Nhanvien nhầm lấy hình ảnh
                Track track = new Track();
                //lấy hình ảnh
                track.Source = uniqueFileName;
                track.Idtrack = model.Idtrack;

                track.Active = 1;
                _context.Track.Add(track);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);

            }
        }

        // GET: Tracks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Track
                .Include(t => t.IdlessonNavigation)
                .FirstOrDefaultAsync(m => m.Idtrack == id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }


        private bool TrackExists(int id)
        {
            return _context.Track.Any(e => e.Idtrack == id);
        }
    }
}
