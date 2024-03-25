using apiLoginUsuarios.Models;
using apiLoginUsuarios.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiLoginUsuarios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosService _usuariosService;
        public UsuariosController(UsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }
        [HttpGet]
        public async Task<List<Usuario>> Get() =>
            await _usuariosService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Usuario>> Get(string id)
        {
            var usuario = await _usuariosService.GetAsync(id);
            if (usuario == null) {
                return NotFound();
            }
            return usuario;
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<Usuario>> GetByEmail(string email)
        {
            var usuario = await _usuariosService.GetAsyncByEmail(email);
            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario newUsuario)
        {
            if(newUsuario.Senha != newUsuario.SenhaLembrete){
                return BadRequest("A senha inserida não corresponde ao lembrete de senha.");
            }
            await _usuariosService.CreateAsync(newUsuario);
            return CreatedAtAction(nameof(Get), new { id = newUsuario.Id }, newUsuario);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Usuario updatedUsuario)
        {
            if(updatedUsuario.Senha != updatedUsuario.SenhaLembrete){
                return BadRequest("A senha inserida não corresponde ao lembrete de senha.");
            }
            var usuario = await _usuariosService.GetAsync(id);
            if (usuario == null || usuario is null) {
                return NotFound();
            }
            updatedUsuario.Id = usuario.Id;
            await _usuariosService.UpdateAsync(id, updatedUsuario);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var usuario = await _usuariosService.GetAsync(id);
            if(usuario == null || usuario is null) {
                return NotFound();
            }
            await _usuariosService.RemoveAsync(id);
            return NoContent();
        }
    }
}
