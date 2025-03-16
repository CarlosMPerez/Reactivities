using System;
using Application.Activities.Commands;
using FluentValidation;

namespace Application.Activities.Validators;

public class CreateActivityValidator : AbstractValidator<CreateActivity.Command>
{
    public CreateActivityValidator()
    {
        RuleFor(x => x.Model.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.Model.Description).NotEmpty().WithMessage("Description is required");
    }
}
