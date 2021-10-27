using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Beosztas
    {
        private TimeSpan munkaido;

        [Required]
        public Guid Id { get; set; }
        [Required]
        public Csoport Csoport { get; set; }
        [Required]
        public DateTime MuszakKezd { get; set; }
        [Required]
        public DateTime MuszakVeg { get; set; }
        [Required]
        public BeosztasTipusEnum BeosztasTipus { get; set; }
        [Required]
        public bool HomeOffice { get; set; }
        public DateTime Letrehozva { get; set; }
        public DateTime Modositva { get; set; }
        public TimeSpan Munkaido { get => munkaido; private set => munkaido = MuszakVeg - MuszakKezd; }
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
