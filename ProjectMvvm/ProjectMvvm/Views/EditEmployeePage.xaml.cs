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
	public partial class EditEmployeePage : ContentPage
	{
		public EditEmployeePage ()
		{
            BindingContext = new EditEmployee();
            InitializeComponent();
        }
        /*public EditEmployeePage(Employee emp)
        {
           // id.Text=emp.Id.ToString();
            //Name.Text = emp.Name;
            //departement.Text = emp.Department;
           
            InitializeComponent ();
        }*/
	}
}