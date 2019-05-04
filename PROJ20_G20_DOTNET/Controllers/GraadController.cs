using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PROJ20_G20_DOTNET.Models.Domain;

namespace PROJ20_G20_DOTNET.Controllers
{
    public class GraadController : Controller
    {
        private IGraadRepository _graadRepository;

        public GraadController(IGraadRepository graadRepository)
        {
            _graadRepository = graadRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Graad> graden = _graadRepository.GetAll();
            return View(graden);
        }

    }
}