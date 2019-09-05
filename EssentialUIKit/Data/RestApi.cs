using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using EssentialUIKit.Models.Rendimiento;
using EssentialUIKit.Models.Rendimiento.Calificaciones;
using EssentialUIKit.Models.Rendimiento.Examenes;
using EssentialUIKit.Models.Rendimiento.Financiero;
using EssentialUIKit.Models.Rendimiento.Perfil;
using EssentialUIKit.Models.Rendimiento.Horarios;
using System.Net.Http;

namespace EssentialUIKit.Data
{
    public class RestAPI
    {
        //para test cedula = 6948405
        //para test perfil cedula = 2024952
        private const string horariosService_Get = "http://192.168.1.137:8480/hubcolumbiatest/rest/mobileService/horarioAlumno?cedula={0}";
        private const string examenesService_Get = "http://192.168.1.137:8480/hubcolumbiatest/rest/mobileService/examenesAlumno?cedula={0}";
        private const string calificacionesService_Get = "http://192.168.1.137:8480/hubcolumbiatest/rest/mobileService/calificacionAlumno?cedula={0}&mostrar=todas";
        private const string financieroService_Get = "http://192.168.1.137:8480/hubcolumbiatest/rest/mobileService/financieroAlumno?cedula={0}&mostrar=todas";
        private const string asistenciaService_Get = "http://192.168.1.137:8480/hubcolumbiatest/rest/mobileService/asistenciaAlumno?cedula={0}";
        private const string perfilService_Get = "http://192.168.1.137:8480/hubcolumbiatest/rest/mobileService/perfil?cedula={0}";


        public ExamenesResult examenesDS_response { get; set; }
        public CalificacionesResult calificacionesDS_response { get; set; }
        public FinancieroResult financieroDS_response { get; set; }
        public AsistenciaResult asistenciaDS_response { get; set; }
        public PerfilResult perfilDS_response { get; set; }
        public HorariosResult horariosDS_response { get; set; }

        async public Task HoraraiosDS_ServiceResponse(String nroCedula)
        {
            this.horariosDS_response = await RestUtility.CallServiceAsync<HorariosResult>(string.Format(horariosService_Get, nroCedula), string.Empty, null, "GET",
              string.Empty, string.Empty) as HorariosResult;


        }
        async public Task ExamenesDS_ServiceResponse(String nroCedula)
        {
            this.examenesDS_response = await RestUtility.CallServiceAsync<ExamenesResult>(string.Format(examenesService_Get, nroCedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as ExamenesResult;
         

        }
        async public Task CalificacionesDS_response(String nroCedula)
        {
            this.calificacionesDS_response = await RestUtility.CallServiceAsync<CalificacionesResult>(string.Format(calificacionesService_Get, nroCedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as CalificacionesResult;
        }
        async public Task FinancieroDS_response(String nroCedula)
        {
            this.financieroDS_response = await RestUtility.CallServiceAsync<FinancieroResult>(string.Format(financieroService_Get, nroCedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as FinancieroResult;
        }
        async public Task AsistenciaDS_response(String nroCedula)
        {

            this.asistenciaDS_response = await RestUtility.CallServiceAsync<AsistenciaResult>(string.Format(asistenciaService_Get, nroCedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as AsistenciaResult;
        }

        
        async public Task PerfilDS_response(String nroCedula)
        {
            this.perfilDS_response = await RestUtility.CallServiceAsync<PerfilResult>(string.Format(perfilService_Get, nroCedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as PerfilResult;
        }

         public void PerfilDS2_response(String nroCedula)
        {
            //6948405
            this.perfilDS_response = RestUtility.CallServiceSync<PerfilResult>(string.Format(perfilService_Get, nroCedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as PerfilResult;

            
        }
        public void HoraraiosDS2_ServiceResponse(String nroCedula)
        {
            //6948405
            this.horariosDS_response = RestUtility.CallServiceSync<HorariosResult>(string.Format(horariosService_Get, nroCedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as HorariosResult;


        }



        async public void demo()
        {

         ExamenesResult lst_examenesDS_response = await RestUtility.CallServiceAsync<ExamenesResult>(examenesService_Get, string.Empty, null, "GET",
               string.Empty, string.Empty) as ExamenesResult;


            CalificacionesResult lst_calificacionesDS_response = await RestUtility.CallServiceAsync<CalificacionesResult>(calificacionesService_Get, string.Empty, null, "GET",
             string.Empty, string.Empty) as CalificacionesResult;


            FinancieroResult lst_financieroDS_response = await RestUtility.CallServiceAsync<FinancieroResult>(financieroService_Get, string.Empty, null, "GET",
             string.Empty, string.Empty) as FinancieroResult;


            AsistenciaResult lst_asistenciaDS_response = await RestUtility.CallServiceAsync<AsistenciaResult>(asistenciaService_Get, string.Empty, null, "GET",
             string.Empty, string.Empty) as AsistenciaResult;


            PerfilResult lst_perfilDS_response = await RestUtility.CallServiceAsync<PerfilResult>(perfilService_Get, string.Empty, null, "GET",
             string.Empty, string.Empty) as PerfilResult;

            Debug.WriteLine(@"\tDIEGO MENDEZ - RestApi {0}", lst_examenesDS_response.materia.Count);
            Debug.WriteLine(@"\tDIEGO MENDEZ - RestApi {0}", lst_calificacionesDS_response.materia.Count);
            Debug.WriteLine(@"\tDIEGO MENDEZ - RestApi {0}", lst_financieroDS_response.cabeceraFinancieroAlumno.Count);
            Debug.WriteLine(@"\tDIEGO MENDEZ - RestApi {0}", lst_asistenciaDS_response.materiaAsistenciaAlumno.Count);
            Debug.WriteLine(@"\tDIEGO MENDEZ - RestApi {0}", lst_perfilDS_response.carreras.Count);

        }
    }
}
