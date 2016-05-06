using Acqio.Clients.Models;
using Acqio.Clients.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Acqio.Clients
{
    public partial class App : Application
    {
        public static UsuarioModel UsuarioModel;
        
        public App()
        {
            InitializeComponent();

            MainPage = new Views.Menu.RootView();
        }
    }
}
