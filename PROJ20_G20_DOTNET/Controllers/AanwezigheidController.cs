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
        [HttpPost]
        public IActionResult Index(string BeginDatum, string EindDatum, string Naam) {
            string activiteitNaam = Naam ?? "";
            DateTime start, eind;
            if (BeginDatum == null) { start = new DateTime(1970,1,1); } else { start = Convert.ToDateTime(BeginDatum); } // Als je niets ingeeft bij data zal hij de range tussen 1970(vaak gebruikte start defaultdate) en huidige datum + 50 jaar zetten
            if (EindDatum == null) { eind = DateTime.Today.AddYears(50); } else { eind = Convert.ToDateTime(EindDatum); }

            IEnumerable<Activiteit> activiteiten = _activiteitRepository
                .GetAll()
                .Where(
                    ac => ac.BeginDatum >= start && 
                    ac.BeginDatum <= eind &&
                    ac.Naam.Contains(activiteitNaam, StringComparison.CurrentCultureIgnoreCase));

            return View(activiteiten);
        }

        public IActionResult Aanwezigheden(int id)
        {
            Activiteit activiteit = _activiteitRepository.GetBy(id);
            return View(activiteit);
        }
        [HttpPost]
        public IActionResult Aanwezigheden(int id, string Naam) {
            string naamFilter = Naam ?? "";
            Activiteit activiteit = _activiteitRepository.GetBy(id);
            activiteit.ActiviteitInschrijvingen = activiteit.ActiviteitInschrijvingen
                .Where(
                    ai => ai.Inschrijving.Lid.Voornaam.Contains(naamFilter, StringComparison.CurrentCultureIgnoreCase) 
                    || ai.Inschrijving.Lid.Achternaam.Contains(naamFilter, StringComparison.CurrentCultureIgnoreCase))
                .ToList();
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
        [HttpPost]
        public IActionResult VerwijderActiviteit(int id, int id2) {
            try {
                Lid lid = _lidRepository.GetBy(id2);
                Activiteit activiteit = _activiteitRepository.GetBy(id);
                ActiviteitInschrijving activiteitInschrijving =
                    activiteit.ActiviteitInschrijvingen.SingleOrDefault(ai => ai.ActiviteitId == id && ai.Inschrijving.LidId == id2);
                activiteitInschrijving.IsAanwezig = false;
                Aanwezigheid aanwezigheid = _aanwezigheidRepository.GetAll().Where(aw => aw.LidId == id2 && aw.ActiviteitId == id).SingleOrDefault();
                _aanwezigheidRepository.Delete(aanwezigheid);
                _aanwezigheidRepository.SaveChanges();
                TempData["Success"] = $"{lid.Voornaam} {lid.Achternaam} is succesvol afwezig geplaatst!";
                return RedirectToAction(nameof(Aanwezigheden), activiteit);
            } catch (Exception ex) {
            }
            TempData["Error"] = "Aanwezig plaatsen is mislukt!";
            return View(nameof(Aanwezigheden), _activiteitRepository.GetBy(id));

        }
     }
}