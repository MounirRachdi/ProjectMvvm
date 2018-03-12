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
	public partial class DetailsPage : ContentPage
	{
        
        DetailViewModel viewModel;

        public DetailsPage()
        {
            
            InitializeComponent();
          
            this.BindingContext= viewModel= new DetailViewModel();
           

        }

        
        private void Refresh_ListView()
        {
           
          //  listview1.ItemsSource = viewModel.EmployeeList;
        }
        private void Edit_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var employee = button.BindingContext as Employee;
            var vm = BindingContext as DetailViewModel;
            vm?.EditCommand.Execute(employee);
           
            //Navigation.PushModalAsync(new NavigationPage(new EditEmployeePage(employee)));
        }
        /*protected override void OnAppearing()
        {
            base.OnAppearing();
           
            if (viewModel.EmployeeList.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }*/
       
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

        public void SearchEmpCommand ()
        {
            

        }
        /* public void Search_Employee(object sender, EventArgs e)
         {

             viewModel.SearchEmpCommand.Execute(MainSearchBar.Text);
         }*/

    }
}