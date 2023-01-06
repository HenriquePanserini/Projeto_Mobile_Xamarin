using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AppTol.Models;
using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;
using SQLitePCL;
using Xamarin.CommunityToolkit.Extensions;
using ZXing;
using SQLite;

namespace AppTol.Helpers
{
    public class DatabaseHelper : data_config
    {
        static SQLiteConnection liteConect;
        public const string DBFileName = "dados.db";
         
        public DatabaseHelper()
        {
            //cria uma pasta base local  e o nome do banco de dados
            var pasta = new LocalRootFolder();

            //Cria o arquivo
            var arquivo = pasta.CreateFile(DBFileName, CreationCollisionOption.OpenIfExists);

            //abre o base de dados
            liteConect = new SQLiteConnection(arquivo.Path, true);

            //cria tabela no banco de dados
            liteConect.CreateTable<cliente>();
        }

        public List<cliente> GetAllClienteData()
        {
            try
            {
                return (from data in liteConect.Table<cliente>()
                        select data)
                        .ToList();
            } 
            catch (Exception ex) { return null; }
            
        }

        public cliente GetClienteData(int id)
        {
            return liteConect.Table<cliente>().FirstOrDefault(t => t.id_cliente == id);
        }

        public void DeleteAllClientes()
        {
            liteConect.DeleteAll<cliente>();
        }

        public void DeletePedido(int id)
        {
            liteConect.Delete<cliente>(id);
        }

        public void InsertCliente(cliente client)
        {
            liteConect.Insert(client);
        }

        public void UpdateCliente(cliente client)
        {
            liteConect.Update(client);
        }
    
    }
}
