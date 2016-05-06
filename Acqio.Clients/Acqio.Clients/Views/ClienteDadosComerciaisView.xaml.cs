using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Acqio.Clients.Views
{
    public partial class ClienteDadosComerciaisView : ContentPage
    {
        public ClienteDadosComerciaisView()
        {
            InitializeComponent();
            this.BindingContext = ClienteView.ClienteModel;
        }
    }
}
