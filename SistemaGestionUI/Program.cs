
using System;
using SistemaGestionBussiness;
using SistemaGestionEntities;
using System.Collections.Generic;

namespace SistemaGestionUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de Gestión");
            Console.WriteLine("1. Listar Usuarios");
            Console.WriteLine("2. Crear Usuario");
            Console.WriteLine("3. Modificar Usuario");
            Console.WriteLine("4. Eliminar Usuario");
            Console.WriteLine("5. Listar Productos");
            Console.WriteLine("6. Crear Producto");
            Console.WriteLine("7. Modificar Producto");
            Console.WriteLine("8. Eliminar Producto");
            

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ListarUsuarios();
                    break;
                case "2":
                    CrearUsuario();
                    break;
                   
            }
        }

        static void ListarUsuarios()
        {
            var usuarios = UsuarioBussiness.ListarUsuarios();
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"ID: {usuario.Id}, Nombre: {usuario.Nombre}, Email: {usuario.Email}");
            }
        }

        static void CrearUsuario()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            Usuario nuevoUsuario = new Usuario { Nombre = nombre, Email = email };
            UsuarioBussiness.CrearUsuario(nuevoUsuario);
            Console.WriteLine("Usuario creado con éxito");
        }

       
    }
}
