using FluentValidation;
using FluentValidation.Results;
using Kattalist.Domain.Entities;
using System;
using System.Linq;

namespace Kattalist.Service.Validators
{
    public class ListaComprasValidator : AbstractValidator<ListaCompras>
    {
        public ListaComprasValidator()
        {
            RuleFor(listaCompras => listaCompras.Name).NotNull();
            RuleFor(ListaCompras => ListaCompras.Name).MinimumLength(1);
            RuleFor(ListaCompras => ListaCompras.Name).Must(n => !n.Any(x => Char.IsWhiteSpace(x)))
                .WithErrorCode("420");
        }

        //protected override bool PreValidate(ValidationContext<ListaCompras> instance, ValidationResult result)
        //{
        //    if(instance.InstanceToValidate == null)
        //    {
        //        result.Errors.Add(new ValidationFailure("ListaCompras", "ListaCompras cannot be null"));
        //        return false;
        //    }
        //    return base.PreValidate(instance, result);
        //}
    }
}
