using HrMangementApi.Models;
using HrMangementApi.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrMangementApi.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            this._context = context;
        }

        public Task<Employee> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public bool EmployeeExists(int EmployeeNumber)
        {
           return _context.Employees.Where(x => x.EmployeeNumber == EmployeeNumber).Any();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.Where(x => x.EmployeeNumber==id).FirstOrDefaultAsync();
        }

        public Task<Employee> UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
