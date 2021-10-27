using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    [Index(nameof(CsoportNev), IsUnique = true)]
    public class Csoport
    {
        public Guid Id {get; set;}
        [Required]
        public string CsoportNev { get; set; }
        public string Informacio { get; set; }
        public MunkaRendTipusEnum MunkaRendTipus { get; set; }
    }

    public enum MunkaRendTipusEnum
    {
        Altalanos,
        Keszenleti,
        MegszakitasNelkuli
    }
}