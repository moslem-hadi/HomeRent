using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;

public record CreateProductCommand : IRequest<Guid>
{
    public string Title { get; init; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

}

public class CreateTodoItemCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Product
        {
            Description = request.Description,
            Title = request.Title,
            Price = request.Price
        };

        entity.AddDomainEvent(new ProductCreatedEvent(entity));

        _context.Products.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
