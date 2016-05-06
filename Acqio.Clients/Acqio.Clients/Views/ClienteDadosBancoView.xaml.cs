using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Acqio.Clients.Views
{
    public partial class ClienteDadosBancoView : ContentPage
    {
        public ClienteDadosBancoView()
        {
            InitializeComponent();
            this.BindingContext = ClienteView.ClienteModel;
        }

        protected async void btnSaveClicked(object sender, EventArgs e)
        {
            try
            {
                Services.APICallService service = new Services.APICallService();
                string nomeFantasia = ((Models.ClienteModel)this.BindingContext).NomeFantasia;

                await service.PostAsync<Models.ClienteModel>("Cliente", (Models.ClienteModel)this.BindingContext);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
