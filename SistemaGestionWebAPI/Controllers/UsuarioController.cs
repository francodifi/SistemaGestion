using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;
using System.Collections.Generic;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult ObtenerUsuario(int id)
        {
            var usuario = UsuarioBussiness.ObtenerUsuario(id);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            var usuarios = UsuarioBussiness.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpPost]
        public IActionResult CrearUsuario([FromBody] Usuario usuario)
        {
            UsuarioBussiness.CrearUsuario(usuario);
            return CreatedAtAction(nameof(ObtenerUsuario), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult ModificarUsuario(int id, [FromBody] Usuario usuario)
        {
            var existingUsuario = UsuarioBussiness.ObtenerUsuario(id);
            if (existingUsuario == null)
                return NotFound();

            usuario.Id = id;
            UsuarioBussiness.ModificarUsuario(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            var existingUsuario = UsuarioBussiness.ObtenerUsuario(id);
            if (existingUsuario == null)
                return NotFound();

            UsuarioBussiness.EliminarUsuario(id);
            return NoContent();
        }
    }
}
