using Acqio.Clients.Services;
using Acqio.Clients.Services.IServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Acqio.Clients.Views
{
    public partial class UsuarioView : ContentPage
    {
        public UsuarioView(ObservableCollection<string> franquiaList)
        {
            InitializeComponent();
            pcrFranquia.ItemsSource = franquiaList;

            this.BindingContext = new Models.UsuarioModel();
        }

        protected async void btnSaveClicked(object sender, EventArgs e)
        {
            try
            {
                if (pcrFranquia.SelectedItem == null)
                {
                    return;
                }

                Services.APICallService service = new Services.APICallService();
                Models.UsuarioModel model = (Models.UsuarioModel)this.BindingContext;
                model.FranquiaId = Convert.ToInt32(pcrFranquia.SelectedItem.ToString().Split('-')[0]);

                //Stream strImage = pdwAssinatura.GetImage(Acr.XamForms.SignaturePad.ImageFormatType.Jpg);
                //byte[] data = ((MemoryStream)strImage).ToArray();
                //model.Assinatura = data;

                //DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", data);

                if (model.Senha != etxSenhaConf.Text)
                {
                    Services.MessageService message = new Services.MessageService();
                    await message.ShowAsync("Senha", "Senhas digitadas não conferem!");
                    return;
                }

                string retorno = await service.PostAsync<Models.UsuarioModel>("Usuario", model);

                if (String.IsNullOrEmpty(retorno))
                {
                    await Navigation.PopAsync();
                }
                else
                {
                    MessageService message = new MessageService();
                    await message.ShowAsync("Erro ao salvar", retorno);
                }
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
