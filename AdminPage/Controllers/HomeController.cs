using AdminPage.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public async Task<IActionResult> Index( string name,  int page = 1, int selectKolElementov = 2, SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = selectKolElementov; //Количество элементов на странице
            IQueryable<User> user = db.User;

            //фильтрация
            if (!String.IsNullOrEmpty(name))
            {
                user = user.Where(p => p.name.Contains(name));
            }

            //сортировка
            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            user = sortOrder switch
            {
                SortState.NameDesc => user.OrderByDescending(s => s.name),
                _ => user.OrderBy(s => s.name),
            };

            // пагинация
            var count = await user.CountAsync();
            var items = await user.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(name),
                User = items,
                KolElementov = selectKolElementov,

        };

            return View(viewModel);
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<ActionResult> Delete(string [] selectedUsers)
        {
            if (selectedUsers.Length > 0)
            {
                foreach (string id in selectedUsers)
                {
                        User user = await db.User.FirstOrDefaultAsync(p => p.id == Convert.ToInt32(id));
                        db.User.Remove(user);
                        await db.SaveChangesAsync();       
                }
                return RedirectToAction("Index");
            }
            // return View(selectedUsers);
            return NotFound();
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
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

        [HttpPost]
        public async Task<ActionResult> Edit(User user)
        {
            db.User.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
 }
