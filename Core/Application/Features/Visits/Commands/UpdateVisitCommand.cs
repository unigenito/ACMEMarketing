using Application.Interfaces;
using Domain.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Visits.Commands;

public record UpdateVisitCommand(int VisitId, DateTime Date, string Note, string Purpose) : IRequest<Unit>;

public class UpdateVisitCommandHandler : IRequestHandler<UpdateVisitCommand, Unit>
{
    private readonly IUnitOfwork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateVisitCommandHandler(IUnitOfwork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateVisitCommand request, CancellationToken cancellationToken)
    {
        var visit = await _unitOfWork.GetRepository<Visit>().GetByIdAsync(e => e.IsDeleted == false && e.Id ==request.VisitId);
        if (visit == null)
        {
            throw new KeyNotFoundException($"Visit with id {request.VisitId} not found");
        }

        visit.VisitedDate = request.Date;
        visit.Notes = request.Note;

        await _unitOfWork.CompleteAsync();

        return Unit.Value;
    }
} 