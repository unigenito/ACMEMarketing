using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Features.Customers.Command;

public record UpdateCustomerCommand(int Id, string Name, string LastName, string Email, string Phone, string City, string ZipCode, string Street) : IRequest<Unit>;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
{
    private readonly IUnitOfwork _unitOfwork;
    private readonly IMapper _mapper;

    public UpdateCustomerCommandHandler(IUnitOfwork unitOfwork, IMapper mapper)
    {
        _unitOfwork = unitOfwork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer? customer = await _unitOfwork.GetRepository<Customer>().GetByIdAsync(request.Id);
        
        if (customer == null)
            throw new KeyNotFoundException($"The customer {request.Id} was not found");

        customer.FirstName = request.Name;
        customer.Email = request.Email;
        customer.PhoneNumber = request.Phone;
        customer.City = request.City;
        customer.ZipCode = request.ZipCode;

        await _unitOfwork.GetRepository<Customer>().UpdateAsync(customer);
        await _unitOfwork.CompleteAsync();

        return Unit.Value;
    }
}