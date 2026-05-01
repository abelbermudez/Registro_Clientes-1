using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Clientes.Datos
{
    public class Conexion
    {
        private static readonly string ConnectionString =
           "Data Source=LAPTOP-PF0SV0IO\\SQLEXPRESS;Initial Catalog= ClientesDB;Integrated Security=True;";

        // Objeto compartido (si lo usa en varios lugares). Alternativamente use GetOpenConnection().
        public static SqlConnection cn = new SqlConnection(ConnectionString);

        public static SqlConnection GetOpenConnection()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
