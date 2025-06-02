using Application.Features.MediatR.Answers.Commands;
using Application.Features.MediatR.Answers.Queries;
using Application.Features.MediatR.Answers.Results;
using Application.Features.MediatR.Department.Results;
using Application.Features.MediatR.Questions.Commands;
using Application.Features.MediatR.Questions.Results;
using Application.Features.MediatR.Tags.Commands;
using Application.Features.MediatR.Tags.Results;
using Application.Features.MediatR.Universities.Results;
using Application.Features.MediatR.Users.Commands;
using Application.Features.MediatR.Users.Results;
using AutoMapper;
using Domain.Entities;

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
            CreateMap<Tag, CreateTagCommand>().ReverseMap();

            //Answers
            CreateMap<Answer,CreateAnswersCommand>().ReverseMap();
            CreateMap<Answer,UpdateAnswerCommand>().ReverseMap();
            CreateMap<Answer,GetByIdAnswerQueryResult>()
                .ForMember(x=>x.UserFullName, y => y.MapFrom(src => src.User.FullName));
            CreateMap<Answer, GetAllAnswerByQuestionIdQueryResult>()
                .ForMember(x => x.UserFullName, y => y.MapFrom(src => src.User.FullName));

        }

    }
}
