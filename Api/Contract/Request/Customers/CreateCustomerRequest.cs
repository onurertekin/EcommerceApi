using FluentValidation;


namespace Contract.Request.Customers
{
    public class CreateCustomerRequest
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string gender { get; set; }
        public int status { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(customers => customers.firstName).NotEmpty().WithMessage("Müşteri adı boş olamaz.");

            RuleFor(customers => customers.lastName).NotEmpty().WithMessage("Müşteri soyadı boş olamaz");

            RuleFor(customers => customers.userName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");

            RuleFor(customer => customer.password)
                  .NotEmpty().WithMessage("Şifre boş olamaz")
                  .MinimumLength(8).WithMessage("Şifre en az 8 karakter uzunluğunda olmalıdır")
                  .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir")
                  .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir")
                  .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir")
                  .Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az bir özel karakter içermelidir");

            RuleFor(customers => customers.phoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz")
                .Matches(@"^\d{10}$").WithMessage("Geçersiz telefon numarası formatı.");

            RuleFor(customers => customers.gender).NotEmpty().WithMessage("Cinsiyet boş olamaz");
        }
    }
}
