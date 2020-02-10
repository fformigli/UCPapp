using EssentialUIKit.Models.Rendimiento;
using EssentialUIKit.Models.Rendimiento.Calificaciones;
using EssentialUIKit.Models.Rendimiento.Examenes;
using EssentialUIKit.Models.Rendimiento.Financiero;
using EssentialUIKit.Models.Rendimiento.Horarios;
using EssentialUIKit.Models.Rendimiento.Perfil;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EssentialUIKit.DataService
{
    public class RestAPI
    {
        private const string UrlService = "https://www.columbia.edu.py/acadweb/phone/mobileService/";
        //"http://192.168.1.137:8480/hubcolumbia/rest/mobileService/";

        //para test cedula = 6948405
        //para test perfil cedula = 2024952
        private const string HorariosServiceGet = UrlService + "horarioAlumno?cedula={0}";
        private const string ExamenesServiceGet = UrlService + "examenesAlumno?cedula={0}";
        private const string CalificacionesServiceGet = UrlService + "calificacionAlumno?cedula={0}&mostrar=todas";
        private const string FinancieroServiceGet = UrlService + "financieroAlumno?cedula={0}&mostrar=todas";
        private const string AsistenciaServiceGet = UrlService + "asistenciaAlumno?cedula={0}";
        private const string PerfilServiceGet = UrlService + "perfil?cedula={0}";


        public ExamenesResult examenesDS_response { get; set; }
        public CalificacionesResult calificacionesDS_response { get; set; }
        public FinancieroResult financieroDS_response { get; set; }
        public AsistenciaResult asistenciaDS_response { get; set; }
        public PerfilResult perfilDS_response { get; set; }
        public HorariosResult horariosDS_response { get; set; }

        async public Task HoraraiosDS_ServiceResponse(String nroCedula)
        {
            this.horariosDS_response = await RestUtility.CallServiceAsync<HorariosResult>(string.Format(HorariosServiceGet, nroCedula), string.Empty, null, "GET",
              string.Empty, string.Empty) as HorariosResult;


        }
        async public Task ExamenesDS_ServiceResponse(String nroCedula)
        {
            this.examenesDS_response = await RestUtility.CallServiceAsync<ExamenesResult>(string.Format(ExamenesServiceGet, nroCedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as ExamenesResult;


        }
        async public Task CalificacionesDS_response(String nroCedula)
        {
            this.calificacionesDS_response = await RestUtility.CallServiceAsync<CalificacionesResult>(string.Format(CalificacionesServiceGet, nroCedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as CalificacionesResult;
        }
        async public Task FinancieroDS_response(String nroCedula)
        {
            this.financieroDS_response = await RestUtility.CallServiceAsync<FinancieroResult>(string.Format(FinancieroServiceGet, nroCedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as FinancieroResult;
        }
        async public Task AsistenciaDS_response(String nroCedula)
        {

            this.asistenciaDS_response = await RestUtility.CallServiceAsync<AsistenciaResult>(string.Format(AsistenciaServiceGet, nroCedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as AsistenciaResult;
        }


        async public Task PerfilDS_response(String nroCedula)
        {
            this.perfilDS_response = await RestUtility.CallServiceAsync<PerfilResult>(string.Format(PerfilServiceGet, nroCedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as PerfilResult;
        }

        public void PerfilDS2_response(String nroCedula)
        {
            Console.WriteLine("Solicitando perfil" + nroCedula);
            //6948405
            this.perfilDS_response = RestUtility.CallServiceSync<PerfilResult>(string.Format(PerfilServiceGet, nroCedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as PerfilResult;


        }
        public void HoraraiosDS2_ServiceResponse(String nroCedula)
        {
            //6948405
            this.horariosDS_response = RestUtility.CallServiceSync<HorariosResult>(string.Format(HorariosServiceGet, nroCedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as HorariosResult;


        }



        async public void demo()
        {

            ExamenesResult lst_examenesDS_response = await RestUtility.CallServiceAsync<ExamenesResult>(ExamenesServiceGet, string.Empty, null, "GET",
                  string.Empty, string.Empty) as ExamenesResult;


            CalificacionesResult lst_calificacionesDS_response = await RestUtility.CallServiceAsync<CalificacionesResult>(CalificacionesServiceGet, string.Empty, null, "GET",
             string.Empty, string.Empty) as CalificacionesResult;


            FinancieroResult lst_financieroDS_response = await RestUtility.CallServiceAsync<FinancieroResult>(FinancieroServiceGet, string.Empty, null, "GET",
             string.Empty, string.Empty) as FinancieroResult;


            AsistenciaResult lst_asistenciaDS_response = await RestUtility.CallServiceAsync<AsistenciaResult>(AsistenciaServiceGet, string.Empty, null, "GET",
             string.Empty, string.Empty) as AsistenciaResult;


            PerfilResult lst_perfilDS_response = await RestUtility.CallServiceAsync<PerfilResult>(PerfilServiceGet, string.Empty, null, "GET",
             string.Empty, string.Empty) as PerfilResult;

            Debug.WriteLine(@"\tDIEGO MENDEZ - RestApi {0}", lst_examenesDS_response.materia.Count);
            Debug.WriteLine(@"\tDIEGO MENDEZ - RestApi {0}", lst_calificacionesDS_response.materia.Count);
            Debug.WriteLine(@"\tDIEGO MENDEZ - RestApi {0}", lst_financieroDS_response.cabeceraFinancieroAlumno.Count);
            Debug.WriteLine(@"\tDIEGO MENDEZ - RestApi {0}", lst_asistenciaDS_response.materiaAsistenciaAlumno.Count);
            Debug.WriteLine(@"\tDIEGO MENDEZ - RestApi {0}", lst_perfilDS_response.carreras.Count);

        }

        public bool AuthenticateLDAP(string username, string password)
        {
            Console.WriteLine(username + " " + password);
            return true;
        }
    }
}
