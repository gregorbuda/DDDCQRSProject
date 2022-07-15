using Application.Features.Test.Commands.CreateTest;
using Application.Features.Test.Queries.GetTestList;
using Application.Response;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TestClass, TestVm>();

            CreateMap<CreateTestCommand, TestClass>();
        }
    }
}
