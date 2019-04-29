using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJ20_G20_DOTNET.Models.Domain;

namespace PROJ20_G20_DOTNET.Controllers
{
    [Authorize(Policy = "ViewAttendings")]
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

        public IActionResult Aanwezigheden(int id)
        {
            Activiteit activiteit = _activiteitRepository.GetBy(id);
            return View(activiteit);
        }

        [HttpPost]
        public IActionResult VoegAanwezigheidToe(int id, int id2)
        {
            try {
                Lid lid = _lidRepository.GetBy(id2);
                Activiteit activiteit = _activiteitRepository.GetBy(id);
                ActiviteitInschrijving activiteitInschrijving =
                    activiteit.ActiviteitInschrijvingen.SingleOrDefault(ai => ai.ActiviteitId == id && ai.Inschrijving.LidId == id2);
                activiteitInschrijving.IsAanwezig = true;
                Aanwezigheid aanwezigheid = new Aanwezigheid(lid, activiteit);
                _aanwezigheidRepository.Add(aanwezigheid);
                _aanwezigheidRepository.SaveChanges();
                TempData["Success"] = $"{lid.Voornaam} {lid.Achternaam} is succesvol aanwezig geplaatst!";
                return RedirectToAction(nameof(Aanwezigheden), activiteit);
            }
            catch (Exception ex) {
            }
            TempData["Error"] = "Aanwezig plaatsen is mislukt!";
            return View(nameof(Aanwezigheden), _activiteitRepository.GetBy(id));
        }
    }
}