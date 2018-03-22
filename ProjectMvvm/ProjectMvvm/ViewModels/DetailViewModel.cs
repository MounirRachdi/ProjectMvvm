using ProjectMvvm.Models;
using ProjectMvvm.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjectMvvm.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private Employee OldEmp;

        public ObservableCollection<Employee> Employees;
       public ICommand SearchCommand { protected set; get; }
        public ICommand LoadItemsCommand { get; set; }
        public ICommand EditEmployeeCommand { get; private set; }
        
        public ObservableCollection<Employee> EmployeeList
        {
            get
            {

                return Employees ?? (Employees = new ObservableCollection<Employee>()); 
            }
            set
            {
                //Employees = value;
                //OnPropertyChanged("EmployeeList");
                SetProperty(ref Employees, value);
            }
        }
       
        public DetailViewModel(INavigation nav)
        {

             ExecuteLoadEmployeeCommand();
                LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand()); 
                
            
            
            _nav = nav; 
            CurrentPage = DependencyInject<DetailsPage>.Get();
            OpenPage();
          

        }


        public DetailViewModel()
        {
          
                ExecuteLoadEmployeeCommand();
                LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            
            
        
        }

        async Task ExecuteLoadItemsCommand()
        {
           if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                EmployeeList.Clear();
                var employees = await DataStore.GetAllAsync();
                foreach (var item in employees)
                {
                    EmployeeList.Add(item);
                   
                }
                
                int nb = EmployeeList.Count;
                Console.WriteLine("Employee Number=  " +nb);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async void ExecuteLoadEmployeeCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                EmployeeList.Clear();
                var employees = await DataStore.GetAllAsync();
                foreach (var item in employees)
                {
                    EmployeeList.Add(item);

                }
                int nb = EmployeeList.Count;
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
                
            }
        }

        

             
        
               
        public ICommand AddEmployeeCommand => new Command(() =>
        {

            var ss = DependencyService.Get<AddEmployeeViewModel>() ?? (new AddEmployeeViewModel(_nav));




        });
       
        public void ShoworHiddenEmployee(Employee emp)
        {
            if (OldEmp == emp)
            {
                emp.IsVisible = !emp.IsVisible;
                UpDateEmployee(emp);
            }
            else
            {
                if (OldEmp != null)
                {
                    OldEmp.IsVisible = false;
                    UpDateEmployee(OldEmp);

                }
                emp.IsVisible = true;
                UpDateEmployee(emp);
            }
            OldEmp = emp;
        }

        public void UpDateEmployee(Employee employee)
        {
            if (EmployeeList.Contains(employee))
            {
                var Index = EmployeeList.IndexOf(employee);


                EmployeeList.Remove(employee);

                EmployeeList.Insert(Index, employee);
            }


        }

        public Command<Employee> RemoveCommand
        {
            get
            {

                return new Command<Employee>(async (emp) =>
                {
                  int res= await DataStore.DeleteAsync(emp);
                    EmployeeList.Remove(emp);

                    Console.WriteLine("delete =  " + res);
                });

            }

        }
        public string searchvalue;
        public string SearchValue
        {
            get
            { return searchvalue; }
            set
            {
                SetProperty(ref searchvalue, value);
            }
        }
        
        public ICommand SearchEmpCommand => new Command(async () =>
        {
            var keyword = searchvalue;
            if (IsBusy)
                return;

            IsBusy = true;
            if (string.IsNullOrEmpty(searchvalue))
            {
                EmployeeList.Clear();
                var employees = await DataStore.GetAllAsync();
                foreach (var item in employees)
                {
                    EmployeeList.Add(item);

                }
            }
            else
            {
                try
                {

                    EmployeeList.Clear();
                    IEnumerable<Employee> searchresult = await DataStore.GetAllAsync(x => x.Name.ToLower().Contains(SearchValue.ToLower()));
                    foreach (var item in searchresult)
                    {
                        EmployeeList.Add(item);

                    }
                    
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsBusy = false;

                }
            }
            
        });
        

          public Command<Employee> EditCommand
          {
              get
              {

                  return new Command<Employee>((emp) =>
                  {
                      

                      var ss = DependencyService.Get<EditEmployee>() ?? (new EditEmployee(emp,_nav));

                  });

              }

          }
    }
}
