using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Model
{
    public class Estudiante
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string apellido { get; set; }

        public double Lengua_espanola { get; set; }
        public double Matematica { get; set; }
        public double Ciencias_naturales { get; set; }
        public double Ciencias_sociales { get; set; }

        public string Literal { get; set; }
    }
}
