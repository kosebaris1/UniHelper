using Application.Features.MediatR.Answers.Commands;
using Application.Features.MediatR.Answers.Results;
using Application.Features.MediatR.Cities.Results;
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
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
            .ForMember(dest => dest.AnswerCount, opt => opt.MapFrom(src => src.Answers.Count()))
            .ForMember(dest => dest.TotalLikes, opt => opt.MapFrom(src =>
                src.Answers.SelectMany(a => a.AnswerLikes).Count()));
            CreateMap<User, GetByIdUserDetailsForAdminQueryResult>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
            .ForMember(dest => dest.UniversityName, opt => opt.MapFrom(src => src.University.Name))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));


            //Question
            CreateMap<Question, CreateQuestionCommand>().ReverseMap();
            CreateMap<Question, UpdateQuestionCommand>().ReverseMap();
            CreateMap<Question, GetFilteredQuestionQueryResult>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.UserImageUrl, opt => opt.MapFrom(src => src.User.ProfilePictureUrl))
                .ForMember(dest => dest.UniversityName, opt => opt.MapFrom(src => src.University.Name))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.QuestionTags, opt => opt.MapFrom(src => src.QuestionTags.Select(qt => qt.Tag.Name).ToList()))
                .ForMember(dest => dest.AnswerCount, opt => opt.MapFrom(src => src.Answers.Count))
                .ForMember(dest => dest.LikeCount, opt => opt.MapFrom(src => src.QuestionLikes.Count));
            CreateMap<Question,GetByIdQuestionQueryResult>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.UniversityName, opt => opt.MapFrom(src => src.University.Name))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.UserProfileUrl, opt => opt.MapFrom(src => src.User.ProfilePictureUrl))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.QuestionTags.Select(qt => qt.Tag.Name).ToList()));
            CreateMap<Question, GetMyTopQuestionQueryResult>()
                .ForMember(dest => dest.UniversityName, opt => opt.MapFrom(src => src.University.Name))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.QuestionTags, opt => opt.MapFrom(src => src.QuestionTags.Select(qt => qt.Tag.Name).ToList()))
                .ForMember(dest => dest.LikeCount, opt => opt.MapFrom(src => src.QuestionLikes.Count))
                .ForMember(dest => dest.AnswerCount, opt => opt.MapFrom(src => src.Answers.Count));

            CreateMap<Question, GetAllPendingQuestionQueryResult>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName));




            //University
            CreateMap<University, GetAllUniversityQueryResult>().ReverseMap();
            CreateMap<Department, GetAllDepartmentQueryResult>().ReverseMap();

            //Department
            CreateMap<Department, GetDepartmentsByUniversityQueryResult>().ReverseMap();
            CreateMap<Department, GetAllDistinctDepartmentQueryResult>().ReverseMap();


            //Tags
            CreateMap<Tag, GetAllTagQueryResult>().ReverseMap();
            CreateMap<Tag, CreateTagCommand>().ReverseMap();

            //Answers
            CreateMap<Answer,CreateAnswersCommand>().ReverseMap();
            CreateMap<Answer,UpdateAnswerCommand>().ReverseMap();
            CreateMap<Answer,GetByIdAnswerQueryResult>()
                .ForMember(x=>x.UserFullName, y => y.MapFrom(src => src.User.FullName));
            CreateMap<Answer, GetAllAnswerByQuestionIdQueryResult>()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.LikeCount, opt => opt.MapFrom(src => src.AnswerLikes.Count))
                .ForMember(dest => dest.IsLikedByCurrentUser, opt => opt.MapFrom((src, dest, destMember, context) =>
                    src.AnswerLikes.Any(like => like.UserId == (int)context.Items["CurrentUserId"])
                ))
                .ForMember(dest => dest.IsVerified, opt => opt.MapFrom(src => src.User.IsVerified))
                .ForMember(dest => dest.UniversityName, opt => opt.MapFrom(src => src.User.Department.University.Name))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.User.Department.Name))
                .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.User.ProfilePictureUrl));

            CreateMap<Answer, GetRecentAnswerByUserIdQueryResult>()
                .ForMember(dest => dest.QuestionTitle, opt => opt.MapFrom(src => src.Question.Title));


            //City
            CreateMap<City, GetAllCityQueryResult>().ReverseMap();

        }

    }
}
