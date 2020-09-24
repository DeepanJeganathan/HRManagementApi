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

        Task<bool> CreateAsync(Employee employee);

        Task<bool> UpdateAsync(Employee employee);

        Task<bool> DeleteAsync(Employee employee);

        Task<bool> EmployeeExists(int EmployeeNumber);

        Task<bool> save();
    }
}
