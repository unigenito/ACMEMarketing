using Application.DTOs;
using Application.Interfaces;
using Domain.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Customers.Command;

public record CreateCustomerCommand(string Name, string LastName, string Email, string Phone, string Street, string City, string ZipCode)
    : IRequest<Unit>;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
{
    private readonly IUnitOfwork _unitOfwork;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(IUnitOfwork unitOfwork, IMapper mapper)
    {
        _unitOfwork = unitOfwork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(request);
        await _unitOfwork.GetRepository<Customer>().AddAsync(customer);
        //await _unitOfwork.CommitAsync();
        return Unit.Value;
    }
}