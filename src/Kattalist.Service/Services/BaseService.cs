using FluentValidation;
using Kattalist.Domain.Entities;
using Kattalist.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Kattalist.Service.Services
{
    public class BaseService<T>: IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public T Add<TValidator>(T obj) where TValidator : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(obj);

            return obj;
        }

        public void Delete(int Id)
        {
            _baseRepository.Delete(Id);
        }

        public IList<T> Get()
        {
            return _baseRepository.Select();
        }

        public T GetById(int Id)
        {
           return _baseRepository.Select(Id);
        }

        public T Update<TValidator>(T obj) where TValidator : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(obj);
            return obj;
        }

        public void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("ListaCompras cannot be null");

            validator.ValidateAndThrow(obj);
        }
    }
}
