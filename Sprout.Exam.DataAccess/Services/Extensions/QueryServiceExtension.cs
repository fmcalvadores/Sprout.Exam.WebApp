using AutoMapper;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.DataAccess.Services.Extensions
{
    public static class QueryServiceExtension
    {
        public static IMapper GetMapper(this QueryService query)
        {
            return (new MapperConfiguration( cfg => 
            {
                cfg.CreateMap<Employee, EmployeeDto>()
                    .ForMember(x => x.TypeId, dto => dto.MapFrom(src => src.EmployeeTypeId));
                cfg.CreateMap<EmployeeDto, Employee>()
                    .ForMember(x => x.EmployeeTypeId, dto => dto.MapFrom(src => src.TypeId));
            })).CreateMapper();
        }
    }
}
