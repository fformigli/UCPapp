using EssentialUIKit.DataService;
using EssentialUIKit.Models.Rendimiento;
using System;
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
            try {
                //cargar perfil
                var api = new RestAPI();
                NombreAlumno = RestAPI.PerfilResponse.Nombres + " " + RestAPI.PerfilResponse.Apellidos;
                CarreraPerfil = Extensions.GetCarrerasPerfil();

                Statistics = new ObservableCollection<Stats> { };

                api.GetRendimiento();
                api.GetAsistencia();
                api.GetCalificacion();

                PromedioActualT = "Promedio Actual: " + RestAPI.RendimientoResponse.PromedioActual;
                DeudaTotalT = string.Format("{0:c}",RestAPI.RendimientoResponse.DeudaTotal)+ " pendiente de pago";
                AsistenciaCount = RestAPI.AsistenciaResponse.MateriaAsistenciaAlumno.Count;

                var title = "Examenes Próximos";          
                var materia1 = "";
                var fecha1 = "";
                var examen1 = "";
                if(RestAPI.RendimientoResponse.ExamenesProximos.Count > 0)
                {
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
                } else
                    Statistics.Add(new Stats
                    {
                        Title = title,
                        Materia1 = "",
                        Materia2 = "",
                        Fecha1 = "Sin "+title,
                        Fecha2 = "",
                        Examen1 = "",
                        Examen2 = ""
                    });
                
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
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