using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PROJ20_G20_DOTNET.Models.Domain;

namespace PROJ20_G20_DOTNET.Controllers
{
    public class OefeningController : Controller
    {
        private IOefeningRepository _oefeningRepository;
        private ILidRepository _lidRepository;

        public OefeningController(IOefeningRepository oefeningRepository, ILidRepository lidRepository)
        {
            _oefeningRepository = oefeningRepository;
            _lidRepository = lidRepository;
        }

        public IActionResult Leden()
        {
            IEnumerable<Lid> leden = _lidRepository.GetAll();
            return View(leden);
        }

        public IActionResult ToonOefeningenLid(int id)
        {
            Lid lid = _lidRepository.GetBy(id);
            Graad graadLid = lid.Graad;

            IEnumerable<Oefening> oefeningen =
                _oefeningRepository.GetAll()
                .Where(oef => (int)oef.Graad <= (int)graadLid)
                .ToList();
            return View(oefeningen);
        }

        public IActionResult RaadpleegOefening(int id)
        {
            Oefening oefening = _oefeningRepository.GetById(id);
            return View(oefening);
        }
    }
}