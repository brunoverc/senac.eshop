using Senac.eShop.Application.ViewModel;
using Senac.eShop.Domain.Entities;
using System.Linq.Expressions;

namespace Senac.eShop.Application.Interfaces
{
    public interface IVoucherAppService
    {
        VoucherViewModel GetById(Guid id);
        IEnumerable<VoucherViewModel> Search(Expression<Func<Voucher, bool>> expression);
        IEnumerable<VoucherViewModel> Search(Expression<Func<Voucher, bool>> expression,
            int pageNumber,
            int pageSize);
        VoucherViewModel Add(VoucherViewModel viewModel);
        VoucherViewModel Update(VoucherViewModel viewModel);
        void Remove(Guid id);
        void Remove(Expression<Func<Voucher, bool>> expression);
    }
}
