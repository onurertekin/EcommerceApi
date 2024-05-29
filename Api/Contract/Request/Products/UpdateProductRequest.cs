using Contract.Request.Customers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.Products
{
    public class UpdateProductRequest
    {
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }

    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(products => products.name).NotEmpty().WithMessage("Ürün adı boş olamaz.");

            RuleFor(products => products.price).NotEmpty().WithMessage("Ürün fiyatı boş olamaz.");

            RuleFor(products => products.quantity).NotEmpty().WithMessage("Ürün miktarı boş olamaz.");

        }
    }
}
