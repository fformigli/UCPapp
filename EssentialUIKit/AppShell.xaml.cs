#if EnableAppCenterAnalytics
using System.Collections.Generic;
using Microsoft.AppCenter.Analytics;
#endif
using EssentialUIKit.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell
    {
        public AppShell()
        {
            this.InitializeComponent();

            this.Navigating += this.AppShell_Navigating;

            Routing.RegisterRoute("templatehostpage", typeof(TemplateHostPage));
        }

        private void AppShell_Navigating(object sender, ShellNavigatingEventArgs e)
        {
            // TODO:Pending
            var uriString = e.Target.Location.OriginalString;
            if (uriString.Contains("?"))
            {
                var pageNameEndIndex = uriString.IndexOf("?", StringComparison.Ordinal);
            }
        }

        /// <summary>
        /// Invoked when the list item is selected.
        /// </summary>
        /// <param name="category">The Category</param>
        /// <param name="page">The Page</param>
        private void PushEvent(string category, string page)
        {
#if EnableAppCenterAnalytics
            Analytics.TrackEvent(
                "Template Clicked",
                new Dictionary<string, string>
                {
                    {
                        "Category", category
                    },
                    {
                        "Page", page
                    }
                });
#endif
        }
    }
}