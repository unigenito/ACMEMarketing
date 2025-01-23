using Application.DTOs;
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
    }
}