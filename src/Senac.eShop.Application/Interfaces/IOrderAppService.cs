﻿using Senac.eShop.Application.ViewModel;
using Senac.eShop.Core.Enums;

namespace Senac.eShop.Application.Interfaces
{
    public interface IOrderAppService
    {
        //Método usado para criar uma nova venda
        OrderViewModel SetCreateNewOrder(OrderViewModel viewModel);
        //Insere um item na venda e retorna todos os itens da venda
        IEnumerable<OrderItemViewModel> SetInsertNewItem(OrderItemViewModel model,
            Guid orderId);
        //Deleta um item da venda e retorna todos os itens
        IEnumerable<OrderItemViewModel> DeleteItemInOrder(Guid orderItemId, Guid orderId);
        //Altera a quantidade de um item em uma venda
        void UpdateQuantityItemInOrder(Guid orderItemId, int newQuantity);
        //Altera o status da venda
        OrderViewModel UpdateStatusOrder(Guid orderId, OrderStatus newStatus);
        //Insere o endereço da entrega
        OrderViewModel SetAddressDelivery(Guid orderId, AddressViewModel addresViewModel);
        //Aplica um voucher e recalcula o valor da venda
        OrderViewModel SetApplyVoucher(Guid orderId, string code);

        //TODO: Novo
        OrderViewModel GetById(Guid orderId);

        //TODO: Novo
        OrderViewModel GetLastOrderByClient(Guid clientId);

        //TODO: Novo
        IEnumerable<OrderViewModel> GetOrdersByClient(Guid clientId);
    }
}
