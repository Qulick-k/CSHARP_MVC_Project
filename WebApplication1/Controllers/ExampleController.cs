using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("example2")]
    public class ExampleController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "Index";
        }

        [HttpGet("delete/{id?}")]
        public string Delete(int id)
        {
            return "Delete" + id;
        }

        [ActionName("delete")] //使用屬性標籤
        [HttpPost]
        public string DeletePost()
        {
            return "DeletePost";
        }
    }
}
