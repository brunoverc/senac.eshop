using Senac.eShop.Application.ViewModel;

namespace Senac.eShop.Application.Interfaces
{
    public interface IBasketAppService
    {
        //Adiciona uma nova cesta
        BasketViewModel AddBasket(BasketViewModel viewModel);
        //Retorna uma cesta por Id
        BasketViewModel GetById(Guid id);
        //Adiciona um item na cesta e retorna todos os itens
        IEnumerable<BasketItemViewModel> AddItemBasket(BasketItemViewModel viewModel);
        //Remove um item da cesta e retorna todos os itens
        IEnumerable<BasketItemViewModel> RemoveItemBasket(Guid idBasketItem);
        //Altera a quantidade de itens na cesta
        //TODO: Alterar aqui
        void UpdateItemQuantity(BasketItemViewModel item, int quantity);
        //Limpa a cesta
        void ClearBasket(Guid basketId);

        //TODO: Novo
        IEnumerable<BasketItemViewModel> RemoveItemBasket(Guid basketId, Guid productId);

    }
}
