using FluentValidation;


namespace Contract.Request.Categories
{
    public class CreateCategoriesRequest
    {
        public string name { get; set; }
        public DateTime CreatedOn { get; set; }
        public int status { get; set; }
    }
    public class CreateCategoriesRequestValidator : AbstractValidator<CreateCategoriesRequest>
    {
        public CreateCategoriesRequestValidator()
        {
            RuleFor(categories => categories.name).NotEmpty().WithMessage("Kategori adı boş olamaz.");
        }
    }
}
