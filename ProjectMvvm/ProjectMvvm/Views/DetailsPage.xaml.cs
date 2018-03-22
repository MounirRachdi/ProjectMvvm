using ProjectMvvm.Models;
using ProjectMvvm.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectMvvm.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailsPage : ContentPage
	{
        
        DetailViewModel viewModel;

        public DetailsPage()
        {
            
            InitializeComponent();
          
            this.BindingContext= viewModel= new DetailViewModel();
           

        }

        
       
        private void Edit_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var employee = button.BindingContext as Employee;
            var vm = BindingContext as DetailViewModel;
            vm?.EditCommand.Execute(employee);
           
            
        }
      
       
        private void listview1_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var emp = e.Item as Employee;

            var vm = BindingContext as DetailViewModel;

            vm?.ShoworHiddenEmployee(emp);
        }

       

        private void Remove_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var employee = button.BindingContext as Employee;
            var vm = BindingContext as DetailViewModel;
            vm?.RemoveCommand.Execute(employee);
            

        }
        private void Detail_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var employee = button.BindingContext as Employee;
            var vm = BindingContext as DetailViewModel;

           Navigation.PushModalAsync(new DetailEmployee(new EmployeeDetailViewModel(employee)));

        }

        public void Search_Employee (object sender, TextChangedEventArgs e)
        {
            if (MainSearchBar.Text!=string.Empty || MainSearchBar.Text!="")
            {
            
                try
            {
                viewModel.Employees.Clear();
                IEnumerable<Employee> searchresult = viewModel.DataStore.GetAllAsync(x => x.Name.ToLower().Contains(MainSearchBar.Text.ToLower())).Result.ToList();
                foreach (var item in searchresult)
                {
                    viewModel.Employees.Add(item);

                }
            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                
                listview1.ItemsSource = viewModel.EmployeeList;
            }
               }
            else
            {
                viewModel.ExecuteLoadEmployeeCommand();
                BindingContext = viewModel;
            }
        }
      

    }
}