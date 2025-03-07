﻿using Application.DTOs;
using Application.Interfaces;
using Domain.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Visits.Queries;

public record GetVisitById(int Id) : IRequest<VisitDto>;

public class GetVisitByIdHandler : IRequestHandler<GetVisitById, VisitDto>
{
    private readonly IUnitOfwork _unitOfWork;
    private readonly IMapper _mapper;

    public GetVisitByIdHandler(IUnitOfwork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<VisitDto> Handle(GetVisitById request, CancellationToken cancellationToken)
    {
        var visit = await _unitOfWork.GetRepository<Domain.Models.Visit>().GetByIdAsync(e => e.IsDeleted == false && e.Id ==request.Id, new List<string>(){"Visitor","Customer"});
        if (visit == null)
        {
            throw new KeyNotFoundException(nameof(Visit));
        }

        return _mapper.Map<VisitDto>(visit);
    }
}