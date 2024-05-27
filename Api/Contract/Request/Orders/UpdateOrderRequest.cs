using Contract.Request.Customers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.Orders
{
    public class UpdateOrderRequest
    {
        public int customerId { get; set; }
        public int addressId { get; set; }
        public DateTime orderDate { get; set; }
        public int orderStatus { get; set; }
    }
    public class UpdateCustomerRequestValidator : AbstractValidator<UpdateOrderRequest>
    {
        public UpdateCustomerRequestValidator()
        {
            RuleFor(orders => orders.customerId).NotEmpty().WithMessage("Customer id boş olamaz");

            RuleFor(orders => orders.addressId).NotEmpty().WithMessage("Address id boş olamaz");

        }
    }
}
