using System.Collections.Generic;
using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBussiness
{
    public static class VentaBussiness
    {
        public static Venta ObtenerVenta(int id)
        {
            return VentaData.ObtenerVenta(id);
        }

        public static List<Venta> ListarVentas()
        {
            return VentaData.ListarVentas();
        }

        public static void CrearVenta(Venta venta)
        {
            VentaData.CrearVenta(venta);
        }

        public static void ModificarVenta(Venta venta)
        {
            VentaData.ModificarVenta(venta);
        }

        public static void EliminarVenta(int id)
        {
            VentaData.EliminarVenta(id);
        }

        public static void CargarVenta(List<Producto> productos, int idUsuario)
        {
           
            var venta = new Venta { IdUsuario = idUsuario };
            VentaData.CrearVenta(venta);

           
            int idVenta = venta.Id;

           
            foreach (var producto in productos)
            {
                var productoVendido = new ProductoVendido
                {
                    ProductoId = producto.Id,
                    VentaId = idVenta,
                    Cantidad = producto.Cantidad
                };
                ProductoVendidoData.CrearProductoVendido(productoVendido);

                producto.Stock -= producto.Cantidad;
                ProductoData.ModificarProducto(producto);
            }
        }
    }
}
