
using FluentValidation;

namespace AdessoDraw.Application.Models.RequestModels;

public class DrawRequestModel
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required int GroupCount { get; set; }
}

public class DrawRequestModelValidator : AbstractValidator<DrawRequestModel>
{
    public DrawRequestModelValidator()
    {
        this.RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required.");
        this.RuleFor(x => x.Surname).NotNull().WithMessage("{PropertyName} is required.");
        this.RuleFor(x => x.GroupCount)
            .Must(groupCount => groupCount == 4 || groupCount == 8)
            .WithMessage("Group count must be either 4 or 8.");
    }
}