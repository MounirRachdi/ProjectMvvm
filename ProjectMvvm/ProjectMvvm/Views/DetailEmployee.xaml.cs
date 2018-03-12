using ProjectMvvm.CustomFormElements;
using ProjectMvvm.Models;
using ProjectMvvm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectMvvm.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailEmployee : ModalPage
	{
        EmployeeDetailViewModel viewModel;
        public DetailEmployee ()
		{
			InitializeComponent ();
            var emp = new Employee
            {
                Name = "Ahmed",
                Department = "Sales Departement.",
               

            };

            viewModel = new EmployeeDetailViewModel(emp);
            BindingContext = viewModel;
        }
        public DetailEmployee(EmployeeDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
            
            Name.Text = viewModel.employee.Name;
            Departement.Text = viewModel.employee.Department;
        }

    }
}