using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppTol.Services
{
    public interface IMesssageService
    {

            System.Threading.Tasks.Task ShowAsync(string message);
            System.Threading.Tasks.Task ShowAsync(string tittle, string message, string text1);
            System.Threading.Tasks.Task ShowAsync(string tittle, string messagem, string text1, string text2);
            Task<bool> ShowAsyncBool(string tittle, string message, string text1, string text2);
       
    }


}
