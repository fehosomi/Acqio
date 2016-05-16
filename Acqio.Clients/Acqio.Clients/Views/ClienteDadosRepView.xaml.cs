using Acqio.Clients.Models;
using Acqio.Clients.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;

namespace Acqio.Clients.Views
{
    public partial class ClienteDadosRepView : ContentPage
    {
        private readonly IDevice _device;
        private readonly ITesseractApi _tesseract;

        public ClienteDadosRepView()
        {
            InitializeComponent();

            _tesseract = Resolver.Resolve<ITesseractApi>();
            _device = Resolver.Resolve<IDevice>();

            this.BindingContext = ClienteView.ClienteModel;

            this.pcrUF.ItemsSource = ClienteView.ClienteModel.UFList;
            this.pcrUF.SelectedItem = ClienteView.ClienteModel.RepEstado;
            this.pcrUF.SelectedIndexChanged += PcrUF_SelectedIndexChanged;
        }

        private void PcrUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClienteView.ClienteModel.RepEstado = this.pcrUF.Items[this.pcrUF.SelectedIndex];
        }

        private async void LoadImageButton_OnClicked(object sender, EventArgs e)
        {
            var result = await _device.MediaPicker.SelectPhotoAsync(new CameraMediaStorageOptions());
            await Recognise(result);
        }

        private async void GetPhotoButton_OnClicked(object sender, EventArgs e)
        {
            var result = await _device.MediaPicker.TakePhotoAsync(new CameraMediaStorageOptions());
            await Recognise(result);
        }

        async Task Recognise(MediaFile result)
        {
            if (result.Source == null)
                return;
            try
            {
                activityIndicator.IsRunning = true;
                if (!_tesseract.Initialized)
                {
                    var initialised = await _tesseract.Init("por");
                    if (!initialised)
                        return;
                }
                await _tesseract.SetImage(result.Source);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Cancel");
            }
            finally
            {
                activityIndicator.IsRunning = false;
            }

            //var words = _tesseract.Results(PageIteratorLevel.Word);
            //var symbols = _tesseract.Results(PageIteratorLevel.Symbol);
            //var blocks = _tesseract.Results(PageIteratorLevel.Block);
            //var paragraphs = _tesseract.Results(PageIteratorLevel.Paragraph);
            //string text = _tesseract.Text;

            var lines = _tesseract.Results(PageIteratorLevel.Textline);

            float higher = 0;
            bool endereco = false;

            foreach (var line in lines)
            {
                if (line.Text.ToLower().Contains("email"))
                {
                    this.etxEmail.Text = line.Text.ToLower().Replace("email", "").Replace("email:", "");
                }
                else if (line.Text.ToLower().Contains("e-mail"))
                {
                    this.etxEmail.Text = line.Text.ToLower().Replace("e-mail", "").Replace("e-mail:", "");
                }
                else if (line.Text.ToLower().Contains("@"))
                {
                    this.etxEmail.Text = line.Text;
                }
                else if (line.Text.ToLower().Contains("cel"))
                {
                    string celular = line.Text.ToLower().Replace("cel", "").Replace("cel:", "").Replace("celular", "").Replace("celular:", "");

                    decimal numero;
                    if (decimal.TryParse(celular.Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", ""), out numero))
                    {
                        this.etxCelular.Text = celular;
                    }
                }
                else if (line.Text.ToLower().Contains("tel"))
                {
                    string telefone = line.Text.ToLower().Replace("tel", "").Replace("tel:", "").Replace("telefone", "").Replace("telefone:", "");

                    decimal numero;
                    if (decimal.TryParse(telefone.Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", ""), out numero))
                    {
                        this.etxTelefone.Text = telefone;
                    }
                }
                else if (line.Text.ToLower().Contains("+") && line.Text.ToLower().Contains("-"))
                {
                    string telefone = line.Text;

                    decimal numero;
                    if (decimal.TryParse(telefone.Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", ""), out numero))
                    {
                        if (telefone.ToString().StartsWith("9") || telefone.ToString().StartsWith("8") || telefone.ToString().StartsWith(""))
                        {
                            this.etxCelular.Text = telefone;
                        }
                        else
                        {
                            this.etxTelefone.Text = telefone;
                        }
                    }
                }
                else if (line.Text.ToLower().Contains("rua"))
                {
                    this.etxEndereco.Text = line.Text.Substring(line.Text.ToLower().IndexOf("rua"));
                }
                else if (line.Text.ToLower().Contains("r."))
                {
                    this.etxEndereco.Text = line.Text.Substring(line.Text.ToLower().IndexOf("r."));
                }
                else if (line.Text.ToLower().Contains("avenida"))
                {
                    this.etxEndereco.Text = line.Text.Substring(line.Text.ToLower().IndexOf("avenida"));
                }
                else if (line.Text.ToLower().Contains("av."))
                {
                    this.etxEndereco.Text = line.Text.Substring(line.Text.ToLower().IndexOf("av."));
                }
                else if (line.Box.Height > higher && line.Text.Length > 3 && line.Text.Split(' ').Length > 1)
                {
                    this.etxNome.Text = line.Text;
                }
            }
        }

        protected async void btnSaveClicked(object sender, EventArgs e)
        {
            try
            {
                ClienteView.ClienteModel.LoginUsuario = App.UsuarioModel.Login;
                ClienteView.ClienteModel.NomeUsuario = App.UsuarioModel.Nome;
                ClienteView.ClienteModel.FranquiaId = App.UsuarioModel.FranquiaId;

                ClienteService service = new ClienteService();
                ClienteModel clienteModel = (Models.ClienteModel)ClienteView.ClienteModel;
                string retorno = await service.Save(clienteModel);
                
                if (String.IsNullOrEmpty(retorno))
                {
                    await Navigation.PushAsync(new ClienteListView(App.UsuarioModel.Login, "Análise"));
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
