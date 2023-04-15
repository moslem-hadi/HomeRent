using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common;

public static class MediatorExtensions
{
    public static async Task DispatchDomainEvents(this IMediator mediator, DbContext dbContext, CancellationToken cancellationToken)
    {
        var entities = dbContext.ChangeTracker
            .Entries<BaseEntity>()
            .Where(a => a.Entity.DomainEvents.Any())
            .Select(a => a.Entity);

        var domainEvents = entities
            .SelectMany(a => a.DomainEvents)
            .ToList();

        entities.ToList().ForEach(a => a.ClearDomainEvents());

        //domainEvents.ForEach(async a => await mediator.Publish(a));
        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }
}