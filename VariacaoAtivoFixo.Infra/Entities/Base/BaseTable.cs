using System.ComponentModel.DataAnnotations;

namespace VariacaoAtivoFixo.Infra.Entities.Base
{
    public class BaseTable<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
