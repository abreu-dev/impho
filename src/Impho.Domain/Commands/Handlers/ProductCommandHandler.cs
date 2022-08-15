using Impho.Core.Extensions;
using Impho.Core.Messaging.Commands;
using Impho.Core.Messaging.Handlers.Interfaces;
using Impho.Core.Notifications;
using Impho.Domain.Commands.ProductCommands;
using Impho.Domain.Entities;
using Impho.Domain.Enums;
using Impho.Domain.Repositories;

namespace Impho.Domain.Commands.Handlers
{
    public class ProductCommandHandler :
        ICommandHandler<AddProductCommand>,
        ICommandHandler<UpdateProductCommand>,
        ICommandHandler<RemoveProductCommand>
    {
        private readonly IDomainNotificationHandler _notificationHandler;
        private readonly IProductRepository _productRepository;

        public ProductCommandHandler(IDomainNotificationHandler notificationHandler,
                                     IProductRepository productRepository)
        {
            _notificationHandler = notificationHandler;
            _productRepository = productRepository;
        }

        public async Task Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            if (!await ValidOperation(command, cancellationToken)) return;

            var unitOfMeasurement = EnumExtensions.GetEnumValueFromName<UnitOfMeasurement>(command.UnitOfMeasurement);
            var currency = new CurrencyDomain(command.CurrencyValue, command.CurrencyCode);
            var product = new ProductDomain(command.Name, command.Description, command.QuantityAvailable, unitOfMeasurement, currency);

            _productRepository.Add(product);
            _productRepository.UnitOfWork.Complete();
        }

        public async Task Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            if (!await ValidOperation(command, cancellationToken)) return;

            var unitOfMeasurement = EnumExtensions.GetEnumValueFromName<UnitOfMeasurement>(command.UnitOfMeasurement);
            var currency = new CurrencyDomain(command.CurrencyValue, command.CurrencyCode);
            var product = new ProductDomain(command.Id, command.Name, command.Description, command.QuantityAvailable, unitOfMeasurement, currency);

            _productRepository.Update(product);
            _productRepository.UnitOfWork.Complete();
        }

        public async Task Handle(RemoveProductCommand command, CancellationToken cancellationToken)
        {
            if (!await ValidOperation(command, cancellationToken)) return;

            _productRepository.Delete(command.Id);
            _productRepository.UnitOfWork.Complete();
        }

        private async Task<bool> ValidOperation(ICommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                foreach (var error in command.ValidationResult.Errors)
                {
                    await _notificationHandler.Handle(new DomainNotification(error.ErrorCode, "", error.ErrorMessage), cancellationToken);
                }
                return false;
            }
            return true;
        }
    }
}
