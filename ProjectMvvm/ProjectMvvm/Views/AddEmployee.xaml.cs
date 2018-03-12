using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMvvm.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectMvvm.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddEmployee : ContentPage
	{
		public AddEmployee ()
		{
            BindingContext = new AddEmployeeViewModel();
			InitializeComponent ();
		}
       /* async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddEmployee", emp);
            // await Navigation.PopToRootAsync();

            await Navigation.PopModalAsync();

        }*/
    }
}