using AppTol.Views;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using AppTol.Services;

namespace AppTol
{
    
    public partial class App : Application
    {

        public static FlyoutPage masterDetail { get; set; }
        public IClienteRepositorio _clienteRepositorio;
        public App()
        {
            InitializeComponent();

            DependencyService.Register<IMesssageService, MessageService>();
            DependencyService.Register<INavigationService, NavigationService>();

            //cria uma instancia do repositorio
            _clienteRepositorio = new ClienteRepositorio();

            //invoca o evento
            OnAppStart();

        }

        private async void OnAppStart()
        {
            //Obtem todos os dados
            var getLocalDB = _clienteRepositorio.GetAllClienteData();

            //Acesso para entrar na tela dce login
            try
            {
                MainPage = new NavigationPage(new LoginUI());
            }
            catch(Exception error)
            {
                MessagingCenter.Send<App>(this, "Erro ao acessar o app" + error);
            }
            finally
            {
                _ = MainPage.Clip;
            }
           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
