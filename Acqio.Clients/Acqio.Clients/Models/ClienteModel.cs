using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acqio.Clients.Models
{
    public class ClienteModel : ViewModel.ViewModelBase
    {
        public int ClienteId { get; set; }
        public int FranquiaId { get; set; }
        public string EmailUsuario { get; set; }
        public System.DateTime DataVisita { get; set; }
        public Nullable<System.DateTime> DataAbertura { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Site { get; set; }
        public Nullable<decimal> QtdePosWiFi { get; set; }
        public Nullable<decimal> QtdePosGPRS { get; set; }
        public Nullable<decimal> MCC { get; set; }
        public string TipoConta { get; set; }
        public string Banco { get; set; }
        public string CodigoBanco { get; set; }
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }
        public string VariacaoOperacao { get; set; }
        public Nullable<decimal> FatMes { get; set; }
        public Nullable<decimal> ValorPos { get; set; }
        public Nullable<decimal> FatPos { get; set; }
        public Nullable<int> QtdeParcSemJuros { get; set; }
        public Nullable<decimal> TaxaAntecipacao { get; set; }
        public Nullable<decimal> TaxaParcela { get; set; }
        public Nullable<decimal> TaxaDebito { get; set; }
        public Nullable<decimal> TaxaCredito { get; set; }
        public string OutrasReceb { get; set; }
    }
}
