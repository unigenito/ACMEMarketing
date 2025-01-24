using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Visits.Queries;

public record GetAllVisits(): IRequest<List<VisitDto>>;

public class GetAllVisitsHandler : IRequestHandler<GetAllVisits, List<VisitDto>>
{
    private readonly IUnitOfwork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllVisitsHandler(IUnitOfwork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<VisitDto>> Handle(GetAllVisits request, CancellationToken cancellationToken)
    {
        var Visit = await _unitOfWork.GetRepository<Domain.Models.Visit>().FindAsync(e => e.IsDeleted == false, new List<string>(){ "Customers", "Visitors"});
        return _mapper.Map<List<VisitDto>>(Visit);
    }
}