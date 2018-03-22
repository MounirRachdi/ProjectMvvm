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

        private readonly IDependencyService _dependencyService;

        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                
                SetProperty(ref _login, value);
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
                SetProperty(ref password, value);
            }
        }
        public string testlabel;
     //   private DependencyServiceWrapper dependencyServiceWrapper;

        public string TestLabel
        {
            get { return testlabel; }
            set
            {
                SetProperty(ref testlabel, value);
            }
        }

        
        public LoginViewModel(): this(new DependencyServiceWrapper())
        {
         
        }
        public LoginViewModel(INavigation nav)
        {
           
            _nav = nav;
            CurrentPage = DependencyInject<LoginPage>.Get();
         


        }

        public LoginViewModel(IDependencyService dependencyService)
        {
            _dependencyService=dependencyService;
        }

        public ICommand RegistartionCommand => new Command(() =>
        {


            var ss = DependencyService.Get<RegistrationViewModel>() ?? (new RegistrationViewModel(_nav));
           


        });
        public ICommand SubmitCommand //new Command(async () =>
        {

            get
            {
                return new Command(async () =>
                { 
                var u = await DataStore1.GetAllAsync(x => x.Login.Equals(Login) && x.Password.Equals(Password));

                if (u.Count() > 0)
                {

                    var ss = DependencyService.Get<DetailViewModel>() ?? (new DetailViewModel(_nav));
                }
                else
                {
                    await CurrentPage.DisplayAlert("Error", "Invalid Login, try again", "OK");
                }



            }); }
}
        
           
        
        
    }
}
