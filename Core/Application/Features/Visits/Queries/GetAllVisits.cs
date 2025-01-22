using MediatR;
using Domain.Models;
using Application.Interfaces;
using Application.DTOs;
using AutoMapper;

namespace Application.Features.Visit.Queries;

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
        var Visit = await _unitOfWork.Repository<Domain.Models.Visit>().GetAllAsync();
        return _mapper.Map<List<VisitDto>>(Visit);
    }
}