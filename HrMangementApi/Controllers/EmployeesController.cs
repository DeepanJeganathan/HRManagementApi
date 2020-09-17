using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HrMangementApi.DTOs.EmployeeDTOs;
using HrMangementApi.Models;
using HrMangementApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrMangementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this._employeeRepository = employeeRepository;
            this._mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> EmployeeList()
        {
            var employeeList = await _employeeRepository.GetAllAsync();

            if (employeeList == null)
            {
                return NotFound();
            }

            var employeeListDto = new List<EmployeeViewDTO>();

            foreach (var emp in employeeList)
            {
                employeeListDto.Add(_mapper.Map<EmployeeViewDTO>(emp));
            }

            return Ok(employeeListDto);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Employee(int id)
        {
            var employee = await _employeeRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            var employeeDto = _mapper.Map<EmployeeViewIdDTO>(employee);

            return Ok(employeeDto);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> create([FromBody]EmployeeCreateDTO employeeCreateDTO)
        {
            if (employeeCreateDTO==null)
            {
                return BadRequest(ModelState);
            }

            if (_employeeRepository.EmployeeExists(employeeCreateDTO.EmployeeNumber))
            {
                ModelState.AddModelError("", "Employee already exists!");
                return StatusCode(404, ModelState);
            }

        }


    }
}