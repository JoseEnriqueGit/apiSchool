using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SchoolApi.Data;
using SchoolApi.Model;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstudianteController : ControllerBase
    {
        [HttpGet(Name = "GetEstudiante")]
        public ActionResult<IEnumerable<Estudiante>> Get()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            Conexion conexion = new Conexion();
            using (SqlConnection connection = new SqlConnection(conexion.cadenaConexion))
            {
                string sql = $"SELECT * FROM Estudiante";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Estudiante estudiante = new Estudiante();
                            estudiante.id = reader.GetInt32(reader.GetOrdinal("id"));
                            estudiante.nombre = reader.GetString(reader.GetOrdinal("nombre"));
                            estudiante.apellido = reader.GetString(reader.GetOrdinal("apellido"));
                            estudiante.Lengua_espanola = reader.GetInt32(reader.GetOrdinal("Lengua_espanola"));
                            estudiante.Matematica = reader.GetInt32(reader.GetOrdinal("Matematica"));
                            estudiante.Ciencias_naturales = reader.GetInt32(reader.GetOrdinal("Ciencias_naturales"));
                            estudiante.Ciencias_sociales = reader.GetInt32(reader.GetOrdinal("Ciencias_sociales"));
                            estudiante.Literal = reader.GetString(reader.GetOrdinal("Literal"));
                            estudiantes.Add(estudiante);
                        }
                    }
                    command.Connection.Close();
                }
            }
            return Ok(estudiantes);
        }

        [HttpGet("{id}", Name = "GetEstudianteById")]
        public ActionResult<Estudiante> Get(int id)
        {
            Estudiante estudiante = new Estudiante();
            Conexion conexion = new Conexion();
            using (SqlConnection connection = new SqlConnection(conexion.cadenaConexion))
            {
                string sql = $"SELECT * FROM Estudiante WHERE id = {id}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            estudiante.id = reader.GetInt32(reader.GetOrdinal("id"));
                            estudiante.nombre = reader.GetString(reader.GetOrdinal("nombre"));
                            estudiante.apellido = reader.GetString(reader.GetOrdinal("apellido"));
                            estudiante.Lengua_espanola = reader.GetInt32(reader.GetOrdinal("Lengua_espanola"));
                            estudiante.Matematica = reader.GetInt32(reader.GetOrdinal("Matematica"));
                            estudiante.Ciencias_naturales = reader.GetInt32(reader.GetOrdinal("Ciencias_naturales"));
                            estudiante.Ciencias_sociales = reader.GetInt32(reader.GetOrdinal("Ciencias_sociales"));
                            estudiante.Literal = reader.GetString(reader.GetOrdinal("Literal"));
                        }
                    }
                    command.Connection.Close();
                }
            }
            return Ok(estudiante);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Estudiante estudiante)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection connection = new SqlConnection(conexion.cadenaConexion))
            {
                string sql = $"INSERT INTO Estudiante (nombre, apellido, Lengua_espanola, Matematica, Ciencias_naturales, Ciencias_sociales, Literal) VALUES ('{estudiante.nombre}', '{estudiante.apellido}', {estudiante.Lengua_espanola}, {estudiante.Matematica}, {estudiante.Ciencias_naturales}, {estudiante.Ciencias_sociales}, '{estudiante.Literal}')";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Estudiante estudiante)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection connection = new SqlConnection(conexion.cadenaConexion))
            {
                string sql = $"UPDATE Estudiante SET nombre = '{estudiante.nombre}', apellido = '{estudiante.apellido}', Lengua_espanola = {estudiante.Lengua_espanola}, Matematica = {estudiante.Matematica}, Ciencias_naturales = {estudiante.Ciencias_naturales}, Ciencias_sociales = {estudiante.Ciencias_sociales}, Literal = '{estudiante.Literal}' WHERE id = {id}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection connection = new SqlConnection(conexion.cadenaConexion))
            {
                string sql = $"DELETE FROM Estudiante WHERE id = {id}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            return Ok();
        }
    }
}
