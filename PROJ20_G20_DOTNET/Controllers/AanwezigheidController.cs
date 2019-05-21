using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJ20_G20_DOTNET.Models.Domain;
using PROJ20_G20_DOTNET.Models.ViewModels;

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
            IEnumerable<Activiteit> activiteiten 
                = _activiteitRepository
                .GetAll()
                //.Where(ac => ac.BeginDatum > DateTime.Today.AddDays(-3) && DateTime.Today.AddDays(3) > ac.BeginDatum) //geeft enkel activiteiten +- 3 dagen == range van een week
                .OrderBy(ac => ac.BeginDatum)
                .ToList();
            if (activiteiten == null) {
                return NotFound();
            }
            ViewBag.Naam = "Naam";
            return View(activiteiten);
        }

        [HttpPost]
        public IActionResult Index(string BeginDatum, string EindDatum, string Naam, string submit) {
            string activiteitNaam = Naam ?? "";
            DateTime start, eind;
            if (BeginDatum == null) { start = DateTime.Today.AddDays(-1000); } else { start = Convert.ToDateTime(BeginDatum); } // Als je niets ingeeft bij data zal hij de range tussen 1970(vaak gebruikte start defaultdate) en huidige datum + 50 jaar zetten
            if (EindDatum == null) { eind = DateTime.Today.AddDays(1000); } else { eind = Convert.ToDateTime(EindDatum); }
            ViewData["NaamFilter"] = Naam;
            IEnumerable<Activiteit> activiteiten = _activiteitRepository
                .GetAll()
                .Where(
                    ac => ac.BeginDatum >= start &&
                    ac.BeginDatum <= eind &&
                    ac.Naam.StartsWith(activiteitNaam, StringComparison.CurrentCultureIgnoreCase))
                .OrderBy(ac => ac.BeginDatum)
                .ToList();
            if (activiteiten == null) {
                return NotFound();
            }
            switch (submit) {
                case "Naam activiteit":
                    activiteiten = activiteiten.OrderBy(a => a.Naam);
                    ViewData["naamStyle"] = "visible";
                    break;
                case "Datum":
                    activiteiten = activiteiten.OrderBy(a => a.BeginDatum);
                    ViewData["begindatumStyle"] = "visible";
                    break;
                case "Tijdstip":
                    activiteiten = activiteiten.OrderBy(a => a.BeginDatum.TimeOfDay);
                    ViewData["einddatumStyle"] = "visible";
                    break;
                case "Formule":
                    activiteiten = activiteiten.OrderBy(a => a.Formule);
                    ViewData["fornuleStyle"] = "visible";
                    break;
                default:
                    activiteiten = activiteiten.OrderBy(a => a.BeginDatum);
                    break;
            }
            ViewBag.Naam = Naam;
            return View(activiteiten);
        }

        public IActionResult Aanwezigheden(int id)
        {
            Activiteit activiteit = _activiteitRepository.GetBy(id);
            if (activiteit == null) {
                return NotFound();
            }
            return View(activiteit);
        }

        [HttpPost]
        public IActionResult Aanwezigheden(int id, string Naam) {
            string naamFilter = Naam ?? "";
            Activiteit activiteit = _activiteitRepository.GetBy(id);
            if (activiteit == null) {
                return NotFound();
            }
            activiteit.ActiviteitInschrijvingen = activiteit.ActiviteitInschrijvingen
                .Where(
                    ai => ai.Inschrijving.Lid.Voornaam.StartsWith(naamFilter, StringComparison.CurrentCultureIgnoreCase) 
                    || ai.Inschrijving.Lid.Achternaam.StartsWith(naamFilter, StringComparison.CurrentCultureIgnoreCase))
                .ToList();
            ViewData["NaamFilter"] = naamFilter;
            return View(activiteit);
        }

        [HttpPost]
        public IActionResult VoegAanwezigheidToe(int id, int id2)
        {
            try {
                Lid lid = _lidRepository.GetBy(id2);
                if (lid == null) {
                    return NotFound();
                }
                Activiteit activiteit = _activiteitRepository.GetBy(id);
                if (activiteit == null) {
                    return NotFound();
                }
                ActiviteitInschrijving activiteitInschrijving =
                    activiteit.ActiviteitInschrijvingen.SingleOrDefault(ai => ai.ActiviteitId == id && ai.Inschrijving.Lid.Id == id2);
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
        public IActionResult VerwijderAanwezigheid(int id, int id2) {
            try {
                Lid lid = _lidRepository.GetBy(id2);
                if (lid == null) {
                    return NotFound();
                }
                Activiteit activiteit = _activiteitRepository.GetBy(id);
                if (activiteit == null) {
                    return NotFound();
                }
                ActiviteitInschrijving activiteitInschrijving =
                    activiteit.ActiviteitInschrijvingen.SingleOrDefault(ai => ai.Activiteit.Id == id && ai.Inschrijving.Lid.Id == id2);
                activiteitInschrijving.IsAanwezig = false;
                Aanwezigheid aanwezigheid = _aanwezigheidRepository.GetAll().Where(aw => aw.Lid.Id == id2 && aw.Activiteit.Id == id).SingleOrDefault();
                _aanwezigheidRepository.Delete(aanwezigheid);
                _aanwezigheidRepository.SaveChanges();
                TempData["Success"] = $"{lid.Voornaam} {lid.Achternaam} is succesvol afwezig geplaatst!";
                return RedirectToAction(nameof(Aanwezigheden), activiteit);
            } catch (Exception ex) {
            }
            TempData["Error"] = "Afwezig plaatsen is mislukt!";
            return View(nameof(Aanwezigheden), _activiteitRepository.GetBy(id));

        }
        [HttpPost]
        public IActionResult VoegGastToe(int id, AddGastOfProeflidViewModel viewModel) {
            try {
                Lid lid = new Lid(viewModel.Voornaam, viewModel.Achternaam, viewModel.Email, viewModel.Gsm, Functie.GAST);
                if(_lidRepository.GetByEmail(lid.Email) != null)
                {
                    int aantalAanwezigheden = _aanwezigheidRepository.GetAll().Where(aanwezigheid => aanwezigheid.Lid.Email == lid.Email).Count();
                    if (aantalAanwezigheden > 3)
                    {
                        TempData["Error"] = "Gast heeft al meer dan 3 aanwezigheden!";
                        return View(nameof(Aanwezigheden), _activiteitRepository.GetBy(id));
                    }
                }
                _lidRepository.Add(lid);
                _lidRepository.SaveChanges();

                Activiteit activiteit = _activiteitRepository.GetBy(id);
                Inschrijving inschrijving = new Inschrijving(lid, activiteit.Formule, DateTime.Now);
                _inschrijvingRepository.Add(inschrijving);
                _inschrijvingRepository.SaveChanges();
                ActiviteitInschrijving activiteitInschrijving = new ActiviteitInschrijving(activiteit, inschrijving);
                activiteitInschrijving.IsAanwezig = true;
                _activiteitInschrijvingRepository.Add(activiteitInschrijving);
                _activiteitInschrijvingRepository.SaveChanges();

                return RedirectToAction(nameof(Aanwezigheden), activiteit);
            } catch(Exception ex) { }
            TempData["Error"] = "Gast toevoegen is mislukt!";
            return View(nameof(Aanwezigheden), _activiteitRepository.GetBy(id));

        }
        public IActionResult NietIngeschrevenLeden(int id) {
            Activiteit activiteit = _activiteitRepository.GetBy(id);
            if (activiteit == null) {
                return NotFound();
            }
            IEnumerable<Lid> reedsIngeschrevenLeden = activiteit.ActiviteitInschrijvingen.Select(ai => ai.Inschrijving).Select(i => i.Lid);
            if (reedsIngeschrevenLeden == null) {
                return NotFound();
            }
            IEnumerable<Lid> nietIngeschrevenLeden = _lidRepository.GetAll().Except(reedsIngeschrevenLeden);
            if (nietIngeschrevenLeden == null) {
                return NotFound();
            }
            LedenActiviteitViewModel ledenActiviteitViewModel = new LedenActiviteitViewModel(activiteit, nietIngeschrevenLeden);
            return View(ledenActiviteitViewModel);
        }
        [HttpPost]
        public IActionResult NietIngeschrevenLedenGefilterd(int id, string Naam) {
            string naamFilter = Naam ?? "";
            Activiteit activiteit = _activiteitRepository.GetBy(id);
            if (activiteit == null) {
                return NotFound();
            }
            IEnumerable<Lid> reedsIngeschrevenLeden = activiteit.ActiviteitInschrijvingen.Select(ai => ai.Inschrijving).Select(i => i.Lid);
            IEnumerable<Lid> nietIngeschrevenLeden = _lidRepository.GetAll().Except(reedsIngeschrevenLeden).Where(
                    lid => lid.Voornaam.Contains(naamFilter, StringComparison.CurrentCultureIgnoreCase)
                    || lid.Achternaam.Contains(naamFilter, StringComparison.CurrentCultureIgnoreCase))
                .ToList(); ;
            LedenActiviteitViewModel ledenActiviteitViewModel = new LedenActiviteitViewModel(activiteit, nietIngeschrevenLeden);
            return View(nameof(NietIngeschrevenLeden),ledenActiviteitViewModel);
            //.Where(
            //ai => ai.Inschrijving.Lid.Voornaam.Contains(naamFilter, StringComparison.CurrentCultureIgnoreCase)
            // || ai.Inschrijving.Lid.Achternaam.Contains(naamFilter, StringComparison.CurrentCultureIgnoreCase))
            //    .ToList();
        }

        [HttpPost]
        public IActionResult NietIngeschrevenLeden(int id, int id2) {
            Activiteit activiteit = _activiteitRepository.GetBy(id);
            if (activiteit == null) {
                return NotFound();
            }
            Lid lid = _lidRepository.GetBy(id2);
            if (lid == null) {
                return NotFound();
            }
            Inschrijving inschrijving = new Inschrijving(lid, activiteit.Formule, DateTime.Now);
            _inschrijvingRepository.Add(inschrijving);
            _inschrijvingRepository.SaveChanges();
            ActiviteitInschrijving activiteitInschrijving = new ActiviteitInschrijving(activiteit, inschrijving);
            activiteitInschrijving.IsAanwezig = true;
            _activiteitInschrijvingRepository.Add(activiteitInschrijving);
            _activiteitInschrijvingRepository.SaveChanges();

            return RedirectToAction(nameof(Aanwezigheden), activiteit);
        }

    }
}