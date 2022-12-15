using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using System;
using System.Collections.Generic;
using System.Text;
using AppTol.Views;
using System.Threading.Tasks;


namespace AppTol.Services
{
    internal class NavigationService : INavigationService
    {
        public async System.Threading.Tasks.Task NavigateToClienteLista()
        {
            await AppTol.App.Current.MainPage.Navigation.PushAsync(new Lista_cliente());
        }

        public async System.Threading.Tasks.Task NavigationToAddCliente()
        {
           await AppTol.App.Current.MainPage.Navigation.PushAsync(new Cad_clientePage());
        }

        public async System.Threading.Tasks.Task NavigationToDetailsPage(int ID)
        {
            await AppTol.App.Current.MainPage.Navigation.PushAsync(new Details_cliente());
        }

        public async void PopAsyncService()
        {
            await AppTol.App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
