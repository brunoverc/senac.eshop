﻿using System.ComponentModel.DataAnnotations;

namespace Senac.eShop.Application.ViewModel
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "O campo Ativo é obrigatório.")]
        public bool Active { get; set; }
        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        public decimal Price { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "O campo Quantidade em estoque é obrigatório.")]
        public int StockQuantity { get; set; }
    }
}
