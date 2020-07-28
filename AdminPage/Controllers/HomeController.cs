using AdminPage.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        [HttpGet]
        public async Task<ActionResult> Details (int? id)
        {
            if (id != null)
            {
                User user = await db.User.FirstOrDefaultAsync(p => p.id == id);
                    if (user != null)
                        return View(user);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id != null)
            {
                User user = await db.User.FirstOrDefaultAsync(p => p.id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        public async Task<ActionResult> Edit(User user)
        {
            db.User.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName ("Delete")]
        public async Task<ActionResult> ConfirmDelete (int? id)
        {
            if (id != null)
            {
                User user = await db.User.FirstOrDefaultAsync(p => p.id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id != null)
            {
                User user = await db.User.FirstOrDefaultAsync(p => p.id == id);
                db.User.Remove(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();

        }
    }
 }
