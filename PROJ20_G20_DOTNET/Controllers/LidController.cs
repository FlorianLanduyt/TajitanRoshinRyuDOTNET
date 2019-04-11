using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PROJ2_G20_.NET.Models.Domain;
using PROJ20_G20_DOTNET.Models.ViewModels;

namespace PROJ20_G20_DOTNET.Controllers
{
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

        //HttpGet
        public IActionResult Edit(int id)
        {
            Lid lid = _lidRepository.GetBy(id);
            if (lid == null)
            {
                return NotFound();
            }
            ViewData["Graden"] = GetGradenAsSelectList();
            ViewData["Functies"] = GetFunctiesAsSelectList();
            return View(new LidEditViewModel(lid));
        }

        [HttpPost]
        public IActionResult Edit(int id, LidEditViewModel lidEditViewModel)
        {
            Lid lid = _lidRepository.GetBy(id);
            if (lid == null)
            {
                return NotFound();
            }
            MapLidEditViewModelToLid(lid, lidEditViewModel);
            _lidRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            ViewData["Graden"] = GetGradenAsSelectList();
            ViewData["Functies"] = GetFunctiesAsSelectList();
            return View(nameof(Edit), new LidEditViewModel());
        }

        [HttpPost]
        public IActionResult Create(LidEditViewModel lidEditViewModel)
        {
            Lid lid = new Lid(lidEditViewModel.Voornaam, lidEditViewModel.Achternaam, lidEditViewModel.GeboorteDatum,
                lidEditViewModel.RijksregisterNummer, lidEditViewModel.GsmNr, lidEditViewModel.VasteTelefoonNr,
                lidEditViewModel.Stad, lidEditViewModel.Straat, lidEditViewModel.HuisNr, lidEditViewModel.PostCode,
                lidEditViewModel.Email, lidEditViewModel.Wachtwoord, lidEditViewModel.GeboortePlaats, lidEditViewModel.Geslacht,
                lidEditViewModel.Nationaliteit, lidEditViewModel.Graad, lidEditViewModel.Functie);

            _lidRepository.Add(lid);
            _lidRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Lid lid = _lidRepository.GetBy(id);
            if (lid == null)
            {
                return NotFound();
            }
            ViewData[nameof(Lid.Voornaam)] = _lidRepository.GetBy(id).Voornaam;
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteBehavior(int id)
        {
            Lid lid = null;
            try
            {
                lid = _lidRepository.GetBy(id);
                _lidRepository.Delete(lid);
                _lidRepository.SaveChanges();
                TempData["Message"] = $"{lid.Voornaam} {lid.Achternaam} is succevol verwijderd";
            }
            catch (Exception e)
            {
                TempData["Error"] = $"Er is een fout opgetreden bij het verwijderen van {lid?.Voornaam} {lid?.Achternaam}";
            }

            return RedirectToAction(nameof(Index));
        }

        public SelectList GetFunctiesAsSelectList()
        {
            return new SelectList(Enum.GetValues(typeof(Functie)).Cast<Functie>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }
            ).ToList(), "Value", "Text");
            
        }

        public SelectList GetGradenAsSelectList()
        {
            return new SelectList(Enum.GetValues(typeof(Graad)).Cast<Graad>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }
            ).ToList(), "Value", "Text");
        }

        public void MapLidEditViewModelToLid(Lid lid, LidEditViewModel lidEditViewModel)
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