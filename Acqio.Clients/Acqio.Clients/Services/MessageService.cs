using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acqio.Clients.Services
{
    public class MessageService
    {
        public async Task ShowAsync(string title, string message)
        {
            await App.Current.MainPage.DisplayAlert(title, message, "OK");
        }
    }
}
