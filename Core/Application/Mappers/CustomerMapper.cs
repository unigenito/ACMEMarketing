using Application.DTOs;
using Application.Features.Customers.Command;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public class CustomerMapper: Profile
{
    public CustomerMapper()
    {
        CreateMap<Customer, CustomerDto>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber))
        .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Street))
        .ForMember(dest => dest.TotalVisited, opt => opt.MapFrom(src => src.Visits.Count))
        .ForMember(dest => dest.Pending, opt => opt.MapFrom(src => src.Visits.Count(v => v.VisitDate == null)))  
        .ReverseMap();
        
        CreateMap<CreateCustomerCommand, Customer>()
        .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identification))
        .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
        .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
        .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
        .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
        .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.ZipCode))
        .ForMember(dest => dest.Genere, opt => opt.MapFrom(src => src.Sex))
        .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
        .ForMember(dest => dest.Visits, opt => opt.Ignore());
    }
}