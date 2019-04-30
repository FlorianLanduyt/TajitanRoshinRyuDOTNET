using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PROJ20_G20_DOTNET.Tests.Models.Domain
{
    public class LidTest
    {
        private Lid _lid;

        #region Testen Voornaam
        [Theory]
        [InlineData("Rob")]
        [InlineData("Pieter Jan")]
        public void NewLid_VoornaamCorrect_CreatesLid(string voornaam)
        {
            _lid = new Lid() { Voornaam = voornaam };
            Assert.Equal(voornaam, _lid.Voornaam);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("sdfqsfq123")]
        [InlineData("12356")]
        [InlineData("aze@ze-*/151")]
        [InlineData("@@/*-+$^")]
        public void NewLid_VoornaamFout_ArgumentException(string voornaam)
        {
            Assert.Throws<ArgumentException>(() => _lid = new Lid() { Voornaam = voornaam });
        }
        #endregion

        #region Testen Familienaam
        [Theory]
        [InlineData("De Putter")]
        [InlineData("Geldof")]
        public void NewLid_FamilienaamCorrect_CreatesLid(string familienaam)
        {
            _lid = new Lid() { Achternaam = familienaam };
            Assert.Equal(familienaam, _lid.Achternaam);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("sdfqsfq123")]
        [InlineData("12356")]
        [InlineData("aze@ze-*/151")]
        [InlineData("@@/*-+$^")]
        public void NewLid_FamilienaamFout_ArgumentException(string familienaam)
        {
            Assert.Throws<ArgumentException>(() => _lid = new Lid() { Achternaam = familienaam });
        }
        #endregion

        #region Testen Geboortedatum
        [Theory]
        [InlineData("1999/05/11")]
        [InlineData("1999/12/12")]
        [InlineData("1997/07/17")]
        [InlineData("1996/05/10")]
        public void NewLid_GeboortedatumCorrect_CreatesLid(string geboortedatum)
        {
            DateTime gebDatum = Convert.ToDateTime(geboortedatum);
            _lid = new Lid() { GeboorteDatum = gebDatum };
            Assert.Equal(gebDatum, _lid.GeboorteDatum);
        }

        [Fact]
        public void NewLid_GeboortedatumTeJong_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _lid = new Lid { GeboorteDatum = DateTime.Now.AddYears(-4) });
        }
        #endregion

        #region Testen Stad
        [Theory]
        [InlineData("Gent")]
        [InlineData("Nieuw Gent")]
        public void NewLid_StadCorrect_CreatesLid(string stad)
        {
            _lid = new Lid() { Stad = stad };
            Assert.Equal(stad, _lid.Stad);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("sdfqsfq123")]
        [InlineData("12356")]
        [InlineData("aze@ze-*/151")]
        [InlineData("@@/*-+$^")]
        public void NewLid_StadFout_ArgumentException(string stad)
        {
            Assert.Throws<ArgumentException>(() => _lid = new Lid() { Stad = stad });
        }
        #endregion

        #region Testen Straat
        [Theory]
        [InlineData("Boekentstraat")]
        [InlineData("Boekent straat")]
        public void NewLid_StraatCorrect_CreatesLid(string straat)
        {
            _lid = new Lid() { Straat = straat };
            Assert.Equal(straat, _lid.Straat);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("sdfqsfq123")]
        [InlineData("12356")]
        [InlineData("aze@ze-*/151")]
        [InlineData("@@/*-+$^")]
        public void NewLid_StraatFout_ArgumentException(string straat)
        {
            Assert.Throws<ArgumentException>(() => _lid = new Lid() { Straat = straat });
        }
        #endregion

        #region Testen Rijksregisternummer

        [Theory]
        [InlineData("99.05.11-313.16", "MAN", "1999/05/11")]
        [InlineData("97.07.17-357.55", "MAN", "1997/07/17")]
        [InlineData("99.12.08-173.04", "MAN", "1999/12/08")]
        //[InlineData("96.05.10-173.04", "MAN", "1996/05/10")]
        public void NewLid_RijksregisterCorrect_CreatesLid(string rijksregister, string geslacht, string geboortedatum)
        {
            DateTime gebDatum = Convert.ToDateTime(geboortedatum);
            _lid = new Lid() { Geslacht = geslacht, GeboorteDatum = gebDatum, RijksregisterNummer = rijksregister };
            Assert.Equal(geslacht, _lid.Geslacht);
            Assert.Equal(rijksregister, _lid.RijksregisterNummer);
            Assert.Equal(gebDatum, _lid.GeboorteDatum);
        }

        [Theory]
        [InlineData("99.05.10-313.16", "MAN", "1999/05/11")] //gebdatum fout
        [InlineData("97.07.17-358.55", "MAN", "1997/07/17")] //geslacht fout
        [InlineData("99.12.08-173.05", "MAN", "1999/12/08")] //checksum fout
        //[InlineData("96.05.10-173.04", "MAN", "1996/05/10")]
        public void NewLid_RijksregisterFout_ArgumentException(string rijksregister, string geslacht, string geboortedatum)
        {
            DateTime gebDatum = Convert.ToDateTime(geboortedatum);
            Assert.Throws<ArgumentException>(() => _lid = new Lid() { Geslacht = geslacht, GeboorteDatum = gebDatum, RijksregisterNummer = rijksregister });
        }


        #endregion

    }
}
