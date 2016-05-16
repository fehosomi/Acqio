using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Acqio.Clients.Views.Menu
{
    public class RootView : MasterDetailPage
    {
        MenuView menuView;

        public RootView()
        {
            Navigation.PushModalAsync(new LoginView());

            menuView = new MenuView();
            menuView.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as Models.MenuItemModel);

            Master = menuView;
            Detail = new NavigationPage(new ClienteView());
        }

        void NavigateTo(Models.MenuItemModel menu)
        {
            if (menu == null)
                return;

            Page displayPage = (Page)Activator.CreateInstance(menu.TargetType, menu.Param);

            Detail = new NavigationPage(displayPage);

            menuView.Menu.SelectedItem = null;
            IsPresented = false;
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    if (App.UsuarioModel.Login == null)
        //    {
        //        Navigation.PushModalAsync(new LoginView());
        //    }
        //}
    }
}
