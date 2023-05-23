using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Model
{
    public class Asistencia
    {
        public int id { get; set; }
        public int id_estudiante { get; set; }
        public DateTime fecha { get; set; }
        public bool presente { get; set; }
    }
}