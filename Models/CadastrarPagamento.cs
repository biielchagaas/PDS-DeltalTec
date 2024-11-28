using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalTech.Models
{
    internal class CadastrarPagamento
    {
        public string Id { get; set; }
        public DateTime DataVencimento { get; set; }
        public double Valor { get; set; }
        public int Parcela { get; set; }
        public string Status { get; set; }
        public string FormaPagamento { get; set; }
        public DateTime DataPagamento { get; set; }

    }
}
