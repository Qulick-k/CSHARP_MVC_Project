using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ATM()
        {
            //一些付款的程序

            //成功後留下成功字樣
            TempData["title"] = "使用ATM完成付款";
            return RedirectToAction("PayOK");
        }

        public IActionResult LinePay()
        {
            //一些付款的程序

            //成功後留下成功字樣
            TempData["title"] = "使用Line Pay完成付款。";
            return RedirectToAction("PayOK");
        }

        public IActionResult PayOK()
        {
            if (TempData["title"] == null)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

/* 這裡可以放一些邏輯來判斷是否是聖誕節
if (DateTime.Now.Date == Convert.ToDateTime("2025-12-25").Date)
{
    return Ok("聖誕節快樂");
}
else
{
    return Ok("今天不是聖誕節");
}

         public IActionResult View2()
        {
            return View();
        }
 
 */

/*
        private readonly KcgContext _kcgContext; // 先在全域宣告資料庫物件

        public DemoController(KcgContext kcgContext)
        {
            _kcgContext = kcgContext;
        }
         public IActionResult Index()
        { 
            TOPMenu model = _kcgContext.TOPMenu.FirstOrDefault();  //資料庫.資料表.第一筆

            return View(model);
        }
 */