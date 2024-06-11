using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using SistemaGestionData;
using SistemaGestionEntities;

public static class ProductoVendidoData
{
    public static ProductoVendido ObtenerProductoVendido(int id)
    {
        ProductoVendido productoVendido = null;
        string query = "SELECT * FROM ProductosVendidos WHERE Id = @Id";

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
                        productoVendido = new ProductoVendido
                        {
                            Id = reader.GetInt32(0),
                            ProductoId = reader.GetInt32(1),
                            VentaId = reader.GetInt32(2),
                            Cantidad = reader.GetInt32(3)

                        };
                    }
                }
            }
        }
        return productoVendido;
    }

    public static List<ProductoVendido> ListarProductosVendidos()
    {
        List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
        string query = "SELECT * FROM ProductosVendidos";

        using (SqlConnection conn = DatabaseConnection.GetConnection())
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductoVendido productoVendido = new ProductoVendido
                        {
                            Id = reader.GetInt32(0),
                            ProductoId = reader.GetInt32(1),
                            VentaId = reader.GetInt32(2),
                            Cantidad = reader.GetInt32(3)
                            
                        };
                        productosVendidos.Add(productoVendido);
                    }
                }
            }
        }
        return productosVendidos;
    }

    public static void CrearProductoVendido(ProductoVendido productoVendido)
    {
        string query = "INSERT INTO ProductosVendidos (ProductoId, VentaId, Cantidad) VALUES (@ProductoId, @VentaId, @Cantidad)";

        using (SqlConnection conn = DatabaseConnection.GetConnection())
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ProductoId", productoVendido.ProductoId);
                cmd.Parameters.AddWithValue("@VentaId", productoVendido.VentaId);
                cmd.Parameters.AddWithValue("@Cantidad", productoVendido.Cantidad);
                

                cmd.ExecuteNonQuery();
            }
        }
    }

    public static void ModificarProductoVendido(ProductoVendido productoVendido)
    {
        string query = "UPDATE ProductosVendidos SET ProductoId = @ProductoId, VentaId = @VentaId, Cantidad = @Cantidad WHERE Id = @Id";

        using (SqlConnection conn = DatabaseConnection.GetConnection())
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ProductoId", productoVendido.ProductoId);
                cmd.Parameters.AddWithValue("@VentaId", productoVendido.VentaId);
                cmd.Parameters.AddWithValue("@Cantidad", productoVendido.Cantidad);
                cmd.Parameters.AddWithValue("@Id", productoVendido.Id);
                

                cmd.ExecuteNonQuery();
            }
        }
    }

    public static void EliminarProductoVendido(int id)
    {
        string query = "DELETE FROM ProductosVendidos WHERE Id = @Id";

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
