using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Beosztas
    {
        private TimeSpan _munkaido;

        public Guid Id { get; set; }
        [ForeignKey("Csoport_Id")]
        public Csoport Csoport { get; set; }
        [Required]
        public Guid Csoport_Id { get; set; }
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
        public TimeSpan Munkaido { get => _munkaido; set => _munkaido = MuszakVeg - MuszakKezd; }
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
