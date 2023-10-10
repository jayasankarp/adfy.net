using FluentValidation;

namespace Adfy.Application.Advertisements.CreateAdvertisement;

public class CreateAdvertisementCommandValidator : AbstractValidator<CreateAdvertisementCommand>
{
    public CreateAdvertisementCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();

        RuleFor(c => c.Title).NotEmpty();

        RuleFor(c => c.Description).NotEmpty();
    }
}