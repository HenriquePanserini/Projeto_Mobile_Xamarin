using System;
using System.Collections.Generic;
using System.Text;
using AppTol.Helpers;
using AppTol.Models;
using static AppTol.Models.data_config;

namespace AppTol.Services
{
    public interface IClienteRepositorio
    {

        List<cliente> GetAllClienteData();

        //Obtem um dado especifico por id
        cliente GetClienteData(int IDCliente);

        //Deleta todos os dados
        void DeleteAllCliente();

        //Deleta um dado especifico
        void DeleteCliente(int IDCliente);

        //Insere um novo dado na base de dados
        void InsertCliente(cliente cliente);

        //Atualizar os dados
        void UpdateCliente(cliente cliente);

    }
}
