using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acqio.Clients.Models
{
    public class RepresentanteModel
    {
        public int RepresentanteId { get; set; }
        public int ClienteId { get; set; }
        public string NomeRep { get; set; }
        public Nullable<System.DateTime> DataNascimento { get; set; }
        public string NomeMae { get; set; }
        public string RG { get; set; }
        public string Emissor { get; set; }
        public Nullable<System.DateTime> DataExped { get; set; }
        public string CPF { get; set; }
        public string Profissao { get; set; }
        public string EstadoCivil { get; set; }
        public string NomeConjuge { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
    }
}
