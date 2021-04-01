using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JokesWebApp.Data;
using WadoRyu.Models;
using System.Text.RegularExpressions;

namespace WadoRyu.Controllers
{
	public class VideosController : Controller
	{
		private readonly ApplicationDbContext _context;

		public VideosController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Videos
		public async Task<IActionResult> Index()
		{
			return View(await _context.Video.ToListAsync());
		}

		// GET: Videos for Kata
		public async Task<IActionResult> Kata()
		{
			return View(await _context.Video.Where(x => x.VideoCategory.Contains("1")).ToListAsync());
		}

		// GET: Video Gallery
		public async Task<IActionResult> Gallery()
		{
			return View(await _context.Video.ToListAsync());
		}

		// GET: Videos/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var video = await _context.Video
				.FirstOrDefaultAsync(m => m.ID == id);
			if (video == null)
			{
				return NotFound();
			}

			return View(video);
		}

		private IEnumerable<SelectListItem> GetVideoCategories()
		{

			var categories = _context.VideoCategory.Select(x => new SelectListItem
			{
				Value = x.VideoCategoryID.ToString(),
				Text = x.Name,
			});

			return new SelectList(categories, "Value", "Text");
		}

		// GET: Videos/Create
		public IActionResult Create()
		{
			var model = new VideoViewModel
			{
				VideoCategories = GetVideoCategories()
			};

			return View(model);
		}

		private bool IsYoutubeUrlValid(string url)
		{

			string pattern = @"^(?:https?\:\/\/)?(?:www\.)?(?:youtu\.be\/|youtube\.com\/(?:embed\/|v\/|watch\?v\=))([\w-]{10,12})(?:$|\&|\?\#).*";
			Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
			return reg.IsMatch(url);
		}

		// POST: Videos/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Name,Url,DateAdded,VideoCategories,SelectedValues")] VideoViewModel vmVideo)
		{
			if (vmVideo.SelectedValues.Count() > 0)
			{
				var video = new Video
				{
					Name = vmVideo.Name,
					Url = vmVideo.Url,
					DateAdded = vmVideo.DateAdded,
				};
					
				video.VideoCategory = string.Join(",", vmVideo.SelectedValues);

				if (IsYoutubeUrlValid(video.Url) && ModelState.IsValid)
				{
					video.Url = video.Url.Replace("watch?v=", "embed/");

					if (!video.Url.Contains("www."))
					{
						video.Url = "www." + video.Url;
					}

					if (!video.Url.Contains("https://"))
					{
						video.Url = "https://" + video.Url;
					}

					_context.Add(video);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
			}

			var model = new VideoViewModel
			{
				VideoCategories = GetVideoCategories()
			};

			return View(model);
		}

		// GET: Videos/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var video = await _context.Video.FindAsync(id);
			if (video == null)
			{
				return NotFound();
			}
			return View(video);
		}

		// POST: Videos/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Url,DateAdded")] Video video)
		{
			if (id != video.ID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(video);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!VideoExists(video.ID))
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
			return View(video);
		}

		// GET: Videos/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var video = await _context.Video
				.FirstOrDefaultAsync(m => m.ID == id);
			if (video == null)
			{
				return NotFound();
			}

			return View(video);
		}

		// POST: Videos/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var video = await _context.Video.FindAsync(id);
			_context.Video.Remove(video);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool VideoExists(int id)
		{
			return _context.Video.Any(e => e.ID == id);
		}
	}
}
