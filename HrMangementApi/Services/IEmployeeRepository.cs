using HrMangementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrMangementApi.Services
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();

        Task<Employee> GetById(int id);

        Task<Employee> CreateAsync();

        Task<Employee> UpdateAsync();

        Task<Employee> DeleteAsync();

        bool EmployeeExists(int EmployeeNumber);

    }
}
