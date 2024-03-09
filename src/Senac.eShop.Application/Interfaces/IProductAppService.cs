using Senac.eShop.Application.ViewModel;
using Senac.eShop.Domain.Entities;
using System.Linq.Expressions;

namespace Senac.eShop.Application.Interfaces
{
    public interface IProductAppService
    {
        ProductViewModel GetById(Guid id);
        IEnumerable<ProductViewModel> Search(Expression<Func<Product, bool>> expression);
        IEnumerable<ProductViewModel> Search(Expression<Func<Product, bool>> expression,
            int pageNumber,
            int pageSize);
        ProductViewModel Add(ProductViewModel viewModel);
        ProductViewModel Update(ProductViewModel viewModel);
        void Remove(Guid id);
        void Remove(Expression<Func<Product, bool>> expression);
        /// <summary>
        /// Dado um valor passado ele aumenta o reduz o estoque
        /// </summary>
        /// <param name="productId">Id do produto</param>
        /// <param name="quantity">Quantidade</param>
        void UpdateStock(Guid productId, int quantity);
        /// <summary>
        /// Checar a quantiade de itens no estoque
        /// </summary>
        /// <param name="productId">Id do produto</param>
        /// <returns>A quantidade de itens de estoque</returns>
        int CheckQuantityStock(Guid productId);
    }
}
