using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PROJ20_G20_DOTNET.Models.Domain;
using PROJ20_G20_DOTNET.Models.ViewModels;

namespace PROJ20_G20_DOTNET.Controllers
{
    [Authorize(Policy = "Beheerder")]
    public class LidController : Controller
    {
        private ILidRepository _lidRepository;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public LidController(ILidRepository lidRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _lidRepository = lidRepository;
            _userManager = userManager;
            _signInManager = signInManager;
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

        public async Task<IActionResult> Details(int id)
        {
            Lid lid = _lidRepository.GetBy(id);
            if (lid == null) {
                return NotFound();
            }
            IdentityUser user = await GetSignedInUserAsync();
            if (user.Email.Equals(lid.Email)) {
                return View(lid);
            }
            TempData["Error"] = "Je bent niet gemachtigd om deze actie uit te voeren.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            Lid lid = _lidRepository.GetBy(id);
            if (lid == null) {
                return NotFound();
            }
            IdentityUser user = await GetSignedInUserAsync();
            if (user.Email.Equals(lid.Email)) {
                ViewData["Graden"] = GetGradenAsSelectList();
                ViewData["Functies"] = GetFunctiesAsSelectList();
                return View(new LidEditViewModel(lid));
            }
            TempData["Error"] = "Je bent niet gemachtigd om deze actie uit te voeren.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(int id, LidEditViewModel lidEditViewModel)
        {
            if (ModelState.IsValid) {
                try {
                    Lid lid = _lidRepository.GetBy(id);
                    UpdateUser(lid, lidEditViewModel).Wait();
                    MapLidEditViewModelToLid(lid, lidEditViewModel);
                    _lidRepository.SaveChanges();
                    TempData["Success"] = $"{lid.Voornaam} {lid.Achternaam} is succesvol gewijzigd!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex) {
                    ModelState.AddModelError("", ex.Message);
                    ViewData["Error"] = ex.Message;
                }
            }
            ViewData["Graden"] = GetGradenAsSelectList();
            ViewData["Functies"] = GetFunctiesAsSelectList();
            return View(nameof(Edit), lidEditViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Lid lid = _lidRepository.GetBy(id);
            if (lid == null) {
                return NotFound();
            }
            IdentityUser user = await GetSignedInUserAsync();
            if (user.Email.Equals(lid.Email)) {
                ViewData["Name"] = lid.Voornaam + " " + lid.Achternaam;
                return View();
            }
            TempData["Error"] = "Je bent niet gemachtigd om deze actie uit te voeren.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid) {
                try {
                    Lid lid = _lidRepository.GetBy(id);
                    DeleteUser(lid).Wait();
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

        #region User async methods
        private async Task<IdentityUser> GetSignedInUserAsync()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

        private async Task UpdateUser(Lid lid, LidEditViewModel lidEditViewModel)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(lid.Email);
            user.Email = lidEditViewModel.Email;
            user.UserName = lidEditViewModel.Email;
            await _userManager.ChangePasswordAsync(user, lid.Wachtwoord, lidEditViewModel.Wachtwoord);
        }

        private async Task DeleteUser(Lid lid)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(lid.Email);
            await _userManager.DeleteAsync(user);
            await SignOutUser();
        }

        private async Task SignOutUser()
        {
            await _signInManager.SignOutAsync();
        }
        #endregion
    }
}