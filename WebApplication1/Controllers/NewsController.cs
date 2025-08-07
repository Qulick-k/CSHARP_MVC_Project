using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class NewsController : Controller
    {
        private readonly KcgContext _context;

        public NewsController(KcgContext context)
        {
            _context = context;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            var result = from a in _context.News
                         select new NewsDto
                         {
                             NewsId = a.NewsId,
                             Title = a.Title,
                             StartDateTime = a.StartDateTime,
                             EndDateTime = a.EndDateTime,
                             Click = a.Click,
                             UpdateDateTime = a.UpdateDateTime,
                             Enable = a.Enable                             
                         };

            return View(await result.ToListAsync());
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: News/Create 
        public IActionResult Create()
        {
            return View();
        }

        // POST: News/Create  沒放[HttpPost]的話，就預設走 GET 方法
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsCreateDto news)
        {
            if (ModelState.IsValid)
            {
                News insert = new News()
                {
                    Title = news.Title,
                    Content = news.Content,
                    StartDateTime = news.StartDateTime,
                    EndDateTime = news.EndDateTime,
                    UpdateDateTime = news.UpdateDateTime,
                    InsertDateTime = news.InsertDateTime,
                    Click = 0,
                    Enable = true,
                    InsertEmploeeId = 1,
                    UpdateEmploeeId = 1
                };

                _context.News.Add(insert);

               await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("NewsId,Title,Content,StartDateTime,EndDateTime,Click,UpdateDateTime,UpdateEmploeeId,InsertDateTime,InsertEmploeeId,Enable")] News news)
        {
            if (id != news.NewsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.NewsId))
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
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var news = await _context.News.FindAsync(id);
            if (news != null)
            {
                _context.News.Remove(news);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(Guid id)
        {
            return _context.News.Any(e => e.NewsId == id);
        }
    }
}
