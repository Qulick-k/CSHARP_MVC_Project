using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly KcgContext _kcgContext; //���b����ŧi��Ʈw����

        public HomeController(KcgContext kcgContext) //�o��O�̿�`�J�ϥΧڭ̭�]�w�n����Ʈw���󪺼g�k
        {
            _kcgContext = kcgContext;
        }

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public string Index()   //���H�N�b�@�ӭ����^��TOPMeni�����
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
