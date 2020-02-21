﻿using EssentialUIKit.Models.Rendimiento;
using EssentialUIKit.Models.Rendimiento.Calificaciones;
using EssentialUIKit.Models.Rendimiento.Examenes;
using EssentialUIKit.Models.Rendimiento.Financiero;
using EssentialUIKit.Models.Rendimiento.Horarios;
using EssentialUIKit.Models.Rendimiento.Perfil;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using EssentialUIKit.Models;

namespace EssentialUIKit.DataService
{
    public class RestAPI
    {
        //private const string UrlService = "http://192.168.1.137:8480/hubcolumbia/rest/mobileService/";
        //private const string UrlService = "https://www.columbia.edu.py/acadweb/phone/mobileService/";
        private const string UrlService = "http://192.168.1.180:8080/acadweb/phone/mobileService/";
        private const string UrlLogin = "https://www.columbia.edu.py/ajax/loginMobile.php";
        
        public static string Cedula;

        private const string RendimientoServiceGet = UrlService + "rendimiento?cedula={0}&cantexam=4";

        private const string HorariosServiceGet = UrlService + "horarioAlumno?cedula={0}";
        private const string ExamenesServiceGet = UrlService + "examenesAlumno?cedula={0}";
        private const string CalificacionesServiceGet = UrlService + "calificacionAlumno?cedula={0}&mostrar=todas";
        private const string FinancieroServiceGet = UrlService + "financieroAlumno?cedula={0}&mostrar=todas";
        private const string AsistenciaServiceGet = UrlService + "asistenciaAlumno?cedula={0}";
        private const string PerfilServiceGet = UrlService + "perfil?cedula={0}";



        public static PerfilResult PerfilResponse { get; set; }
        public static RendimientoResult RendimientoResponse { get; set; }
        public static ExamenesResult ExamenesResponse { get; set; }

        public CalificacionesResult calificacionesDS_response { get; set; }
        public FinancieroResult financieroDS_response { get; set; }
        public AsistenciaResult asistenciaDS_response { get; set; }
        public HorariosResult horariosDS_response { get; set; }


        public static string AuthenticateLDAP(string username, string password)
        {
            var login = RestUtility.Login(UrlLogin, username, password);
            Cedula = login.Cedula.Trim();

            return login.Status.Equals("error")?login.Msg:login.Status;
        }

        public void getPerfil(String nroCedula)
        {
            PerfilResponse = RestUtility.CallServiceSync<PerfilResult>(string.Format(PerfilServiceGet, nroCedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as PerfilResult;
        }

        public void getRendimiento(String nroCedula)
        {
            RendimientoResponse = RestUtility.CallServiceSync<RendimientoResult>(string.Format(RendimientoServiceGet, nroCedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as RendimientoResult;
        }





        public void ExamenesDS_ServiceResponse(String nroCedula)
        {
            ExamenesResponse = RestUtility.CallServiceSync<ExamenesResult>(string.Format(ExamenesServiceGet, nroCedula), string.Empty, null, "GET",
               string.Empty, string.Empty) as ExamenesResult;

        }

        async public Task HoraraiosDS_ServiceResponse(String nroCedula)
        {
            this.horariosDS_response = await RestUtility.CallServiceAsync<HorariosResult>(string.Format(HorariosServiceGet, nroCedula), string.Empty, null, "GET",
              string.Empty, string.Empty) as HorariosResult;


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
            PerfilResponse = await RestUtility.CallServiceAsync<PerfilResult>(string.Format(PerfilServiceGet, nroCedula), string.Empty, null, "GET",
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
            Debug.WriteLine(@"\tDIEGO MENDEZ - RestApi {0}", lst_perfilDS_response.Carreras.Count);

        }
    }
}
