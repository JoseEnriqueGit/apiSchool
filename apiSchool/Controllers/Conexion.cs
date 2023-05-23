namespace SchoolApi.Data
{
    public class Conexion
    {
        public string cadenaConexion { get; set; }
        //public Conexion()
        //{
        //    //cadenaConexion = "Server=tcp:schoolapp-server.database.windows.net,1433;Initial Catalog=schoolapp-server;Persist Security Info=False;User ID=school-server;Password={8wvZrm*n3EsGPt;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //    cadenaConexion = "Server=tcp:schoolapp-server.database.windows.net,1433;Initial Catalog=schoolapp-server;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\";";
        //}

        public Conexion()
        {
            cadenaConexion = "Server=tcp:schoolapp-server.database.windows.net,1433;Initial Catalog=schoolapp-server;Persist Security Info=False;User ID=school-server;Password={8wvZrm*n3EsGPt;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
    }
}
