using FirebaseDemo.Services.Implementations;
using FirebaseDemo.Services.Interfaces;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirebaseDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new  MainPage());

            DependencyService.Register<IEmployeeService, EmployeeService>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
