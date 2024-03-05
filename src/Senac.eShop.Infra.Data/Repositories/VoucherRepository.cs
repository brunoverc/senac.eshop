using Senac.eShop.Domain.Entities;
using Senac.eShop.Domain.Interfaces;
using Senac.eShop.Infra.Data.Context;
using System.Linq.Expressions;

namespace Senac.eShop.Infra.Data.Repositories
{
    public class VoucherRepository : Repository<Voucher>, IVoucherRepository
    {
        public VoucherRepository(EShopDbContext context) : base(context)
        { }

        public Voucher Add(Voucher entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public Voucher GetById(Guid id)
        {
            var context = DbSet.AsQueryable();
            var Voucher = context.FirstOrDefault(c => c.Id == id);
            return Voucher;
        }

        public void Remove(Guid id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Voucher, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(predicate);
            DbSet.RemoveRange(entities);
        }

        public IEnumerable<Voucher> Search(Expression<Func<Voucher, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public IEnumerable<Voucher> Search(Expression<Func<Voucher, bool>> predicate,
            int pageNumber,
            int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            return result;
        }

        public Voucher Update(Voucher entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
