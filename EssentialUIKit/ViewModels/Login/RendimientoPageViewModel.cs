using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using EssentialUIKit.Models.Rendimiento;
using System;
using EssentialUIKit.Data;
using System.Collections.Generic;
using EssentialUIKit.Models.Rendimiento;
using System.Diagnostics;

namespace EssentialUIKit.ViewModels.Login
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class RendimientoPageViewModel : LoginViewModel
    {
        #region Fields

        private string password;
        IRestService restService;


        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginPageViewModel" /> class.
        /// </summary>
        public RendimientoPageViewModel()
        {
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.ForgotPasswordCommand = new Command(this.ForgotPasswordClicked);
            this.SocialMediaLoginCommand = new Command(this.SocialLoggedIn);

            Statistics = new ObservableCollection<Stats>();
            Statistics.Add(new Stats { Title = "Examen", Label1 = "Agosto-Base de Datos", Label2 = "Agosto-Redes 2", Value1 = "24", Value2 = "27" });
            Statistics.Add(new Stats { Title = "Promedio Actual", Label1 = "Total", Label2 = "Semestre", Value1 = "4.5", Value2 = "5" });
            restService = new RestService();
  
            RestAPI api = new RestAPI();
            api.ExamenesDS_ServiceResponse("6948405").ContinueWith((antecedent) => {
                Debug.WriteLine(@"DIEGO MENDEZ - EXAMENES  {0}", api.examenesDS_response.materia.Count);
            });          

        }

        private Task<AsistenciaResult> GetMateriaAsistenciaAlumnoAsync(String nroDoc)
        {
            
            return restService.GetMateriaAsistenciaAlumnoAsync(nroDoc);;

        }

        #endregion

        #region property

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.password = value;
                this.OnPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }
        public ObservableCollection<Stats> Statistics { get; set; }
        public List<MateriaAsistenciaAlumno> ItemsMateriaAsistenciaAlumno { get; private set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Forgot Password button is clicked.
        /// </summary>
        public Command ForgotPasswordCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the social media login button is clicked.
        /// </summary>
        public Command SocialMediaLoginCommand { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Invoked when the Log In button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoginClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SignUpClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Forgot Password button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void ForgotPasswordClicked(object obj)
        {
            var label = obj as Label;
            label.BackgroundColor = Color.FromHex("#70FFFFFF");
            await Task.Delay(100);
            label.BackgroundColor = Color.Transparent;
        }

        /// <summary>
        /// Invoked when social media login button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SocialLoggedIn(object obj)
        {
            // Do something
        }

        #endregion
    }
}