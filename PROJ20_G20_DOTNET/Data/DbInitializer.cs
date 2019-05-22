using Microsoft.AspNetCore.Identity;
using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PROJ20_G20_DOTNET.Data
{
    public class DbInitializer
    {

        private JiuJitsuDbContext _dbContext;
        private UserManager<IdentityUser> _userManager;

        public DbInitializer(JiuJitsuDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }


        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated()) {

                #region Leden
                Lid lid1 = new Lid("Tim", "Geldof", new DateTime(1997, 07, 17),
                     "97.07.17-001.23", "0479330959", "051303050", "Izegem", "Winkelhoekstraat",
                     "52", "8870", "tim.geldof@outlook.com", "P@ssword1", "Izegem", "Man", "Belg", Graad.DAN5, Functie.BEHEERDER);

                Lid lid2 = new Lid("Tybo", "Vanderstraeten", new DateTime(1999, 12, 8),
                    "99.12.08-173.04", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "tybo.vanderstraeten@outlook.com",
                    "P@ssword1", "Gent", "Man", "Belg", Graad.KYU3, Functie.LID);

                Lid lid3 = new Lid("Paul", "Pieters", new DateTime(1990, 05, 3),
                    "90.05.03-001.88", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "paul.pieters@outlook.com",
                    "P@ssword1", "Gent", "Man", "Belg", Graad.DAN5, Functie.TRAINER);

                Lid lid4 = new Lid("Sarah", "De Bakker", new DateTime(1990, 04, 4),
                    "90.04.04-002.50", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "sarah.pieters@outlook.com",
                    "P@ssword1", "Gent", "Vrouw", "Belg", Graad.DAN2, Functie.LID);

                Lid lid5 = new Lid("Thomas", "De Slager", new DateTime(1999, 06, 3),
                    "99.06.03-001.90", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "thomas.pieters@outlook.com",
                    "P@ssword1", "Gent", "Man", "Belg", Graad.DAN4, Functie.LID);

                Lid lid6 = new Lid("Jasper", "Vandamme", new DateTime(1997, 06, 6),
                    "97.06.06-001.55", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "jasper.pieters@outlook.com",
                    "P@ssword1", "Gent", "Man", "Belg", Graad.DAN2, Functie.LID);

                Lid lid7 = new Lid("Lisa", "Baekelandt", new DateTime(1994, 08, 8),
                    "94.08.08-002.42", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "lisa.pieters@outlook.com",
                    "P@ssword1", "Gent", "Vrouw", "Belg", Graad.KYU3, Functie.LID);

                Lid lid8 = new Lid("Jonas", "Vangogh", new DateTime(1993, 02, 2),
                    "93.02.02-001.63", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "jonas.pieters@outlook.com",
                    "P@ssword1", "Gent", "Man", "Belg", Graad.KYU6, Functie.LID);

                Lid lid9 = new Lid("Siska", "Schoeters", new DateTime(1998, 05, 2),
                    "98.05.02-002.91", "0477441465", "051303054", "Gent", "Korenmarkt", "21", "9000", "siska.pieters@outlook.com",
                    "P@ssword1", "Gent", "Vrouw", "Belg", Graad.DAN5, Functie.TRAINER);


                _dbContext.Leden.Add(lid1);
                _dbContext.Leden.Add(lid2);
                _dbContext.Leden.Add(lid3);
                _dbContext.Leden.Add(lid4);
                _dbContext.Leden.Add(lid5);
                _dbContext.Leden.Add(lid6);
                _dbContext.Leden.Add(lid7);
                _dbContext.Leden.Add(lid8);
                _dbContext.Leden.Add(lid9);

                await CreateUser(lid1);
                await CreateUser(lid2);
                await CreateUser(lid3);
                await CreateUser(lid4);
                await CreateUser(lid5);
                await CreateUser(lid6);
                await CreateUser(lid7);
                await CreateUser(lid8);
                await CreateUser(lid9);

                #endregion

                #region Activiteiten
                Activiteit act1 = new Activiteit("Eindexamen", Formule.EXAMEN, new DateTime(2019, 5, 31, 12, 00, 00), new DateTime(2019, 5, 31,13,00,00),
                    new DateTime(2019, 5, 30), "0477441462", "act@act.act", "Rokerspaviljoen", "Korenmarkt", "Gent", "9000",
                    "20", "5", 50);
                Activiteit act2 = new Activiteit("Bobbejaanland", Formule.UITSTAP, new DateTime(2019, 6, 01, 7, 00, 00), new DateTime(2019, 6, 01,20,00,00),
                   new DateTime(2019, 5, 24), "0477441462", "act@act.act", "Rokerspaviljoen", "Korenmarkt", "Gent", "9000",
                   "20", "5", 50);

                Activiteit act3 = new Activiteit("Stage Polen", Formule.STAGE, new DateTime(2020, 5, 18, 10, 00, 00), new DateTime(2020, 5, 21,20,00,00),
                   new DateTime(2020, 5, 16), "0477441462", "act@act.act", "Rokerspaviljoen", "Korenmarkt", "Gent", "9000",
                   "20", "5", 50);

                Activiteit act4 = new Activiteit("Dinsdag Training", Formule.DI_DO, new DateTime(2019, 05, 28, 18, 00, 00), new DateTime(2019, 05, 28,20,00,00),
                   new DateTime(2019, 05, 27), "0477441462", "act@act.act", "Rokerspaviljoen", "Korenmarkt", "Gent", "9000",
                   "20", "5", 50);

                Activiteit act5 = new Activiteit("Teambuilding Ardennen", Formule.UITSTAP, new DateTime(2020, 10, 09, 6, 30, 00), new DateTime(2020, 10, 11,22,00,00),
                   new DateTime(2020, 09, 01), "0477441462", "act@act.act", "Rokerspaviljoen", "Korenmarkt", "Gent", "9000",
                   "20", "5", 50);

                Activiteit act6 = new Activiteit("Examen Kyu naar Dan", Formule.EXAMEN, new DateTime(2019, 05, 30, 8, 30, 00), new DateTime(2019, 05, 30,10,30,00),
                    new DateTime(2019, 05, 24), "0477441462", "act@act.act", "Rokerspaviljoen", "Korenmarkt", "Gent", "9000",
                    "20", "5", 50);

                _dbContext.Activiteiten.Add(act1);
                _dbContext.Activiteiten.Add(act2);
                _dbContext.Activiteiten.Add(act3);
                _dbContext.Activiteiten.Add(act4);
                _dbContext.Activiteiten.Add(act5);
                _dbContext.Activiteiten.Add(act6);

                #endregion

                #region Inschrijvingen

                #region Activiteit 1
                Inschrijving inschrijving1 = new Inschrijving(lid2, act1.Formule, DateTime.Now);
                Inschrijving inschrijving3 = new Inschrijving(lid1, act1.Formule, DateTime.Now);
                Inschrijving inschrijving4 = new Inschrijving(lid3, act1.Formule, DateTime.Now);
                Inschrijving inschrijving13 = new Inschrijving(lid4, act1.Formule, DateTime.Now);
                Inschrijving inschrijving14 = new Inschrijving(lid5, act1.Formule, DateTime.Now);
                Inschrijving inschrijving15 = new Inschrijving(lid6, act1.Formule, DateTime.Now);
                Inschrijving inschrijving16 = new Inschrijving(lid7, act1.Formule, DateTime.Now);
                Inschrijving inschrijving17 = new Inschrijving(lid8, act1.Formule, DateTime.Now);
                Inschrijving inschrijving18 = new Inschrijving(lid9, act1.Formule, DateTime.Now);
                #endregion

                #region Activiteit 2
                Inschrijving inschrijving2 = new Inschrijving(lid2, act2.Formule, DateTime.Now);
                Inschrijving inschrijving5 = new Inschrijving(lid3, act2.Formule, DateTime.Now);
                Inschrijving inschrijving19 = new Inschrijving(lid5, act2.Formule, DateTime.Now);
                Inschrijving inschrijving20 = new Inschrijving(lid8, act2.Formule, DateTime.Now);
                Inschrijving inschrijving21 = new Inschrijving(lid9, act2.Formule, DateTime.Now);

                #endregion

                #region Activiteit 3
                Inschrijving inschrijving6 = new Inschrijving(lid1, act3.Formule, DateTime.Now);
                Inschrijving inschrijving7 = new Inschrijving(lid2, act3.Formule, DateTime.Now);
                #endregion

                #region Activiteit 4
                Inschrijving inschrijving8 = new Inschrijving(lid1, act4.Formule, DateTime.Now);
                Inschrijving inschrijving9 = new Inschrijving(lid3, act4.Formule, DateTime.Now);
                Inschrijving inschrijving22 = new Inschrijving(lid4, act4.Formule, DateTime.Now);
                Inschrijving inschrijving23 = new Inschrijving(lid5, act4.Formule, DateTime.Now);

                #endregion

                #region Activiteit 5
                Inschrijving inschrijving10 = new Inschrijving(lid3, act5.Formule, DateTime.Now);
                Inschrijving inschrijving11 = new Inschrijving(lid1, act5.Formule, DateTime.Now);
                Inschrijving inschrijving12 = new Inschrijving(lid2, act5.Formule, DateTime.Now);
                Inschrijving inschrijving24 = new Inschrijving(lid6, act5.Formule, DateTime.Now);
                Inschrijving inschrijving25 = new Inschrijving(lid7, act5.Formule, DateTime.Now);
                Inschrijving inschrijving26 = new Inschrijving(lid4, act5.Formule, DateTime.Now);

                #endregion

                #region Activiteit 6
                Inschrijving inschrijving27 = new Inschrijving(lid8, act6.Formule, DateTime.Now);
                #endregion



                _dbContext.Inschrijvingen.Add(inschrijving1);
                _dbContext.Inschrijvingen.Add(inschrijving2);
                _dbContext.Inschrijvingen.Add(inschrijving3);
                _dbContext.Inschrijvingen.Add(inschrijving4);
                _dbContext.Inschrijvingen.Add(inschrijving5);
                _dbContext.Inschrijvingen.Add(inschrijving6);
                _dbContext.Inschrijvingen.Add(inschrijving7);
                _dbContext.Inschrijvingen.Add(inschrijving8);
                _dbContext.Inschrijvingen.Add(inschrijving9);
                _dbContext.Inschrijvingen.Add(inschrijving10);
                _dbContext.Inschrijvingen.Add(inschrijving11);
                _dbContext.Inschrijvingen.Add(inschrijving12);

                act1.AddInschrijving(inschrijving1);
                act1.AddInschrijving(inschrijving3);
                act1.AddInschrijving(inschrijving4);
                act1.AddInschrijving(inschrijving13);
                act1.AddInschrijving(inschrijving14);
                act1.AddInschrijving(inschrijving15);
                act1.AddInschrijving(inschrijving16);
                act1.AddInschrijving(inschrijving17);
                act1.AddInschrijving(inschrijving18);

                act2.AddInschrijving(inschrijving2);
                act2.AddInschrijving(inschrijving5);
                act2.AddInschrijving(inschrijving19);
                act2.AddInschrijving(inschrijving20);
                act2.AddInschrijving(inschrijving21);

                act3.AddInschrijving(inschrijving6);
                act3.AddInschrijving(inschrijving7);

                act4.AddInschrijving(inschrijving8);
                act4.AddInschrijving(inschrijving9);
                act4.AddInschrijving(inschrijving22);
                act4.AddInschrijving(inschrijving23);

                act5.AddInschrijving(inschrijving10);
                act5.AddInschrijving(inschrijving11);
                act5.AddInschrijving(inschrijving12);
                act5.AddInschrijving(inschrijving24);
                act5.AddInschrijving(inschrijving25);
                act5.AddInschrijving(inschrijving26);

                act6.AddInschrijving(inschrijving27);
                #endregion

                #region Oefeningen
                Oefening oefening1 = new Oefening("Ko Soto Gake", "https://www.youtube.com/embed/8-fgNbmJkKs", "De ko-soto-gake wordt soms ook wel de tegenhanger van de ō-soto-gari genoemd. Stap je bij de ō-soto-gari met je linkerbeen vooruit (uitgaande van een rechtse pakking), dan werp je met je rechterbeen, terwijl dit bij de ko-soto-gake precies andersom is. Als we echter beter naar het principe van de twee worpen gaan kijken, zien we dat het om twee totaal verschillende technieken gaat.", DateTime.Now, Graad.KYU1, new Thema("Techniek"));
                Oefening oefening2 = new Oefening("Kata Ashi Dori", "https://www.youtube.com/embed/h_OI-mZiLp8", "Tori stapt met zijn rechter been naar uke toe en duwt met zijn rechterhand op de kin van uke. Uke moet hierdoor (om zijn balans te herstellen) een pas met zijn linkervoet achteruit doen. Tori duwt (extra) onder de kin van uke, waardoor uke nog verder uit balans komt te staan. Tegelijkertijd gaat tori op een zijn rechter knie zitten en brengt zijn rechterhand (binnendoor) en zijn linkerhand (buitenom) op de rechter enkel van uke. Om uke te werpen duwt tori met zijn rechterschouder op de rechter knie van uke, terwijl tori zijn handen naar zich toe brengt.", DateTime.Now, Graad.KYU1, new Thema("Defensief"));
                Oefening oefening3 = new Oefening("Kubi Gatame", "https://www.youtube.com/embed/6zk1-7hi2F0", "Uke stapt met URB naar voren en pakt met beide armen Tori om de de keel. Tori zakt door beide knieën en trekt met TLH URH van de keel. Atemi: Elleboog maakt een stoot onder de kin van Uke. TRH duwt de elleboog van URA omhoog en tori stap er onder door, onderwijl Uke meetrekkend aan URA. TRH maakt weer een teisho onder de kin van uke. Tori beweegt zijn hoofd onder URA door en plaatst deze in zijn nek, om vervolgens kubi gatame aan te kunnen zetten.Uke stapt met URB naar voren en pakt met beide armen Tori om de de keel. Tori zakt door beide knieën en trekt met TLH URH van de keel. Atemi: Elleboog maakt een stoot onder de kin van Uke. TRH duwt de elleboog van URA omhoog en tori stap er onder door, onderwijl Uke meetrekkend aan URA. TRH maakt weer een teisho onder de kin van uke. Tori beweegt zijn hoofd onder URA door en plaatst deze in zijn nek, om vervolgens kubi gatame aan te kunnen zetten.", DateTime.Now, Graad.KYU1, new Thema("Techniek"));
                Oefening oefening4 = new Oefening("Kubi Nage", "https://www.youtube.com/embed/esZvkH7Mp_Q", "Om Kubi-nage uit te voeren, moet Tori zijn lichaam op dezelfde manier plaatsen als voor O-Goshi . Het verschil is dat hier de hand die Uke 's rug vasthoudt, teruggaat over zijn nek zoals in Koshi - Guruma . Dan trekt Tori Uke's mouw, draait terwijl hij zijn been in het spervuur ​​zet, wat ertoe leidt dat Uke naar voren valt.", DateTime.Now, Graad.KYU1, new Thema("Offensief"));
                Oefening oefening5 = new Oefening("Kubi Gatame", "https://www.youtube.com/embed/6zk1-7hi2F0", "Tori trekt uke verder uit balans (maushiro no kuzushi) door naar voren te bewegen. TRH pakt URrever en houdt deze iets omhoog. Tori draait nu 180 graden rechtsom, terug naar uke, en pakt met TLH om de nek van uke heen de rever. TLB stapt achterom en trekt uke naar de grond. TRA steekt achter de nek van uke en door de rever aan te trekken met TLH ontstaat kata ha jime.", DateTime.Now, Graad.KYU1, new Thema("Defensief"));
                Oefening oefening6 = new Oefening("O Goshi", "https://www.youtube.com/embed/ck-6D3IUyMo", "Tori plaatst de rechterhand op de onderrug van uke en plaatst in dezelfde beweging zijn rechterheup voorbij de rechterheup van uke, de knieën gebogen. Tori strekt de benen en buigt voorover en heft zo uke van de grond. Simultaan maakt tori een draaiende beweging met het bovenlichaam en werpt uke over zijn heup.", DateTime.Now, Graad.KYU1, new Thema("Algemeen"));
                Oefening oefening7 = new Oefening("Kubi Nage Variantie", "https://www.youtube.com/embed/7LD9uvnG7pc", "Om Kubi-nage uit te voeren, moet Tori zijn lichaam op dezelfde manier plaatsen als voor O-Goshi . Het verschil is dat hier de hand die Uke 's rug vasthoudt, teruggaat over zijn nek zoals in Koshi - Guruma . Dan trekt Tori Uke's mouw, draait terwijl hij zijn been in het spervuur ​​zet, wat ertoe leidt dat Uke naar voren valt.", DateTime.Now, Graad.KYU1, new Thema("Algemeen"));
                Oefening oefening8 = new Oefening("Ude Osea", "https://www.youtube.com/embed/qQxJdIvSzQg", "Uke stapt met URB naar voren en pakt met beide armen Tori om de de keel. Tori zakt door beide knieën en trekt met TLH URH van de keel. Atemi: Elleboog maakt een stoot onder de kin van Uke. TRH duwt de elleboog van URA omhoog en tori stap er onder door, onderwijl Uke meetrekkend aan URA. TRH maakt weer een teisho onder de kin van uke. Tori beweegt zijn hoofd onder URA door en plaatst deze in zijn nek, om vervolgens kubi gatame aan te kunnen zetten.Uke stapt met URB naar voren en pakt met beide armen Tori om de de keel. Tori zakt door beide knieën en trekt met TLH URH van de keel. Atemi: Elleboog maakt een stoot onder de kin van Uke. TRH duwt de elleboog van URA omhoog en tori stap er onder door, onderwijl Uke meetrekkend aan URA. TRH maakt weer een teisho onder de kin van uke. Tori beweegt zijn hoofd onder URA door en plaatst deze in zijn nek, om vervolgens kubi gatame aan te kunnen zetten.", DateTime.Now, Graad.KYU2, new Thema("Algemeen"));
                Oefening oefening9 = new Oefening("O Goshi", "https://www.youtube.com/embed/ck-6D3IUyMo", "Tori plaatst de rechterhand op de onderrug van uke en plaatst in dezelfde beweging zijn rechterheup voorbij de rechterheup van uke, de knieën gebogen. Tori strekt de benen en buigt voorover en heft zo uke van de grond. Simultaan maakt tori een draaiende beweging met het bovenlichaam en werpt uke over zijn heup.", DateTime.Now, Graad.KYU3, new Thema("Algemeen"));
                Oefening oefening10 = new Oefening("Shiho Nage", "https://www.youtube.com/embed/D0G3MwJqtSA", "De ko-soto-gake wordt soms ook wel de tegenhanger van de ō-soto-gari genoemd. Stap je bij de ō-soto-gari met je linkerbeen vooruit (uitgaande van een rechtse pakking), dan werp je met je rechterbeen, terwijl dit bij de ko-soto-gake precies andersom is. Als we echter beter naar het principe van de twee worpen gaan kijken, zien we dat het om twee totaal verschillende technieken gaat.", DateTime.Now, Graad.KYU4, new Thema("Algemeen"));
                Oefening oefening11 = new Oefening("Nage Shiho", "https://www.youtube.com/embed/T9vWR7EdQdM", "Tori plaatst de rechterhand op de onderrug van uke en plaatst in dezelfde beweging zijn rechterheup voorbij de rechterheup van uke, de knieën gebogen. Tori strekt de benen en buigt voorover en heft zo uke van de grond. Simultaan maakt tori een draaiende beweging met het bovenlichaam en werpt uke over zijn heup.", DateTime.Now, Graad.KYU5, new Thema("Algemeen"));
                Oefening oefening12 = new Oefening("Ryo Ashi Dori", "https://www.youtube.com/embed/tJVGNbY8EtQ", "Tijdens de worp pakt tori met TRH URP vast. Als uke op de grond ligt geeft tori een trap op de borst van uke met TRB. Vervolgens brengt tori zijn rechterbeen weer naar de buitenkant terug en pakt met TLH URP over. Tori gaat op de grond zitten en brengt URA over TRBovenbeen en vervolgens onder TRonderbeen waardoor er een ashi ude garami op URA komt te zitten. Voor extra controle pakt tori met TRH ULP en zet hier ook een ude garami op. Tori duwt vervolgens met zijn vrije hand uke's hoofd af, waardoor uke volledig gecontroleerd kan worden.", DateTime.Now, Graad.KYU6, new Thema("Algemeen"));
                Oefening oefening13 = new Oefening("Ne Waza Kata", "https://www.youtube.com/embed/5lgI9xk43Fw", "Het Ne waza jitsu no kata is een Jiujitsu kata en onderdeel van het examen voor de 2e dan. Het is ontwikkeld in de jaren 1970 in Nederland door de Nationale Graden Commissie samen met een aantal hoge dangraadhouders, om het gat in het leerplan te dichten tussen het Ebo no kata, Goshin Jitsu no Kata en Kime no Kata.", DateTime.Now, Graad.DAN1, new Thema("Algemeen"));
                Oefening oefening14 = new Oefening("Aikido Beperking", "https://www.youtube.com/embed/hNA7yw6Iqcc", "Aikido (合気道 aikidō), letterlijk vertaald de weg van het samenkomen met Ki is een Japanse krijgsdiscipline (zie onder) met een sterk filosofische inslag, die in het begin van de 20e eeuw door Morihei Ueshiba ontwikkeld werd. Ueshiba, door aikidoka's O'Sensei (de grote meester) genoemd, liet zich hierbij inspireren door de technieken van de Japanse samoerai en krijgskunsten en/of vechtsporten als Daito ryu jiu jitsu, jiujitsu en kenjutsu. Ueshiba voegde ook een morele waarde toe aan de kunst van aikido, die ontleend werd aan de toen nieuwe Japanse religie Omoto-kyo.", DateTime.Now, Graad.DAN2, new Thema("Algemeen"));


                _dbContext.Oefeningen.Add(oefening1);
                _dbContext.Oefeningen.Add(oefening2);
                _dbContext.Oefeningen.Add(oefening3);
                _dbContext.Oefeningen.Add(oefening4);
                _dbContext.Oefeningen.Add(oefening5);
                _dbContext.Oefeningen.Add(oefening6);
                _dbContext.Oefeningen.Add(oefening7);
                _dbContext.Oefeningen.Add(oefening8);
                _dbContext.Oefeningen.Add(oefening9);
                _dbContext.Oefeningen.Add(oefening10);
                _dbContext.Oefeningen.Add(oefening11);
                _dbContext.Oefeningen.Add(oefening12);
                _dbContext.Oefeningen.Add(oefening13);
                _dbContext.Oefeningen.Add(oefening14);
                #endregion

                _dbContext.SaveChanges();

            }
        }

        private async Task CreateUser(Lid lid)
        {
            IdentityUser user = new IdentityUser() {
                UserName = lid.Email,
                Email = lid.Email,
            };

            await _userManager.CreateAsync(user, lid.Wachtwoord);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, lid.Functie.ToString().ToLower()));
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "viewPersonalDetails"));
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "viewHome"));
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "viewExercisesOwn"));

            if (lid.Functie.Equals(Functie.BEHEERDER) || lid.Functie.Equals(Functie.TRAINER)) {
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "viewAttendings"));
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "viewExercisesAllMembers"));
            }

            _dbContext.SaveChanges();
        }
    }
}

