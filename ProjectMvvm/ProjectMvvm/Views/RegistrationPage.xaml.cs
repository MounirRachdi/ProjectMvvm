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
	public partial class RegistrationPage : ContentPage
	{
        RegistrationViewModel rvm;
		public RegistrationPage ()
		{
           this.BindingContext = rvm=new RegistrationViewModel();
            
           rvm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "password incorrect, try again", "OK");
            InitializeComponent ();
		}
        
    }
}