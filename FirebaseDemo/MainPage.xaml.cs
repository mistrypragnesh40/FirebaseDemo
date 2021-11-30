using FirebaseDemo.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirebaseDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void addEmployee_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddUpdateEmployee());
        }

        private void showEmployee_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EmployeeList());
        }
    }
}
