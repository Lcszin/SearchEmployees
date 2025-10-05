using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using SearchEmployees.WebAPI.Entities;
using System.Globalization;
using SearchEmployees.Repositories;

namespace SearchEmployees.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpGet("exportar-csv")]
        public async Task<IActionResult> ExportarCsv()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();

            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(usuarios);
                writer.Flush();
                memoryStream.Position = 0;

                return File(memoryStream.ToArray(), "text/csv", "usuarios.csv");
            }
        }
    }
}

