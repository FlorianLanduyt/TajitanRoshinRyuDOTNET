using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using PROJ20_G20_DOTNET.Controllers;
using PROJ20_G20_DOTNET.Models.Domain;
using PROJ20_G20_DOTNET.Models.ViewModels;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Xunit;

namespace PROJ20_G20_DOTNET.Tests.Controllers
{
    public class LidControllerTest
    {
        private LidController _controller;
        private Mock<ILidRepository> _lidRepository;
        private DummyJiuJitsuDbContext _dummyContext;
        private Mock<UserManager<IdentityUser>> _userManager;
        private Mock<SignInManager<IdentityUser>> _signInManager;

        private ClaimsPrincipal user;
        private IdentityUser identityUser;
        private IdentityUser wrongIdentityUser;

        public LidControllerTest()
        {
            _dummyContext = new DummyJiuJitsuDbContext();
            _lidRepository = new Mock<ILidRepository>();
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
            wrongIdentityUser = new IdentityUser() { Email = _dummyContext.Tim.Email };


            _controller = new LidController(_lidRepository.Object, _userManager.Object, _signInManager.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() { User = user }
                }
            };
        }

        #region Testen Index
        [Fact]
        public async Task Index_GeeftAangemeldLid()
        {
            Lid Rob = _dummyContext.Rob; // aangemeld lid
            _userManager.Setup(m => m.GetUserAsync(user)).ReturnsAsync(identityUser);
            _userManager.Setup(m => m.FindByEmailAsync(_dummyContext.Rob.Email)).ReturnsAsync(identityUser);
            _lidRepository.Setup(m => m.GetAll()).Returns(_dummyContext.Leden);

            IActionResult actionResult = await _controller.Index();
            Lid lid = (actionResult as ViewResult)?.Model as Lid;

            Assert.Equal(Rob.Email, lid.Email);
        }
        #endregion

        #region Testen Edit - GET
        [Fact]
        public async Task Edit_GET_GeeftViewResultMetLidEditViewModel()
        {
            _lidRepository.Setup(m => m.GetBy(1)).Returns(_dummyContext.Rob);
            _userManager.Setup(m => m.GetUserAsync(user)).ReturnsAsync(identityUser);
            _userManager.Setup(m => m.FindByEmailAsync(_dummyContext.Rob.Email)).ReturnsAsync(identityUser);
            IActionResult actionResult = await _controller.Edit(1);
            LidEditViewModel lidEditViewModel = (actionResult as ViewResult)?.Model as LidEditViewModel;
            Assert.Equal(_dummyContext.Rob.Email, lidEditViewModel.Email);
        }
        #endregion

    }

}


