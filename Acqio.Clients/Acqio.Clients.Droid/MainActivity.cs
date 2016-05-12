using System;

using Autofac;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using XLabs.Platform.Services.Media;
using Tesseract.Droid;
using TinyIoC;
using XLabs.Ioc.TinyIOC;
using Tesseract;
using XLabs.Ioc;
using XLabs.Ioc.Autofac;
using XLabs.Platform.Device;

namespace Acqio.Clients.Droid
{
    [Activity(Label = "Acqio.Clients", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            var containerBuilder = TinyIoCContainer.Current;
            containerBuilder.Register<IDevice>(AndroidDevice.CurrentDevice);
            containerBuilder.Register<ITesseractApi>((cont, parameters) =>
            {
                return new TesseractApi(ApplicationContext, Tesseract.Droid.AssetsDeployment.OncePerInitialization);
            });

            Resolver.SetResolver(new TinyResolver(containerBuilder));

            LoadApplication(new App());
        }
    }
}

