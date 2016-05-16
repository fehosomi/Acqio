using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Acqio.Clients.Views
{
    public partial class ClienteDadosComerciaisView : ContentPage
    {
        public ClienteDadosComerciaisView()
        {
            InitializeComponent();
            this.BindingContext = ClienteView.ClienteModel;

            this.pcrOutras.ItemsSource = ClienteView.ClienteModel.OutrasRecebList;
            this.pcrOutras.SelectedItem = ClienteView.ClienteModel.OutrasReceb;
            this.pcrOutras.SelectedIndexChanged += PcrOutras_SelectedIndexChanged;
        }

        private void PcrOutras_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClienteView.ClienteModel.OutrasReceb = this.pcrOutras.Items[this.pcrOutras.SelectedIndex];
        }
    }
}
