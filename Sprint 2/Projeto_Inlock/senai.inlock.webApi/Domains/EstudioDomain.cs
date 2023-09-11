using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }

        [Required(ErrorMessage ="O nome da empresa é necessário!")]
        public string NomeEstudio { get; set; }
    }
}
