using AutoMapper;
using MediatR;
using Senac.eShop.Application.Interfaces;
using Senac.eShop.Application.ViewModel;
using Senac.eShop.Core.Enums;
using Senac.eShop.Domain.Entities;
using Senac.eShop.Domain.Interfaces;
using Senac.eShop.Domain.Shared.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senac.eShop.Application.Services
{
    public class OrderAppService : BaseService, IOrderAppService
    {
        protected readonly IOrderRepository _repository;
        protected readonly IOrderItemRepository _itemRepository;
        protected readonly IMapper _mapper;
        protected readonly IAddressRepository _addressRepository;

        public OrderAppService(IOrderRepository repository,
            IOrderItemRepository itemRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMediator bus,
            IAddressRepository addressRepository) : base(unitOfWork, bus)
        {
            _repository = repository;
            _itemRepository = itemRepository;
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public IEnumerable<OrderItemViewModel> DeleteItemInOrder(Guid orderItemId, Guid orderId)
        {
            _itemRepository.Remove(orderItemId);
            Commit();

            var order = _repository.GetById(orderId);
            var orderViewModel = _mapper.Map<IEnumerable<OrderItemViewModel>>(order.OrderItems);
            return orderViewModel;
        }

        public OrderViewModel SetAddressDelivery(Guid orderId, AddressViewModel addresViewModel)
        {
            //1. Salvar o endereço
            var address = _mapper.Map<Address>(addresViewModel);
            address = _addressRepository.Add(address);
            Commit();

            //2. Inserir esse endereço na entrega
            var order = _repository.GetById(orderId);
            order.SetAddress(address);
            order = _repository.Update(order);
            Commit();

            var orderViewModel = _mapper.Map<OrderViewModel>(order);
            return orderViewModel;
        }

        public OrderViewModel SetApplyVoucher(Guid orderId, string code)
        {
            throw new NotImplementedException();
        }

        public OrderViewModel SetCreateNewOrder(OrderViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderViewModel> SetInsertNewItem(OrderItemViewModel model, Guid orderId)
        {
            throw new NotImplementedException();
        }

        public void UpdateQuantityItemInOrder(int orderItemId, Guid newQuantity)
        {
            throw new NotImplementedException();
        }

        public OrderViewModel UpdateStatusOrder(Guid orderId, OrderStatus newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
