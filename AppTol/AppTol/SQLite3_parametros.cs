using System;
using System.Collections.Generic;
using System.Text;

namespace AppTol
{
    public class SQLite3_parametros
    {

        public string nome { get; set; }
        public object valor { get; set; }

        public SQLite3_parametros(string parametro,  object valor)
        {
            this.nome = parametro;
            this.valor = valor;
        }

    }
}
