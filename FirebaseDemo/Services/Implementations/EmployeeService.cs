using Firebase.Database;
using Firebase.Database.Query;
using FirebaseDemo.Models;
using FirebaseDemo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseDemo.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        FirebaseClient firebase = new FirebaseClient(Setting.FireBaseDatabaseUrl, new FirebaseOptions
        {
            AuthTokenAsyncFactory = () => Task.FromResult(Setting.FireBaseSeceret)
        });

        public async Task<bool> AddOrUpdateEmployee(EmployeeModel employeeModel)
        {
            if (!string.IsNullOrWhiteSpace(employeeModel.Key))
            {
                try
                {
                    await firebase.Child(nameof(EmployeeModel)).Child(employeeModel.Key).PutAsync(employeeModel);
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
            else
            {
                var response = await firebase.Child(nameof(EmployeeModel)).PostAsync(employeeModel);
                if (response.Key != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
         
        }

        public async Task<bool> DeleteEmployee(string key)
        {
            try
            {
                await firebase.Child(nameof(EmployeeModel)).Child(key).DeleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<EmployeeModel>> GetAllEmployee()
        {
            return (await firebase.Child(nameof(EmployeeModel)).OnceAsync<EmployeeModel>()).Select(f => new EmployeeModel
            {
                Email = f.Object.Email,
                FirstName = f.Object.FirstName,
                Gender = f.Object.Gender,
                LastName = f.Object.LastName,
                MobileNumber = f.Object.MobileNumber,
                Position = f.Object.Position,
                Key = f.Key
            }).ToList();

        }
    }
}
