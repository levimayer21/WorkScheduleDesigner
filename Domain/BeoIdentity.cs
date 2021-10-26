using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class BeoIdentity : IdentityUser
    {
        [Required]
        public JogosultsagokEnum Jogosultsag { get; set; }
        [Required]
        public string VezetekNev { get; set; }
        [Required]
        public string KeresztNev { get; set; }
        public Csoport Csoport { get; set; }
    }

    public enum JogosultsagokEnum
    {
        admin,
        user
    }
}