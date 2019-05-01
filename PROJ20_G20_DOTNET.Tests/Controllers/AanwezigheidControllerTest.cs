using Microsoft.AspNetCore.Mvc;
using Moq;
using PROJ20_G20_DOTNET.Controllers;
using PROJ20_G20_DOTNET.Models.Domain;
using Xunit;

namespace PROJ20_G20_DOTNET.Tests.Controllers
{
    public class AanwezigheidControllerTest
    {
        private Mock<ILidRepository> _lidRepository;
        private Mock<IAanwezigheidRepository> _aanwezigheidRepository;
        private Mock<IActiviteitInschrijvingRepository> _activiteitInschrijvingRepository;
        private Mock<IInschrijvingRepository> _inschrijvingRepository;
        private Mock<IActiviteitRepository> _activiteitRepository;

        private DummyJiuJitsuDbContext _dummyContext;

        private AanwezigheidController _controller;

        public AanwezigheidControllerTest()
        {
            _controller = new AanwezigheidController(_lidRepository.Object, _aanwezigheidRepository.Object
                , _activiteitRepository.Object, _inschrijvingRepository.Object, _activiteitInschrijvingRepository.Object);
        }


        #region Index

        [Fact]
        public void Index_GeeftOrderedLijstVanActiviteitenInViewResultModel()
        {
            _activiteitRepository.Setup(m => m.GetAll()).Returns(_dummyContext.Activiteiten);
            //IActionResult actionResult = _controller.Index();
        }
        #endregion



    }
}
