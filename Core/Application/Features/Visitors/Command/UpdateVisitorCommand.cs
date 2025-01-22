using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace ACMEMarketing.Core.Application.Features.Visitors.Command
{
    public record UpdateVisitorCommand(int Id, string Name, string LastName, string Email) : IRequest<Unit>;

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
            var visitor = await _unitOfWork.Repository<Visitor>().GetByIdAsync(request.Id);
            if (visitor == null)
            {
                throw new KeyNotFoundException(nameof(Visitor));
            }

            visitor.FirstName = request.Name;
            visitor.LastName = request.LastName;
            visitor.Email = request.Email;

            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}