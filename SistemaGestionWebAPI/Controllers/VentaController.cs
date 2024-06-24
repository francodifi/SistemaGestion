using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<Venta> Get(int id)
        {
            var venta = VentaBussiness.ObtenerVenta(id);
            if (venta == null) return NotFound();
            return Ok(venta);
        }

        [HttpGet]
        public ActionResult<List<Venta>> Get()
        {
            return Ok(VentaBussiness.ListarVentas());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Venta venta)
        {
            VentaBussiness.CrearVenta(venta);
            return CreatedAtAction(nameof(Get), new { id = venta.Id }, venta);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Venta venta)
        {
            var existingVenta = VentaBussiness.ObtenerVenta(id);
            if (existingVenta == null) return NotFound();

            venta.Id = id;
            VentaBussiness.ModificarVenta(venta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var venta = VentaBussiness.ObtenerVenta(id);
            if (venta == null) return NotFound();

            VentaBussiness.EliminarVenta(id);
            return NoContent();
        }
    }
}
