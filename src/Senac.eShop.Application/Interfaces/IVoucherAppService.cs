using Senac.eShop.Application.ViewModel;
using Senac.eShop.Domain.Entities;
using System.Linq.Expressions;

namespace Senac.eShop.Application.Interfaces
{
    public interface IVoucherAppService
    {
        VoucherViewModel GetById(Guid id);
        IEnumerable<AddressViewModel> Search(Expression<Func<Address, bool>> expression);
        IEnumerable<AddressViewModel> Search(Expression<Func<Address, bool>> expression,
            int pageNumber,
            int pageSize);
        AddressViewModel Add(AddressViewModel viewModel);
        AddressViewModel Update(AddressViewModel viewModel);
        void Remove(Guid id);
        void Remove(Expression<Func<Address, bool>> expression);
    }
}
