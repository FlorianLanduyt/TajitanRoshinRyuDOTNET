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

        #region Testen Huisnummer
        [Theory]
        [InlineData("13")]
        [InlineData("114")]
        [InlineData("1")]
        public void NewLid_HuisnummerCorrect_CreatesLid(string huisnummer)
        {
            _lid = new Lid { HuisNr = huisnummer };
            Assert.Equal(huisnummer, _lid.HuisNr);
        }

        [Theory]
        [InlineData("1233456")]
        [InlineData("74aaaa")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("aaaa")]
        [InlineData("/*@-")]
        public void NewLid_HuisnummerFout_ArgumentException(string huisnummer)
        {
            Assert.Throws<ArgumentException>(() => _lid = new Lid() { HuisNr = huisnummer });
        }
        #endregion

        #region Testen Bus
        [Theory]
        [InlineData("15")]
        [InlineData("18a")]
        public void NewLid_BusCorrect_CreatesLid(string bus)
        {
            _lid = new Lid() { Bus = bus };
            Assert.Equal(bus, _lid.Bus);
        }

        [Theory]
        [InlineData("123455")]
        [InlineData("aaaaaaa")]
        [InlineData("123aaaa")]
        public void NewLid_BusFout_ArgumentException(string bus)
        {
            Assert.Throws<ArgumentException>(() => _lid = new Lid() { Bus = bus });
        }
        #endregion

        #region Testen Postcode
        [Theory]
        [InlineData("9451")]
        [InlineData("9000")]
        public void NewLid_PostcodeCorrect_CreatesLid(string postcode)
        {
            _lid = new Lid() { PostCode = postcode };
            Assert.Equal(postcode, _lid.PostCode);
        }

        [Theory]
        [InlineData("55555")]
        [InlineData("74aa")]
        [InlineData("aaaa")]
        [InlineData("74@-")]
        [InlineData("/*@-")]
        [InlineData("")]
        [InlineData(null)]
        public void NewLid_PostcodeFout_ArgumentException(string postcode)
        {
            Assert.Throws<ArgumentException>(() => _lid = new Lid() { PostCode = postcode });
        }
        #endregion

        #region Testen Email
        [Theory]
        [InlineData("robdeputter@hotmail.com")]
        [InlineData("robdp@gmail.com")]
        public void NewLid_EmailCorrect_CreatesLid(string email)
        {
            _lid = new Lid() { Email = email };
            Assert.Equal(email, _lid.Email);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Rob Deputter@hotmail.com")]
        public void NewLid_EmailFout_ArgumentException(string email)
        {
            Assert.Throws<ArgumentException>(() => _lid = new Lid() { Email = email });
        }
        #endregion

        #region Testen Email vader
        [Theory]
        [InlineData("robdeputter@hotmail.com")]
        [InlineData("robdp@gmail.com")]
        public void NewLid_EmailVaderCorrect_CreatesLid(string email)
        {
            _lid = new Lid() { EmailVader = email };
            Assert.Equal(email, _lid.EmailVader);
        }

        [Theory]
        [InlineData("Rob Deputter@hotmail.com")]
        public void NewLid_EmailVaderFout_ArgumentException(string email)
        {
            Assert.Throws<ArgumentException>(() => _lid = new Lid() { EmailVader = email });
        }
        #endregion

        #region Testen Email moeder
        [Theory]
        [InlineData("robdeputter@hotmail.com")]
        [InlineData("robdp@gmail.com")]
        public void NewLid_EmailMoederCorrect_CreatesLid(string email)
        {
            _lid = new Lid() { EmailMoeder = email };
            Assert.Equal(email, _lid.EmailMoeder);
        }

        [Theory]
        [InlineData("Rob Deputter@hotmail.com")]
        public void NewLid_EmailMoederFout_ArgumentException(string email)
        {
            Assert.Throws<ArgumentException>(() => _lid = new Lid() { EmailMoeder = email });
        }
        #endregion

        #region Testen Geboorteplaats
        [Theory]
        [InlineData("Aalst")]
        [InlineData("Gent")]
        public void NewLid_GeboorteplaatsCorrect_CreatesLid(string geboorteplaats)
        {
            _lid = new Lid() { GeboortePlaats = geboorteplaats };
            Assert.Equal(geboorteplaats, _lid.GeboortePlaats);
        }

        [Theory]
        [InlineData("azezae12345")]
        [InlineData("15515")]
        [InlineData("aze@ze-*/151")]
        [InlineData("@@/*-+$^")]
        public void NewLid_GeboorteplaatsFout_ArgumentException(string geboorteplaats)
        {
            Assert.Throws<ArgumentException>(() => _lid = new Lid() { GeboortePlaats = geboorteplaats });
        }
        #endregion

        #region Testen gsmnummer
        [Theory]
        [InlineData("0476456851")]
        [InlineData("+32476456851")]
        public void NewLid_GsmNummerCorrect_CreatesLid(string gsmnummer)
        {
            _lid = new Lid() { GsmNr = gsmnummer };
            Assert.Equal(gsmnummer, _lid.GsmNr);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("aaaaa12345")]
        [InlineData("aaaaaaaaaa")]
        [InlineData("@@@@@12345")]
        [InlineData("@@@@@@@@@@")]
        public void NewLid_GsmnummerFout_ArgumentException(string gsmnummer)
        {
            Assert.Throws<ArgumentException>(() => _lid = new Lid() { GsmNr = gsmnummer });
        }
        #endregion

        #region Testen nationaliteit
        [Theory]
        [InlineData("Belg")]
        [InlineData("Vietna mees")]
        public void NewLid_NationaliteitCorrect_CreatesLid(string nationaliteit)
        {
            _lid = new Lid() { Nationaliteit = nationaliteit };
            Assert.Equal(nationaliteit, _lid.Nationaliteit);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("sdfqsfq123")]
        [InlineData("12356")]
        [InlineData("aze@ze-*/151")]
        [InlineData("@@/*-+$^")]
        public void NewLid_NationaliteitFout_CreatesLid(string nationaliteit)
        {
            Assert.Throws<ArgumentException>(() => _lid = new Lid() { Nationaliteit = nationaliteit });
        }

        #endregion

        #region Testen vaste telefoonnummer
        [Theory]
        [InlineData("053833670")]
        public void NewLid_TelefoonnummerCorrect_CreatesLid(string telefoonnummer)
        {
            _lid = new Lid() { VasteTelefoonNr = telefoonnummer };
            Assert.Equal(telefoonnummer, _lid.VasteTelefoonNr);
        }

        [Theory]
        [InlineData("053833670aaa")]
        [InlineData("aaaaaaaaa")]
        [InlineData("053aaaaaa")]
        public void NewLid_TelefoonummerFout_ArgumentException(string telefoonnummer)
        {
            Assert.Throws<ArgumentException>(() => _lid = new Lid() { VasteTelefoonNr = telefoonnummer });
        }
        #endregion

    }
}
