using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly KcgContext _kcgContext; //先在全域宣告資料庫物件

        public HomeController(KcgContext kcgContext) //這邊是依賴注入使用我們剛設定好的資料庫物件的寫法
        {
            _kcgContext = kcgContext;
        }

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public string Index()   //先隨意在一個頁面回傳TOPMeni的資料
        {
            return _kcgContext.TOPMenu.FirstOrDefault().Name;
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult HelloWorld()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
