using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SchoolApi.Data;
using SchoolApi.Model;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        //[HttpGet(Name = "GetEstudiante")]
        ////[Route("GetEstudiante")]
        //public ActionResult<IEnumerable<Estudiante>> Get()
        //{
        //    List<Estudiante> estudiantes = new List<Estudiante>();
        //    Conexion conexion = new Conexion();
        //    using (SqlConnection connection = new SqlConnection(conexion.cadenaConexion))
        //    {
        //        string sql = $"SELECT * FROM Estudiante";
        //        using (SqlCommand command = new SqlCommand(sql, connection))
        //        {
        //            command.Connection.Open();
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    Estudiante estudiante = new Estudiante();
        //                    estudiante.id = reader.GetInt32(reader.GetOrdinal("id"));
        //                    estudiante.nombre = reader.GetString(reader.GetOrdinal("nombre"));
        //                    estudiante.apellido = reader.GetString(reader.GetOrdinal("apellido"));
        //                    estudiante.Lengua_espanola = reader.GetInt32(reader.GetOrdinal("Lengua_espanola"));
        //                    estudiante.Matematica = reader.GetInt32(reader.GetOrdinal("Matematica"));
        //                    estudiante.Ciencias_naturales = reader.GetInt32(reader.GetOrdinal("Ciencias_naturales"));
        //                    estudiante.Ciencias_sociales = reader.GetInt32(reader.GetOrdinal("Ciencias_sociales"));
        //                    estudiante.Literal = reader.GetString(reader.GetOrdinal("Literal"));
        //                    estudiantes.Add(estudiante);
        //                }
        //            }
        //            command.Connection.Close();
        //        }
        //    }
        //    return Ok(estudiantes);
        //}
    }
}