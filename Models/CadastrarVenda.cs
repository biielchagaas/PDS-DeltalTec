using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalTech.Models
{
    internal class CadastrarVenda
    {

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public double Desconto { get; set; }
        public string FormaRecebimento { get; set; }
        public int Parcelas { get; set; }

    }
}
