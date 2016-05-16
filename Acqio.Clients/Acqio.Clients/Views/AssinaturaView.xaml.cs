using Acqio.Clients.Services.IServices;
using Acr.XamForms.SignaturePad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Acqio.Clients.Views
{
    public partial class AssinaturaView : ContentPage
    {
        public AssinaturaView()
        {
            InitializeComponent();
        }

        private void btnSaveClicked(object sender, EventArgs e)
        {
            Stream strImage = pdwAssinatura.GetImage(Acr.XamForms.SignaturePad.ImageFormatType.Jpg);
            strImage.Position = 0;
            int valorByte;

            valorByte = strImage.ReadByte();
            List<byte> byteList = new List<byte>();
            byte[] data;

            while (valorByte != -1)
            {
                byteList.Add((byte)valorByte);
                valorByte = strImage.ReadByte();
            }

            data = byteList.ToArray();
            

            //byte[] buffer = new byte[16 * 1024];
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    int read;
            //    while ((read = strImage.Read(buffer, 0, buffer.Length)) > 0)
            //    {
            //        ms.Write(buffer, 0, read);
            //    }
            //    data = ms.ToArray();
            //}

            //byte[] data = ((MemoryStream)strImage).ToArray();
            
            DependencyService.Get<IPicture>().SavePictureToDisk("ChartImage", data);
        }
    }
}
