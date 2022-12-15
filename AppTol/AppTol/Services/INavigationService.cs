using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTol.Services
{
    internal interface INavigationService
    {
        Task NavigationToAddCliente();
        Task NavigationToDetailsPage(int ID);
        Task NavigateToClienteLista();
        void PopAsyncService();
    }
}
