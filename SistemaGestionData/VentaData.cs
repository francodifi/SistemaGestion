using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using SistemaGestionData;
using SistemaGestionEntities;

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
                            Fecha = reader.GetDateTime(1),
                            Total = reader.GetDecimal(2)
                           
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
                            Fecha = reader.GetDateTime(1),
                            Total = reader.GetDecimal(2)
                           
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
        string query = "INSERT INTO Ventas (Fecha, Total) VALUES (@Fecha, @Total)";

        using (SqlConnection conn = DatabaseConnection.GetConnection())
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
                cmd.Parameters.AddWithValue("@Total", venta.Total);
               

                cmd.ExecuteNonQuery();
            }
        }
    }

    public static void ModificarVenta(Venta venta)
    {
        string query = "UPDATE Ventas SET Fecha = @Fecha, Total = @Total WHERE Id = @Id";

        using (SqlConnection conn = DatabaseConnection.GetConnection())
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
                cmd.Parameters.AddWithValue("@Total", venta.Total);
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
