using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalTech.Models
{
    internal class Orcamento
    {

        public int Id { get; set; }
        public double Valor { get; set; }
        public string PacienteOrcamento { get; set; }
        public string FuncionarioOrcamento { get; set; }
        public string Descricao { get; set; }
        public Paciente Paciente { get; set; }
        public Funcionario Funcionario { get; set; }


        //escreva o resto que falta
    }
}
