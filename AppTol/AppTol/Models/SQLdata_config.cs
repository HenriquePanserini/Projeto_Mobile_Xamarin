using DocumentFormat.OpenXml.InkML;
using SQLite;
using System;
using System.Runtime.CompilerServices;

namespace AppTol.Models
{
    public class data_config
    {
        [Table("clientes")]
        public class cliente
        {
            [PrimaryKey, AutoIncrement]
            public int id_cliente { get; set; }
            public string nome { get; set; }
            public string telefone { get; set; }
            public DateTime atualizacao { get; set; }
            public string endereco { get; set; }
            public string bairro { get; set; }
            public string cidade { get; set; }
            public string numero { get; set; }
            public string cep { get; set; }
            public string telefone1 { get; set; }
            public string telefone2 { get; set; }
            public string celular { get; set; }
            public string contato { get; set; }
            public string cnpj { get; set; }
            public string ie { get; set; }
            public string cpf { get; set; }
            public string rg { get; set; }
            public string novo { get; set; }
            public string fantasia { get; set; }
            public string email { get; set; }

        }

        [Table("receber")]
        public class SQLdata_receber
        {

            [PrimaryKey, AutoIncrement]
            public Int32 id_titulo { get; set; }
            public string titulo { get; set; }
            public DateTime emissao { get; set; }
            public DateTime vencimento { get; set; }
            public Decimal valor { get; set; }
            
        }

        
    }
}
