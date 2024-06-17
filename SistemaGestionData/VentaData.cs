using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SistemaGestionEntities;

namespace SistemaGestionData
{
    public static class VentaData
    {
        public static Venta ObtenerVenta(int id)
        {
            Venta venta = null;
            string query = "SELECT * FROM Ventas WHERE Id = @Id";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            venta = new Venta
                            {
                                Id = reader.GetInt32(0),
                                IdUsuario = reader.GetInt32(1)
                            };
                        }
                    }
                }
            }
            return venta;
        }

        public static List<Venta> ListarVentas()
        {
            List<Venta> ventas = new List<Venta>();
            string query = "SELECT * FROM Ventas";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Venta venta = new Venta
                            {
                                Id = reader.GetInt32(0),
                                IdUsuario = reader.GetInt32(1)
                            };
                            ventas.Add(venta);
                        }
                    }
                }
            }
            return ventas;
        }

        public static void CrearVenta(Venta venta)
        {
            string query = "INSERT INTO Ventas (IdUsuario) VALUES (@IdUsuario); SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                    venta.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static void ModificarVenta(Venta venta)
        {
            string query = "UPDATE Ventas SET IdUsuario = @IdUsuario WHERE Id = @Id";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                    cmd.Parameters.AddWithValue("@Id", venta.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarVenta(int id)
        {
            string query = "DELETE FROM Ventas WHERE Id = @Id";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
