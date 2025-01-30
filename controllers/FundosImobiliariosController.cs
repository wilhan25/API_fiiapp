using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fiiApi.Data; // Ajuste o namespace para o correto no seu projeto
using fiiApi.Models; // Ajuste o namespace para os modelos

namespace fiiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FundosImobiliariosController : ControllerBase
    {
        private readonly FiiApiContext _context;

        public FundosImobiliariosController(FiiApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FundoImobiliario>>> GetFundosImobiliarios()
        {
            return await _context.FundosImobiliarios.ToListAsync();
        }
    }
}
