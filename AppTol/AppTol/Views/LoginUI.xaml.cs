using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AppTol.Controller;
using AppTol.Views;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Wordprocessing;
using FluentValidation.Internal;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTol.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUI : ContentPage
    {

        verificaPermissao permissao = new verificaPermissao();
        
        public LoginUI()
        {
            
            InitializeComponent();

        }


        public async Task TapGestureRecognizer_TappedAsync(object sender, EventArgs e)
        {

        }

        public async Task Button_ClickedAsync(object sender, EventArgs e)
        {
            
            try
            {
                var contentPage = new ContentPage();
                var Enter_User = Entry_user.Text.ToString();
                var Enter_Pass = Entry_pass.Text.ToString();

                if (Enter_User.ToString() != string.Empty && Enter_Pass.ToString() != string.Empty)
                {
                    MessagingCenter.Send<LoginUI>(this, "Hi");
                    Query_Exec.inicioAplicacaoSync();
                    await Navigation.PushModalAsync(new MainPage());

                }
                else
                {
                    MessagingCenter.Send<LoginUI>(this, "Usuario ou senha invalida");
                    Enter_User = string.Empty;
                    Enter_Pass = string.Empty;
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Alerta!","Erro ao acessar o aplicativo","Ok");
            }                
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            permissao.CheckPermissionAppAsync();
            Button_ClickedAsync(sender, e);
            
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}