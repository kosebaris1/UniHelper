using Application.Features.MediatR.Users.Commands;
using Application.Features.MediatR.Users.Results;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MapperProfiles
{
    public class MapperProfile :Profile
    {
        public MapperProfile()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, DeleteUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, GetAllUserQueryResult>()
          .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
          .ForMember(dest => dest.UniversityName, opt => opt.MapFrom(src => src.University.Name))
          .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));

            CreateMap<User, GetByIdUserQueryResult>()
         .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
         .ForMember(dest => dest.UniversityName, opt => opt.MapFrom(src => src.University.Name))
         .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
        }
      
    }
}
