using AutoMapper;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.DataAccess.Services.Extensions
{
    public static class EmployeeServiceExtenstion
    {

        public static IMapper GetMapper(this EmployeeService query)
        {
            return (new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>()
                    .ForMember(x => x.TypeId, dto => dto.MapFrom(src => src.EmployeeTypeId));
                cfg.CreateMap<EmployeeDTO, Employee>()
                    .ForMember(x => x.EmployeeTypeId, dto => dto.MapFrom(src => src.TypeId));
            })).CreateMapper();
        }
    }
}
