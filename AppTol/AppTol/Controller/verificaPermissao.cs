using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Essentials;
using AppTol.Models;
using System.IO.Packaging;

namespace AppTol.Controller
{

    internal class verificaPermissao
    {

        public static string recebeUser;

        public interface IDeviceInfo
        {
            string GetOSVersion();

        }

        public async Task<PermissionStatus> CheckPermissionAppAsync()
        {
            //Request Version
            var version = Convert.ToInt32(DependencyService.Get<IDeviceInfo>().GetOSVersion());

            //Resquest and check permission
            var CheckReadStorage = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
            var CheckWriteStorage = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
            var CheckCoarseLocation = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
            var CheckFineLocation = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            var CheckBasePermission = await Permissions.CheckStatusAsync<Permissions.BasePlatformPermission>();

            if (version >= 23)
            {
                await App.Current.MainPage.DisplayAlert("Versao Android incompativel", "Alerta", "Sair");
                return PermissionStatus.Denied;
            }
            else
            {
               
                if(CheckReadStorage == PermissionStatus.Granted &&
                   CheckWriteStorage == PermissionStatus.Granted &&
                   CheckCoarseLocation == PermissionStatus.Granted &&
                   CheckFineLocation == PermissionStatus.Granted &&
                   CheckBasePermission == PermissionStatus.Granted)
                {
                    //Inicio aplicativo
                    await Query_Exec.inicioAplicacaoSync();
                    return PermissionStatus.Granted;
                }
                else
                {
                    
                    await Permissions.RequestAsync<Permissions.StorageRead>();
                    await Permissions.RequestAsync<Permissions.StorageWrite>();
                    await Permissions.RequestAsync<Permissions.LocationAlways>();
                    await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                    await Permissions.RequestAsync<Permissions.BasePlatformPermission>();

                    if(CheckReadStorage == PermissionStatus.Granted &&
                       CheckWriteStorage == PermissionStatus.Granted &&
                       CheckCoarseLocation == PermissionStatus.Granted &&
                       CheckFineLocation == PermissionStatus.Granted &&
                       CheckBasePermission == PermissionStatus.Granted)
                    {
                        await Query_Exec.inicioAplicacaoSync();
                        return PermissionStatus.Granted;
                    }
                    else
                    {
                        return PermissionStatus.Denied;
                        System.Environment.Exit(0);
                    }


                }

            }

        }

    }
}
