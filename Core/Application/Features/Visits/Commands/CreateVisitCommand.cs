using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Features.Visits.Commands;

public record CreateVisitCommand(int CustomerId, int VisitorId, DateTime VisitDate, string Purpose, string Note): IRequest<Unit>;

public class CreateVisitCommandHandler : IRequestHandler<CreateVisitCommand, Unit>
{
    public CreateVisitCommandHandler(IMapper mapper, IUnitOfwork unitOfwork)
    {
        _mapper = mapper;
        _unitOfwork = unitOfwork;
    }

    private readonly IUnitOfwork _unitOfwork;
    private readonly IMapper _mapper;

    public async Task<Unit> Handle(CreateVisitCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Visit>(request);
        await _unitOfwork.GetRepository<Visit>().AddAsync(customer);
        return Unit.Value;
    }
}