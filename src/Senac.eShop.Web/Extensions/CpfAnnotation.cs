using Senac.eShop.Core.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace Senac.eShop.Web.Extensions
{
    public class CpfAnnotation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return Cpf.Valid(value.ToString()) ? ValidationResult.Success :
                new ValidationResult("CPF em formato inválido");
        }
    }
}
