using Acqio.Clients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Acqio.Clients.Views
{
    public partial class ClienteView : CarouselPage
    {
        public static ClienteModel ClienteModel { get; set; }
        
        public ClienteView()
        {
            InitializeComponent();
            ClienteModel = new ClienteModel();
            ClienteModel.DataVisita = DateTime.Now;
            
            this.Children.Add(new ClienteDadosEmpresaView());
            this.Children.Add(new ClienteDadosBancoView());
            this.Children.Add(new ClienteDadosComerciaisView());
            this.Children.Add(new ClienteDadosRepView());
            this.Children.Add(new ClienteAssinaturaView());
        }

        public ClienteView(ClienteModel clienteModel)
        {
            InitializeComponent();
            ClienteModel = clienteModel;

            this.Children.Add(new ClienteDadosEmpresaView());
            this.Children.Add(new ClienteDadosBancoView());
            this.Children.Add(new ClienteDadosComerciaisView());
            this.Children.Add(new ClienteDadosRepView());
            
        }
    }
}
