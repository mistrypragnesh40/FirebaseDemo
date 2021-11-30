using FirebaseDemo.Models;
using FirebaseDemo.Services.Implementations;
using FirebaseDemo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirebaseDemo.ViewModels
{
    public class AddUpdateEmployeePageViewModel : BaseViewModel
    {
        #region Properties
        private readonly IEmployeeService _employeeService;

        private EmployeeModel _employeeDetail = new EmployeeModel();
        public EmployeeModel EmployeeDetail
        {
            get => _employeeDetail;
            set => SetProperty(ref _employeeDetail, value);
        }
        #endregion

        #region Constructor
        public AddUpdateEmployeePageViewModel()
        {
            _employeeService = DependencyService.Resolve<IEmployeeService>();
        }

        public AddUpdateEmployeePageViewModel(EmployeeModel employeeResponse)
        {
            _employeeService = DependencyService.Resolve<IEmployeeService>();
            EmployeeDetail =  new EmployeeModel
            {
                FirstName = employeeResponse.FirstName,
                LastName = employeeResponse.LastName,
                Key = employeeResponse.Key,
                Gender = employeeResponse.Gender,
                Email = employeeResponse.Email,
                MobileNumber =employeeResponse.MobileNumber,
                Position = employeeResponse.Position
            };
        }
        #endregion

        #region Commands
        public ICommand SaveEmployeeCommand => new Command(async () =>
        {
            if (IsBusy) return;
            IsBusy = true;
            bool res = await _employeeService.AddOrUpdateEmployee(EmployeeDetail);
            if (res)
            {
               
                if (!string.IsNullOrWhiteSpace(EmployeeDetail.Key))
                {
                    await App.Current.MainPage.DisplayAlert("Success!", "Record Updated successfully.", "Ok");
                }
                else
                {
                    EmployeeDetail = new EmployeeModel() { };
                    await App.Current.MainPage.DisplayAlert("Success!", "Record added successfully.", "Ok");
                }
            }
            IsBusy = false;
        });
        #endregion
    }
}
