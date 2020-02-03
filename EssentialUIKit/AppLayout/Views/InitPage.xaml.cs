using EssentialUIKit.AppLayout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.AppLayout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InitPage : ContentPage
    {
        #region Fields

        private const double TranslatedHeaderX = 15;

        private const double TranslatedHeaderY = 10;

        private bool loaded;

        private bool isNavigationInQueue;

        private double actualHeaderX, actualHeaderY;

        private double headerDeltaX, headerDeltaY;

        private double scrollDensity;

        private double width;

        private double height;
        public string descAlumno { set; get; }

        #endregion


        public InitPage()
        {
            InitializeComponent();
        }

        #region Methods

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (Device.RuntimePlatform == "UWP" ||
                !AppSettings.Instance.IsSafeAreaEnabled) return;

            if (width == this.width && height == this.height) return;

            var safeAreaHeight = AppSettings.Instance.SafeAreaHeight;
            this.width = width;
            this.height = height;
        }

        protected override void OnAppearing()
        {
            this.isNavigationInQueue = false;
            base.OnAppearing();
        }

        private void ListView_OnSelectionChanged(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null || this.isNavigationInQueue) return;
            this.isNavigationInQueue = true;
            Navigation.PushAsync(new TemplatePage(e.SelectedItem as Category));
        }
        #endregion
    }
}