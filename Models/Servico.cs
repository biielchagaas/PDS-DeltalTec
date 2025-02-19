using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalTech.Models
{
    internal class Servico
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }

        public string FuncionarioServico { get; set; }
        public Servico Funcionario { get; set; }


        /*? olhar script*/
    }
}
