using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Acqio.Clients.Views
{
    public partial class ClienteDadosEmpresaView : ContentPage
    {
        public ClienteDadosEmpresaView()
        {
            InitializeComponent();
            this.BindingContext = ClienteView.ClienteModel;

            this.pcrUF.Items.Add("AC");
            this.pcrUF.Items.Add("AL");
            this.pcrUF.Items.Add("AP");
            this.pcrUF.Items.Add("AM");
            this.pcrUF.Items.Add("BA");
            this.pcrUF.Items.Add("CE");
            this.pcrUF.Items.Add("DF");
            this.pcrUF.Items.Add("ES");
            this.pcrUF.Items.Add("GO");
            this.pcrUF.Items.Add("MA");
            this.pcrUF.Items.Add("MT");
            this.pcrUF.Items.Add("MS");
            this.pcrUF.Items.Add("MG");
            this.pcrUF.Items.Add("PA");
            this.pcrUF.Items.Add("PB");
            this.pcrUF.Items.Add("PR");
            this.pcrUF.Items.Add("PE");
            this.pcrUF.Items.Add("PI");
            this.pcrUF.Items.Add("RJ");
            this.pcrUF.Items.Add("RN");
            this.pcrUF.Items.Add("RS");
            this.pcrUF.Items.Add("RO");
            this.pcrUF.Items.Add("RR");
            this.pcrUF.Items.Add("SC");
            this.pcrUF.Items.Add("SP");
            this.pcrUF.Items.Add("SE");
            this.pcrUF.Items.Add("TO");
        }
    }
}
