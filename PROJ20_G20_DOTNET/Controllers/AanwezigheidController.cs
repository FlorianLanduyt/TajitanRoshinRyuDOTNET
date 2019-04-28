using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJ20_G20_DOTNET.Models.Domain;

namespace PROJ20_G20_DOTNET.Controllers
{
    [Authorize(Policy = "Beheerder")]
    public class AanwezigheidController : Controller
    {
        private ILidRepository _lidRepository;
        private IAanwezigheidRepository _aanwezigheidRepository;
        private IActiviteitRepository _activiteitRepository;
        private IInschrijvingRepository _inschrijvingRepository;
        private IActiviteitInschrijvingRepository _activiteitInschrijvingRepository;

        public AanwezigheidController(ILidRepository lidRepository, IAanwezigheidRepository aanwezigheidRepository,
            IActiviteitRepository activiteitRepository, IInschrijvingRepository inschrijvingRepository,
            IActiviteitInschrijvingRepository activiteitInschrijvingRepository)
        {
            _lidRepository = lidRepository;
            _aanwezigheidRepository = aanwezigheidRepository;
            _activiteitRepository = activiteitRepository;
            _inschrijvingRepository = inschrijvingRepository;
            _activiteitInschrijvingRepository = activiteitInschrijvingRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Activiteit> activiteiten = _activiteitRepository.GetAll().OrderBy(a => a.BeginDatum).ToList();
            return View(activiteiten);
        }

        public IActionResult IndexAanwezigheden(int id)
        {
            Activiteit activiteit = _activiteitRepository.GetBy(id);
            return View(activiteit);
        }

        [HttpPost]
        public IActionResult VoegAanwezigheidToe(int id, int id2)
        {
            Lid lid = _lidRepository.GetBy(id2);
            Activiteit activiteit = _activiteitRepository.GetBy(id);
            Aanwezigheid aanwezigheid = new Aanwezigheid(lid, activiteit);
            _aanwezigheidRepository.Add(aanwezigheid);
            _aanwezigheidRepository.SaveChanges();
            return View(nameof(IndexAanwezigheden), activiteit);
        }


    }
}