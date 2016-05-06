using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Acqio.Clients.Views
{
    public partial class UsuarioView : ContentPage
    {
        public UsuarioView()
        {
            InitializeComponent();
            this.BindingContext = new Models.UsuarioModel();
        }

        protected async void btnSaveClicked(object sender, EventArgs e)
        {
            try
            {
                Services.APICallService service = new Services.APICallService();
                Models.UsuarioModel model = (Models.UsuarioModel)this.BindingContext;

                if (model.Senha != etxSenhaConf.Text)
                {
                    Services.MessageService message = new Services.MessageService();
                    await message.ShowAsync("Senha", "Senhas digitadas não conferem!");
                    return;
                }

                model.FranquiaId = 1;

                await service.PostAsync<Models.UsuarioModel>("Usuario", model);
                model.Email = String.Empty;
                model.Senha = String.Empty;

                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {

            }
        }

        protected async void btnCancelClicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
