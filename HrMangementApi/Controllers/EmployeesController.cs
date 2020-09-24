using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HrManagementApi.DTOs.EmployeeDTOs;
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
        public async Task<ActionResult<Employee>> Create([FromBody]EmployeeCreateDTO employeeCreateDTO)
        {
            if (employeeCreateDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (await _employeeRepository.EmployeeExists(employeeCreateDTO.EmployeeNumber))
            {
                ModelState.AddModelError("", "Employee already exists!");
                return StatusCode(404, ModelState);
            }

            var employee = _mapper.Map<Employee>(employeeCreateDTO);

            if (!await _employeeRepository.CreateAsync(employee))
            {
                ModelState.AddModelError("", "Error encountered when saving to database, try again. If problem persists contact your administrator");
                return StatusCode(500, ModelState);
            };

            return CreatedAtAction(nameof(Employee), new { Id = employee.EmployeeNumber }, employee);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Update(int id, [FromBody] EmployeeUpdateDTO employeeUpdateDTO)
        {
            if (id != employeeUpdateDTO.EmployeeNumber || employeeUpdateDTO == null)
            {

                return BadRequest();
            }

            var employee = _mapper.Map<Employee>(employeeUpdateDTO);

            if (!await _employeeRepository.UpdateAsync(employee))
            {
                ModelState.AddModelError("", "Error encountered when saving to database, try again. If problem persists contact your administrator");
                return StatusCode(500, ModelState);

            }

            return NoContent();
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<Employee>> Delete(int id)
        {
            
            if (!await _employeeRepository.EmployeeExists(id))
            {
                ModelState.AddModelError("", "Employee does not exist!");
                return StatusCode(404, ModelState);
            }

            var employee = await _employeeRepository.GetById(id);

            if (!await _employeeRepository.DeleteAsync(employee)) 
            {

                ModelState.AddModelError("", "Error encountered when deleting from database, try again. If problem persists contact your administrator");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

    }
}