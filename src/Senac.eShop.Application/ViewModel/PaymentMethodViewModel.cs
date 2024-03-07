using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senac.eShop.Application.ViewModel
{
    public class PaymentMethodViewModel
    {
        [Required(ErrorMessage = "O campo Alias é obrigatório.")]
        public string Alias { get; private set; }
        [Required(ErrorMessage = "O campo CardId é obrigatório.")]
        public string CardId { get; private set; }
        [Required(ErrorMessage = "O campo Last4 é obrigatório.")]
        [MaxLength(4, ErrorMessage = "O campo Last4 deve conter 4 caracteres")]
        public string Last4 { get; private set; }
        [Required(ErrorMessage = "O campo ClientId é obrigatório.")]
        public Guid ClientId { get; private set; }
        public ClientViewModel Client { get; private set; }
    }
}
