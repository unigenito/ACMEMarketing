using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Features.Customers.Command;

public record UpdateCustomerCommand(int Id, string Name, string Email, string Phone) : IRequest<Unit>;

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
        var customer = await _unitOfwork.Repository<Customer>().GetByIdAsync(request.Id);
        customer.FirstName = request.Name;
        customer.Email = request.Email;
        customer.PhoneNumber = request.Phone;
        await _unitOfwork.Repository<Customer>().UpdateAsync(customer);
        //await _unitOfwork.CommitAsync();
        return Unit.Value;
    }
}