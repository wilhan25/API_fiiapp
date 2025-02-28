using System.Collections.Generic;

namespace fiiApi.Models
{
    public class Investidor
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        // A carteira é uma lista dos fundos favoritos do investidor
        public List<FundoImobiliario> Carteira { get; set; } = new();
    }
}
