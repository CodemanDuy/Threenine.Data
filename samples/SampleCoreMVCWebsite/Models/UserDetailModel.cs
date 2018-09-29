﻿using AutoMapper;
using Sample.Entity;
using Threenine.Map;

namespace SampleCoreMVCWebsite.Models
{
    public class UserDetailModel : ICustomMap
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        public string Headline { get; set; }

        public void CustomMap(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Person, UserDetailModel>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => string.Concat(src.FirstName, " ", src.LastName)))
                .ForMember(dest => dest.Headline, opt => opt.MapFrom(src => src.TagLine))
                .ForMember(dest => dest.Bio, opt => opt.MapFrom(src => src.Profile))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}