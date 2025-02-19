using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalTech.Models
{
    internal class Consulta
    {
        public int Id { get; set; }
        public TimeSpan? Hora { get; set; }
        public DateTime? Data { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }

        public string PacienteConsulta { get; set; }
        public string FuncionarioConsulta { get; set; }

        public Paciente Paciente { get; set; }
        public Funcionario Funcionario { get; set; }
        public Anamnese Anamnese { get; set; }

    }
}
