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
    }
}