using Acqio.Clients.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acqio.Clients.Services
{
    public class ClienteService
    {
        public async Task<string> Save(Models.ClienteModel clienteModel)
        {
            string msg = String.Empty;

            ClienteView.ClienteModel.LoginUsuario = App.UsuarioModel.Login;
            ClienteView.ClienteModel.NomeUsuario = App.UsuarioModel.Nome;
            ClienteView.ClienteModel.FranquiaId = App.UsuarioModel.FranquiaId;

            Services.APICallService service = new Services.APICallService();

            if (clienteModel.ClienteId == 0)
            {
                msg = await service.PostAsync<Models.ClienteModel>("Cliente", clienteModel);
            }
            else
            {
                msg = await service.PutAsync<Models.ClienteModel>("Cliente", clienteModel.ClienteId.ToString(), clienteModel);
            }

            return msg;
        }
    }
}
