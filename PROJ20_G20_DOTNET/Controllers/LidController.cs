using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PROJ20_G20_DOTNET.Models.Domain;
using PROJ20_G20_DOTNET.Models.ViewModels;

namespace PROJ20_G20_DOTNET.Controllers
{
    [Authorize(Policy = "ViewPersonalDetails")]
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

        public async Task<IActionResult> Index()
        {
            IdentityUser signedInUser = await GetSignedInUserAsync();
            Lid lid = _lidRepository.GetAll().SingleOrDefault(l => l.Email.Equals(signedInUser.Email));
            if (lid == null) {
                return NotFound();
            }
            return View(lid);
        }


        public async Task<IActionResult> Edit(int id)
        {
            Lid lid = _lidRepository.GetBy(id);
            if (lid == null) {
                return NotFound();
            }
            IdentityUser user = await GetSignedInUserAsync();
            if (user.Email.Equals(lid.Email)) {
                return View(new LidEditViewModel(lid));
            }
            TempData["Error"] = "Je kan deze actie niet uitvoeren op dit moment.";
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
            return View(nameof(Edit), lidEditViewModel);
        }

        private void MapLidEditViewModelToLid(Lid lid, LidEditViewModel lidEditViewModel)
        {
            lid.Voornaam = lidEditViewModel.Voornaam;
            lid.Achternaam = lidEditViewModel.Achternaam;
            lid.RijksregisterNummer = lidEditViewModel.RijksregisterNummer;
            lid.Nationaliteit = lidEditViewModel.Nationaliteit;
            lid.GeboorteDatum = lidEditViewModel.GeboorteDatum;
            lid.GsmNr = lidEditViewModel.GsmNr;
            lid.VasteTelefoonNr = lidEditViewModel.VasteTelefoonNr;
            lid.Stad = lidEditViewModel.Stad;
            lid.Straat = lidEditViewModel.Straat;
            lid.HuisNr = lidEditViewModel.HuisNr;
            lid.Bus = lidEditViewModel.Bus;
            lid.PostCode = lidEditViewModel.PostCode;
            lid.Email = lidEditViewModel.Email;
            lid.EmailVader = lidEditViewModel.EmailVader;
            lid.EmailMoeder = lidEditViewModel.EmailMoeder;
            lid.GeboortePlaats = lidEditViewModel.GeboortePlaats;
            lid.Geslacht = lidEditViewModel.Geslacht;
            lid.Beroep = lidEditViewModel.Beroep;
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
        }
        #endregion
    }
}