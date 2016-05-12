using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Acqio.Clients.Views.Menu
{
    public class MenuListView : ListView
    {
        public MenuListView()
        {
            List<Models.MenuItemModel> data = new List<Models.MenuItemModel>();

            data.Add(new Models.MenuItemModel()
            {
                Title = "Incluir Cliente",
                IconSource = "contacts.png",
                TargetType = typeof(ClienteView)
            });

            data.Add(new Models.MenuItemModel()
            {
                Title = "Clientes Franquia",
                IconSource = "list.png",
                TargetType = typeof(ClienteListView),
                Param = new string[] { "", "Aprovado" }
            });

            data.Add(new Models.MenuItemModel()
            {
                Title = "Meus Clientes",
                IconSource = "list.png",
                TargetType = typeof(ClienteListView),
                Param = new string[] { App.UsuarioModel.Login, "" }
            });

            data.Add(new Models.MenuItemModel()
            {
                Title = "Clientes Pendentes",
                IconSource = "list.png",
                TargetType = typeof(ClienteListView),
                Param = new string[] { App.UsuarioModel.Login, "Análise" }
            });

            ItemsSource = data;
            VerticalOptions = LayoutOptions.FillAndExpand;
            BackgroundColor = Color.Transparent;
            SeparatorVisibility = SeparatorVisibility.None;

            var cell = new DataTemplate(typeof(MenuCell));
            cell.SetBinding(MenuCell.TextProperty, "Title");
            cell.SetBinding(MenuCell.ImageSourceProperty, "IconSource");

            ItemTemplate = cell;
        }
    }
}
