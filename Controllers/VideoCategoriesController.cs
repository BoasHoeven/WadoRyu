using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JokesWebApp.Data;
using WadoRyu.Models;

namespace WadoRyu.Controllers
{
    public class VideoCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VideoCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VideoCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.VideoCategory.ToListAsync());
        }

        // GET: VideoCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoCategory = await _context.VideoCategory
                .FirstOrDefaultAsync(m => m.VideoCategoryID == id);
            if (videoCategory == null)
            {
                return NotFound();
            }

            return View(videoCategory);
        }

        // GET: VideoCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VideoCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoCategoryID,Name")] VideoCategory videoCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videoCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(videoCategory);
        }

        // GET: VideoCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoCategory = await _context.VideoCategory.FindAsync(id);
            if (videoCategory == null)
            {
                return NotFound();
            }
            return View(videoCategory);
        }

        // POST: VideoCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideoCategoryID,Name")] VideoCategory videoCategory)
        {
            if (id != videoCategory.VideoCategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videoCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoCategoryExists(videoCategory.VideoCategoryID))
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
            return View(videoCategory);
        }

        // GET: VideoCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoCategory = await _context.VideoCategory
                .FirstOrDefaultAsync(m => m.VideoCategoryID == id);
            if (videoCategory == null)
            {
                return NotFound();
            }

            return View(videoCategory);
        }

        // POST: VideoCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var videoCategory = await _context.VideoCategory.FindAsync(id);
            _context.VideoCategory.Remove(videoCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoCategoryExists(int id)
        {
            return _context.VideoCategory.Any(e => e.VideoCategoryID == id);
        }
    }
}
