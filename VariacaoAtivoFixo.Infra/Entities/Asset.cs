using System.ComponentModel.DataAnnotations.Schema;
using VariacaoAtivoFixo.Domain.Interfaces.Entities;
using VariacaoAtivoFixo.Infra.Entities.Base;

namespace VariacaoAtivoFixo.Infra.Entities
{
    public class Asset : BaseTable<int>, IAsset
    {
        [Column(TypeName = "varchar(20)")]
        public required string Paper { get; set; }
        [Column(TypeName = "Datetime")]
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal VariationFromPreviousDay { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal VariationOnTheFirstDate { get; set; }
    }
}
