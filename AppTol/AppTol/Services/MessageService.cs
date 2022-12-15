using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppTol.Services
{
    internal class MessageService : IMesssageService
    {

        public async System.Threading.Tasks.Task ShowAsync(string message)
        {
            await AppTol.App.Current.MainPage.DisplayAlert("Clientes", message, "OK");
        }

        public async System.Threading.Tasks.Task ShowAsync(string tittle, string message, string text)
        {
            await AppTol.App.Current.MainPage.DisplayAlert(tittle, message, text);
        }

        public async System.Threading.Tasks.Task ShowAsync(string tittle, string message, string text1, string text2)
        {
            await AppTol.App.Current.MainPage.DisplayAlert(tittle, message, text1, text2);
        }

        public async Task<bool> ShowAsyncBool(string tittle, string message, string text1, string text2)
        {
            return await AppTol.App.Current.MainPage.DisplayAlert(tittle, message, text1, text2);
        }

    }
}
