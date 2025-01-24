using Application.DTOs;
using Application.Features.Visitors.Command;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public class VisitorMapper: Profile
{
    public VisitorMapper()
    {
        CreateMap<Visitor, VisitorDto>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName))
        .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber))
        .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
        .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
        .ForMember(dest => dest.LastVisitDate, opt => opt.MapFrom(src => src.Visits.Select(v => v.VisitDate).LastOrDefault()))
        .ForMember(dest => dest.TotalVisits, opt => opt.MapFrom(src => src.Visits.Count))
        .ForMember(dest => dest.VisitsCompleted, opt => opt.MapFrom(src => src.Visits.Count(v => v.VisitDate != null)))
        .ReverseMap();

        CreateMap<CreateVisitorCommand, Visitor>()
        .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
        .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
        .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
        .ForMember(dest => dest.Visits, opt => opt.Ignore());
    }
}