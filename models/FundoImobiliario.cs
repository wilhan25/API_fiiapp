// Models/FundoImobiliario.cs
namespace fiiApi.Models
{
    public class FundoImobiliario
    {
        public int Id { get; set; }
        public required string Sigla { get; set; }
        public decimal DY { get; set; }
        public decimal PV { get; set; }
        public int LiquidezDiaria { get; set; }
        public decimal PatrimonioLiquido { get; set; }
        public decimal Variacao12Meses { get; set; }
    }
}
