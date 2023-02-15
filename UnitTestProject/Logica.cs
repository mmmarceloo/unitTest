using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public class Logica
    {
        /// <summary>
        /// Metodo recebe um numero em texto usando separador . como separador de milhar e , como separador decimal
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns></returns>
        internal decimal ConverteStringParaDecimal(string numeroString)
        {
            decimal numero = 0;

            string[] numeroEmString = numeroString.Split('.');
            string textoFormatado = "";

            foreach (var item in numeroEmString)
            {
                textoFormatado += item;
            }
            numero = Convert.ToDecimal(textoFormatado);
            return numero;
        }

        /// <summary>
        /// Metodo recebe uma data em texto no formato dd/MM/yyyy e retorna a data convertida
        /// </summary>
        /// <param name="dataString"></param>
        /// <returns></returns>
        internal DateTime ConverteStringParaData(string dataString)
        {
            string[] dataStringArray = dataString.Split('/');
            DateTime dataFormatada = new DateTime(
                int.Parse(dataStringArray[2]),
                int.Parse(dataStringArray[1]),
                int.Parse(dataStringArray[0]));

            return dataFormatada;
        }

        /// <summary>
        /// Vendedor Gustavo
        /// Código Produto	quantidade    valor total 	     Data venda
        /// ARA-1012	    17 UN          R$ 3.642,17 	         08/04/2021
        /// </summary>
        /// <param name="produtosString"></param>
        /// <returns></returns>
        internal List<VendaTO> ConverteStringParaVendas(string produtosString)
        {
            List<VendaTO> vendaTOs = new List<VendaTO>();
            var produtosArray = produtosString.Split(' ');
            string vendedor = "";
            string codigoDoProduto = "";
            int quantidade = 0;
            decimal valorTotal = 0;
            DateTime DataVenda;

            for (int i = 0; i < produtosArray.Length; i++)
            {
                if (produtosArray[i] != "")
                {
                    if (produtosArray[i] == "Vendedor")
                    {
                       vendedor = produtosArray[i+1].ToString().Trim();
                    }

                    if (Regex.IsMatch(produtosArray[i], @"^[a-zA-Z][a-zA-Z][a-zA-Z][\-][0-9]{3}"))
                    {
                        codigoDoProduto =  produtosArray[i].ToString().Trim();
                    }

                    if (Regex.IsMatch(produtosArray[i], "^[0-9]+$"))
                    {
                        quantidade = ConvertStringParaInt(produtosArray[i]);
                    }

                    if (Regex.IsMatch(produtosArray[i], @"^[0-9]?[0-9]?[0-9]?[.]?[0-9]?[0-9]?[0-9]?[\,][0-9]{2}"))
                    {
                        valorTotal = ConverteStringParaDecimal(produtosArray[i]);
                    }

                    if (Regex.IsMatch(produtosArray[i], @"^[0-9]{2}/[0-9]{2}/[0-9]{4}"))
                    {
                        DataVenda = ConverteStringParaData(produtosArray[i]);
                        vendaTOs.Add(new VendaTO(
                            vendedor,
                            codigoDoProduto,
                            quantidade,
                            valorTotal,
                            DataVenda
                            ));
                    }
                }
            }
            return vendaTOs;
        }

        internal int ConvertStringParaInt(string value)
        {
            return Convert.ToInt32(value);
        }
    }
}
