using System.Collections.Generic;

namespace fiiApi.Models
{
    public class InvestidorRequest
    {
        public required string Nome { get; set; }
        public List<int> Carteira { get; set; } = new();// Lista de IDs dos FIIs a serem associados
    }
}
