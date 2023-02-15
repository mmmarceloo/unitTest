using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public class VendaTO
    {
        public string Vendedor { get; set; }
        public string Codigo { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        public VendaTO(string vendedor, string codigo, int quantidade, decimal valor, DateTime data)
        {
            Vendedor = vendedor;
            Codigo = codigo;
            Quantidade = quantidade;
            Valor = valor;
            Data = data;
        }
    }
}
