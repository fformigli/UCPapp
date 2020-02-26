using EssentialUIKit.DataService;
using EssentialUIKit.Models.Rendimiento;
using EssentialUIKit.Models;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Stats> Statistics { get; set; }

        public string DeudaTotalT { get; set; }
        public string PromedioActualT { get; set; }
        public int AsistenciaCount { get; set; }


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

            api.getRendimiento();
            api.getAsistencia();

            PromedioActualT = "Promedio Actual: " + RestAPI.RendimientoResponse.PromedioActual;
            DeudaTotalT = string.Format("{0:c}",RestAPI.RendimientoResponse.DeudaTotal)+ " pendiente de pago";
            AsistenciaCount = RestAPI.AsistenciaResponse.MateriaAsistenciaAlumno.Count;

            var title = "Examenes Próximos";          
            var materia1 = "";
            var fecha1 = "";
            var examen1 = "";
            for (var i = 0; i < RestAPI.RendimientoResponse.ExamenesProximos.Count; i++)
            {
                if ((i % 2) == 0)
                {
                    materia1 = RestAPI.RendimientoResponse.ExamenesProximos[i].Materia;
                    fecha1 = RestAPI.RendimientoResponse.ExamenesProximos[i].Fecha;
                    examen1 = RestAPI.RendimientoResponse.ExamenesProximos[i].TipoExamen;
                }
                else
                {
                    string materia2 = RestAPI.RendimientoResponse.ExamenesProximos[i].Materia;
                    string fecha2 = RestAPI.RendimientoResponse.ExamenesProximos[i].Fecha;
                    string examen2 = RestAPI.RendimientoResponse.ExamenesProximos[i].TipoExamen;

                    Statistics.Add(new Stats { Title = title, Materia1 = materia1, Materia2 = materia2, 
                        Fecha1 = fecha1, Fecha2 = fecha2, Examen1 = examen1, Examen2 = examen2 });
                }
            }


        }

        #endregion

        #region methods

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