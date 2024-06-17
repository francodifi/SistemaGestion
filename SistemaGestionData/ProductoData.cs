using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SistemaGestionEntities;
public static class ProductoData
{
    public static Producto ObtenerProducto(int id)
    {
        Producto producto = null;
        string query = "SELECT * FROM Productos WHERE Id = @Id";

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
                        producto = new Producto
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Precio = reader.GetDecimal(2)
                            
                        };
                    }
                }
            }
        }
        return producto;
    }

    public static List<Producto> ListarProductos()
    {
        List<Producto> productos = new List<Producto>();
        string query = "SELECT * FROM Productos";

        using (SqlConnection conn = DatabaseConnection.GetConnection())
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Precio = reader.GetDecimal(2)
                           
                        };
                        productos.Add(producto);
                    }
                }
            }
        }
        return productos;
    }

    public static void CrearProducto(Producto producto)
    {
        string query = "INSERT INTO Productos (Nombre, Precio) VALUES (@Nombre, @Precio)";

        using (SqlConnection conn = DatabaseConnection.GetConnection())
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
               

                cmd.ExecuteNonQuery();
            }
        }
    }

    public static void ModificarProducto(Producto producto)
    {
        string query = "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio WHERE Id = @Id";

        using (SqlConnection conn = DatabaseConnection.GetConnection())
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                cmd.Parameters.AddWithValue("@Id", producto.Id);
               

                cmd.ExecuteNonQuery();
            }
        }
    }

    public static void EliminarProducto(int id)
    {
        string query = "DELETE FROM Productos WHERE Id = @Id";

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
