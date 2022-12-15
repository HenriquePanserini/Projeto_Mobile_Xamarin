using System;
using System.Collections.Generic;
using System.Text;
using static AppTol.Models.data_config;
using AppTol.Helpers;

namespace AppTol.Services
{
    public class ClienteRepositorio : IClienteRepositorio
    {

        DatabaseHelper _DatabaseHelper;
        public ClienteRepositorio()
        {
            _DatabaseHelper = new DatabaseHelper();
        }

        public void DeleteAllCliente()
        {   
            _DatabaseHelper.DeleteAllClientes();
        }

        public void DeleteCliente(int IDCliente)
        {
            _DatabaseHelper.DeletePedido(IDCliente);
        }

        public List<cliente> GetAllClienteData()
        {
            return _DatabaseHelper.GetAllClienteData();
        }

        public cliente GetClienteData(int IDCliente)
        {
            return _DatabaseHelper.GetClienteData(IDCliente);
        }

        public void InsertCliente(cliente cliente)
        {
            _DatabaseHelper.InsertCliente(cliente);
        }

        public void UpdateCliente(cliente cliente)
        {
            _DatabaseHelper.UpdateCliente(cliente);
        }
    }
}
