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
            NombreAlumno = RestAPI.PerfilResponse.Nombres + " " + RestAPI.PerfilResponse.Apellidos;
            CarreraPerfil = "";
            for (var i = 0; i < RestAPI.PerfilResponse.Carreras.Count; i++)
            {
                if (i == 0)
                    CarreraPerfil += RestAPI.PerfilResponse.Carreras[i].CarreraPerfil;
                else if (i == RestAPI.PerfilResponse.Carreras.Count - 1)
                    CarreraPerfil += " y " + RestAPI.PerfilResponse.Carreras[i].CarreraPerfil;
                else if (i > 0)
                    CarreraPerfil += ", " + RestAPI.PerfilResponse.Carreras[i].CarreraPerfil;
            }

            Statistics = new ObservableCollection<Stats> { };

            api.getRendimiento(RestAPI.Cedula);
            var  title = "Examenes Próximos";          
            var label1 = "";         
            var value1 = "";
            for (var i = 0; i < RestAPI.RendimientoResponse.ExamenesProximos.Count; i++)
            {
                if ((i % 2) == 0)
                {
                    label1 = RestAPI.RendimientoResponse.ExamenesProximos[i].Materia;
                    value1 = RestAPI.RendimientoResponse.ExamenesProximos[i].Fecha+" "+RestAPI.RendimientoResponse.ExamenesProximos[i].Fecha;
                }
                else
                {
                    string label2 = RestAPI.RendimientoResponse.ExamenesProximos[i].Materia;
                    string value2 = RestAPI.RendimientoResponse.ExamenesProximos[i].Fecha+" "+RestAPI.RendimientoResponse.ExamenesProximos[i].Fecha;

                    Statistics.Add(new Stats { Title = title, Label1 = label1, Label2 = label2, Value1 = value1, Value2 = value2 });
                }
            }
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