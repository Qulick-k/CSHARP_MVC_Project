using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class News2Controller : Controller
    {
        private readonly KcgContext _context;
        public News2Controller(KcgContext context)
        {
            _context = context;
        }

        public IActionResult Index(string keyword)
        {
            var result = from a in _context.News
                         join b in _context.TOPMenu on a.NewsId equals b.TOPMenuId
                         select new NewsDto
                         {
                             Click = a.Click,
                             Enable = a.Enable,
                             EndDateTime = a.EndDateTime,
                             NewsId = a.NewsId,
                             StartDateTime = a.StartDateTime,
                             Title = a.Title,
                             UpdateDateTime = a.UpdateDateTime,
                             UpdateEmploeeName = b.Name
                         };
            if (!string.IsNullOrEmpty(keyword)) result = result.Where(x => x.Title.Contains(keyword));
            return View(result.ToList());
        }
    }
}
