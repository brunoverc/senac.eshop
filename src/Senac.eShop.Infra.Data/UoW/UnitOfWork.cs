using Senac.eShop.Domain.Shared.Transaction;

namespace Senac.eShop.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context.EShopDbContext _context;

        public UnitOfWork(Context.EShopDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
