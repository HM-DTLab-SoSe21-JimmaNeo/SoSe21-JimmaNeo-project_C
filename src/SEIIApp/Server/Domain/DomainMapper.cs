using AutoMapper;
using SEIIApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class DomainMapper : Profile
    {

        public DomainMapper()
        {

            CreateMap<PostDto, PostDefinition>();
            CreateMap<PostDefinition, PostDto>();

       

        }

    }
}
