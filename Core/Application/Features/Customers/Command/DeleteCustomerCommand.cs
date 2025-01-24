using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Features.Customers.Command;

public record DeleteCustomerCommand(int Id): IRequest<Unit>;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
{
    private readonly IUnitOfwork _unitOfwork;

    public DeleteCustomerCommandHandler( IUnitOfwork unitOfwork)
    {
        _unitOfwork = unitOfwork;
    }

    public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer? customer = await _unitOfwork.GetRepository<Customer>().GetByIdAsync(e => e.IsDeleted == false && e.Id == request.Id);
        
        if (customer == null)
        {
            throw new KeyNotFoundException($"The customer was {request.Id} not found");
        }

        customer.IsDeleted = true;
        await _unitOfwork.GetRepository<Customer>().UpdateAsync(customer);

        var visits = await _unitOfwork.GetRepository<Visit>().FindAsync(e => e.CustomerId == request.Id);
        foreach (var visit in visits)
        {
            visit.IsDeleted = true;
            await _unitOfwork.GetRepository<Visit>().UpdateAsync(visit);
        }

        await _unitOfwork.CompleteAsync();

        return Unit.Value;
    }
}