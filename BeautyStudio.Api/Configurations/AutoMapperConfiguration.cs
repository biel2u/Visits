using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeautyStudio.Domain.Dto;
using BeautyStudio.Domain.Models;

namespace BeautyStudio.Api.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<AddVisitDto, Visit>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.IsCanceled, opt => opt.Ignore());
            CreateMap<Visit, AddVisitDto>();

            CreateMap<Visit, VisitDto>();
            CreateMap<VisitDto, Visit>();

            CreateMap<UpdateVisitDto, Visit>()
                .ForMember(dest => dest.IsCanceled, opt => opt.Ignore());
            CreateMap<Visit, UpdateVisitDto>();
        }
    }
}
