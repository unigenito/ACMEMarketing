using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace ACMEMarketing.Core.Application.Features.Visitors.Queries
{
    public record GetAllVisitors() : IRequest<List<VisitorDto>>;
            
    public class GetAllVisitorsHandler : IRequestHandler<GetAllVisitors, List<VisitorDto>>{
        private readonly IUnitOfwork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllVisitorsHandler(IUnitOfwork unitOfWork, IMapper mapper){
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<VisitorDto>> Handle(GetAllVisitors request, CancellationToken cancellationToken){
            var visits = await _unitOfWork.GetRepository<Visitor>().FindAsync(e => e.IsDeleted == false);
            return _mapper.Map<List<VisitorDto>>(visits);
        }
    }
}