using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using System;

namespace EssentialUIKit.Views.Login
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage" /> class.
        /// </summary>
        public LoginPage()
        {
            this.InitializeComponent();
            this.BackgroundImageSource = FileImageSource.FromFile("LoginBackground");
        }

        private void PasswordToggle(object sender, EventArgs e)
        {
            this.PasswordEntry.IsPassword = !this.PasswordEntry.IsPassword;
        }

        private void Loading(object sender, EventArgs e)
        {
            this.LoginButton.ImageSource = "@drawable/loading";
        }

    }
}