using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PROJ20_G20_DOTNET.Models.Domain;

namespace PROJ20_G20_DOTNET.Controllers
{
    public class OefeningController : Controller
    {
        private IOefeningRepository _oefeningRepository;

        public OefeningController(IOefeningRepository oefeningRepository)
        {
            _oefeningRepository = oefeningRepository;
        }

        public IActionResult Index(Graad id)
        {
            Graad graad = id;
            IEnumerable<Oefening> oefeningen = _oefeningRepository.GetAllByGraad(graad);
            ViewData["Graad"] = graad;
            return View(oefeningen);
        }
    }
}