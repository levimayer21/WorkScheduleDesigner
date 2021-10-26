using System;

namespace Domain
{
    public class Beosztas
    {
        private int munkaido;

        public Guid Id { get; set; }
        public BeoIdentity Beosztott { get; set; }
        public Csoport Csoport { get; set; }
        public DateTime MuszakKezd { get; set; }
        public DateTime MuszakVeg { get; set; }
        public int Munkaido { get => munkaido; private set => munkaido = Math.Abs(MuszakVeg.Hour-MuszakKezd.Hour); }
        public BeosztasTipusEnum BeosztasTipus { get; set; }
        public bool HomeOffice { get; set; }
        public DateTime Letrehozva { get; set; }
        public DateTime Modositva { get; set; }
    }

    public enum BeosztasTipusEnum
    {
        N,
        E,
        K,
        X,
        Sz,
        Bsz,
        T
    }
}
