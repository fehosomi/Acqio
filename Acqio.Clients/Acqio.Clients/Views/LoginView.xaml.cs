using Acqio.Clients.Views.Menu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Acqio.Clients.Views
{
    public partial class LoginView : ContentPage
    {
        public ObservableCollection<string> franquiaList = new ObservableCollection<string>();

        public LoginView()
        {
            InitializeComponent();

            Services.APICallService service = new Services.APICallService();
            var es = service.GetListAsync<Models.FranquiaModel>("Franquia", String.Empty).ContinueWith(t =>
            {
                if (t.Status == TaskStatus.RanToCompletion)
                {
                    List<Models.FranquiaModel> list = t.Result;

                    foreach (var item in list)
                    {
                        franquiaList.Add(item.FranquiaId + " - " + item.Nome);
                    }
                     
                    pcrFranquia.ItemsSource = franquiaList;
                }
            });

            this.BindingContext = new Models.UsuarioModel();
        }

        protected async void btnLoginClicked(object sender, EventArgs e)
        {
            try
            {
                Models.UsuarioModel currentModel = ((Models.UsuarioModel)this.BindingContext);

                Services.APICallService service = new Services.APICallService();

                var franquia = pcrFranquia.SelectedItem.ToString().Split('-')[0].Trim();

                currentModel.FranquiaId = Convert.ToInt32(franquia);
                string param = String.Format("FranquiaId={0}&Login={1}", currentModel.FranquiaId, currentModel.Login);

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
                    await message.ShowAsync("Login", "Usuário inválido");
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
                await Navigation.PushModalAsync(new UsuarioView(franquiaList));
            }
            catch (Exception ex)
            {

            }
        }
    }
}
