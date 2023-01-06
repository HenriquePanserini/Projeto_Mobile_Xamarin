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
            public Int32 telefone { get; set; }
            public DateTime atualizacao { get; set; }
            public string endereco { get; set; }
            public string bairro { get; set; }
            public string cidade { get; set; }
            public Int32 numero { get; set; }
            public Int32 cep { get; set; }
            public Int32 telefone1 { get; set; }
            public Int32 telefone2 { get; set; }
            public Int32 celular { get; set; }
            public Int32 contato { get; set; }
            public Int32 cnpj { get; set; }
            public Int32 ie { get; set; }
            public Int32 cpf { get; set; }
            public Int32 rg { get; set; }
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
