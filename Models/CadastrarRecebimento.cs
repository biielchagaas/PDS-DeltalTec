using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalTech.Models
{
    internal class CadastrarRecebimento
    {

        public int Id { get; set; } 
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public int Parcela { get;set; }
        public string Status { get; set; }
        public string FormaRecebimento { get; set; }
        public string DataRecebimento { get; set; }

        /*? duvidas olhar script*/

    }
}
