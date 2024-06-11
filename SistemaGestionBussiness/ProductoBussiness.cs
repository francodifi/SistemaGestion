using System.Collections.Generic;
using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBussiness
{
    public static class ProductoBussiness
    {
        public static Producto ObtenerProducto(int id)
        {
            return ProductoData.ObtenerProducto(id);
        }

        public static List<Producto> ListarProductos()
        {
            return ProductoData.ListarProductos();
        }

        public static void CrearProducto(Producto producto)
        {
            ProductoData.CrearProducto(producto);
        }

        public static void ModificarProducto(Producto producto)
        {
            ProductoData.ModificarProducto(producto);
        }

        public static void EliminarProducto(int id)
        {
            ProductoData.EliminarProducto(id);
        }
    }
}