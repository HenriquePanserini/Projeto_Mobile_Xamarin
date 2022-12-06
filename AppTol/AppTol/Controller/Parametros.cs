using System;
using System.Collections.Generic;
using System.Text;

namespace AppTol.Controller
{
    public class SQLite3_parametros
    {

        public string nome { get; set; }
        public object valor { get; set; }

        public SQLite3_parametros(string parametro, object valor)
        {
            nome = parametro;
            this.valor = valor;
        }

    }

    public class vars
    {

        public static int numerocliente, numeroproduto, nropgto, pedidoselecionado, pedidoselecionadodet, numeropedidosalvo, numeropedidosalvol, numerovendedor, nbarra, npedidoemail, npedidoaltera, numeropedidosalvo_or, parvenda, numeroseqsalvo;
        public static int gerentesn, maxlinhas, parusuario;
        public static string nomeproduto, nomeclientesel, pedidoorcamento;
        public static decimal precoproduto, precoproduto2, precoproduto3, precoproduto4, quantidadeproduto, precoprodutodesc, totalproduto, desconto, descontoprod, descontovendedor;
        public static bool pedis, alterarped, flagmeiopedido, dupliped, web_local;
        public static string nomeemp, enderecoemp, bairroemp, cidadeemp, foneemp, obspedx;

    }

    public class cl_clientes2
    {
        public int id_clientes { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string nro { get; set; }
        public string cep { get; set; }
        public string telefone1 { get; set; }
        public string telefone2 { get; set; }
        public string celular { get; set; }
        public string contato { get; set; }
    }
}
