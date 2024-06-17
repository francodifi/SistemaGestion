using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<Producto> ObtenerProducto(int id)
        {
            var producto = ProductoBussiness.ObtenerProducto(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpGet]
        public ActionResult<List<Producto>> ListarProductos()
        {
            var productos = ProductoBussiness.ListarProductos();
            return Ok(productos);
        }

        [HttpPost]
        public IActionResult CrearProducto([FromBody] Producto producto)
        {
            ProductoBussiness.CrearProducto(producto);
            return CreatedAtAction(nameof(ObtenerProducto), new { id = producto.Id }, producto);
        }

        [HttpPut]
        public IActionResult ModificarProducto([FromBody] Producto producto)
        {
            ProductoBussiness.ModificarProducto(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarProducto(int id)
        {
            ProductoBussiness.EliminarProducto(id);
            return NoContent();
        }
    }
}
