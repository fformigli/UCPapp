using EssentialUIKit.Models;
using EssentialUIKit.Data;

namespace EssentialUIKit.DataService
{
    public class RestAPI
    {
        public static string Cedula;

        public static PerfilResult PerfilResponse { get; set; }
        public static RendimientoResult RendimientoResponse { get; set; }
        public static AsistenciaResult AsistenciaResponse { get; set; }
        public static HorariosResult HorarioResponse { get; set; }
        public static CalificacionResult CalificacionResponse { get; set; }
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

        public void GetCalificacion()
        {
            if (CalificacionResponse != null)
                return;
            CalificacionResponse = RestUtility.CallServiceSync<CalificacionResult>(string.Format(Constants.CalificacionesServiceGet, Cedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as CalificacionResult;
        }

        public void GetFinanciero()
        {
            if (FinancieroResponse != null)
                return;
            FinancieroResponse = RestUtility.CallServiceSync<FinancieroResult>(string.Format(Constants.FinancieroServiceGet, Cedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as FinancieroResult;
        }
    }
}
