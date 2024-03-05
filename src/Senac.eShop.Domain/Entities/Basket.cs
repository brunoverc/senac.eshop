using Senac.eShop.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senac.eShop.Domain.Entities
{
    public class Basket : Entity
    {
        protected Basket() { }
        public Basket(Client client)
        {
            Client = client;
            ClientId = client.Id;
            //Inicilizando uma nova Lista
            Items = new List<BasketItem>();
        }

        public Guid ClientId { get; private set; }
        public Client Client { get; private set; }
        public List<BasketItem> Items { get; private set; }

        public void AddItem(BasketItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(BasketItem item)
        {
            Items.Remove(item);
        }

        public void ClearBasket()
        {
            Items = new List<BasketItem>();
        }

        public void SetUpdateAmountItem(BasketItem item, int newAmount)
        {
            Items.Where(i => i.Id == item.Id).First().SetAmount(newAmount);
        }
    }
}
