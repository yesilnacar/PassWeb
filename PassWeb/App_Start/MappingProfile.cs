using AutoMapper;
using PassWeb.Dtos;
using PassWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassWeb.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<User, UserDto>();

            // Dto to Domain
            Mapper.CreateMap<UserDto, User>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}