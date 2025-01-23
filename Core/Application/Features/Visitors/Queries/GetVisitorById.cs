using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;
namespace Application.Features.Visitors.Queries;
public record GetVisitorById(int Id) : IRequest<VisitorDto>;

public class GetVisitorHandler : IRequestHandler<GetVisitorById, VisitorDto>
{
    private readonly IUnitOfwork _unitOfWork;
    private readonly IMapper _mapper;

    public GetVisitorHandler(IUnitOfwork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<VisitorDto> Handle(GetVisitorById request, CancellationToken cancellationToken)
    {
        var visits = await _unitOfWork.GetRepository<Visitor>().GetAllAsync();
        return _mapper.Map<VisitorDto>(visits);
    }
}