using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROJ20_G20_DOTNET.Tests
{
    public class DummyJiuJitsuDbContext
    {
        public Lid Rob { get; }
        public Lid Tim { get; }
        public Lid Tybo { get; }
        public Lid Florian { get; }

        public DummyJiuJitsuDbContext()
        {
            int lidId = 1;

            Rob = new Lid("Rob", "De Putter", new DateTime(1999, 5, 11), "99.05.11-313.16",
                "0476456851", "053833670", "Kerksken", "Boekentstraat", "115", "9451", "robdeputter@hotmail.com",
                "P@ssword1", "Aalst", "Man", "Belg", Graad.KYU6, Functie.BEHEERDER)
            { Id = lidId++ };
        }

    }
}
