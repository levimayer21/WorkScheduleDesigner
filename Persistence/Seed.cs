using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedDataAsync(DataContext context)
        {
            Random rnd = new Random();

            List<Csoport> csoportok;

            if (!context.Csoportok.Any())
            {
                csoportok = new List<Csoport>
                {
                    new Csoport
                    {
                        CsoportNev = "TSM",
                        Informacio = "TSM csoport beosztása",
                        MunkaRendTipus = MunkaRendTipusEnum.MegszakitasNelkuli
                    },
                    new Csoport
                    {
                        CsoportNev = "KIRUI-HW",
                        Informacio = "KIRUI-HW csoport beosztása",
                        MunkaRendTipus = MunkaRendTipusEnum.Keszenleti
                    },
                    new Csoport
                    {
                        CsoportNev = "Munkaügyek",
                        Informacio = "Munkaügyek csoport beosztása",
                        MunkaRendTipus = MunkaRendTipusEnum.Altalanos
                    }
                };

                await context.Csoportok.AddRangeAsync(csoportok);
            }
            else
            {
                csoportok = await context.Csoportok.ToListAsync();
            }

            if (context.Beosztasok.Any()) return;

            var beosztasok = new List<Beosztas>
            {
                new Beosztas
                {
                    Csoport = csoportok.FirstOrDefault(x => x.CsoportNev == "TSM"),
                    Csoport_Id = csoportok.FirstOrDefault(x => x.CsoportNev == "TSM").Id,
                    MuszakKezd = DateTime.Parse("2021/10/26 6:00"),
                    MuszakVeg = DateTime.Parse("2021/10/26 18:00"),
                    BeosztasTipus = BeosztasTipusEnum.N,
                    HomeOffice = false,
                    Letrehozva = DateTime.Now,
                    Modositva = DateTime.Now,
                    Munkaido = TimeSpan.Zero
                },
                new Beosztas
                {
                    Csoport = csoportok.FirstOrDefault(x => x.CsoportNev == "KIRUI-HW"),
                    Csoport_Id = csoportok.FirstOrDefault(x => x.CsoportNev == "KIRUI-HW").Id,
                    MuszakKezd = DateTime.Parse("2021/10/26 0:00"),
                    MuszakVeg = DateTime.Parse("2021/10/26 20:00"),
                    BeosztasTipus = BeosztasTipusEnum.K,
                    HomeOffice = true,
                    Letrehozva = DateTime.Now,
                    Modositva = DateTime.Now,
                    Munkaido = TimeSpan.Zero
                },
                new Beosztas
                {
                    Csoport = csoportok.FirstOrDefault(x => x.CsoportNev == "Munkaügyek"),
                    Csoport_Id = csoportok.FirstOrDefault(x => x.CsoportNev == "Munkaügyek").Id,
                    MuszakKezd = DateTime.Parse("2021/10/26 8:00"),
                    MuszakVeg = DateTime.Parse("2021/10/26 16:00"),
                    BeosztasTipus = BeosztasTipusEnum.N,
                    HomeOffice = false,
                    Letrehozva = DateTime.Now,
                    Modositva = DateTime.Now,
                    Munkaido = TimeSpan.Zero
                },
            };

            await context.Beosztasok.AddRangeAsync(beosztasok);
            await context.SaveChangesAsync();
        }
    }
}