using AutoMapper;
using HrManagementApi.DTOs.CommentDTOs;
using HrManagementApi.DTOs.EmployeeDTOs;
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
            CreateMap<EmployeeCreateDTO, Employee>();
            CreateMap<EmployeeUpdateDTO, Employee>();

            CreateMap<Comment, CommentViewDTO>();
            CreateMap<Comment, CommentViewIdDTO>();
            CreateMap<CommentCreateDTO, Comment>();
            CreateMap<CommentUpdateDTO, Comment>();

        }


    }
}
