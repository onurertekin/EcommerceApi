using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.CustomerAddresses
{
    public class UpdateCustomerAddressesRequest
    {
        public int customerId { get; set; }
        public string streetAddress { get; set; }
        public string streetAddress2 { get; set; }
        public string city { get; set; }
        public string zipPostalCode { get; set; }
        public string phoneNumber { get; set; }
        public bool isDefault { get; set; }
    }
    public class UpdateCustomerAddressesRequestValidator : AbstractValidator<UpdateCustomerAddressesRequest>
    {
        public UpdateCustomerAddressesRequestValidator()
        {
            RuleFor(customerAddresses => customerAddresses.streetAddress).NotEmpty().WithMessage("Adress alanı boş olamaz.");

            RuleFor(customerAddresses => customerAddresses.city).NotEmpty().WithMessage("Şehir alanı boş olamaz.");

            RuleFor(customerAddresses => customerAddresses.zipPostalCode).NotEmpty().WithMessage("Posta kodu alanı boş olamaz.");

            RuleFor(customers => customers.phoneNumber)
            .NotEmpty().WithMessage("Telefon numarası boş olamaz")
            .Matches(@"^\d{10}$").WithMessage("Geçersiz telefon numarası formatı.");
        }
    }
}
