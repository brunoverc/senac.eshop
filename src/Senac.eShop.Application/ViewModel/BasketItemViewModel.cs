using System.ComponentModel.DataAnnotations;

namespace Senac.eShop.Application.ViewModel
{
    public class BasketItemViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo ProductId é obrigatório.")]
        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        [Required(ErrorMessage = "O campo BasketId é obrigatório.")]
        public Guid BasketId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade precisa ser maior que 0.")]
        public int Amount { get; set; }
        public BasketViewModel Basket { get; set; }
    }
}
