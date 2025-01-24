using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Features.Visitors.Command;

public record DeleteVisitorCommand(int Id): IRequest<Unit>;

public class DeleteVisitorCommandHandler : IRequestHandler<DeleteVisitorCommand, Unit>
{
    private readonly IUnitOfwork _unitOfwork;

    public DeleteVisitorCommandHandler( IUnitOfwork unitOfwork)
    {
        _unitOfwork = unitOfwork;
    }

    public async Task<Unit> Handle(DeleteVisitorCommand request, CancellationToken cancellationToken)
    {
        Visitor? visitor = await _unitOfwork.GetRepository<Visitor>().GetByIdAsync(e => e.IsDeleted == false && e.Id ==request.Id);
        
        if (visitor == null)
            throw new KeyNotFoundException($"The visitor was {request.Id} not found");

        visitor.IsDeleted = true;
        await _unitOfwork.GetRepository<Visitor>().UpdateAsync(visitor);

        await _unitOfwork.CompleteAsync();

        return Unit.Value;
    }
}