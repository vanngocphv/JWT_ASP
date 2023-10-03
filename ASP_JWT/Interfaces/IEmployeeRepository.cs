using ASP_JWT.Models;

namespace ASP_JWT.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<IEnumerable<Employee>> GetByName(string name);
        Task<Employee> GetById(int id);
        bool Add(Employee employee);
        bool Update(Employee employee);
        bool Delete(Employee employee);
        bool Save();
    }
}
