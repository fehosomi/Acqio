using Acqio.Clients.Models;
using Acqio.Clients.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Acqio.Clients.Views
{
    public partial class ClienteDadosRepView : ContentPage
    {
        public ClienteDadosRepView()
        {
            InitializeComponent();
            this.BindingContext = new RepresentanteModel();
        }

        protected async void btnSaveClicked(object sender, EventArgs e)
        {
            try
            {
                ClienteView.ClienteModel.EmailUsuario = App.UsuarioModel.Email;
                ClienteView.ClienteModel.FranquiaId = App.UsuarioModel.FranquiaId;

                Services.APICallService service = new Services.APICallService();

                string retorno;
                ClienteModel clienteModel = (Models.ClienteModel)ClienteView.ClienteModel;

                if (clienteModel.ClienteId == 0)
                {
                    retorno = await service.PostAsync<Models.ClienteModel>("Cliente", clienteModel);
                    if (String.IsNullOrEmpty(retorno))
                    {
                        retorno = await service.PostAsync<Models.RepresentanteModel>("Representante", (Models.RepresentanteModel)this.BindingContext);
                    }
                }
                else
                {
                    retorno = await service.PutAsync<Models.ClienteModel>("Cliente", clienteModel.ClienteId.ToString(), clienteModel);
                    if (String.IsNullOrEmpty(retorno))
                    {
                        retorno = await service.PutAsync<Models.RepresentanteModel>("Representante", ((Models.RepresentanteModel)this.BindingContext).RepresentanteId.ToString(), (Models.RepresentanteModel)this.BindingContext);
                    }
                }

                if (String.IsNullOrEmpty(retorno))
                {
                    await Navigation.PushAsync(new ClienteListView());
                }
                else
                {
                    MessageService message = new MessageService();
                    await message.ShowAsync("Erro ao salvar", retorno);
                }
                
            }
            catch (Exception ex)
            {
                MessageService message = new MessageService();
                await message.ShowAsync("Erro ao salvar", ex.Message);
            }
        }
    }
}
