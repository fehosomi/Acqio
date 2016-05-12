using System;

using Xamarin.Forms;

namespace Acqio.Clients.Views
{
    public partial class ClienteDadosBancoView : ContentPage
    {
        public ClienteDadosBancoView()
        {
            InitializeComponent();
            this.BindingContext = ClienteView.ClienteModel;
            this.pcrTipoConta.ItemsSource = ClienteView.ClienteModel.TipoContaList;
            this.pcrTipoConta.SelectedItem = ClienteView.ClienteModel.TipoConta;
        }
    }
}
