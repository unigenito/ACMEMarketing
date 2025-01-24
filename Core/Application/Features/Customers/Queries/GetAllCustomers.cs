using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Features.Customers.Queries;

public record GetAllCustomers():IRequest<List<CustomerDto>>;

public class GetAllCustomersHandler : IRequestHandler<GetAllCustomers, List<CustomerDto>>
{
    private readonly IUnitOfwork _unitOfwork;
    private readonly IMapper _mapper;

    public GetAllCustomersHandler(IUnitOfwork unitOfwork, IMapper mapper)
    {
        _unitOfwork = unitOfwork;
        _mapper = mapper;
    }

    public async Task<List<CustomerDto>> Handle(GetAllCustomers request, CancellationToken cancellationToken)
    {
        var customers = await _unitOfwork.GetRepository<Customer>().FindAsync(e => e.IsDeleted == false, new List<string>(){"Visits"});
        return _mapper.Map<List<CustomerDto>>(customers);
    }
}