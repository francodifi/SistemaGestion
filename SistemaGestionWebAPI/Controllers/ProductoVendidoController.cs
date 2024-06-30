using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;
using System.Collections.Generic;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult ObtenerProductoVendido(int id)
        {
            var productoVendido = ProductoVendidoBussiness.ObtenerProductoVendido(id);
            if (productoVendido == null)
                return NotFound();
            return Ok(productoVendido);
        }

        [HttpGet]
        public IActionResult ListarProductosVendidos()
        {
            var productosVendidos = ProductoVendidoBussiness.ListarProductosVendidos();
            return Ok(productosVendidos);
        }

        [HttpPost]
        public IActionResult CrearProductoVendido([FromBody] ProductoVendido productoVendido)
        {
            ProductoVendidoBussiness.CrearProductoVendido(productoVendido);
            return CreatedAtAction(nameof(ObtenerProductoVendido), new { id = productoVendido.Id }, productoVendido);
        }

        [HttpPut("{id}")]
        public IActionResult ModificarProductoVendido(int id, [FromBody] ProductoVendido productoVendido)
        {
            var existingProductoVendido = ProductoVendidoBussiness.ObtenerProductoVendido(id);
            if (existingProductoVendido == null)
                return NotFound();

            productoVendido.Id = id;
            ProductoVendidoBussiness.ModificarProductoVendido(productoVendido);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarProductoVendido(int id)
        {
            var existingProductoVendido = ProductoVendidoBussiness.ObtenerProductoVendido(id);
            if (existingProductoVendido == null)
                return NotFound();

            ProductoVendidoBussiness.EliminarProductoVendido(id);
            return NoContent();
        }
    }
}

