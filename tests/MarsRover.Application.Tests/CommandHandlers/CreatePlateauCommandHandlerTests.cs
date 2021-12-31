using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MarsRover.Application.CommandHandlers;
using MarsRover.Application.Commands;
using MarsRover.Application.Queries;
using MarsRover.Core.Abstraction.Data;
using MarsRover.Core.Abstraction.Domain.SeedWork;
using MarsRover.Core.Abstraction.Exceptions;
using MediatR;
using Xunit;

namespace MarsRover.Application.Tests.CommandHandlers
{
    public class CreatePlateauCommandHandlerTests
    {
        private const string plateauAllreadyExistedMessage = "The plateau is allready existed";
        
        [Fact]
        public async Task Handle__IsPlateauExists__ThrowsBusinessException()
        {
            //Arrange
            var request = new CreatePlateauCommand();
            //Act
            var handler = new CreatePlateauCommandHandler(new StubUnitOfWork(), new StubMediatr());
            Func<Task> act = () => handler.Handle(request, default);

            //Assert
            var exception= await Assert.ThrowsAsync<BusinessException>(act);
            Assert.Equal(plateauAllreadyExistedMessage, exception.Message);

            // await act.Should()
            //     .ThrowAsync<BusinessException>()
            //     .WithMessage(plateauAllreadyExistedMessage)
            //     .Where(ex=> ex.Message.StartsWith("The"));
            //
            // await act.Should().NotThrowAsync<SystemException>();
        }
    }
    
    public class StubUnitOfWork: IUnitOfWork
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IAggregateRoot
        {
            throw new System.NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            throw new System.NotImplementedException();
        }

        public bool BeginNewTransaction()
        {
            throw new System.NotImplementedException();
        }

        public bool RollBackTransaction()
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> AttachAsync<TEntity>(object id) where TEntity : class
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class StubMediatr:IMediator
    {
        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = new CancellationToken())
        {
            if (request.GetType() == typeof(CheckPlateauByCodeQuery))
            {
                object falseResult = true;
                return Task.FromResult((TResponse)falseResult);
            }
            return default;
        }

        private static Task<bool> Send<TResponse>()
        {
            return Task.FromResult(false);
        }

        public Task<object?> Send(object request, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public Task Publish(object notification, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = new CancellationToken()) where TNotification : INotification
        {
            throw new System.NotImplementedException();
        }
    }
}