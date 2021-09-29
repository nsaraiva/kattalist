using FluentValidation;
using FluentValidation.Results;
using Kattalist.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kattalist.Domain.Validators
{
    public class ListaComprasValidator : AbstractValidator<ListaComprasDTO>
    {
        public ListaComprasValidator()
        {
            RuleFor(listaCompras => listaCompras.Name).NotNull();
            RuleFor(ListaCompras => ListaCompras.Name).MinimumLength(1);
            RuleFor(ListaCompras => ListaCompras.Name).Must(n => !n.Any(x => Char.IsWhiteSpace(x)));
        }

        protected override bool PreValidate(ValidationContext<ListaComprasDTO> instance, ValidationResult result)
        {
            if(instance.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("ListaCompras", "LIstaCompras cannot be null"));
                return false;
            }
            return base.PreValidate(instance, result);
        }
    }
}
