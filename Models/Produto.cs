using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalTech.Models
{
    internal class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataFabricao { get; set; }
        public DateTime? DataValidade { get; set; }

        public string CodigoBarras { get; set; }

        public double Valor {  get; set; }

    }
}
