using EssentialUIKit.Models.Rendimiento.Calificaciones;
using EssentialUIKit.Models.Rendimiento.Examenes;
using EssentialUIKit.Models.Rendimiento.Financiero;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using EssentialUIKit.Models;
using EssentialUIKit.Data;

namespace EssentialUIKit.DataService
{
    public class RestAPI
    {
        public static string Cedula;

        public static PerfilResult PerfilResponse { get; set; }
        public static RendimientoResult RendimientoResponse { get; set; }
        public static ExamenesResult ExamenesResponse { get; set; }
        public static AsistenciaResult AsistenciaResponse { get; set; }
        public static HorariosResult HorarioResponse { get; set; }
        public static CalificacionesResult CalificacionResponse { get; set; }
        public static FinancieroResult FinancieroResponse { get; set; }


        public static string AuthenticateLDAP(string username, string password)
        {
            var login = RestUtility.Login(Constants.UrlLogin, username, password);
            Cedula = login.Cedula.Trim();

            return login.Status.Equals("error")?login.Msg:login.Status;
        }

        public static void Clear()
        {
            PerfilResponse = null;
            RendimientoResponse = null;
            AsistenciaResponse = null;
            HorarioResponse= null;
            CalificacionResponse = null;
            FinancieroResponse = null;
        }

        public void GetPerfil()
        {
            if (PerfilResponse != null)
                return;
            PerfilResponse = RestUtility.CallServiceSync<PerfilResult>(string.Format(Constants.PerfilServiceGet, Cedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as PerfilResult;
        }

        public void GetRendimiento()
        {
            if (RendimientoResponse != null)
                return;
            RendimientoResponse = RestUtility.CallServiceSync<RendimientoResult>(string.Format(Constants.RendimientoServiceGet, Cedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as RendimientoResult;
        }

        public void GetAsistencia()
        {
            if (AsistenciaResponse != null)
                return;
            AsistenciaResponse = RestUtility.CallServiceSync<AsistenciaResult>(string.Format(Constants.AsistenciaServiceGet, Cedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as AsistenciaResult;
        }

        public void GetHorario()
        {
            if (HorarioResponse != null)
                return;
            HorarioResponse = RestUtility.CallServiceSync<HorariosResult>(string.Format(Constants.HorarioServiceGet, Cedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as HorariosResult;
        }
        
        async public void demo()
        {

            ExamenesResult lst_examenesDS_response = await RestUtility.CallServiceAsync<ExamenesResult>(Constants.ExamenesServiceGet, string.Empty, null, "GET",
                  string.Empty, string.Empty) as ExamenesResult;


            CalificacionesResult lst_calificacionesDS_response = await RestUtility.CallServiceAsync<CalificacionesResult>(Constants.CalificacionesServiceGet, string.Empty, null, "GET",
             string.Empty, string.Empty) as CalificacionesResult;


            FinancieroResult lst_financieroDS_response = await RestUtility.CallServiceAsync<FinancieroResult>(Constants.FinancieroServiceGet, string.Empty, null, "GET",
             string.Empty, string.Empty) as FinancieroResult;


            AsistenciaResult lst_asistenciaDS_response = await RestUtility.CallServiceAsync<AsistenciaResult>(Constants.AsistenciaServiceGet, string.Empty, null, "GET",
             string.Empty, string.Empty) as AsistenciaResult;


            PerfilResult lst_perfilDS_response = await RestUtility.CallServiceAsync<PerfilResult>(Constants.PerfilServiceGet, string.Empty, null, "GET",
             string.Empty, string.Empty) as PerfilResult;

            Debug.WriteLine(@"\tDIEGO MENDEZ - RestApi {0}", lst_examenesDS_response.materia.Count);
            Debug.WriteLine(@"\tDIEGO MENDEZ - RestApi {0}", lst_calificacionesDS_response.materia.Count);
            Debug.WriteLine(@"\tDIEGO MENDEZ - RestApi {0}", lst_financieroDS_response.cabeceraFinancieroAlumno.Count);
            Debug.WriteLine(@"\tDIEGO MENDEZ - RestApi {0}", lst_asistenciaDS_response.MateriaAsistenciaAlumno.Count);
            Debug.WriteLine(@"\tDIEGO MENDEZ - RestApi {0}", lst_perfilDS_response.Carreras.Count);

        }
    }
}
