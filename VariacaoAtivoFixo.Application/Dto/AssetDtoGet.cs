namespace VariacaoAtivoFixo.Application.Dto
{
    public class AssetDtoGet
    {
        public string Papel { get; set; } = "";
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public decimal VariacaoDiaAnterior { get; set; }
        public decimal VariacaoPrimeiraData { get; set; }
    }
}
