using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using PROJ20_G20_DOTNET.Controllers;
using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PROJ20_G20_DOTNET.Tests.Controllers
{
    public class OefeningControllerTest
    {
        private Mock<IOefeningRepository> _oefeningRepository;
        private Mock<ILidRepository> _lidRepository;
        private Mock<IRaadplegingRepository> _raadpleegRepository;
        private Mock<UserManager<IdentityUser>> _userManager;
        private Mock<SignInManager<IdentityUser>> _signInManager;

        private DummyJiuJitsuDbContext _dummyContext;
        private OefeningController _controller;

        private IdentityUser identityUser; // Rob
        private IdentityUser identityUserTybo;
        private IdentityUser wrongIdentityUser;

        private ClaimsPrincipal user;

        public OefeningControllerTest()
        {
            _dummyContext = new DummyJiuJitsuDbContext();
            _oefeningRepository = new Mock<IOefeningRepository>();
            _lidRepository = new Mock<ILidRepository>();
            _raadpleegRepository = new Mock<IRaadplegingRepository>();
            _userManager = new Mock<UserManager<IdentityUser>>(
                new Mock<IUserStore<IdentityUser>>().Object,
              new Mock<IOptions<IdentityOptions>>().Object,
              new Mock<IPasswordHasher<IdentityUser>>().Object,
              new IUserValidator<IdentityUser>[0],
              new IPasswordValidator<IdentityUser>[0],
              new Mock<ILookupNormalizer>().Object,
              new Mock<IdentityErrorDescriber>().Object,
              new Mock<IServiceProvider>().Object,
              new Mock<ILogger<UserManager<IdentityUser>>>().Object);

            _signInManager = new Mock<SignInManager<IdentityUser>>(_userManager.Object,
                     new Mock<IHttpContextAccessor>().Object,
                     new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object,
                     new Mock<IOptions<IdentityOptions>>().Object,
                     new Mock<ILogger<SignInManager<IdentityUser>>>().Object,
                     new Mock<IAuthenticationSchemeProvider>().Object);

            user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, _dummyContext.Rob.Email),
            }));

            identityUser = new IdentityUser() { Email = _dummyContext.Rob.Email };
            identityUserTybo = new IdentityUser() { Email = _dummyContext.Tybo.Email };
            wrongIdentityUser = new IdentityUser() { Email = _dummyContext.Tybo.Email }; // geen beheerder!

            _controller = new OefeningController(_oefeningRepository.Object, _lidRepository.Object,
                _raadpleegRepository.Object, _userManager.Object, _signInManager.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                }
            };
        }

        #region Testen BepaalAdminLid
        [Fact]
        public async Task BepaalAdminLid_GaatNaarLeden()
        {
            //Rob en Tim zijn beheerders!!
            _userManager.Setup(m => m.GetUserAsync(user)).ReturnsAsync(identityUser);
            _userManager.Setup(m => m.FindByEmailAsync(_dummyContext.Rob.Email)).ReturnsAsync(identityUser);
            _lidRepository.Setup(m => m.GetAll()).Returns(_dummyContext.Leden);

            RedirectToActionResult actionResult = await _controller.BepaalAdminLid() as RedirectToActionResult;
            Assert.Equal("Leden", actionResult?.ActionName);
        }

        [Fact]
        public async Task BepaalAdminLid_GaatNaarToonOefeningLid()
        {
            _userManager.Setup(m => m.GetUserAsync(user)).ReturnsAsync(wrongIdentityUser); // geen BEHEERDER  of TRAINER
            _userManager.Setup(m => m.FindByEmailAsync(_dummyContext.Tybo.Email)).ReturnsAsync(wrongIdentityUser); // geen BEHEERDER  of TRAINER
            _lidRepository.Setup(m => m.GetAll()).Returns(_dummyContext.Leden);

            RedirectToActionResult actionResult = await _controller.BepaalAdminLid() as RedirectToActionResult;
            Assert.Equal("ToonOefeningenLid", actionResult?.ActionName);
        }
        #endregion

        #region Testen Leden
        [Fact]
        public void Leden_GeeftOverzichtVanLeden()
        {
            _lidRepository.Setup(m => m.GetAll()).Returns(_dummyContext.Leden);
            ViewResult viewResult = _controller.Leden() as ViewResult;

            Assert.Equal(_dummyContext.Leden, viewResult?.Model);
        }
        #endregion

        #region Testen ToonOefeningenLid
        [Fact]
        public void ToonOefeningLid_GeeftOverzichtVanOefeningen()
        {
            int lidId = 1; //Rob zit in de hoogste graad ==> hij kan alle oefeningen zien
            _lidRepository.Setup(m => m.GetBy(lidId)).Returns(_dummyContext.Rob);
            _oefeningRepository.Setup(m => m.GetAll()).Returns(_dummyContext.Oefeningen);

            ViewResult viewResult = _controller.ToonOefeningenLid(lidId) as ViewResult;
            IList<Oefening> oefeningenViewResult = viewResult?.Model as IList<Oefening>;
            IList<Oefening> dummyOefeningen = _dummyContext.Oefeningen as IList<Oefening>;
            Assert.Equal(dummyOefeningen.Count, oefeningenViewResult.Count);
        }
        #endregion

        

    }
}
