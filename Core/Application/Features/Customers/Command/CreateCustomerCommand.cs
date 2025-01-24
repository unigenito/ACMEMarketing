using Application.DTOs;
using Application.Interfaces;
using Domain.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Customers.Command;

public class CreateCustomerCommand : IRequest<Unit>
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public string Identification { get; set; }
    public string Sex { get; set; }
}

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
        await _unitOfwork.CompleteAsync();
        return Unit.Value;
    }
}