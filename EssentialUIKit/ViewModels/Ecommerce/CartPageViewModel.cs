﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using EssentialUIKit.Models.ECommerce;
using System.Runtime.Serialization;
using EssentialUIKit.DataService;
using EssentialUIKit.Data;
using EssentialUIKit.Models.Rendimiento.Horarios;

namespace EssentialUIKit.ViewModels.ECommerce
{
    /// <summary>
    /// ViewModel for cart page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class CartPageViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ECommerceDataService dataService = ECommerceDataService.Instance;

        private ObservableCollection<Product> cartDetails;
        private ObservableCollection<Materia> materias;

        private double totalPrice;

        private double discountPrice;

        private double discountPercent;

        private double percent;
        
        private ObservableCollection<Product> produts;
        
        private Command placeOrderCommand;
        
        private Command notificationCommand;
        
        private Command addToCartCommand;
        
        private Command saveForLaterCommand;
        
        private Command removeCommand;
        
        private Command quantitySelectedCommand;
        
        private Command variantSelectedCommand;
        
        private Command applyCouponCommand;

        #endregion

        #region Event

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the cart details.
        /// </summary>
        public ObservableCollection<Product> CartDetails
        {
            get
            {
                return this.cartDetails;
            }

            set
            {
                if (this.cartDetails == value)
                {
                    return;
                }

                this.cartDetails = value;
                this.NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Materia> Materias
        {
            get { return this.materias; }

            set
            {
                if (this.materias == value)
                {
                    return;
                }

                this.materias = value;
                this.NotifyPropertyChanged();
            }
        }


        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the total price.
        /// </summary>
        public double TotalPrice
        {
            get
            {
                return this.totalPrice;
            }

            set
            {
                if (this.totalPrice == value)
                {
                    return;
                }

                this.totalPrice = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays total discount price.
        /// </summary>
        public double DiscountPrice
        {
            get
            {
                return this.discountPrice;
            }

            set
            {
                if (this.discountPrice == value)
                {
                    return;
                }

                this.discountPrice = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays discount.
        /// </summary>
        public double DiscountPercent
        {
            get
            {
                return this.discountPercent;
            }
        
            set
            {
                if (this.discountPercent == value)
                {
                    return;
                }

                this.discountPercent = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with list view, which displays the collection of products from json.
        /// </summary>

        [DataMember(Name = "products")]
        public ObservableCollection<Product> Products
        {
            get
            {
                return this.produts;
            }
            set
            {
                if (this.produts == value)
                {
                    return;
                }
                this.produts = value;
                this.NotifyPropertyChanged();
                GetProducts(Products);
                UpdatePrice();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will be executed when the Edit button is clicked.
        /// </summary>
        public Command PlaceOrderCommand
        {
            get { return this.placeOrderCommand ?? (this.placeOrderCommand = new Command(this.PlaceOrderClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the Notification button is clicked.
        /// </summary>
        public Command NotificationCommand
        {
            get { return this.notificationCommand ?? (this.notificationCommand = new Command(this.NotificationClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the AddToCart button is clicked.
        /// </summary>
        public Command AddToCartCommand
        {
            get { return this.addToCartCommand ?? (this.addToCartCommand = new Command(this.AddToCartClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the Save for Later button is clicked.
        /// </summary>
        public Command SaveForLaterCommand
        {
            get { return this.saveForLaterCommand ?? (this.saveForLaterCommand = new Command(this.SaveForLaterClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the Remove button is clicked.
        /// </summary>
        public Command RemoveCommand
        {
            get { return this.removeCommand ?? (this.removeCommand = new Command(this.RemoveClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the quantity is selected.
        /// </summary>
        public Command QuantitySelectedCommand
        {
            get { return this.quantitySelectedCommand ?? (this.quantitySelectedCommand = new Command(this.QuantitySelected)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the variant is selected.
        /// </summary>
        public Command VariantSelectedCommand
        {
            get { return this.variantSelectedCommand ?? (this.variantSelectedCommand = new Command(this.VariantSelected)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the apply coupon is clicked.
        /// </summary>
        public Command ApplyCouponCommand
        {
            get { return this.applyCouponCommand ?? (this.applyCouponCommand = new Command(this.ApplyCouponClicked)); }
        }

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
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void PlaceOrderClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void NotificationClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void AddToCartClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SaveForLaterClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void RemoveClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the quantity is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void QuantitySelected(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the variant is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void VariantSelected(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the apply coupon button is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ApplyCouponClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// This method is used to get the products from json.
        /// </summary>
        /// <param name="Products"></param>
        private void GetProducts(ObservableCollection<Product> Products)
        {
            this.CartDetails = new ObservableCollection<Product>();

            RestAPI api = new RestAPI();
            api.HoraraiosDS2_ServiceResponse("3593109");
            //.ContinueWith((antecedent) => {
            this.materias = new ObservableCollection<Materia>();
            for (int i = 0; i < api.horariosDS_response.materia.Count; i++)
            {
                this.Materias.Add(new Materia
                {
                    curso = api.horariosDS_response.materia[i].curso,
                    horario = api.horariosDS_response.materia[i].horario,
                    nombreCarrera = api.horariosDS_response.materia[i].nombreCarrera,
                    seccion = api.horariosDS_response.materia[i].seccion,
                    semestre = api.horariosDS_response.materia[i].semestre,
                    nombreMateria = api.horariosDS_response.materia[i].nombreMateria,
                    turno = api.horariosDS_response.materia[i].turno

                });

            }

            if (Products != null && Products.Count > 0)
                this.CartDetails = Products;
        }

        /// <summary>
        /// This method is used to update the price amount.
        /// </summary>
        private void UpdatePrice()
        {
            ResetPriceValue();

            if (this.CartDetails != null && this.CartDetails.Count > 0)
            {
                foreach (var cartDetail in this.CartDetails)
                {
                    if (cartDetail.TotalQuantity == 0)
                        cartDetail.TotalQuantity = 1;
                    this.TotalPrice += (cartDetail.ActualPrice * cartDetail.TotalQuantity);
                    this.DiscountPrice += (cartDetail.DiscountPrice * cartDetail.TotalQuantity);
                    this.percent += cartDetail.DiscountPercent;
                }

                this.DiscountPercent = this.percent > 0 ? this.percent / this.CartDetails.Count : 0;
            }
        }

        /// <summary>
        /// This method is used to reset the price amount.
        /// </summary>
        private void ResetPriceValue()
        {
            this.TotalPrice = 0;
            this.DiscountPercent = 0;
            this.DiscountPrice = 0;
            this.percent = 0;
        }

        #endregion
    }
}
