using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalTech.Models
{
    internal class CadastrarFornecedor
    {

        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Representante { get; set; }
        public string Telefone { get; set; }
    }
}
