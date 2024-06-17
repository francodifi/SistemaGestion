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
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<ProductoVendido> ObtenerProductoVendido(int id)
        {
            var productoVendido = ProductoVendidoBussiness.ObtenerProductoVendido(id);
            if (productoVendido == null)
            {
                return NotFound();
            }
            return Ok(productoVendido);
        }

        [HttpGet]
        public ActionResult<List<ProductoVendido>> ListarProductosVendidos()
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
    }
}
