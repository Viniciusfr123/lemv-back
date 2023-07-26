using FluentValidation;
using FluentValidation.Results;
using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces;
using LEMV.Domain.Interfaces.Repositories;
using LEMV.Domain.Notifications;
using System;
using System.Threading.Tasks;

namespace LEMV.Domain.Services
{
    public abstract class BaseService<T> : IBaseService<T>
        where T : Entity
    {
        private readonly INotificator _notificator;
        protected readonly IRepository<T> _repository;

        public BaseService(INotificator notificator, IRepository<T> repository)
        {
            _notificator = notificator;
            _repository = repository;
        }

        protected void Notify(string message)
        {
            _notificator.Handle(new Notification(message));
        }

        protected void Notify(ValidationResult validationResult)
        {
            var errors = validationResult.Errors;

            foreach (var error in errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected bool Validate<TEntity>(AbstractValidator<TEntity> validator, TEntity entity)
        {
            var result = validator.Validate(entity);

            if (result.IsValid) return true;

            Notify(result);

            return false;
        }


        public void Delete(string id)
        {
            _repository.Delete(id);

            return;
        }

        public T Create(T entity)
        {
            var currentDate = DateTime.Now;

            entity.CreatedAt = currentDate;
            entity.LastMofication = currentDate;

            return _repository.Add(entity); ;
        }

        public T Update(T entity)
        {
            var currentDate = DateTime.Now;
            entity.LastMofication = currentDate;

            return _repository.Update(entity);
        }
    }
}
