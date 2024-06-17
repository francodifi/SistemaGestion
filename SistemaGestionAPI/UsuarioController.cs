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
    public class UsuarioController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<Usuario> ObtenerUsuario(int id)
        {
            var usuario = UsuarioBussiness.ObtenerUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpGet]
        public ActionResult<List<Usuario>> ListarUsuarios()
        {
            var usuarios = UsuarioBussiness.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpPut]
        public IActionResult ModificarUsuario([FromBody] Usuario usuario)
        {
            UsuarioBussiness.ModificarUsuario(usuario);
            return NoContent();
        }
    }
}
