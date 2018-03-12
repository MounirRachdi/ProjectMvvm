using ProjectMvvm.Models;
using ProjectMvvm.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectMvvm.ViewModels
{
    public class EditEmployee: BaseViewModel
    {
        //public List<Employee> employees { get; set; }
        public EditEmployee(Employee emp, INavigation nav)
        {
           
            Id = emp.Id;
            Name = emp.Name;
            Departement = emp.Department;
            _nav = nav;
            CurrentPage = DependencyInject<EditEmployeePage>.Get();
            OpenPage();
        }
        public EditEmployee()
        {

        }
       
        
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
                departement = value;
                OnPropertyChanged();
            }
        }
        
        public ICommand SaveEditCommand { get; private set; }
        public ICommand SaveCommand => new Command(async () =>
        {

            var emp = (await DataStore.GetAllAsync(e => e.Id == Id)).ToList().First();
           emp.Name = Name;
            emp.Department = Departement;
          int res=  await DataStore.UpdateAsync(emp);
           Console.Write("update result = " + res);
           //await Application.Current.MainPage.Navigation.PopAsync();
           var ss = DependencyService.Get<DetailViewModel>() ?? (new DetailViewModel(_nav));
           
        });
      
       
    }
}
