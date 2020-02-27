
using Xamarin.Forms;

namespace EssentialUIKit.Data
{
    public static class Constants
    {

        //URLS PRINCIPALES
        //private const string UrlService = "http://192.168.1.137:8480/hubcolumbia/rest/mobileService/";
        //private const string UrlService = "https://www.columbia.edu.py/acadweb/phone/mobileService/";
        public const string UrlService = "http://192.168.1.180:8080/acadweb/phone/mobileService/";
        //private const string UrlService = "http://192.168.0.3:5000/";
        public const string UrlLogin = "https://www.columbia.edu.py/ajax/loginMobile.php";

        public const string PerfilServiceGet = UrlService + "perfil?cedula={0}";
        public const string RendimientoServiceGet = UrlService + "rendimiento?cedula={0}&cantexam=4";
        public const string AsistenciaServiceGet = UrlService + "asistenciaAlumno?cedula={0}";
        public const string HorarioServiceGet = UrlService + "horarioAlumno?cedula={0}";
        public const string CalificacionesServiceGet = UrlService + "calificacionAlumno?cedula={0}&mostrar=todas";
        public const string FinancieroServiceGet = UrlService + "financieroAlumno?cedula={0}&mostrar=todas";
        public const string ExamenesServiceGet = UrlService + "examenesAlumno?cedula={0}";
    }

}
