using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SegundoPost.Models;
using SegundoPost.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoPost.Controllers {
    public class HomeController : Controller {
        UsersRepository repo;
        public HomeController(UsersRepository repo) {
            this.repo = repo;
        }        
        public IActionResult Index() {
            return View(this.repo.GetUsers()); ;
        }
        public IActionResult Register() {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string name, string surname, string email, string department, string job, string password) {
            this.repo.RegisterUser(name, surname, email, department, job, password);
            return RedirectToAction("Index", "Home");
        }
    }
}
