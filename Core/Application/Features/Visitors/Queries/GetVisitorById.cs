using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;
namespace Application.Features.Visitors.Queries;
public record GetVisitorById(int Id) : IRequest<List<VisitorDto>>;

public class GetVisitorHandler : IRequestHandler<GetVisitorById, List<VisitorDto>>
{
    private readonly IUnitOfwork _unitOfWork;
    private readonly IMapper _mapper;

    public GetVisitorHandler(IUnitOfwork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<VisitorDto>> Handle(GetVisitorById request, CancellationToken cancellationToken)
    {
        var visits = await _unitOfWork.Repository<Visitor>().GetAllAsync();
        return _mapper.Map<List<VisitorDto>>(visits);
    }
}