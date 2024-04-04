using Microsoft.EntityFrameworkCore;
using Senac.eShop.Domain.Entities;
using Senac.eShop.Domain.Interfaces;
using Senac.eShop.Infra.Data.Context;
using System.Linq.Expressions;

namespace Senac.eShop.Infra.Data.Repositories
{
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        protected readonly IClientRepository _clientRepository;
        public BasketRepository(EShopDbContext context, IClientRepository clientRepository) : base(context)
        {
            _clientRepository = clientRepository;
        }

        public Basket Add(Basket entity)
        {
            DbSet.Add(entity);

            if (entity.Client == null)
            {
                entity.SetClient(_clientRepository.GetById(entity.ClientId));
            }

            return entity;
        }

        public Basket GetById(Guid id)
        {
            var context = DbSet.AsQueryable();
            var basket = context.FirstOrDefault(c => c.Id == id);
            if(basket.Client == null)
            {
                basket.SetClient(_clientRepository.GetById(basket.ClientId));
            }
            return basket;
        }

        public void Remove(Guid id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Basket, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(predicate);
            DbSet.RemoveRange(entities);
        }

        public IEnumerable<Basket> Search(Expression<Func<Basket, bool>> predicate)
        {
            var context = DbSet.AsQueryable().Include("Client");
            return context.Where(predicate).ToList();
        }

        public IEnumerable<Basket> Search(Expression<Func<Basket, bool>> predicate,
            int pageNumber,
            int pageSize)
        {
            var context = DbSet.AsQueryable().Include("Client");
            var result = context.Where(predicate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            return result;
        }

        public Basket Update(Basket entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
