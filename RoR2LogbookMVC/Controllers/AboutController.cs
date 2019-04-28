using Microsoft.AspNetCore.Mvc;

namespace RoR2LogbookMVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}