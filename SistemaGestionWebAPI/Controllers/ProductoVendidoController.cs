using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<ProductoVendido> Get(int id)
        {
            var productoVendido = ProductoVendidoBussiness.ObtenerProductoVendido(id);
            if (productoVendido == null) return NotFound();
            return Ok(productoVendido);
        }

        [HttpGet]
        public ActionResult<List<ProductoVendido>> Get()
        {
            return Ok(ProductoVendidoBussiness.ListarProductosVendidos());
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductoVendido productoVendido)
        {
            ProductoVendidoBussiness.CrearProductoVendido(productoVendido);
            return CreatedAtAction(nameof(Get), new { id = productoVendido.Id }, productoVendido);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductoVendido productoVendido)
        {
            var existingProductoVendido = ProductoVendidoBussiness.ObtenerProductoVendido(id);
            if (existingProductoVendido == null) return NotFound();

            productoVendido.Id = id;
            ProductoVendidoBussiness.ModificarProductoVendido(productoVendido);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productoVendido = ProductoVendidoBussiness.ObtenerProductoVendido(id);
            if (productoVendido == null) return NotFound();

            ProductoVendidoBussiness.EliminarProductoVendido(id);
            return NoContent();
        }
    }
}

