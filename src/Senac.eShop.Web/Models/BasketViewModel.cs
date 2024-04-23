using System.ComponentModel.DataAnnotations;

namespace Senac.eShop.Web.Models
{
    public class BasketViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo Cliente Id é obrigatório.")]
        public Guid ClientId { get; set; }
        public ClientViewModel? Client { get; set; }
        public List<BasketItemViewModel> Items { get; set; }
    }

    public class BasketItemViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo ProductId é obrigatório.")]
        public Guid ProductId { get; set; }
        public ProductViewModel? Product { get; set; }
        [Required(ErrorMessage = "O campo BasketId é obrigatório.")]
        public Guid BasketId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade precisa ser maior que 0.")]
        public int Amount { get; set; }
    }
}
