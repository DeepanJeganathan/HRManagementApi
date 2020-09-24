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

        public async Task<bool> CreateAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            
            return await save();
        }

        public async Task<bool> DeleteAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            return await save();
          
        }

        public async Task<bool> EmployeeExists(int EmployeeNumber)
        {
           return await _context.Employees.Where(x => x.EmployeeNumber == EmployeeNumber).AnyAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.Where(x => x.EmployeeNumber==id).FirstOrDefaultAsync();
        }

        public async Task<bool>   save()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
              return await save();
        }
    }
}
