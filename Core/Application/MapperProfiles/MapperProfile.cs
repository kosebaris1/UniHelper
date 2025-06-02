using Application.Features.MediatR.Department.Results;
using Application.Features.MediatR.QuestionLikes.Commands;
using Application.Features.MediatR.Questions.Commands;
using Application.Features.MediatR.Questions.Results;
using Application.Features.MediatR.Tags.Results;
using Application.Features.MediatR.Universities.Results;
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

            //User
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

            CreateMap<User, GetByIdUserDetailsForAdminQueryResult>()
         .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
         .ForMember(dest => dest.UniversityName, opt => opt.MapFrom(src => src.University.Name))
         .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));


            //Question
            CreateMap<Question, CreateQuestionCommand>().ReverseMap();
            CreateMap<Question, UpdateQuestionCommand>().ReverseMap();
            CreateMap<Question, GetFilteredQuestionQueryResult>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.UniversityName, opt => opt.MapFrom(src => src.University.Name))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.QuestionTags, opt => opt.MapFrom(src => src.QuestionTags.Select(qt=>qt.Tag.Name).ToList()));

            //University
            CreateMap<University, GetAllUniversityQueryResult>().ReverseMap();
            CreateMap<Department, GetAllDepartmentQueryResult>().ReverseMap();

            //Department
            CreateMap<Department, GetDepartmentsByUniversityQueryResult>().ReverseMap();


            //Tags
            CreateMap<Tag, GetAllTagQueryResult>().ReverseMap();

        }

    }
}
