using Acqio.Clients.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acqio.Clients.ViewModel
{
    public class ClienteViewModel
    {
        public ObservableCollection<Models.ClienteModel> Items { get; set; }

        public NotifyTaskCompletion<ObservableCollection<Models.ClienteModel>> Item;

        public ClienteViewModel()
        {
            //Services.APICallService service = new Services.APICallService();
            //string param = String.Format("FranquiaId={0}&Email={1}&ClienteId=0", App.UsuarioModel.FranquiaId, App.UsuarioModel.Email);
            //Item = new NotifyTaskCompletion<ObservableCollection<Models.ClienteModel>>(service.GetObservableCollectionAsync<Models.ClienteModel>("Cliente", param));

            var t = this.LoadData();
            t.ContinueWith(task =>
            {
            }, TaskContinuationOptions.OnlyOnFaulted);
        }

        public async Task LoadData()
        {
            Services.APICallService service = new Services.APICallService();
            string param = String.Format("FranquiaId={0}&Email={1}&ClienteId=0", App.UsuarioModel.FranquiaId, App.UsuarioModel.Email);
            List<Models.ClienteModel> list = await service.GetListAsync<Models.ClienteModel>("Cliente", param);
            list = list.OrderBy(l => l.NomeFantasia).ToList();

            Items = new ObservableCollection<Models.ClienteModel>(list);
        }
    }
}
