using AdminPage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace AdminPage.Controllers
{
    public class HomeController : Controller
    {

        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(db.User.ToList());
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            db.User.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}