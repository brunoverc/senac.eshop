using Senac.eShop.Application.ViewModel;
using Senac.eShop.Domain.Entities;
using System.Linq.Expressions;

namespace Senac.eShop.Application.Interfaces
{
    public interface IPaymentMethodAppService
    {
        PaymentMethodViewModel GetById(Guid id);
        IEnumerable<PaymentMethodViewModel> Search(Expression<Func<PaymentMethod, bool>> expression);
        IEnumerable<PaymentMethodViewModel> Search(Expression<Func<PaymentMethod, bool>> expression,
            int pageNumber,
            int pageSize);
        PaymentMethodViewModel Add(PaymentMethodViewModel viewModel);
        PaymentMethodViewModel Update(PaymentMethodViewModel viewModel);
        void Remove(Guid id);
        void Remove(Expression<Func<PaymentMethod, bool>> expression);
    }
}
