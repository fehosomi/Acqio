using Acqio.Clients.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Acqio.Clients.Views
{
    public partial class ClienteListView : ContentPage
    {
        ClienteViewModel ViewModel = new ClienteViewModel();
        public ObservableCollection<Models.ClienteModel> Items { get; set; }

        public ClienteListView(string login, string status)
        {
            InitializeComponent();

            Services.APICallService service = new Services.APICallService();
            string param = String.Format("FranquiaId={0}&Login={1}&ClienteId=0&Status={2}", App.UsuarioModel.FranquiaId, login, status);
            var es = service.GetListAsync<Models.ClienteModel>("Cliente", param).ContinueWith(t =>
            {
                if (t.Status == TaskStatus.RanToCompletion)
                {
                    List<Models.ClienteModel> list = t.Result;
                    list = list.OrderBy(l => l.NomeFantasia).ToList();
                    Items = new ObservableCollection<Models.ClienteModel>(list);

                    Device.BeginInvokeOnMainThread(() => this.lvwCliente.ItemsSource = Items);
                }
            });
            //this.BindingContext = this.ViewModel;
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            Navigation.PushAsync(new ClienteView((Models.ClienteModel)e.SelectedItem));
            //DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            
        }
    }
}
