using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Features.Visitors.Command
{
    public record CreateVisitorCommand(
        string Name,
        string LastName,
        string Email,
        DateTime VisitDate,
        string Position,
        string Department,
        string Phone) : IRequest<Unit>;

    public class CreateVisitorCommandHandler : IRequestHandler<CreateVisitorCommand, Unit>
    {
        private readonly IUnitOfwork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateVisitorCommandHandler(IUnitOfwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateVisitorCommand request, CancellationToken cancellationToken)
        {
            var visitor = _mapper.Map<Visitor>(request);

            await _unitOfWork.GetRepository<Visitor>().AddAsync(visitor);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}