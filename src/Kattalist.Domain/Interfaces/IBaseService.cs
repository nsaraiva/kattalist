using FluentValidation;
using Kattalist.Domain.Entities;
using System.Collections.Generic;

namespace Kattalist.Domain.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        T Add<TValidator> (T obj) where TValidator : AbstractValidator<T>;
        void Delete(int Id);
        IList<T> Get();
        T GetById(int Id);
        T Update<TValidator>(T obj) where TValidator : AbstractValidator<T>;
        void Validate(T obj, AbstractValidator<T> validator);

    }
}
