using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;
using System.Collections.Generic;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult ObtenerProducto(int id)
        {
            var producto = ProductoBussiness.ObtenerProducto(id);
            if (producto == null)
                return NotFound();
            return Ok(producto);
        }

        [HttpGet]
        public IActionResult ListarProductos()
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

        [HttpPut("{id}")]
        public IActionResult ModificarProducto(int id, [FromBody] Producto producto)
        {
            var existingProducto = ProductoBussiness.ObtenerProducto(id);
            if (existingProducto == null)
                return NotFound();

            producto.Id = id;
            ProductoBussiness.ModificarProducto(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarProducto(int id)
        {
            var existingProducto = ProductoBussiness.ObtenerProducto(id);
            if (existingProducto == null)
                return NotFound();

            ProductoBussiness.EliminarProducto(id);
            return NoContent();
        }
    }
}
