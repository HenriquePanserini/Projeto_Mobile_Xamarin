using AppTol.Controller;
using System.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTol.Views
{
    internal class ConsultaCliente
    {
        public static List<cl_clientes2> clientes;
        public static List<string> nomes;

        public static void Clientes_pesquisa()
        {
            DataTable dados = Query_Exec.EXE_QUERY("SELECT * FROM clientes ORDER BY nome ASC");
            clientes = new List<cl_clientes2>();
            foreach(DataRow linha in dados.Rows)
            {
                clientes.Add(new cl_clientes2()
                {

                    id_clientes = Convert.ToInt32(linha["id_cliente"]),
                    nome = linha["nome"].ToString(),
                    endereco = linha["endereco"].ToString() + ", " + linha["numero"].ToString(),
                    bairro = linha["bairro"].ToString(),
                    cidade = linha["cidade"].ToString() + " " + linha["cep"].ToString(),
                    telefone1 = linha["telefone1"].ToString() + " " + linha["telefone2"].ToString(),
                    celular = linha["celular"].ToString() + " " + linha["contato"].ToString()
                });

                nomes = new List<string>();
                foreach(cl_clientes2 cliente in clientes)
                {
                    nomes.Add("Codigo:       " + cliente.id_clientes +
                              "\nCliente:     " + cliente.nome +
                              "\nEndereço:     " + cliente.endereco +
                              "\nBairro:       " + cliente.bairro + 
                              "\nCidade:       " + cliente.cidade + 
                              "\nTelefones:    " + cliente.telefone1 + "\n" + cliente.celular);
                }
            }
        }


    }
}
