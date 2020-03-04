using EssentialUIKit.DataService;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.ECommerce
{
    /// <summary>
    /// ViewModel for Checkout page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CheckoutPageViewModel : INotifyPropertyChanged
    {
        #region Fields

        



        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="CheckoutPageViewModel" /> class.
        /// </summary>
        public CheckoutPageViewModel()
        {
            Console.WriteLine("Nueva VERISION");
            RestAPI api = new RestAPI();
            //api.HoraraiosDS2_ServiceResponse("3593109");
            //.ContinueWith((antecedent) => {
      
            //   });




            this.EditCommand = new Command(this.EditClicked);
            this.AddAddressCommand = new Command(this.AddAddressClicked);
            this.PlaceOrderCommand = new Command(this.PlaceOrderClicked);
            this.PaymentOptionCommand = new Command(PaymentOptionClicked);
            this.ApplyCouponCommand = new Command(this.ApplyCouponClicked);

        }

        #endregion

        #region Event

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public properties



 










        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will be executed when the Edit button is clicked.
        /// </summary>
        public Command EditCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the Add new address button is clicked.
        /// </summary>
        public Command AddAddressCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the Edit button is clicked.
        /// </summary>
        public Command PlaceOrderCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the payment option button is clicked.
        /// </summary>
        public Command PaymentOptionCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the apply coupon button is clicked.
        /// </summary>
        public Command ApplyCouponCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Invoked when the Edit button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void EditClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Add address button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void AddAddressClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Place order button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void PlaceOrderClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Payment option is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void PaymentOptionClicked(object obj)
        {
            if (obj is RowDefinition rowDefinition && rowDefinition.Height.Value == 0)
            {
                rowDefinition.Height = GridLength.Auto;
            }
        }

        /// <summary>
        /// Invoked when the Apply coupon button is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ApplyCouponClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}