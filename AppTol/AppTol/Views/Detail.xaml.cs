using AppTol.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTol
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detail : ContentPage
    {
        public Detail()
        {
            InitializeComponent();
        }

        private async Task cons_cliente_Clicked(object sender, EventArgs e)
        {
            
            try{
                MessagingCenter.Send(this, "Acesso denied");
                Navigation.PushModalAsync(new )
            }catch(Exception ex)
            {
                
            }
           
        }
    }
}