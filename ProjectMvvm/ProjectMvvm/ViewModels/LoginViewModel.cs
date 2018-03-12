using ProjectMvvm.Models;

using ProjectMvvm.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjectMvvm.ViewModels
{
   public class LoginViewModel : BaseViewModel
    {
        public Action DisplayInvalidLoginPrompt;
        public INavigation GotoDetailPage;
        public ObservableCollection<User> users { get; set; }
        public User user;
      
        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }
        public string testlabel;
        public string TestLabel
        {
            get { return testlabel; }
            set
            {
                testlabel = value;
                OnPropertyChanged();
            }
        }

        async void ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                users = new ObservableCollection<User>();
                users.Clear();
                var u = await DataStore1.GetAllAsync();
                foreach (var item in u)
                {
                    users.Add(item);

                }
                int nb = users.Count;
               
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
        public LoginViewModel()
        {
         //   Title = "login";
            //ExecuteLoadItemsCommand();
                

           // CurrentPage = DependencyInject<LoginPage>.Get();
           // OpenPage();
        }
        public LoginViewModel(INavigation nav)
        {
           /// Title = "login";
            _nav = nav;
            CurrentPage = DependencyInject<LoginPage>.Get();
          //  ExecuteLoadItemsCommand();


        }
       
        public ICommand RegistartionCommand => new Command(() =>
        {


            var ss = DependencyService.Get<RegistrationViewModel>() ?? (new RegistrationViewModel(_nav));
           


        });
        public ICommand SubmitCommand => new Command(async () =>
        {
            users = new ObservableCollection<User>();
            users.Clear();
            var u = await DataStore1.GetAllAsync(x => x.Login.Equals(Login) && x.Password.Equals(Password));
         // u.ToList());
            if(u.Count()>0)
            {

                var ss = DependencyService.Get<DetailViewModel>() ?? (new DetailViewModel(_nav));
            }
            else
            { 
                TestLabel = "Invalid Login !!, try again";
            }

         
    
        });

        
           
        
        
    }
}
