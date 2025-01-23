using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Features.Customers.Queries;

public record GetCustomerById(int id): IRequest<CustomerDto>;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerById, CustomerDto>
{
    private readonly IUnitOfwork _unitOfwork;
    private readonly IMapper _mapper;

    public GetCustomerByIdHandler(IUnitOfwork unitOfwork, IMapper mapper)
    {
        _unitOfwork = unitOfwork;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(GetCustomerById request, CancellationToken cancellationToken)
    {
        var customer = await _unitOfwork.GetRepository<Customer>().GetByIdAsync(request.id);
        return _mapper.Map<CustomerDto>(customer);
    }
}