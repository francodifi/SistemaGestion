using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            var producto = ProductoBussiness.ObtenerProducto(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            return Ok(ProductoBussiness.ListarProductos());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Producto producto)
        {
            ProductoBussiness.CrearProducto(producto);
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Producto producto)
        {
            var existingProducto = ProductoBussiness.ObtenerProducto(id);
            if (existingProducto == null) return NotFound();

            producto.Id = id;
            ProductoBussiness.ModificarProducto(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var producto = ProductoBussiness.ObtenerProducto(id);
            if (producto == null) return NotFound();

            ProductoBussiness.EliminarProducto(id);
            return NoContent();
        }
    }
}
