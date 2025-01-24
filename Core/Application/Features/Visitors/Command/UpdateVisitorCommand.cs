using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Features.Visitors.Command
{
    public record UpdateVisitorCommand(int Id, string Email, string Phone, string Position, string Department) : IRequest<Unit>;

    public class UpdateVisitorCommandHandler : IRequestHandler<UpdateVisitorCommand, Unit>
    {
        private readonly IUnitOfwork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateVisitorCommandHandler(IUnitOfwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateVisitorCommand request, CancellationToken cancellationToken)
        {
            Visitor? visitor = await _unitOfWork.GetRepository<Visitor>().GetByIdAsync(e => e.IsDeleted == false && e.Id ==request.Id);
            
            if (visitor == null)
                throw new KeyNotFoundException($"The visitor {request.Id} was not found");

            visitor.PhoneNumber = request.Phone;
            visitor.Position = request.Position;
            visitor.Department = request.Department;
            visitor.Email = request.Email;

            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}