using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        // GET: /<controller>/
        public ViewResult Index()
        {
            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;
            return View();
            //return View(DateTime.Now);
        }

        public ViewResult Result()
        {
            return View((object)"Hello World");
        }

        //public RedirectResult Redirect() => RedirectPermanent("/Example/Index");
        //public RedirectToRouteResult Redirect() => RedirectToRoute(new { controller = "Example", action = "Index", ID = "MyID" });
        public RedirectToActionResult Redirect() => RedirectToAction("Index", "Home");

        public JsonResult Index2() => Json(new[] { "Alice", "Bob", "Joe" });

        public ContentResult Index3() => Content("[\"Alice\", \"Bob\", \"Joe\"]", "application/json");

        public OkObjectResult Index4() => Ok(new string[] { "Alice", "Bob", "Joe" });

        public VirtualFileResult Index5() => File("~/bower_components/bootstrap/dist/css/bootstrap.css", "text/css");

        public StatusCodeResult Index6() => StatusCode(StatusCodes.Status404NotFound);

        public NotFoundResult Index7() => NotFound();
    }
}
