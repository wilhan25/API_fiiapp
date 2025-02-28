using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fiiApi.Data;
using fiiApi.Models;

namespace fiiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestidorController : ControllerBase
    {
        private readonly FiiApiContext _context;

        public InvestidorController(FiiApiContext context)
        {
            _context = context;
        }

        // GET: api/Investidor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investidor>>> GetInvestidores()
        {
            return await _context.Investidores
                .Include(i => i.Carteira) // Inclui os fundos associados à carteira
                .ToListAsync();
        }

        // GET: api/Investidor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Investidor>> GetInvestidor(int id)
        {
            var investidor = await _context.Investidores
                .Include(i => i.Carteira)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (investidor == null)
            {
                return NotFound("Investidor não encontrado.");
            }

            return investidor;
        }

        // POST: api/Investidor
        [HttpPost]
public async Task<IActionResult> PostInvestidor(InvestidorRequest request)
{
    if (request.Carteira == null || !request.Carteira.Any())
    {
        return BadRequest("A carteira não pode ser vazia.");
    }

    var investidor = new Investidor
    {
        Nome = request.Nome,
        Carteira = new List<FundoImobiliario>()
    };

    // Para cada ID na carteira, buscamos individualmente o fundo
    foreach (var id in request.Carteira)
    {
        var fundo = await _context.FundosImobiliarios.FindAsync(id);
        if (fundo == null)
        {
            return BadRequest($"FII com id {id} não existe.");
        }
        investidor.Carteira.Add(fundo);
    }

    _context.Investidores.Add(investidor);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetInvestidor), new { id = investidor.Id }, investidor);
}

    }
}
