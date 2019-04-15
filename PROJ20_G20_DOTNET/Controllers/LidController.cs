using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PROJ20_G20_DOTNET.Models.Domain;
using PROJ20_G20_DOTNET.Models.ViewModels;

namespace PROJ20_G20_DOTNET.Controllers
{
    [Authorize(Policy = "Lid")]
    public class LidController : Controller
    {
        private ILidRepository _lidRepository;

        public LidController(ILidRepository lidRepository)
        {
            _lidRepository = lidRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Lid> leden = _lidRepository
                .GetAll()
                .OrderBy(lid => lid.Achternaam)
                .OrderBy(lid => lid.Voornaam)
                .ToList();
            return View(leden);
        }

        public IActionResult Details(int id)
        {
            Lid lid = _lidRepository.GetBy(id);
            if (lid == null) {
                return NotFound();
            }
            return View(lid);
        }

        public IActionResult Edit(int id)
        {
            Lid lid = _lidRepository.GetBy(id);
            if (lid == null) {
                return NotFound();
            }
            ViewData["Graden"] = GetGradenAsSelectList();
            ViewData["Functies"] = GetFunctiesAsSelectList();
            return View(new LidEditViewModel(lid));
        }

        [HttpPost]
        public IActionResult Edit(int id, LidEditViewModel lidEditViewModel)
        {
            if (ModelState.IsValid) {
                try {
                    Lid lid = _lidRepository.GetBy(id);
                    MapLidEditViewModelToLid(lid, lidEditViewModel);
                    _lidRepository.SaveChanges();
                    TempData["Success"] = $"{lid.Voornaam} {lid.Achternaam} is succesvol gewijzigd!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex) {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            ViewData["Graden"] = GetGradenAsSelectList();
            ViewData["Functies"] = GetFunctiesAsSelectList();
            return View(nameof(Edit), lidEditViewModel);
        }

        public IActionResult Delete(int id)
        {
            Lid lid = _lidRepository.GetBy(id);
            if (lid == null) {
                return NotFound();
            }
            ViewData["Name"] = lid.Voornaam + " " + lid.Achternaam;
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid) {
                try {
                    Lid lid = _lidRepository.GetBy(id);
                    _lidRepository.Delete(lid);
                    _lidRepository.SaveChanges();
                    TempData["Success"] = $"{lid.Voornaam} {lid.Achternaam} is succesvol verwijderd!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex) {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            Lid lid2 = _lidRepository.GetBy(id);
            ViewData["Name"] = lid2.Voornaam + " " + lid2.Achternaam;
            return View(nameof(Delete));
        }

        public SelectList GetFunctiesAsSelectList()
        {
            return new SelectList(Enum.GetValues(typeof(Functie)).Cast<Functie>().Select(v => new SelectListItem {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }
            ).ToList(), "Value", "Text");

        }

        public SelectList GetGradenAsSelectList()
        {
            return new SelectList(Enum.GetValues(typeof(Graad)).Cast<Graad>().Select(v => new SelectListItem {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }
            ).ToList(), "Value", "Text");
        }

        private void MapLidEditViewModelToLid(Lid lid, LidEditViewModel lidEditViewModel)
        {
            lid.Voornaam = lidEditViewModel.Voornaam;
            lid.Achternaam = lidEditViewModel.Achternaam;
            lid.RijksregisterNummer = lidEditViewModel.RijksregisterNummer;
            lid.Nationaliteit = lidEditViewModel.Nationaliteit;
            lid.DatumEersteTraining = lidEditViewModel.DatumEersteTraining;
            lid.GeboorteDatum = lidEditViewModel.GeboorteDatum;
            lid.GsmNr = lidEditViewModel.GsmNr;
            lid.VasteTelefoonNr = lidEditViewModel.VasteTelefoonNr;
            lid.Stad = lidEditViewModel.Stad;
            lid.Straat = lidEditViewModel.Straat;
            lid.HuisNr = lidEditViewModel.HuisNr;
            lid.Bus = lidEditViewModel.Bus;
            lid.PostCode = lidEditViewModel.PostCode;
            lid.Email = lidEditViewModel.Email;
            lid.Wachtwoord = lidEditViewModel.Wachtwoord;
            lid.EmailVader = lidEditViewModel.EmailVader;
            lid.EmailMoeder = lidEditViewModel.EmailMoeder;
            lid.GeboortePlaats = lidEditViewModel.GeboortePlaats;
            lid.Geslacht = lidEditViewModel.Geslacht;
            lid.Beroep = lidEditViewModel.Beroep;
            lid.Graad = lidEditViewModel.Graad;
            lid.Functie = lidEditViewModel.Functie;
        }
    }
}