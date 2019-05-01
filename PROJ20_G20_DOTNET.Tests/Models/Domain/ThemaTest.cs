using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PROJ20_G20_DOTNET.Tests.Models.Domain
{
    public class ThemaTest
    {
        private Thema _thema;

        #region Testen naam
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("sdfqsfq123")]
        [InlineData("12356")]
        [InlineData("aze@ze-*/151")]
        [InlineData("@@/*-+$^")]
        public void NewThema_NaamFout_ArgumentException(string naam)
        {
           Assert.Throws<ArgumentException>(() => _thema = new Thema() { Naam = naam });
        }

        #endregion
    }
}
