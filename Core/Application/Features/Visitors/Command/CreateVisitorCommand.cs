using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Features.Visitors.Command
{
    public class CreateVisitorCommand : IRequest<Unit>
    {
        public string Identification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
    }

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