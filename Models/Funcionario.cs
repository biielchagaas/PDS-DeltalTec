using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalTech.Models
{
    internal class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Status { get; set; }
        public string Rg { get; set; }
        public string Expedidor { get; set; }

        public string EstadoCivil { get; set; }
        public string Genero { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public DateTime? DataNascimento { get; set; }
        public string Cep { get; set; }

        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }

        public int Numero { get; set; }

        public DateTime? DataAdmissao { get; set; }
        public string Ctps { get; set; }
        public string Cnh { get; set; }
        public string Senha { get; set; }
    }
}
