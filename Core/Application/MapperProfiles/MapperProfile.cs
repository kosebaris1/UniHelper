using Application.Features.MediatR.Users.Commands;
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
        }
      
    }
}
