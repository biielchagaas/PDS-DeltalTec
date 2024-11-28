using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalTech.Models
{
    internal class CadastrarConsulta
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }

    }
}
