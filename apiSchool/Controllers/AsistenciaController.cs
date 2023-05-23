using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SchoolApi.Data;
using SchoolApi.Model;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsistenciaController : ControllerBase
    {
        [HttpGet(Name = "GetAsistencia")]
        public ActionResult<IEnumerable<Asistencia>> Get()
        {
            List<Asistencia> asistencias = new List<Asistencia>();
            Conexion conexion = new Conexion();
            using (SqlConnection connection = new SqlConnection(conexion.cadenaConexion))
            {
                string sql = $"SELECT * FROM Asistencia";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Asistencia asistencia = new Asistencia();
                            asistencia.id = reader.GetInt32(reader.GetOrdinal("id"));
                            asistencia.id_estudiante = reader.GetInt32(reader.GetOrdinal("id_estudiante"));
                            asistencia.fecha = reader.GetDateTime(reader.GetOrdinal("fecha"));
                            asistencia.presente = reader.GetBoolean(reader.GetOrdinal("presente"));
                            asistencias.Add(asistencia);

                        }
                    }
                    command.Connection.Close();
                }
            }
            return Ok(asistencias);
        }

        [HttpGet("{id}", Name = "GetAsistenciaById")]
        public ActionResult<Asistencia> Get(int id)
        {
            Asistencia asistencia = new Asistencia();
            Conexion conexion = new Conexion();
            using (SqlConnection connection = new SqlConnection(conexion.cadenaConexion))
            {
                string sql = $"SELECT * FROM Asistencia WHERE id = {id}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            asistencia.id = reader.GetInt32(reader.GetOrdinal("id"));
                            asistencia.id_estudiante = reader.GetInt32(reader.GetOrdinal("id_estudiante"));
                            asistencia.fecha = reader.GetDateTime(reader.GetOrdinal("fecha"));
                            asistencia.presente = reader.GetBoolean(reader.GetOrdinal("presente"));
                        }
                    }
                    command.Connection.Close();
                }
            }
            return Ok(asistencia);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Asistencia asistencia)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection connection = new SqlConnection(conexion.cadenaConexion))
            {
                string sql = $"INSERT INTO Asistencia (id_estudiante, fecha, presente) VALUES ('{asistencia.id_estudiante}', '{asistencia.fecha}', '{asistencia.presente}')";
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
        public ActionResult Put(int id, [FromBody] Asistencia asistencia)
        {
            Conexion conexion = new Conexion();
            using (SqlConnection connection = new SqlConnection(conexion.cadenaConexion))
            {
                string sql = $"UPDATE Asistencia SET id_estudiante = '{asistencia.id_estudiante}', fecha = '{asistencia.fecha}', presente = '{asistencia.presente}' WHERE id = {id}";
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
                string sql = $"DELETE FROM Asistencia WHERE id = {id}";
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
