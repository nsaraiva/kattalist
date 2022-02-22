using FluentValidation;
using FluentValidation.Results;
using Kattalist.Domain.Entities;
using System;
using System.Linq;

namespace Kattalist.Service.Validators
{
    public class GroceryListValidator : AbstractValidator<GroceryList>
    {
        public GroceryListValidator()
        {
            RuleFor(r => r.Name).NotNull();
            RuleFor(r => r.Name).MinimumLength(1);
            RuleFor(r => r.Name).MaximumLength(50);
            RuleFor(r => r.Name).Must(n => !n.Any(x => Char.IsWhiteSpace(x)))
                .WithErrorCode("420");
        }

        protected override bool PreValidate(ValidationContext<GroceryList> instance, ValidationResult result)
        {
            if(instance.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("GroceryList", "Grocery list name cannot be null"));
                return false;
            }
            return base.PreValidate(instance, result);
}
    }
}
