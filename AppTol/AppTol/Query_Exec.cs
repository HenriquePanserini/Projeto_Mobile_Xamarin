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
using SQLitePCL;
using System.Data;
using Mono.Data.Sqlite;

namespace AppTol
{
    public partial class Query_Exec
    {

        static string pasta_dados;
        static string base_dados;
        static SqliteConnection conexao;
        static SqliteCommand comando;
        static SqliteDataAdapter adapter;
        static DataTable dados;

        public static async Task inicioAplicãcaoSync()
        {

            pasta_dados = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "Vendas");

            if (!Directory.Exists(pasta_dados))
            {
                Directory.CreateDirectory(pasta_dados);
            }

            base_dados = pasta_dados + @"/dados.db";

            if (!File.Exists(base_dados))
            {

                SqliteConnection.CreateFile(base_dados);

                conexao = new SqliteConnection("Data Source = " + base_dados);
                conexao.Open();

                comando = new SqliteCommand();
                comando.Connection = conexao;

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

                //Lista de Produtos Vendidos (Tabela temporario)
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

                //Vendas
                comando.CommandText =
                    "CREATE TABLE vendas(" +
                    "id_pedido INTERGER not null primary key ," +
                    "id_cliente INTEGER not null ," +
                    "nome NVARCHAR(70) ," +
                    "id_pgto INTEGER ," +
                    "desconto DECIMAL(10,2) ," +
                    "total DECIMAL(10,2) ," +
                    "data DATETIME)";
                comando.ExecuteNonQuery();

                //Backup dos produtos
                comando.CommandText =
                    "CREATE TABLE vendasprd_BKP(" +
                    "id_pedido INTEGER ," +
                    "id_produto INTEGER ," +
                    "descricao NVARCHAR(30) ," +
                    "quantidade DECIMAL(10,2) ," +
                    "preco DECIMAL(10,2) ," +
                    "desconto DECIMAL(10,2) ," +
                    "precodesconto DECIMAL(10,2) ," +
                    "total DECIMAL(10,2))";
                comando.CommandText =
                    "CREATE TABLE vendas_BKP(" +
                    "id_pedido INTEGER ," +
                    "id_cliente INTEGER ," +
                    "nome NVARCHAR(30) ," +
                    "id_pgto INTEGER ," +
                    "desconto DECIMAL(10,2) ," +
                    "total DECIMAL(10,2) ," +
                    "data DATETIME)";
                comando.ExecuteNonQuery();

                //sincronizar dados
                comando.CommandText =
                    "CREATE TABLE sincronizar(" +
                    "id_seq INTEGER not null default 0 ," +
                    "data DATETIME)";
                comando.ExecuteNonQuery();

                comando.CommandText =
                    "CREATE TABLE IF NOT EXISTS usuario(" +
                    "id_usuario INTEGER NOT NULL primary key ," +
                    "nome NVARCHAR(30) ," +
                    "senha NVARCHAR(15))";


                List<SQLite3_parametros> SQLparametros = new List<SQLite3_parametros>();

                SQLparametros.Add(new SQLite3_parametros("@id_pagamento", 2));
                SQLparametros.Add(new SQLite3_parametros("@descricao", "30 dias"));
                SQLparametros.Add(new SQLite3_parametros("@dias", 0));

                NOM_QUERY(
                    "INSERT INTO pagamento (id_pagamento, descricao) values (" +
                    "@id_pagamento ," +
                    "@descricao);", SQLparametros);

                conexao.Clone();
                conexao.Dispose();

            }
            else
            {

                conexao = new SqliteConnection("Data Source = " + base_dados);
                conexao.Open();

                comando = new SqliteCommand();
                comando.Connection = conexao;

                EXE_QUERY("SELECT * FROM parametro");

                //Tabela de backup de lista de produtos vendidos
                comando.CommandText =
                    "CREATE TABLE IF NOT EXISTS vendasprd_BKP(" +
                    "id_pedido INTEGER ," +
                    "id_produto INTEGER ," +
                    "descricao NVARCHAR(30) ," +
                    "quantidade DECIMAL(10,2) ," +
                    "preco DECIMAL(10,2) ," +
                    "desconto DECIMAL(10,2) ," +
                    "precodesconto DECIMAL(10,2) ," +
                    "total DECIMAL(10,2))";
                comando.ExecuteNonQuery();

                //Tabela de backup de vendas
                comando.CommandText =
                    "CREATE TABLE IF NOT EXISTS vendas_BKP( " +
                    "id_pedido INTEGER ," +
                    "id_produto INTEGER ," +
                    "nome NVARCHAR(30) ," +
                    "id_pgto INTEGER ," +
                    "desconto DECIMAL(10,2) ," +
                    "total DECIMAL(10,2) ," +
                    "data DATETIME)";
                comando.ExecuteNonQuery();

                if (dados.Columns.Contains("usuario"))
                {

                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("usuario"));

                }
                else
                {
                    comando.CommandText = " ALTER TABLE parametro ADD usuario NVARCHAR(100) ";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("senha"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("senha"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE parametro ADD senha NVARCHAR(50)";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("smtp"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("smtp"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE parametro DD smtp NVARCHAR(50)";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("vendedor"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("vendedor"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE parametro ADD vendedor NVARCHAR(50)";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("caminholocal"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("caminholocal"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE parametro ADD caminholocal NVARCHAR(40)";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("vendasdesc"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("vendasdesc"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE parametro ADD vendasdesc INTEGER";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("login"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("login"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE parametro ADD login INTEGER";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("banco"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("banco "));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE parametro ADD banco NVARCHAR(40)";
                    comando.ExecuteNonQuery();
                }

                comando.CommandText =
                    "CREATE TABLE IF NOT EXISTS usuario(" +
                    "id_usuario INTEGER NOT NULL primary key ," +
                    "nome NVARCHAR(30) ," +
                    "senha NVARCHAR(15))";
                comando.ExecuteNonQuery();

                dados = EXE_QUERY("SELECT * FROM clientes");

                if (dados.Columns.Contains("endereco"))
                {

                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("endereco"));

                }
                else
                {
                    comando.CommandText = "ALTER TABLE clientes ADD endereco NVARCHAR(100)";
                    comando.ExecuteNonQuery();
                }

                if(dados.Columns.Contains("bairro"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("bairro"));
                }
                else
                {
                    comando.CommandText = " ALTER TABLE clientes ADD bairro NVARCHAR(50)";
                    comando.ExecuteNonQuery();
                }

                if(dados.Columns.Contains("cidade")) 
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("cidade"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE clientes ADD cidade NVARCHAR(50)";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("numero"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("numero"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE clientes ADD numero NVARCHAR(50)";
                    comando.ExecuteNonQuery();
                }

                if(dados.Columns.Contains("cep"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("cep"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE clientes ADD cep NVARCHAR(50)";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("telefone1"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("telefone1"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE clientes ADD telefone1 NVARCHAR(20)";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("telefone2"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("telefone2"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE clientes ADD telefone2 NVARCHAR(20)";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("celular"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("celular"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE clientes ADD celular NVARCHAR(20)";
                    comando.ExecuteNonQuery();

                }

                if (dados.Columns.Contains("contato"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("contato"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE clientes ADD contato NVARCHAR(20)";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("email"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("email"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE clientes ADD email NVARCHAR(50)";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("cnpj"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("cnpj"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE clientes ADD cnpj NVARCHAR(50);";
                    comando.ExecuteNonQuery();

                }

                if (dados.Columns.Contains("ie"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("ie"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE clientes ADD ie NVARCHAR(50)";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("cpf"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("cpf"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE clientes ADD cpf NVARCHAR(50)";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("rg"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("rg"));
                }
                else 
                {
                    comando.CommandText = "ALTER TABLE clientes ADD rg NVARCHAR(50)";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("novo"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("novo"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE clientes ADD novo INTEGER";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("fantasia"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("fantasia"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE clientes ADD fantasia NVARCHAR(50)";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("email"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("email"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE clientes ADD email NVARCHAR(60)";
                    comando.ExecuteNonQuery();
                }

                if(dados.Columns.Contains("estado"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("estado"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE clientes ADD estado NVARCHAR(30)";
                    comando.ExecuteNonQuery();
                }

                if (dados.Columns.Contains("vend"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("vend"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE clientes ADD vend NVARCHAR(30) ";
                    comando.ExecuteNonQuery();
                }

                DataTable dados1;
                dados1 = Query_Exec.EXE_QUERY("SELECT * FROM Produsos");

                if (dados1.Columns.Contains("codbar"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("codbar"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE Produtos ADD codbar NVARCHAR(16)";
                    comando.ExecuteNonQuery();
                }

                if (dados1.Columns.Contains("preco2"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("codbar"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE Produtos ADD preco2 DECIMAL(10,2)";
                    comando.ExecuteNonQuery();
                }

                if (dados1.Columns.Contains("preco3"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("preco3"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE Produtos ADD preco3 DECIMAL(10,2)";
                    comando.ExecuteNonQuery();
                }

                if (dados1.Columns.Contains("preco4"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("preco4"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE Produtos ADD preco4 DECIMAL(10,2)";
                    comando.ExecuteNonQuery();
                }

                if (dados1.Columns.Contains("descapp"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("descapp"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE Produtos ADD descapp DECIMAL(5,2)";
                    comando.ExecuteNonQuery();
                }

                if (dados1.Columns.Contains("uni"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("uni"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE Produtos ADD uni NVARCHAR(4)";
                    comando.ExecuteNonQuery();
                }

                if (dados1.Columns.Contains("qtd"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("qtd"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE Produtos ADD qtd NVARCHAR(5)";
                    comando.ExecuteNonQuery();
                }

                if (dados1.Columns.Contains("custo"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("custo"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE Produtos ADD custo DECIMAL(10,2)";
                    comando.ExecuteNonQuery();
                }

                DataTable dados2x;
                dados2x = EXE_QUERY("SELECT * FROM vendasprd");

                if (dados2x.Columns.Contains("nrovendabco"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("nrovendabco"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE vendasprd ADD nrovendabco INTEGER";
                    comando.ExecuteNonQuery();
                }

                DataTable dados2y;
                dados2y = EXE_QUERY("SELECT * FROM vendas");

                if (dados2y.Columns.Contains("datasincro"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("datasincro"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE vendas ADD datasincro DATETIME";
                    comando.ExecuteNonQuery();
                }

                if (dados2y.Columns.Contains("id_formapgto"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("id_formapgto"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE vendas ADD id_formapgto INTEGER ";
                    comando.ExecuteNonQuery();
                }

                if (dados2y.Columns.Contains("tipopagto"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("tipopagto"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE vendas ADD tipopagto NVARCHAR(15)";
                    comando.ExecuteNonQuery();
                }

                if (dados2y.Columns.Contains("nrovendabco"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("nrovendabco"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE vendas ADD nrovendabco INTEGER ";
                    comando.ExecuteNonQuery();
                }

                if (dados2y.Columns.Contains("checar"))
                {
                    Console.WriteLine("Campo em banco de dados ja existe" + dados.Columns.Contains("checar"));
                }
                else
                {
                    comando.CommandText = "ALTER TABLE vendas ADD checar INTEGER";
                    comando.ExecuteNonQuery();
                }
            }

        }

        public static void NOM_QUERY(string query, List<SQLite3_parametros> parametros)
        {

            conexao = new SqliteConnection("Data source = " + base_dados);
            conexao.Open();
            comando = new SqliteCommand(query, conexao);
            comando.CommandText = query.Trim();

            foreach(SQLite3_parametros parametro in parametros)
            {
                comando.Parameters.Add(new SqliteParameter(parametro.nome, parametro.valor));
            }
            comando.ExecuteNonQuery();

            comando.Dispose();
            conexao.Clone();
            conexao.Dispose();
        }

        public static DataTable EXE_QUERY(string query, List<SQLite3_parametros> parametros)
        {

            conexao = new SqliteConnection("Data Source = " + base_dados);
            conexao.Open();

            adapter = new SqliteDataAdapter(query, conexao);

            comando = new SqliteCommand(query, conexao);

            foreach (SQLite3_parametros parametro in parametros)
            {

                adapter.SelectCommand.Parameters.Add(new SqliteParameter(parametro.nome, parametro.valor));


            }

            dados = new DataTable();
            adapter.Fill(dados);
            return dados;

        }

        public static DataTable EXE_QUERY(string query)
        {

            conexao = new SqliteConnection("Data Source = " + base_dados);
            conexao.Open();

            adapter = new SqliteDataAdapter(query, conexao);

            comando = new SqliteCommand(query, conexao);

            dados = new DataTable();
            adapter.Fill(dados);
            return dados;

        }
    }
}
