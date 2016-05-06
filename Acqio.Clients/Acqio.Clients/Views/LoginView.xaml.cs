using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Acqio.Clients.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            this.BindingContext = new Models.UsuarioModel();
        }

        protected async void btnLoginClicked(object sender, EventArgs e)
        {
            try
            {
                Models.UsuarioModel currentModel = ((Models.UsuarioModel)this.BindingContext);

                Services.APICallService service = new Services.APICallService();

                currentModel.FranquiaId = 1;
                string param = String.Format("FranquiaId={0}&Email={1}", currentModel.FranquiaId, currentModel.Email);

                Models.UsuarioModel model = await service.GetAsync<Models.UsuarioModel>("Usuario", param);
                if (model != null)
                {
                    if (model.Senha == currentModel.Senha)
                    {
                        App.UsuarioModel = model;
                        await Navigation.PopModalAsync();
                    }
                    else
                    {
                        Services.MessageService message = new Services.MessageService();
                        await message.ShowAsync("Login", "Senha inválida");
                    }
                }
                else
                {
                    Services.MessageService message = new Services.MessageService();
                    await message.ShowAsync("Login", "E-mail inválido");
                }
            
            }
            catch (Exception ex)
            {
                Services.MessageService message = new Services.MessageService();
                await message.ShowAsync("Erro Geral", ex.Message);
            }
        }

        protected async void btnRegClicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushModalAsync(new UsuarioView());
            }
            catch (Exception ex)
            {

            }
        }
    }
}
