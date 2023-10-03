using ASP_JWT.Data;
using ASP_JWT.Interfaces;
using ASP_JWT.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_JWT.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Employee employee)
        {
            _context.Employees.Add(employee);
            return Save();
        }

        public bool Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            return Save();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetByName(string name)
        {
            return await _context.Employees.Where(e => e.EmployeeName.Contains(name)).ToListAsync();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0;
        }

        public bool Update(Employee employee)
        {
            _context.Employees.Update(employee);
            return Save();
        }
    }
}
