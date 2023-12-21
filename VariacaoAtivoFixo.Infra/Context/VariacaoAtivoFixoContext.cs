using Microsoft.EntityFrameworkCore;
using VariacaoAtivoFixo.Infra.Entities;

namespace VariacaoAtivoFixo.Infra.Context
{
    public class VariacaoAtivoFixoContext : DbContext
    {
        public VariacaoAtivoFixoContext(DbContextOptions<VariacaoAtivoFixoContext> options) : base(options)
        { }

        #region Tables
        public DbSet<Asset> Asset { get; set; }
        #endregion
    }
}
