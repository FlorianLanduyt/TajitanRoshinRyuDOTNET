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
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public OefeningController(IOefeningRepository oefeningRepository, ILidRepository lidRepository,
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _oefeningRepository = oefeningRepository;
            _lidRepository = lidRepository;
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
            return View(leden);
        }

        public IActionResult ToonOefeningenLid(int id)
        {
            Lid lid = _lidRepository.GetBy(id);
            Graad graadLid = lid.Graad;

            IEnumerable<Oefening> oefeningen =
                _oefeningRepository.GetAll()
                .Where(oef => oef.Graad.CompareTo(graadLid) <= 0)
                .OrderBy(oef => oef.Graad)
                .ThenBy(oef => oef.Thema.Naam)
                .ThenBy(oef => oef.Titel)
                .ToList();
            ViewData["LidNaam"] = $"{lid.Voornaam} {lid.Achternaam}";
            ViewData["LidId"] = id;
            return View(oefeningen);
        }

        public IActionResult RaadpleegOefening(int id, int id2)
        {
            Oefening oefening = _oefeningRepository.GetById(id);
            //id2 dient louter om een lidid te kunnen doorgeven zodat de 'terug' knop naar toonoefeningenlid werkt :p
            ViewData["LidId"] = id2;
            return View(oefening);
        }

        #region User async methods
        private async Task<IdentityUser> GetSignedInUserAsync()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
        #endregion
    }
}