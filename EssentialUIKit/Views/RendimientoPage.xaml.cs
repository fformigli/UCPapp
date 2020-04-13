using System;
using EssentialUIKit.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RendimientoPage
    {
        public RendimientoPage()
        {
            this.InitializeComponent();
        }
        private void AsistenciaTapped(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new AsistenciaPage(), false));
        }

        private void CalificacionTapped(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new CalificacionPage(), false));
        }
    }

}