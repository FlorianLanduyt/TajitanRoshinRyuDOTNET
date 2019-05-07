using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PROJ20_G20_DOTNET.Models.Domain;

namespace PROJ20_G20_DOTNET.Controllers
{
    [Authorize(Policy = "ViewHome")]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}