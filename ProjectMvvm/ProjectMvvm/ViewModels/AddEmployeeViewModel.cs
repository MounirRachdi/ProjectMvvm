using ProjectMvvm.Models;
using ProjectMvvm.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjectMvvm.ViewModels
{
    public class AddEmployeeViewModel : DetailViewModel
    {
        //public ObservableCollection<Employee> Employees { get; set; }
        //public Employee emp;

       
        public int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        public string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string departement;
        public string Departement
        {
            get { return departement; }
            set
            {
                departement= value;
                OnPropertyChanged();
            }
        }
        public ICommand SaveCommand => new Command(async () =>
        {
           Employee emp = new Employee
            {
                Id = Id,
                Name =Name,
                Department = Departement,

            };

            int res = await DataStore.AddAsync(emp);
                EmployeeList.Add(emp);

            Console.Write("result add =  " + res);
            // After adding new entry to database close this page
             var ss = DependencyService.Get<DetailViewModel>() ?? (new DetailViewModel(_nav));

           // await Application.Current.MainPage.Navigation.PopAsync() ;
        });
     


        public AddEmployeeViewModel()
        {
           
        }

        public AddEmployeeViewModel(INavigation nav)
        {
            _nav = nav;
            CurrentPage = DependencyInject<AddEmployee>.Get();
            OpenPage();
           
        }
        
        
    }
}
