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
    [Preserve(AllMembers = true)]
    public class RendimientoPageViewModel
    {
        #region Fields
        
        public string NombreAlumno { get; set; }
        public string CarreraPerfil { get; set; }

        #endregion

        #region Constructor


        public RendimientoPageViewModel()
        {
            //cargar perfil
            var api = new RestAPI();
            NombreAlumno = RestAPI.perfilResponse.Nombres + " " + RestAPI.perfilResponse.Apellidos;
            CarreraPerfil = "";
            for (var i = 0; i < RestAPI.perfilResponse.Carreras.Count; i++)
            {
                if (i == 0)
                    CarreraPerfil += RestAPI.perfilResponse.Carreras[i].CarreraPerfil;
                /*else if (i == RestAPI.perfilDS_response.Carreras.Count - 1)
                    CarreraPerfil += " y " + RestAPI.perfilDS_response.Carreras[i].CarreraPerfil;
                else if (i > 0)
                    CarreraPerfil += ", " + RestAPI.perfilDS_response.Carreras[i].CarreraPerfil;*/
            }

            Statistics = new ObservableCollection<Stats> { };

            api.ExamenesDS_ServiceResponse(RestAPI.Cedula);

            Console.WriteLine("->>>>>>>>>>>>>>>>>>>>>>>>>> salio");

            for (var i = 0; i < RestAPI.ExamenesResponse.materia.Count; i++)
            {
                Statistics.Add(new Stats
                {
                    Title = "Examen",
                    Label1 = RestAPI.ExamenesResponse.materia[i].nombreMateria,
                    Label2 = RestAPI.ExamenesResponse.materia[i].nombreMateria,
                    Value1 = RestAPI.ExamenesResponse.materia[i].nombreMateria,
                    Value2 = RestAPI.ExamenesResponse.materia[i].nombreMateria
                });
            }

            /*Statistics = new ObservableCollection<Stats>
            {
                new Stats { Title = "Examen", Label1 = "Agosto-Base de Datos", Label2 = "Agosto-Redes 2", Value1 = "24", Value2 = "27" },
                new Stats { Title = "Promedio Actual", Label1 = "Total", Label2 = "Semestre", Value1 = "4.5", Value2 = "5" }
            };

            api.ExamenesDS_ServiceResponse(RestAPI.Cedula).ContinueWith((antecedent) =>
            {
                Debug.WriteLine(@"DIEGO MENDEZ - EXAMENES  {0}", RestAPI.ExamenesResponse.materia.Count);
            });*/

        }

        #endregion

        #region methods

        public ObservableCollection<Stats> Statistics { get; set; }

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