using FirebaseDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseDemo.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> AddOrUpdateEmployee(EmployeeModel employeeModel);
        Task<bool> DeleteEmployee(string key);
        Task<List<EmployeeModel>> GetAllEmployee();
    }
}
