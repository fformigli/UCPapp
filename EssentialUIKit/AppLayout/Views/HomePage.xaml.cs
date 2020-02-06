using EssentialUIKit.AppLayout.Controls;
using EssentialUIKit.AppLayout.Models;
using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.AppLayout.Views
{
    /// <summary>
    /// UITemplate home page
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage
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

        #region  Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage" /> class.
        /// </summary>
        public HomePage()
        {
            this.InitializeComponent();
        }



        #endregion

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

            if (width < height)
            {
                iOSSafeArea.Height = iOSSafeAreaTitle.Height = safeAreaHeight;
                ListViewHeader.HeightRequest += safeAreaHeight;
                DefaultActionBar.Height = DefaultActionBar.Height.Value + safeAreaHeight;
            }
            else
            {
                iOSSafeArea.Height = iOSSafeAreaTitle.Height = 0;
                ListViewHeader.HeightRequest = 275;
                DefaultActionBar.Height = 60;
            }
        }

        protected override void OnAppearing()
        {
            this.isNavigationInQueue = false;
            base.OnAppearing();
        }

        protected override bool OnBackButtonPressed()
        {
            if (!this.SettingsView.IsVisible) return base.OnBackButtonPressed();
            this.SettingsView.Hide();
            return true;
        }

        private void ListView_OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (!loaded)
            {
                this.scrollDensity = Application.Current.MainPage.Width / listView.WidthInPixel;
                this.actualHeaderX = HeaderText.X;
                this.actualHeaderY = HeaderText.Y;

                this.headerDeltaX = this.actualHeaderX - TranslatedHeaderX;
                this.headerDeltaY = this.actualHeaderY - TranslatedHeaderY;
                this.loaded = true;
            }

            var scrollValue = e.Position * this.scrollDensity;

            var factor = (scrollValue + 215) / 215;

            if (scrollValue <= -215)
            {
                ActionBar.IsVisible = true;
            }
            else if (scrollValue > -215)
            {
                Description.Opacity = factor;
                HeaderBackground.Opacity = factor;
                HeaderImage.Opacity = factor;
                HeaderText.Opacity = factor;
                BrandName.Opacity = (scrollValue + 75) / 75;
                ActionBar.IsVisible = false;
                SettingsIcon.TranslationY = scrollValue * -1;
            }
        }

        private void ListView_OnSelectionChanged(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null || this.isNavigationInQueue) return;
            this.isNavigationInQueue = true;
            

            if (Device.RuntimePlatform == "UWP")
            {
                var assembly = typeof(App).GetTypeInfo().Assembly;
                Navigation.PushAsync((Page)Activator.CreateInstance(
                    assembly.GetType($"EssentialUIKit.{((Category)e.SelectedItem).PageName}")));
            }
            else
                Navigation.PushAsync(new TemplateHostPage(e.SelectedItem as Category));
        }

        private void ShowSettings(object sender, EventArgs e)
        {
            SettingsView.Show();
        }
        #endregion
    }
}