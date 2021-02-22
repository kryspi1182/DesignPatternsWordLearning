using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ztp_projekt.Models;

namespace ztp_projekt
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var context = PytaniaDBContext.GetDBContext();
            context.Database.EnsureCreated();

            if (context.Pytania.Any() == false)
            {
                List<Pytania> pytania = new List<Pytania>() {
                    new Pytania()
                    {
                        IdPytania = 1,
                        TrescAngielski = "Father of a father",
                        TrescPolski = "Ojciec ojca",
                        OdpowiedzAngielski = "Grandfather",
                        OdpowiedzPolski = "Dziadek",
                        BlednaOdpAngielski1 = "Granduncle",
                        BlednaOdpAngielski2 = "Uncle",
                        BlednaOdpAngielski3 = "Ancestor",
                        BlednaOdpPolski1 = "Wujek",
                        BlednaOdpPolski2 = "Prawujek",
                        BlednaOdpPolski3 = "Brat"
                    },
                    new Pytania()
                    {
                        IdPytania = 2,
                        TrescAngielski = "Mother of a father",
                        TrescPolski = "Matka ojca",
                        OdpowiedzAngielski = "Grandmother",
                        OdpowiedzPolski = "Babcia",
                        BlednaOdpAngielski1 = "Aunt",
                        BlednaOdpAngielski2 = "Niece",
                        BlednaOdpAngielski3 = "Sister",
                        BlednaOdpPolski1 = "Prababcia",
                        BlednaOdpPolski2 = "Ciocia",
                        BlednaOdpPolski3 = "Baba"
                    },
                    new Pytania()
                    {
                        IdPytania = 3,
                        TrescAngielski = "Fruit, company which makes iPhones",
                        TrescPolski = "Owoc, firma produkująca iPhone",
                        OdpowiedzAngielski = "Apple",
                        OdpowiedzPolski = "Jabłko",
                        BlednaOdpAngielski1 = "Pear",
                        BlednaOdpAngielski2 = "Poop",
                        BlednaOdpAngielski3 = "Lime",
                        BlednaOdpPolski1 = "Gruszka",
                        BlednaOdpPolski2 = "Cytryna",
                        BlednaOdpPolski3 = "Banan"
                    }
                };

                context.Pytania.AddRange(pytania);
                context.SaveChanges();

            }

            
        }
    }
}
