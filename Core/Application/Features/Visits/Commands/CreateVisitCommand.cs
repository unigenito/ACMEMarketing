using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Features.Visits.Commands;

public record CreateVisitCommand(int customerId, int visitorId, DateTime visitDate, string purpose): IRequest<Unit>;

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
        var customer = _mapper.Map<Domain.Models.Visit>(request);
        await _unitOfwork.Repository<Domain.Models.Visit>().AddAsync(customer);
        return Unit.Value;
    }
}