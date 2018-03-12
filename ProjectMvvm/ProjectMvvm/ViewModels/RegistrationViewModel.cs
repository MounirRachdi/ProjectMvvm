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
                id = value;
                OnPropertyChanged();
            }
        }
        public string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }
        public string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }
        public string password2;
        public string Password2
        {
            get { return password2; }
            set
            {
                password2 = value;
                OnPropertyChanged();
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

           int res= await DataStore1.AddAsync(user);
            Console.WriteLine("Add user = " + res);
            if(res==1)
            await Application.Current.MainPage.Navigation.PopAsync();
        });
          
    }
}
