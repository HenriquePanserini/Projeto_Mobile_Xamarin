using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;
using SQLite;
using System.Collections.Generic;
using System.Linq;


namespace AppTol
{
    public partial class Query_Exec
    {

        public const string base_dados = "dados.db";

        public static async Task inicioAplicãcaoSync()
        {

             var pasta_dados = new LocalRootFolder();

            if (!Directory.Exists(pasta_dados.ToString()))
            {
                Directory.CreateDirectory(pasta_dados.ToString());
            }

            

            if (!File.Exists(base_dados))
            {

                var arquivo = pasta_dados.CreateFile(base_dados, CreationCollisionOption.OpenIfExists);


                SQLiteConnection ligacao = new SQLiteConnection(arquivo.Path);
              
                SQLiteCommand comando = new SQLiteCommand(ligacao);
                
                //Receber
                comando.CommandText =
                    "CREATE TABLE receber(" +
                    "titulo NVARCHAR(10) ," +
                    "emissao DATETIME ," +
                    "vencimento DATETIME , " +
                    "valor DECIMAL(10, 2) ," +
                    "nome NVARCHAR(20))";
                comando.ExecuteNonQuery();

                //Dados Cliente
                comando.CommandText =
                    "CREATE TABLE clientes (" +
                    "id_cliente INTEGER not null primary key ," +
                    "nome NVCARCHAR(50) ," +
                    "telefone NVARCHA(20) ," +
                    "atualizacao DATETIME ," +
                    "endereco NVARCHAR(100) ," +
                    "bairro NVARCHAR(50) ," +
                    "cidade NVARCHAR(50) ," +
                    "numero NVARCHAR(10) ," +
                    "cep NVARCHAR(10) ," +
                    "telefone1 NVARCHAR(20) ," +
                    "telefone2 NVARCHAR(20) ," +
                    "celular NVARCHAR(20) ," +
                    "contato NVARCHAR(20) ," +
                    "cnpj NVARCHAR(20) ," +
                    "ie NVARCHAR(20) ," +
                    "cpf NVARCHAR(20) ," +
                    "rg NVARCHAR(20) ," +
                    "novo NVARCHAR(20) ," +
                    "fantasia NVARCHAR(20) ," +
                    "email NVARCHAR(20))";
                comando.ExecuteNonQuery();

                //Criação de parametro
                comando.CommandText =
                    "CREATE TABLE IF NOT EXISTS parametrocli(" +
                    "nome NVARCHAR(80) ," +
                    "endereco NVARCHAR(80) ," +
                    "bairro NVARCHAR(80) ," +
                    "cidade NVARCHAR(60) ," +
                    "fone NVARCHAR(60))";
                comando.ExecuteNonQuery();

                //Lista de Produtos
                comando.CommandText =
                    "CREATE TABLE produtos(" +
                    "id_produto INTEGER not null primary key ," +
                    "descricao NVARCHAR(70) ," +
                    "preco DECIMAL(10,2) ," +
                    "preco2 DECIMAL(10,2) ," +
                    "preco3 DECIMAL(10,2) ," +
                    "preco4 DECIMAL(10,2) ," +
                    "atualizacao DATETIME)";
                comando.ExecuteNonQuery();

                //Tipos de pagamento
                comando.CommandText =
                    "CREATE TABLE pagamento(" +
                    "id_pagamento integer not primary key ," +
                    "descricao NVARCHAR(30))";
                comando.ExecuteNonQuery();

                //Usuarios
                comando.CommandText =
                    "CREATE TABLE usuario(" +
                    "id_usuario integer not null Primary Key ," +
                    "nome NVARCHAR(30) ," +
                    "senha NVARCHAR(15))";
                comando.ExecuteNonQuery();

                //Clientes (Tabela temporaria)
                comando.CommandText =
                    "CREATE TABLE tmp_cliente(" +
                    "id_cliente integer not null ," +
                    "nome NVARCHAR(50))";
                comando.ExecuteNonQuery();

                //Parametro
                comando.CommandText =
                    "CREATE TABLE parametro (" +
                    "id_parametro integer not null primary key ," +
                    "descricao NVARCHAR(30))";
                comando.ExecuteNonQuery();

                //Pagamento (Tabela temporario)
                comando.CommandText =
                    "CREATE TABLE tmp_pagamento(" +
                    "id_pagamento INTEGER not null primary key ," +
                    "decricao NVARCHAR(30))";
                comando.ExecuteNonQuery();

                //Vendas de Produtos
                comando.CommandText =
                    "CREATE TABLE vendasprd(" +
                    "id_pedido INTEGER not null Primary Key ," +
                    "id_produto INTEGER not null ," +
                    "descricao NVARCHAR(70) ," +
                    "quantidade DECIMAL(10,2) ," +
                    "preco DECIMAL(10,2) ," +
                    "desconto DECIMAL(10,2) ," +
                    "precodesconto DECIMAL(10,2) ," +
                    "total DECIMAL(10,2))";
                comando.ExecuteNonQuery();

                //Vendas de Produtos (Tabela temporario)
                comando.CommandText =
                    "CREATE TABLE tmp_vendas_prod(" +
                    "id_produto INTEGER not null Primary Key," +
                    "descricao NVARCHAR(30) ," +
                    "quantidade DECIMAL(10,2) ," +
                    "preco DECIMAL(10,2) , " +
                    "desconto DECIMAL(10,2)" +
                    "precodesconto DECIMAL(10,2)" +
                    "total DECIMAL(10,2))";
                comando.ExecuteNonQuery();

            }

        }

    }
}
