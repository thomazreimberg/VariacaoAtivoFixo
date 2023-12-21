using VariacaoAtivoFixo.Domain.Interfaces.Entities;
using VariacaoAtivoFixo.Infra.Entities.Base;

namespace VariacaoAtivoFixo.Infra.Entities
{
    public class Asset : BaseTable<int>, IAsset
    {
        public required string Paper { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public decimal VariationFromPreviousDay { get; set; }
        public decimal VariationOnTheFirstDate { get; set; }
    }
}
