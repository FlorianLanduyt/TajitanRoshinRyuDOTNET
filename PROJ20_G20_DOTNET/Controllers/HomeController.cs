using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PROJ20_G20_DOTNET.Models.Domain;

namespace PROJ20_G20_DOTNET.Controllers {
    [AllowAnonymous]
    public class HomeController : Controller {
        private readonly ILidRepository _lidRepository;
        private readonly IAanwezigheidRepository _aanwezigheidRepository;

        public HomeController(ILidRepository lidRepository, 
            IAanwezigheidRepository aanwezigheidRepository) {
            _lidRepository = lidRepository;
            _aanwezigheidRepository = aanwezigheidRepository;
        }

        public IActionResult Index() {
            IList<string> lijst = new List<string> {
                "Profiel",
                "Aanwezigheden",
                "Lesmateriaal"
            };
            return View(lijst);
        }

        public IActionResult Profiel() {
            string user = Environment.UserName;
            _lidRepository.GetAll().SingleOrDefault(l => l.Voornaam.StartsWith(user));

            return View();
        }

        public IActionResult Aanwezigheden(int id) {
            return View();
        }

        public IActionResult LesMateriaal(int id) {
            return View();
        }



    }



}