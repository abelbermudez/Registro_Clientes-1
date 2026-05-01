using Registro_Clientes.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Clientes.Repository
{
    public class ClienteRepository
    {
        public void Guardar(Cliente cliente)
        {
            using (SqlConnection conn = Conexion.GetOpenConnection())
            {
                string query = "INSERT INTO Clientes (Nombre, Telefono, Correo) VALUES (@Nombre, @Telefono, @Correo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Correo", cliente.Correo);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SqlConnection conn = Conexion.GetOpenConnection())
            {
                string query = "SELECT * FROM Clientes";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clientes.Add(new Cliente
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Correo = reader["Correo"].ToString()
                    });
                }
            }
            return clientes;
        }

        public void Eliminar(int id)
        {
            using (SqlConnection conn = Conexion.GetOpenConnection())
            {
                string query = "DELETE FROM Clientes WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Cliente> Buscar(string termino)
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SqlConnection conn = Conexion.GetOpenConnection())
            {
                string query = "SELECT * FROM Clientes WHERE Nombre LIKE @Termino OR Correo LIKE @Termino";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Termino", "%" + termino + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clientes.Add(new Cliente
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Correo = reader["Correo"].ToString()
                    });
                }
            }
            return clientes;
        }
    }
}
