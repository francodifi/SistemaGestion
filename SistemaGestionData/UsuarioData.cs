using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionData
{
    public static class UsuarioData 
    {
        public static Usuario ObtenerUsuario(int id)
        {
            Usuario usuario = null;
            string query = "SELECT * FROM Usuarios WHERE Id = @Id";

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
                            usuario = new Usuario
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Email = reader.GetString(2)
                            };
                        }
                    }
                }
            }
            return usuario;
        }

        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string query = "SELECT * FROM Usuarios";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Email = reader.GetString(2)
                            };
                            usuarios.Add(usuario);
                        }
                    }
                }
            }
            return usuarios;
        }

        public static void CrearUsuario(Usuario usuario)
        {
            string query = "INSERT INTO Usuarios (Nombre, Email) VALUES (@Nombre, @Email)";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ModificarUsuario(Usuario usuario)
        {
            string query = "UPDATE Usuarios SET Nombre = @Nombre, Email = @Email WHERE Id = @Id";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Id", usuario.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarUsuario(int id)
        {
            string query = "DELETE FROM Usuarios WHERE Id = @Id";

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