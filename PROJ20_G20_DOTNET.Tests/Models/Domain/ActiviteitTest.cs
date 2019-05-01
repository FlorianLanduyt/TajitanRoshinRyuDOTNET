using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PROJ20_G20_DOTNET.Tests.Models.Domain
{
    public class ActiviteitTest
    {
        private Activiteit _activiteit;

        #region Testen naam
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("sdfqsfq123")]
        [InlineData("12356")]
        [InlineData("aze@ze-*/151")]
        [InlineData("@@/*-+$^")]
        public void NewActiviteit_NaamFout_ArgumentException(string naam)
        {
            Assert.Throws<ArgumentException>(() => _activiteit = new Activiteit() { Naam = naam });
        }

        [Theory]
        [InlineData("De rob")]
        [InlineData("Rob")]
        public void NewActiviteit_NaamCorrect_ArgumentException(string naam)
        {
            _activiteit = new Activiteit() { Naam = naam };
            Assert.Equal(naam, _activiteit.Naam);
        }
        #endregion

        #region Testen Straat
        [Theory]
        [InlineData("Boekentstraat")]
        [InlineData("Boekent straat")]
        public void NewActiviteit_StraatCorrect_CreatesLid(string straat)
        {
            _activiteit = new Activiteit() { Straat = straat };
            Assert.Equal(straat, _activiteit.Straat);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("sdfqsfq123")]
        [InlineData("12356")]
        [InlineData("aze@ze-*/151")]
        [InlineData("@@/*-+$^")]
        public void NewActiviteit_StraatFout_ArgumentException(string straat)
        {
            Assert.Throws<ArgumentException>(() => _activiteit = new Activiteit() { Straat = straat });
        }
        #endregion

        #region Testen Stad
        [Theory]
        [InlineData("Gent")]
        [InlineData("Nieuw Gent")]
        public void NewActiviteit_StadCorrect_CreatesLid(string stad)
        {
            _activiteit = new Activiteit() { Stad = stad };
            Assert.Equal(stad, _activiteit.Stad);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("sdfqsfq123")]
        [InlineData("12356")]
        [InlineData("aze@ze-*/151")]
        [InlineData("@@/*-+$^")]
        public void NewActiviteit_StadFout_ArgumentException(string stad)
        {
            Assert.Throws<ArgumentException>(() => _activiteit = new Activiteit() { Stad = stad });
        }
        #endregion

        #region Testen Huisnummer
        [Theory]
        [InlineData("13")]
        [InlineData("114")]
        [InlineData("1")]
        public void NewActiviteit_HuisnummerCorrect_CreatesLid(string huisnummer)
        {
            _activiteit = new Activiteit { HuisNummer = huisnummer };
            Assert.Equal(huisnummer, _activiteit.HuisNummer);
        }

        [Theory]
        [InlineData("1233456")]
        [InlineData("74aaaa")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("aaaa")]
        [InlineData("/*@-")]
        public void NewActiviteit_HuisnummerFout_ArgumentException(string huisnummer)
        {
            Assert.Throws<ArgumentException>(() => _activiteit = new Activiteit() { HuisNummer = huisnummer });
        }
        #endregion

        #region Testen Bus
        [Theory]
        [InlineData("15")]
        [InlineData("18a")]
        public void NewActiviteit_BusCorrect_CreatesLid(string bus)
        {
            _activiteit = new Activiteit() { BusNummer = bus };
            Assert.Equal(bus, _activiteit.BusNummer);
        }

        [Theory]
        [InlineData("123455")]
        [InlineData("aaaaaaa")]
        [InlineData("123aaaa")]
        public void NewActiviteit_BusFout_ArgumentException(string bus)
        {
            Assert.Throws<ArgumentException>(() => _activiteit = new Activiteit() { BusNummer = bus });
        }
        #endregion

        #region Testen Postcode
        [Theory]
        [InlineData("9451")]
        [InlineData("9000")]
        public void NewActiviteit_PostcodeCorrect_CreatesLid(string postcode)
        {
            _activiteit = new Activiteit() { Postcode = postcode };
            Assert.Equal(postcode, _activiteit.Postcode);
        }

        [Theory]
        [InlineData("55555")]
        [InlineData("74aa")]
        [InlineData("aaaa")]
        [InlineData("74@-")]
        [InlineData("/*@-")]
        [InlineData("")]
        [InlineData(null)]
        public void NewActiviteit_PostcodeFout_ArgumentException(string postcode)
        {
            Assert.Throws<ArgumentException>(() => _activiteit = new Activiteit() { Postcode = postcode });
        }
        #endregion

        #region Testen Email
        [Theory]
        [InlineData("robdeputter@hotmail.com")]
        [InlineData("robdp@gmail.com")]
        public void NewActiviteit_EmailCorrect_CreatesLid(string email)
        {
            _activiteit = new Activiteit() { Email = email };
            Assert.Equal(email, _activiteit.Email);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Rob Deputter@hotmail.com")]
        public void NewActiviteit_EmailFout_ArgumentException(string email)
        {
            Assert.Throws<ArgumentException>(() => _activiteit = new Activiteit() { Email = email });
        }
        #endregion

        #region Testen gsmnummer
        [Theory]
        [InlineData("0476456851")]
        [InlineData("+32476456851")]
        public void NewActiviteit_GsmNummerCorrect_CreatesLid(string gsmnummer)
        {
            _activiteit = new Activiteit() { GsmNummer = gsmnummer };
            Assert.Equal(gsmnummer, _activiteit.GsmNummer);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("aaaaa12345")]
        [InlineData("aaaaaaaaaa")]
        [InlineData("@@@@@12345")]
        [InlineData("@@@@@@@@@@")]
        public void NewActiviteit_GsmnummerFout_ArgumentException(string gsmnummer)
        {
            Assert.Throws<ArgumentException>(() => _activiteit = new Activiteit() { GsmNummer = gsmnummer });
        }
        #endregion

        #region Testen Begindatum
        [Fact]
        public void NewActiviteit_BegindatumCorrect_CreatesActiviteit()
        {
            DateTime beginDatum = DateTime.Today.AddMonths(2);
            _activiteit = new Activiteit() { BeginDatum = beginDatum };
            Assert.Equal(beginDatum, _activiteit.BeginDatum);
        }
        [Fact]
        public void NewActiviteit_BegindatumInHetVerleden_ArgumentException()
        {
            _activiteit = new Activiteit() {};
            DateTime beginDatum = DateTime.Today.AddMonths(-1);
            Assert.Throws<ArgumentException>(() => _activiteit.BeginDatum = beginDatum);
        }
        #endregion

        #region Testen Einddatum
        [Fact]
        public void NewActiviteit_EinddatumCorrect_CreatesActiviteit()
        {
            DateTime beginDatum = DateTime.Today.AddMonths(2);
            DateTime eindDatum = DateTime.Today.AddMonths(3);
            _activiteit = new Activiteit() { BeginDatum = beginDatum , EindDatum = eindDatum};
            Assert.Equal(eindDatum, _activiteit.EindDatum);
        }
        [Fact]
        public void NewActiviteit_EinddatumInHetVerleden_ArgumentException()
        {
            _activiteit = new Activiteit();
            DateTime einddatum = DateTime.Today.AddMonths(-1);
            Assert.Throws<ArgumentException>(() => _activiteit.EindDatum = einddatum);
        }
        [Fact]
        public void NewActiviteit_EinddatumLigtVoorBeginDatum_ArgumentException()
        {
            _activiteit = new Activiteit() { BeginDatum = DateTime.Today.AddMonths(2)};
            DateTime einddatum = DateTime.Today.AddMonths(1);
            Assert.Throws<ArgumentException>(() => _activiteit.EindDatum = einddatum);
        }
        #endregion

        #region Testen DatumEersteInschrijving
        [Fact]
        public void NewActiviteit_DatumEersteInschrijvingCorrect_CreatesActiviteit()
        {
            DateTime beginDatum = DateTime.Today.AddMonths(2);
            DateTime datumEersteInschrijving = DateTime.Today.AddMonths(1);
            _activiteit = new Activiteit() { BeginDatum = beginDatum, UitersteInschrijvingsDatum = datumEersteInschrijving };
            Assert.Equal(datumEersteInschrijving, _activiteit.UitersteInschrijvingsDatum);
        }
        [Fact]
        public void NewActiviteit_DatumEersteInschrijvingInHetVerleden_ArgumentException()
        {
            _activiteit = new Activiteit();
            DateTime datumEersteInschrijving = DateTime.Today.AddMonths(-1);
            Assert.Throws<ArgumentException>(() => _activiteit.UitersteInschrijvingsDatum = datumEersteInschrijving);
        }
        [Fact]
        public void NewActiviteit_DatumEersteInschrijvingLigtNaBeginDatum_ArgumentException()
        {
            _activiteit = new Activiteit() { BeginDatum = DateTime.Today.AddMonths(2) };
            DateTime datumEersteInschrijving = DateTime.Today.AddMonths(3);
            Assert.Throws<ArgumentException>(() => _activiteit.UitersteInschrijvingsDatum = datumEersteInschrijving);
        }
        #endregion

    }
}
