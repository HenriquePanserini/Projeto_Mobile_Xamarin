using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AppTol.Views;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Wordprocessing;
using FluentValidation.Internal;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppTol.Helpers;
using Xamarin.CommunityToolkit.Extensions;
using System.Threading.Tasks;


namespace AppTol.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUI : ContentPage
    {

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
                   
                    try
                    {
                        MessagingCenter.Send<LoginUI>(this, "Hi");
                        Navigation.PushModalAsync(new MainPage());
                    }
                    catch (Exception ex)
                    {
                        await this.DisplayToastAsync("Erro ao inserir o usuario" + ex.Message, 5000);
                    }

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

            Button_ClickedAsync(sender, e);
            
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            try
            {

                await Navigation.PushModalAsync(new IPconfig());

            }catch(Exception ex)
            {
                await this.DisplayToastAsync("Não foi possivel acessar a paginas: Erro|" + ex.Message.Trim(), 5000);
            }
        }
    }
}