﻿
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tesseract;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;

namespace Acqio.Clients.Views
{
    public partial class ClienteDadosEmpresaView : ContentPage
    {
        //private readonly IMediaPicker _mediaPicker;
        private readonly IDevice _device;
        private readonly ITesseractApi _tesseract;

        public ClienteDadosEmpresaView()
        {
            InitializeComponent();
            //_mediaPicker = Resolver.Resolve<IMediaPicker>();
            
            _tesseract = Resolver.Resolve<ITesseractApi>();
            _device = Resolver.Resolve<IDevice>();

            this.BindingContext = ClienteView.ClienteModel;
            this.pcrUF.ItemsSource = ClienteView.ClienteModel.UFList;
            this.pcrUF.SelectedItem = ClienteView.ClienteModel.Estado;
            this.pcrUF.SelectedIndexChanged += PcrUF_SelectedIndexChanged;

            this.pcrStatus.ItemsSource = ClienteView.ClienteModel.StatusList;
            this.pcrStatus.SelectedItem = ClienteView.ClienteModel.Status;
            this.pcrStatus.SelectedIndexChanged += PcrStatus_SelectedIndexChanged;
        }

        private void PcrUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClienteView.ClienteModel.Estado = this.pcrUF.Items[this.pcrUF.SelectedIndex];
        }

        private void PcrStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClienteView.ClienteModel.Status = this.pcrStatus.Items[this.pcrStatus.SelectedIndex];
        }

        protected override void OnDisappearing()
        {
            if (this.pcrStatus.SelectedItem != null)
            {
                ClienteView.ClienteModel.Status = this.pcrStatus.SelectedItem.ToString();
            }

            base.OnDisappearing();
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
                if (line.Text.ToLower().Contains("www"))
                {
                    this.etxSite.Text = line.Text.Substring(line.Text.IndexOf("www"));
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
                    this.etxNomeFantasia.Text = line.Text;
                }

                if (endereco)
                {

                }
            }
        }
    }
}
