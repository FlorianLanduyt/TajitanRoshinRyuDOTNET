using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PROJ20_G20_DOTNET.Models.Domain;

namespace PROJ20_G20_DOTNET.Controllers
{
    [Authorize(Policy = "ViewExercisesOwn")]
    public class OefeningController : Controller
    {
        private IOefeningRepository _oefeningRepository;
        private ILidRepository _lidRepository;
        private IRaadplegingRepository _raadplegingRepository;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public OefeningController(IOefeningRepository oefeningRepository, ILidRepository lidRepository, IRaadplegingRepository raadplegingRepository,
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _oefeningRepository = oefeningRepository;
            _lidRepository = lidRepository;
            _raadplegingRepository = raadplegingRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> BepaalAdminLid()
        {
            IdentityUser signedInUser = await GetSignedInUserAsync();
            Lid lid = _lidRepository.GetAll().SingleOrDefault(l => l.Email.Equals(signedInUser.Email));
            if (lid == null) {
                return NotFound();
            }
            if (lid.Functie.Equals(Functie.BEHEERDER) || lid.Functie.Equals(Functie.TRAINER)) {
                return RedirectToAction(nameof(Leden));
            }
            return RedirectToAction(nameof(ToonOefeningenLid), new { id = lid.Id });
        }

        [Authorize(Policy = "ViewExercisesAllMembers")]
        public IActionResult Leden()
        {
            IEnumerable<Lid> leden = _lidRepository.GetAll();
            if (leden == null) {
                return NotFound();
            }
            return View(leden);
        }

        public IActionResult ToonOefeningenLid(int id)
        {
            Lid lid = _lidRepository.GetBy(id);
            if (lid == null) {
                return NotFound();
            }
            Graad graadLid = lid.Graad;

            IEnumerable<Oefening> oefeningen =
                _oefeningRepository.GetAll()
                .Where(oef => oef.Graad.CompareTo(graadLid) <= 0)
                .OrderByDescending(oef => oef.Graad)
                .ThenBy(oef => oef.Thema.Naam)
                .ThenBy(oef => oef.Titel)
                .ToList();

            ViewData["LidNaam"] = $"{lid.Voornaam} {lid.Achternaam}";
            ViewData["LidId"] = id;
            return View(oefeningen);
        }

        public IActionResult RaadpleegOefening(int id, int id2)
        {
            //id = oefeningId | id2 = lidId
            Oefening oefening = _oefeningRepository.GetById(id);
            if (oefening == null) {
                return NotFound();
            }
            UpdateRaadpleging(id, id2);
            ViewData["LidId"] = id2;
            return View(oefening);
        }

        private void UpdateRaadpleging(int oefeningId, int lidId)
        {
            Raadpleging raadpleging = _raadplegingRepository.GetAll().SingleOrDefault(r => r.OefeningId == oefeningId && r.LidId == lidId);
            if (raadpleging != null) {
                raadpleging.AantalRaadplegingen++;
                raadpleging.VoegRaadplegingsTijdstipToe();
                _raadplegingRepository.SaveChanges();
            }
            else {
                Lid lid = _lidRepository.GetBy(lidId);
                Oefening oefening = _oefeningRepository.GetById(oefeningId);
                Raadpleging raadplegingNew = new Raadpleging(lid, oefening);
                raadplegingNew.AantalRaadplegingen++;
                raadplegingNew.VoegRaadplegingsTijdstipToe();
                _raadplegingRepository.Add(raadplegingNew);
                _raadplegingRepository.SaveChanges();
            }
        }

        #region User async methods
        private async Task<IdentityUser> GetSignedInUserAsync()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
        #endregion
    }
}