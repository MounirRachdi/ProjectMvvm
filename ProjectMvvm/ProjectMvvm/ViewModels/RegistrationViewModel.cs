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
    public class RegistrationViewModel : BaseViewModel
    {
        public ObservableCollection<User> users { get; set; }
        public User user;
        public Action DisplayInvalidLoginPrompt;

        public int id;
        public int Id
        {
            get { return id; }
            set
            {
                SetProperty(ref id, value);
                
            }
        }
        public string login;
        public string Login
        {
            get { return login; }
            set
            {
                SetProperty(ref login, value);
            }
        }
        public string password;
        public string Password
        {
            get { return password; }
            set
            {
                SetProperty(ref password, value);
            }
        }
        public string password2;
        public string Password2
        {
            get { return password2; }
            set
            {
                SetProperty(ref password2, value);
            }
        }

        public string alerttext;
        public string AlertText
        {
            get { return alerttext; }
            set
            {
                SetProperty(ref alerttext, value);
            }
        }
        public RegistrationViewModel()
        {

          

        }
        
        public RegistrationViewModel(INavigation nav)
        {
            _nav = nav;
            CurrentPage = DependencyInject<RegistrationPage>.Get();
            OpenPage();
           
        }
        public ICommand SaveCommand => new Command(async () =>
        {
            user = new User
            {

                Login = Login,
                Password = Password,


            };
            if (password.Equals(password2))
            {
                int res = await DataStore1.AddAsync(user);
            Console.WriteLine("Add user = " + res);
            if (res == 1)
                await Application.Current.MainPage.Navigation.PopAsync(); 
               
            }
            else
            {
                AlertText = "Please confirm your password";
           }
        });
          
    }
}
