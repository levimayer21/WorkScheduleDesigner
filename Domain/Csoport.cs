using System;

namespace Domain
{
    public class Csoport
    {
        public Guid Id {get; set;}
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