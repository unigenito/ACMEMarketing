using Application.DTOs;
using Application.Features.Visits.Commands;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public class VisitMapper: Profile
{
    public VisitMapper()
    {
        CreateMap<Visit, VisitDto>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
        .ForMember(dest => dest.VisitorId, opt => opt.MapFrom(src => src.VisitorId))
        .ForMember(dest => dest.VisitDate, opt => opt.MapFrom(src => src.VisitDate))
        .ForMember(dest => dest.VisitedDate, opt => opt.MapFrom(src => src.VisitedDate))
        .ForMember(dest => dest.Purpose, opt => opt.MapFrom(src => src.Purpose))
        .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
        .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.FirstName} {src.Customer.LastName}"))
        .ForMember(dest => dest.VisitorName, opt => opt.MapFrom(src => $"{src.Visitor.FirstName} {src.Visitor.LastName}"))
        .ReverseMap();

        CreateMap<CreateVisitCommand, Visit>()
        .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
        .ForMember(dest => dest.VisitorId, opt => opt.MapFrom(src => src.VisitorId))
        .ForMember(dest => dest.VisitDate, opt => opt.MapFrom(src => src.VisitDate))
        .ForMember(dest => dest.Purpose, opt => opt.MapFrom(src => src.Purpose))
        .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Note));
    }
}