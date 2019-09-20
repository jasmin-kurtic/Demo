using AutoMapper;
using Demo.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entity.Models.User, UserModel>();
            CreateMap<UserRegisterModel, Entity.Models.User>();
        }
    }
}
