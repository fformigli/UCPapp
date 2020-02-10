
using Xamarin.Forms;

namespace EssentialUIKit.DataService
{
    public static class Constants
    {
        public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "http://192.168.1.137:8480" : "http://192.168.1.137:8480";
        public static string AsistenciaAlumno = BaseAddress + "/hubcolumbiatest/rest/mobileService/asistenciaAlumno?cedula={0}";

    }

}
