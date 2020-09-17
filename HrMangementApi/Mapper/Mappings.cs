using AutoMapper;
using HrMangementApi.DTOs.EmployeeDTOs;
using HrMangementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrMangementApi.Mapper
{
    public class Mappings:Profile
    {
        public Mappings()
        {
            CreateMap<Employee, EmployeeViewDTO>();
            CreateMap<Employee, EmployeeViewIdDTO>();


        }


    }
}
