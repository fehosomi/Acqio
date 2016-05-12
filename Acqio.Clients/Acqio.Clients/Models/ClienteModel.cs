using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acqio.Clients.Models
{
    public class ClienteModel : ViewModel.ViewModelBase
    {
        public ObservableCollection<string> StatusList;
        public ObservableCollection<string> TipoContaList;
        public ObservableCollection<string> OutrasRecebList;
        public ObservableCollection<string> UFList;

        public ClienteModel()
        {
            StatusList = new ObservableCollection<string>();
            StatusList.Add("Análise");
            StatusList.Add("Aprovado");
            StatusList.Add("Não Aprovado");
            StatusList.Add("Cancelado");
            
            TipoContaList = new ObservableCollection<string>();
            TipoContaList.Add("Corrente");
            TipoContaList.Add("Poupança");

            OutrasRecebList = new ObservableCollection<string>();
            OutrasRecebList.Add("Boleto");
            OutrasRecebList.Add("Cartão Próprio");

            UFList = new ObservableCollection<string>();

            UFList.Add("AC");
            UFList.Add("AL");
            UFList.Add("AP");
            UFList.Add("AM");   
            UFList.Add("BA");
            UFList.Add("CE");
            UFList.Add("DF");
            UFList.Add("ES");
            UFList.Add("GO");
            UFList.Add("MA");
            UFList.Add("MT");
            UFList.Add("MS");
            UFList.Add("MG");
            UFList.Add("PA");
            UFList.Add("PB");
            UFList.Add("PR");
            UFList.Add("PE");
            UFList.Add("PI");
            UFList.Add("RJ");
            UFList.Add("RN");
            UFList.Add("RS");
            UFList.Add("RO");
            UFList.Add("RR");
            UFList.Add("SC");
            UFList.Add("SP");
            UFList.Add("SE");
            UFList.Add("TO");
        }

        public int ClienteId { get; set; }
        public int FranquiaId { get; set; }
        public string LoginUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Status { get; set; }
        public System.DateTime DataVisita { get; set; }
        public Nullable<System.DateTime> DataAbertura { get; set; }
        public Nullable<System.DateTime> DataProxVisita { get; set; }
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
        public string QtdePosWiFiStr
        {
            get
            {
                if (this.QtdePosWiFi.HasValue)
                {
                    return this.QtdePosWiFi.Value.ToString("f2");
                }
                else
                {
                    return String.Empty;
                }
            }
            set
            {
                decimal decimalValue;
                decimal.TryParse(value, out decimalValue);
                this.QtdePosWiFi = decimalValue;
            }
        }

        public Nullable<decimal> QtdePosGPRS { get; set; }
        public string QtdePosGPRSStr
        {
            get
            {
                if (this.QtdePosGPRS.HasValue)
                {
                    return this.QtdePosGPRS.Value.ToString("f2");
                }
                else
                {
                    return String.Empty;
                }
            }
            set
            {
                decimal decimalValue;
                decimal.TryParse(value, out decimalValue);
                this.QtdePosGPRS = decimalValue;
            }
        }

        public Nullable<decimal> MCC { get; set; }
        public string MCCStr
        {
            get
            {
                if (this.MCC.HasValue)
                {
                    return this.MCC.Value.ToString("f2");
                }
                else
                {
                    return String.Empty;
                }
            }
            set
            {
                decimal decimalValue;
                decimal.TryParse(value, out decimalValue);
                this.MCC = decimalValue;
            }
        }

        public string TipoConta { get; set; }
        public string Banco { get; set; }
        public string CodigoBanco { get; set; }
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }
        public string VariacaoOperacao { get; set; }
        public Nullable<decimal> FatMes { get; set; }
        public string FatMesStr
        {
            get
            {
                if (this.FatMes.HasValue)
                {
                    return this.FatMes.Value.ToString("f2");
                }
                else
                {
                    return String.Empty;
                }
            }
            set
            {
                decimal decimalValue;
                decimal.TryParse(value, out decimalValue);
                this.FatMes = decimalValue;
            }
        }

        public Nullable<decimal> ValorPos { get; set; }
        public string ValorPosStr
        {
            get
            {
                if (this.ValorPos.HasValue)
                {
                    return this.ValorPos.Value.ToString("f2");
                }
                else
                {
                    return String.Empty;
                }
            }
            set
            {
                decimal decimalValue;
                decimal.TryParse(value, out decimalValue);
                this.ValorPos = decimalValue;
            }
        }

        public Nullable<decimal> FatPos { get; set; }
        public string FatPosStr
        {
            get
            {
                if (this.FatPos.HasValue)
                {
                    return this.FatPos.Value.ToString("f2");
                }
                else
                {
                    return String.Empty;
                }
            }
            set
            {
                decimal decimalValue;
                decimal.TryParse(value, out decimalValue);
                this.FatPos = decimalValue;
            }
        }

        public Nullable<int> QtdeParcSemJuros { get; set; }
        public Nullable<decimal> TaxaAntecipacao { get; set; }
        public string TaxaAntecipacaoStr
        {
            get
            {
                if (this.TaxaAntecipacao.HasValue)
                {
                    return this.TaxaAntecipacao.Value.ToString("f2");
                }
                else
                {
                    return String.Empty;
                }
            }
            set
            {
                decimal decimalValue;
                decimal.TryParse(value, out decimalValue);
                this.TaxaAntecipacao = decimalValue;
            }
        }

        public Nullable<decimal> TaxaParcela { get; set; }
        public string TaxaParcelaStr
        {
            get
            {
                if (this.TaxaParcela.HasValue)
                {
                    return this.TaxaParcela.Value.ToString("f2");
                }
                else
                {
                    return String.Empty;
                }
            }
            set
            {
                decimal decimalValue;
                decimal.TryParse(value, out decimalValue);
                this.TaxaParcela = decimalValue;
            }
        }

        public Nullable<decimal> TaxaDebito { get; set; }
        public string TaxaDebitoStr
        {
            get
            {
                if (this.TaxaDebito.HasValue)
                {
                    return this.TaxaDebito.Value.ToString("f2");
                }
                else
                {
                    return String.Empty;
                }
            }
            set
            {
                decimal decimalValue;
                decimal.TryParse(value, out decimalValue);
                this.TaxaDebito = decimalValue;
            }
        }

        public Nullable<decimal> TaxaCredito { get; set; }
        public string TaxaCreditoStr
        {
            get
            {
                if (this.TaxaCredito.HasValue)
                {
                    return this.TaxaCredito.Value.ToString("f2");
                }
                else
                {
                    return String.Empty;
                }
            }
            set
            {
                decimal decimalValue;
                decimal.TryParse(value, out decimalValue);
                this.TaxaCredito = decimalValue;
            }
        }

        public string OutrasReceb { get; set; }
        public string RepNome { get; set; }
        public Nullable<System.DateTime> RepDataNascimento { get; set; }
        public string RepNomeMae { get; set; }
        public string RepRG { get; set; }
        public string RepEmissor { get; set; }
        public Nullable<System.DateTime> RepDataExped { get; set; }
        public string RepCPF { get; set; }
        public string RepProfissao { get; set; }
        public string RepEstadoCivil { get; set; }
        public string RepNomeConjuge { get; set; }
        public string RepEndereco { get; set; }
        public string RepNumero { get; set; }
        public string RepComplemento { get; set; }
        public string RepBairro { get; set; }
        public string RepCidade { get; set; }
        public string RepEstado { get; set; }
        public string RepCEP { get; set; }
        public string RepTelefone { get; set; }
        public string RepCelular { get; set; }
        public string RepEmail { get; set; }
    }
}
