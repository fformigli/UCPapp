using EssentialUIKit.Models.Rendimiento;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;


namespace EssentialUIKit.Data
{
    public class RestService : IRestService
    {
        HttpClient _client;

        public AsistenciaResult ItemsMateriaAsistenciaAlumno { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
        }

        async Task<AsistenciaResult> IRestService.GetMateriaAsistenciaAlumnoAsync(String nroDoc)
        {
            ItemsMateriaAsistenciaAlumno = new AsistenciaResult();

            var uri = new Uri(string.Format(Constants.AsistenciaAlumno, nroDoc));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ItemsMateriaAsistenciaAlumno = JsonConvert.DeserializeObject<AsistenciaResult>(content);
                    Debug.WriteLine(@"\tDIEGO MENDEZ - ASISTENCIAS {0}", ItemsMateriaAsistenciaAlumno.materiaAsistenciaAlumno.Count);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex);
                AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
                {
                    System.Exception ex2 = (System.Exception)args.ExceptionObject;
                    Console.WriteLine(ex2);
                };

            }

            return ItemsMateriaAsistenciaAlumno;
        }



        /*
       public async Task SaveTodoItemAsync(TodoItem item, bool isNewItem = false)
       {
           var uri = new Uri(string.Format(Constants.TodoItemsUrl, string.Empty));

           try
           {
               var json = JsonConvert.SerializeObject(item);
               var content = new StringContent(json, Encoding.UTF8, "application/json");

               HttpResponseMessage response = null;
               if (isNewItem)
               {
                   response = await _client.PostAsync(uri, content);
               }
               else
               {
                   response = await _client.PutAsync(uri, content);
               }

               if (response.IsSuccessStatusCode)
               {
                   Debug.WriteLine(@"\tTodoItem successfully saved.");
               }

           }
           catch (Exception ex)
           {
               Debug.WriteLine(@"\tERROR {0}", ex.Message);
           }
       }

       public async Task DeleteTodoItemAsync(string id)
       {
           var uri = new Uri(string.Format(Constants.TodoItemsUrl, id));

           try
           {
               var response = await _client.DeleteAsync(uri);

               if (response.IsSuccessStatusCode)
               {
                   Debug.WriteLine(@"\tTodoItem successfully deleted.");
               }

           }
           catch (Exception ex)
           {
               Debug.WriteLine(@"\tERROR {0}", ex.Message);
           }
       }*/
    }

}
