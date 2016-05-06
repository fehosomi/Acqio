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
                Title = "Lista Clientes",
                IconSource = "list.png",
                TargetType = typeof(ClienteListView)
            });

            //data.Add(new Models.MenuItemModel()
            //{
            //    Title = "Leads",
            //    IconSource = "leads.png",
            //    TargetType = typeof(LeadsPage)
            //});

            //data.Add(new Models.MenuItemModel()
            //{
            //    Title = "Accounts",
            //    IconSource = "accounts.png",
            //    TargetType = typeof(AccountsPage)
            //});

            //data.Add(new Models.MenuItemModel()
            //{
            //    Title = "Opportunities",
            //    IconSource = "opportunities.png",
            //    TargetType = typeof(OpportunitiesPage)
            //});

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
