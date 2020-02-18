using EssentialUIKit.DataService;
using EssentialUIKit.Models.Rendimiento;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class RendimientoPageViewModel
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
            Statistics = new ObservableCollection<Stats>
            {
                new Stats { Title = "Examen", Label1 = "Agosto-Base de Datos", Label2 = "Agosto-Redes 2", Value1 = "24", Value2 = "27" },
                new Stats { Title = "Promedio Actual", Label1 = "Total", Label2 = "Semestre", Value1 = "4.5", Value2 = "5" }
            };
            restService = new RestService();

            RestAPI api = new RestAPI();
            api.ExamenesDS_ServiceResponse(RestAPI.Cedula).ContinueWith((antecedent) =>
            {
                Debug.WriteLine(@"DIEGO MENDEZ - EXAMENES  {0}", api.examenesDS_response.materia.Count);
            });

        }

        private Task<AsistenciaResult> GetMateriaAsistenciaAlumnoAsync(String nroDoc)
        {

            return restService.GetMateriaAsistenciaAlumnoAsync(nroDoc); ;

        }

        #endregion

        #region methods

        public ObservableCollection<Stats> Statistics { get; set; }
        public List<MateriaAsistenciaAlumno> ItemsMateriaAsistenciaAlumno { get; private set; }

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
        #endregion
    }
}