using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using PROJ20_G20_DOTNET.Controllers;
using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
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
            _lidRepository = new Mock<ILidRepository>();
            _aanwezigheidRepository = new Mock<IAanwezigheidRepository>();
            _activiteitInschrijvingRepository = new Mock<IActiviteitInschrijvingRepository>();
            _inschrijvingRepository = new Mock<IInschrijvingRepository>();
            _activiteitRepository = new Mock<IActiviteitRepository>();
            _dummyContext = new DummyJiuJitsuDbContext();

            _controller = new AanwezigheidController(_lidRepository.Object, _aanwezigheidRepository.Object
                , _activiteitRepository.Object, _inschrijvingRepository.Object, _activiteitInschrijvingRepository.Object)
            {
                TempData = new Mock<ITempDataDictionary>().Object
            };
        }


        #region Index

        // -- Index GET --
        [Fact]
        public void Index_GeeftOrderedListVanActiviteitenInViewResultModel()
        {
            _activiteitRepository.Setup(m => m.GetAll()).Returns(_dummyContext.Activiteiten);
            IActionResult actionResult = _controller.Index();
            IList<Activiteit> activiteitenInModel = (actionResult as ViewResult)?.Model as IList<Activiteit>;
            Assert.Equal(2, activiteitenInModel.Count);
            Assert.Equal("Testactiviteit een", activiteitenInModel?[0].Naam);
            Assert.Equal("Testactiviteit twee", activiteitenInModel?[1].Naam);
        }

        // -- Index POST --
        [Fact]
        public void Index_GeefOrderedListVanGefilterdeActiviteitenMetAlleParametersInViewResultModel()
        {
            _activiteitRepository.Setup(m => m.GetAll()).Returns(_dummyContext.Activiteiten);
            string beginDatum = "2020/08/11";
            string eindDatum = "2020/08/14";
            string naam = "Testactiviteit een";
            IActionResult actionResult = _controller.Index(beginDatum, eindDatum, naam);
            IList<Activiteit> activiteitenInModel = (actionResult as ViewResult)?.Model as IList<Activiteit>;
            Assert.Equal(1, activiteitenInModel?.Count);
            Assert.Equal("Testactiviteit een", activiteitenInModel?[0].Naam);
        }
        [Fact]
        public void Index_GeefOrderedListVanGefilterdeActiviteitenMetZonderParametersInViewResultModel()
        {
            _activiteitRepository.Setup(m => m.GetAll()).Returns(_dummyContext.Activiteiten);
            string beginDatum = null;
            string eindDatum = null;
            string naam = "";
            IActionResult actionResult = _controller.Index(beginDatum, eindDatum, naam);
            IList<Activiteit> activiteitenInModel = (actionResult as ViewResult)?.Model as IList<Activiteit>;
            Assert.Equal(2, activiteitenInModel?.Count);
            Assert.Equal("Testactiviteit een", activiteitenInModel?[0].Naam);
            Assert.Equal("Testactiviteit twee", activiteitenInModel?[1].Naam);
        }

        [Fact]
        public void Index_GeefOrderedListVanGefilterdeActiviteitenMetDatumsInViewResultModel()
        {
            _activiteitRepository.Setup(m => m.GetAll()).Returns(_dummyContext.Activiteiten);
            string beginDatum = "2020/08/11";
            string eindDatum = "2020/08/14";
            string naam = "";
            IActionResult actionResult = _controller.Index(beginDatum, eindDatum, naam);
            IList<Activiteit> activiteitenInModel = (actionResult as ViewResult)?.Model as IList<Activiteit>;
            Assert.Equal(1, activiteitenInModel?.Count);
            Assert.Equal("Testactiviteit een", activiteitenInModel?[0].Naam);
        }
        [Fact]
        public void Index_GeefOrderedListVanGefilterdeActiviteitenMetNaamInViewResultModel()
        {
            _activiteitRepository.Setup(m => m.GetAll()).Returns(_dummyContext.Activiteiten);
            string beginDatum = null;
            string eindDatum = null;
            string naam = "Testactiviteit een";
            IActionResult actionResult = _controller.Index(beginDatum, eindDatum, naam);
            IList<Activiteit> activiteitenInModel = (actionResult as ViewResult)?.Model as IList<Activiteit>;
            Assert.Equal(1, activiteitenInModel?.Count);
            Assert.Equal("Testactiviteit een", activiteitenInModel?[0].Naam);
        }

        [Fact]
        public void Index_GeefOrderedListVanGefilterdeActiviteitenAlleenBegindatumInViewResultModel()
        {
            _activiteitRepository.Setup(m => m.GetAll()).Returns(_dummyContext.Activiteiten);
            string beginDatum = "2020/08/11";
            string eindDatum = null;
            string naam = "";
            IActionResult actionResult = _controller.Index(beginDatum, eindDatum, naam);
            IList<Activiteit> activiteitenInModel = (actionResult as ViewResult)?.Model as IList<Activiteit>;
            Assert.Equal(2, activiteitenInModel?.Count);
            Assert.Equal("Testactiviteit een", activiteitenInModel?[0].Naam);
            Assert.Equal("Testactiviteit twee", activiteitenInModel?[1].Naam);
        }

        [Fact]
        public void Index_GeefOrderedListVanGefilterdeActiviteitenAlleenEinddatumInViewResultModel()
        {
            _activiteitRepository.Setup(m => m.GetAll()).Returns(_dummyContext.Activiteiten);
            string beginDatum = null;
            string eindDatum = "2020/09/15";
            string naam = "";
            IActionResult actionResult = _controller.Index(beginDatum, eindDatum, naam);
            IList<Activiteit> activiteitenInModel = (actionResult as ViewResult)?.Model as IList<Activiteit>;
            Assert.Equal(2, activiteitenInModel?.Count);
            Assert.Equal("Testactiviteit een", activiteitenInModel?[0].Naam);
            Assert.Equal("Testactiviteit twee", activiteitenInModel?[1].Naam);
        }
        #endregion

        #region Testen Aanwezigheden
        [Fact]
        public void Aanwezigheden_GeefActiviteitDoorActiviteitId()
        {
            _activiteitRepository.Setup(m => m.GetBy(1)).Returns(_dummyContext.Act1);
            IActionResult actionResult = _controller.Aanwezigheden(1);
            Activiteit activiteitenInModel = (actionResult as ViewResult)?.Model as Activiteit;
            Assert.Equal("Testactiviteit een", activiteitenInModel?.Naam);
        }

        [Fact]
        public void Aanwezigheden_ActiviteitsIdBestaatNiet_GeeftNull()
        {
            _activiteitRepository.Setup(m => m.GetBy(1000)).Returns((Activiteit)null);
            IActionResult actionResult = _controller.Aanwezigheden(1000);
            Assert.Null((actionResult as ViewResult)?.Model);
        }

        [Fact]
        public void Aanwezigheden_GeefAanwezighedenMetActiviteitsIdEnNaamLid()
        {
            //Rob is ingeschreven voor de activiteit met id 1!
            _activiteitRepository.Setup(m => m.GetBy(1)).Returns(_dummyContext.Act1);
            string naam = "Rob";
            IActionResult actionResult = _controller.Aanwezigheden(1, naam);
            Activiteit activiteitenInModel = (actionResult as ViewResult)?.Model as Activiteit;
            Assert.Equal("Testactiviteit een", activiteitenInModel?.Naam);
        }
        #endregion

        #region Testen VoegAanwezigheidToe
        [Fact]
        public void VoegAanwezigheidToe_MetIdLidenIdActiviteit()
        {
            int lidId = 1; //Rob
            int activiteitId = 1; //Act1
            _lidRepository.Setup(m => m.GetBy(lidId)).Returns(_dummyContext.Rob);
            _activiteitRepository.Setup(m => m.GetBy(activiteitId)).Returns(_dummyContext.Act1);
            RedirectToActionResult redirectToActionResult = _controller.VoegAanwezigheidToe(activiteitId, lidId)
                as RedirectToActionResult;
            _aanwezigheidRepository.Verify(m => m.SaveChanges(), Times.Once());
            Assert.Equal("Aanwezigheden", redirectToActionResult?.ActionName);
            Assert.Null(redirectToActionResult?.ControllerName);
        }

        [Fact]
        public void VoegAanwezigheidToe_IdLidEnIdActiviteitBestaatniet()
        {
            int lidId = 1000; //Rob
            int activiteitId = 1000; //Act1
            _lidRepository.Setup(m => m.GetBy(lidId)).Returns((Lid)null);
            _activiteitRepository.Setup(m => m.GetBy(activiteitId)).Returns((Activiteit)null);
            ViewResult viewResult = _controller.VoegAanwezigheidToe(activiteitId, lidId)
                as ViewResult;
            _aanwezigheidRepository.Verify(m => m.SaveChanges(), Times.Never());
        }
        #endregion

        #region Verwijder aanwezigheid
        [Fact]
        public void VerwijderAanwezigheid_MetLidIdEnActiviteitId()
        {
            int lidId = 2; //Tim
            int activiteitId = 2; //Act2

            _lidRepository.Setup(m => m.GetBy(lidId)).Returns(_dummyContext.Tim);
            _activiteitRepository.Setup(m => m.GetBy(activiteitId)).Returns(_dummyContext.Act2);
            _aanwezigheidRepository.Setup(m => m.GetAll()).Returns(_dummyContext.Aanwezigheden);
            _aanwezigheidRepository.Setup(m => m.Delete(It.IsAny<Aanwezigheid>()));
            RedirectToActionResult redirectToActionResult = _controller.VerwijderAanwezigheid(activiteitId, lidId)
                as RedirectToActionResult;

            _lidRepository.Verify(m => m.GetBy(2), Times.Once());
            _activiteitRepository.Verify(m => m.GetBy(2), Times.Once());
            _aanwezigheidRepository.Verify(m => m.SaveChanges(), Times.Once());
        }
        #endregion
    }
}
