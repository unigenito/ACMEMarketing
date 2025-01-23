using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Features.Visits.Commands;

public record DeleteVisitCommand(int Id) : IRequest<Unit>;

public class DeleteVisitCommandHandler : IRequestHandler<DeleteVisitCommand, Unit>
{
    private readonly IUnitOfwork _unitOfWork;

    public DeleteVisitCommandHandler(IUnitOfwork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteVisitCommand request, CancellationToken cancellationToken)
    {
        Visit? visit = await _unitOfWork.GetRepository<Visit>().GetByIdAsync(request.Id);

        if (visit == null)
            throw new KeyNotFoundException($"The visit was {request.Id} not found");

        visit.IsDeleted = true;
        await _unitOfWork.GetRepository<Visit>().UpdateAsync(visit);

        await _unitOfWork.CompleteAsync();

        return Unit.Value;
    }
}