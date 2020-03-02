using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EssentialUIKit.Models;

namespace EssentialUIKit.DataService
{
    class RestUtility
    {

        public static object CallServiceSync<T>(string url, string operation, object requestBodyObject, string method, string username,
          string password) where T : class
        {
            try
            {
                var client = new HttpClient();
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    // by calling .Result you are synchronously reading the result
                    string responseString = responseContent.ReadAsStringAsync().Result;

                    Console.WriteLine(responseString);
                    return JsonConvert.DeserializeObject<T>(responseString);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }


            return null;

        }
        public static async Task<object> CallServiceAsync<T>(string url, string operation, object requestBodyObject, string method, string username,
       string password) where T : class
        {
            // Initialize an HttpWebRequest for the current URL.
            var webReq = (HttpWebRequest)WebRequest.Create(url);
            webReq.Method = method;
            webReq.Accept = "application/json";

            //Add basic authentication header if username is supplied
            if (!string.IsNullOrEmpty(username))
            {
                webReq.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password));
            }

            //Add key to header if operation is supplied
            if (!string.IsNullOrEmpty(operation))
            {
                webReq.Headers["Operation"] = operation;
            }

            //Serialize request object as JSON and write to request body
            if (requestBodyObject != null)
            {
                var requestBody = JsonConvert.SerializeObject(requestBodyObject);
                webReq.ContentLength = requestBody.Length;
                var streamWriter = new StreamWriter(webReq.GetRequestStream(), Encoding.ASCII);
                streamWriter.Write(requestBody);
                streamWriter.Close();
            }

            var response = await webReq.GetResponseAsync();

            if (response == null)
            {
                return default;
            }

            var streamReader = new StreamReader(response.GetResponseStream());

            var responseContent = streamReader.ReadToEnd().Trim();

            var jsonObject = JsonConvert.DeserializeObject<T>(responseContent);

            return jsonObject;
        }

        public static Login Login(string url, string username, string password)
        {
            var postData = "username=" + username + "&password=" + password;
            var data = Encoding.ASCII.GetBytes(postData);
            
            // Initialize an HttpWebRequest for the current URL.
            var webReq = (HttpWebRequest)WebRequest.Create(url);
            webReq.Method = WebRequestMethods.Http.Post;
            webReq.ContentType = "application/x-www-form-urlencoded";
            webReq.Accept = "application/json";
            webReq.ContentLength = data.Length;
            Console.WriteLine(data.Length);
            
            //create stream
            var requestStream = webReq.GetRequestStream();
            requestStream.Write(data, 0 ,data.Length);
            requestStream.Close();

            // response
            var response = webReq.GetResponse();

            var streamReader = new StreamReader(response.GetResponseStream());

            var responseContent = streamReader.ReadToEnd().Trim();

            Console.WriteLine("RestUtility 116: "+responseContent);

            var jsonObject = JsonConvert.DeserializeObject<Login>(responseContent);

            return jsonObject;
        }
    }
}
