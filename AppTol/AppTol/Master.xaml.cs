using Android.OS;
using DocumentFormat.OpenXml.Drawing;
using SendGrid.Helpers.Mail;
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
    public partial class Master : ContentPage
    {
        public Button buttonUser;
        public Button buttonSincro;
        public Button buttonCad;
        public Button buttonLimp;
        public Button buttonSair;

        Master master = new Master();
        public Master()
        {
            InitializeComponent();  
        }

        protected void Create()
        {
            buttonSair = master.FindByName<Button>("btn_sair");
            buttonSair.Clicked += ButtonSair_Clicked;

            buttonSincro = master.FindByName<Button>("btn_sinc");
            buttonSincro.Clicked += ButtonSincro_Clicked;
        }

     
  
        private void ButtonSincro_Clicked(object sender, EventArgs e)
        {
            
        }

        private async void ButtonSair_Clicked(object sender, EventArgs e)
        {
            bool resposta = await DisplayAlert("Aviso!", "Deseja mesmo encerrar o aplicativo", "Yes", "No");

            if (resposta = false)
            {

                System.Environment.Exit(0);

            }
            
        }

    }
}