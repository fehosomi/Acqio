using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acqio.Clients.Models
{
    public class UsuarioModel : ViewModel.ViewModelBase
    {
        public int FranquiaId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[] Assinatura { get; set; }
    }
}
