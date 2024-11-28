using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalTech.Models
{
    internal class CadastrarCaixa
    {

        public string Id { get; set; }
        public DateTime Abertura { get; set; }
        public DateTime Fechamento { get; set;}
        public double SaldoInicial { get; set; }
        public double Troco { get; set; }
        public double ValorCreditos { get; set; }
        public double ValorDesconto { get; set; }
        public double SaldoFinal { get; set; }
        public string Status { get;}
    }
}
