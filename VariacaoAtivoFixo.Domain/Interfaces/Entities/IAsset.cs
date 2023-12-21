using System.Collections.Generic;

namespace VariacaoAtivoFixo.Domain.Interfaces.Entities
{
    public interface IAsset
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public decimal VariationFromPreviousDay { get; set; }
        public decimal VariationOnTheFirstDate { get; set; }
        public string Paper { get; set; }
    }
}
