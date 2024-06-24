using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = UsuarioBussiness.ObtenerUsuario(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            return Ok(UsuarioBussiness.ListarUsuarios());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            UsuarioBussiness.CrearUsuario(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            var existingUsuario = UsuarioBussiness.ObtenerUsuario(id);
            if (existingUsuario == null) return NotFound();

            usuario.Id = id;
            UsuarioBussiness.ModificarUsuario(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = UsuarioBussiness.ObtenerUsuario(id);
            if (usuario == null) return NotFound();

            UsuarioBussiness.EliminarUsuario(id);
            return NoContent();
        }
    }
}
