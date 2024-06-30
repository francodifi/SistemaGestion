using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;
using System.Collections.Generic;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult ObtenerVenta(int id)
        {
            var venta = VentaBussiness.ObtenerVenta(id);
            if (venta == null)
                return NotFound();
            return Ok(venta);
        }

        [HttpGet]
        public IActionResult ListarVentas()
        {
            var ventas = VentaBussiness.ListarVentas();
            return Ok(ventas);
        }

        [HttpPost]
        public IActionResult CrearVenta([FromBody] Venta venta)
        {
            VentaBussiness.CrearVenta(venta);
            return CreatedAtAction(nameof(ObtenerVenta), new { id = venta.Id }, venta);
        }

        [HttpPut("{id}")]
        public IActionResult ModificarVenta(int id, [FromBody] Venta venta)
        {
            var existingVenta = VentaBussiness.ObtenerVenta(id);
            if (existingVenta == null)
                return NotFound();

            venta.Id = id;
            VentaBussiness.ModificarVenta(venta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarVenta(int id)
        {
            var existingVenta = VentaBussiness.ObtenerVenta(id);
            if (existingVenta == null)
                return NotFound();

            VentaBussiness.EliminarVenta(id);
            return NoContent();
        }
    }
}
