using AutoMapper;
using Senac.eShop.Application.ViewModel;
using Senac.eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senac.eShop.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() {

            CreateMap<Address, AddressViewModel>()
                .ReverseMap();
            CreateMap<Basket, BasketViewModel>()
                .ReverseMap();
            CreateMap<BasketItem, BasketItemViewModel>()
                .ReverseMap();
            CreateMap<Client, ClientViewModel>()
                .ReverseMap();
            CreateMap<Order, OrderViewModel>()
                .ReverseMap();
            CreateMap<OrderItem, OrderItemViewModel>()
                .ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodViewModel>()
                .ReverseMap();
            CreateMap<Product, ProductViewModel>()
                .ReverseMap();
            CreateMap<Voucher, VoucherViewModel>()
                .ReverseMap();

        }
    }
}
