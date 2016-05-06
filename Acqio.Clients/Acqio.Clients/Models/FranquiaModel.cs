using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acqio.Clients.Models
{
    public class FranquiaModel : ViewModel.ViewModelBase
    {
        public int FranquiaId { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CodIbge { get; set; }
    }
}
