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

        
        public Master()
        {
            InitializeComponent();
            btn_sair.Clicked += Btn_sair_Clicked;
            btn_sinc.Clicked += Btn_sinc_Clicked;

            
        }

        private async void Btn_sinc_Clicked(object sender, EventArgs e)
        {
           


        }

        private async void Btn_sair_Clicked(object sender, EventArgs e)
        {
            bool resposta = await DisplayAlert("Aviso!", "Deseja realmente encerrar o aplicativo", "Yes","No");

            if (resposta){

                System.Environment.Exit(0);

            }
                
            
        }

    }
}