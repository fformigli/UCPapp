﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using EssentialUIKit.Models.OnBoarding;

namespace EssentialUIKit.ViewModels.OnBoarding
{
    /// <summary>
    /// ViewModel for on-boarding gradient page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class OnBoardingGradientViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<Boarding> boardings;

        private string nextButtonText = "SIGUIENTE";

        private bool isSkipButtonVisible = true;

        private int selectedIndex;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="OnBoardingGradientViewModel" /> class.
        /// </summary>
        public OnBoardingGradientViewModel()
        {
            this.Boardings = new ObservableCollection<Boarding>
            {
                new Boarding
                {
                    ImagePath = "ChooseGradient.svg",
                    Header = "ELIGE",
                    Content = "Selecciona la opción de tu interés en el menú principal"
                },
                new Boarding
                {
                    ImagePath = "ConfirmGradient.svg",
                    Header = "LOREM IPSUM",
                    Content = "Aliquam luctus turpis a enim malesuada commodo. Aliquam ac sodales enim"
                },
                new Boarding
                {
                    ImagePath = "DeliverGradient.svg",
                    Header = "LOREM IPSUM",
                    Content = "Etiam quis mi rhoncus, auctor ligula et, vehicula mi. Integer auctor ipsum sed justo vehicula"
                }
            };

            this.SkipCommand = new Command(this.Skip);
            this.NextCommand = new Command(this.Next);
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the command that is executed when the Skip button is clicked.
        /// </summary>
        public ICommand SkipCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Done button is clicked.
        /// </summary>
        public ICommand NextCommand { get; set; }

        #endregion

        #region Events

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the boardings collection.
        /// </summary>
        public ObservableCollection<Boarding> Boardings
        {
            get { return this.boardings; }
            set
            {
                this.boardings = value;
                this.OnPropertyChanged();
            }
        }

        public string NextButtonText
        {
            get
            {
                return this.nextButtonText;
            }
            set
            {
                if (this.nextButtonText == value)
                {
                    return;
                }
                this.nextButtonText = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsSkipButtonVisible
        {
            get
            {
                return this.isSkipButtonVisible;
            }
            set
            {
                if (this.isSkipButtonVisible == value)
                {
                    return;
                }
                this.isSkipButtonVisible = value;
                this.OnPropertyChanged();
            }
        }

        public int SelectedIndex
        {
            get
            {
                return this.selectedIndex;
            }
            set
            {
                if (this.selectedIndex == value)
                {
                    return;
                }
                this.selectedIndex = value;
                this.OnPropertyChanged();

                this.ValidateSelection();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool ValidateAndUpdateSelectedIndex()
        {
            if (this.selectedIndex >= this.Boardings.Count - 1) return true;

            this.SelectedIndex++;
            return false;
        }

        private void ValidateSelection()
        {
            if (this.selectedIndex < this.Boardings.Count - 1)
            {
                this.IsSkipButtonVisible = true;
                this.NextButtonText = "SIGUIENTE";
            }
            else
            {
                this.NextButtonText = "HECHO";
                this.IsSkipButtonVisible = false;
            }
        }

        /// <summary>
        /// Invoked when the Skip button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void Skip(object obj)
        {
            MoveToNextPage();
        }

        /// <summary>
        /// Invoked when the Done button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void Next(object obj)
        {
            if (ValidateAndUpdateSelectedIndex())
            {
                Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                MoveToNextPage();
            }
        }

        private void MoveToNextPage()
        {
            //Move to next page
        }

        #endregion
    }
}