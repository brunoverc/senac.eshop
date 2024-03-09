using Senac.eShop.Application.ViewModel;
using Senac.eShop.Domain.Entities;
using System.Linq.Expressions;

namespace Senac.eShop.Application.Interfaces
{
    public interface IClientAppService
    {
        ClientViewModel GetById(Guid id);
        IEnumerable<ClientViewModel> Search(Expression<Func<Client, bool>> expression);
        IEnumerable<ClientViewModel> Search(Expression<Func<Client, bool>> expression,
            int pageNumber,
            int pageSize);
        ClientViewModel Add(ClientViewModel viewModel);
        ClientViewModel Update(ClientViewModel viewModel);
        void Remove(Guid id);
        void Remove(Expression<Func<Client, bool>> expression);
    }
}
