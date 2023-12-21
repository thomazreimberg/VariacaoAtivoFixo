namespace VariacaoAtivoFixo.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        public T CreateFactory();
    }
}
