using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PROJ20_G20_DOTNET.Tests.Models.Domain
{
    public class OefeningTest
    {
        private Oefening _oefening;

        #region Testen titel
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("sdfqsfq123")]
        [InlineData("12356")]
        [InlineData("aze@ze-*/151")]
        [InlineData("@@/*-+$^")]
        public void NewOefening_TitelFout_ArgumentException(string titel)
        {
            Assert.Throws<ArgumentException>(() => _oefening = new Oefening() { Titel = titel });
        }

        [Theory]
        [InlineData("De stage")]
        [InlineData("Schouderomwenteling")]
        public void NewOefening_TitelCorrect_CreatesOefening(string titel)
        {
            _oefening = new Oefening() { Titel = titel };
            Assert.Equal(titel, _oefening.Titel);
        }
        #endregion

        #region Testen UrlVideo
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void NewOefening_UrlVideoFout_ArgumentException(string urlVideo)
        {
            Assert.Throws<ArgumentException>(() => _oefening = new Oefening() { UrlVideo = urlVideo });
        }

        [Theory]
        [InlineData("www.video.com")]
        [InlineData("www.RobIsTop.com")]
        public void NewOefening_UrlVideoCorrect_CreatesOefening(string urlVideo)
        {
            _oefening = new Oefening() { UrlVideo = urlVideo };
            Assert.Equal(urlVideo, _oefening.UrlVideo);
        }

        #endregion

        #region Testen UrlAfbeelding
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void NewOefening_UrlAfbeeldingFout_ArgumentException(string urlAfbeelding)
        {
            Assert.Throws<ArgumentException>(() => _oefening = new Oefening() { UrlAfbeelding = urlAfbeelding });
        }

        [Theory]
        [InlineData("oefening.jpeg")]
        [InlineData("robIsTop.jpeg")]
        public void NewOefening_UrlAfbeeldingCorrect_CreatesOefening(string urlAfbeelding)
        {
            _oefening = new Oefening() { UrlAfbeelding = urlAfbeelding };
            Assert.Equal(urlAfbeelding, _oefening.UrlAfbeelding);
        }

        #endregion

        #region Testen Thema
        [Theory]
        [InlineData(null)]
        public void NewOefening_ThemaNull_ArgumentException(Thema thema)
        {
            Assert.Throws<ArgumentException>(() => _oefening = new Oefening() { Thema = thema });
        }

        [Fact]
        public void NewOefening_ThemaCorrect_CreatesOefening()
        {
            Thema thema = new Thema("Tester");
            _oefening = new Oefening() { Thema = thema };
            Assert.Equal(thema, _oefening.Thema);
            
        }
        #endregion
    }
}
