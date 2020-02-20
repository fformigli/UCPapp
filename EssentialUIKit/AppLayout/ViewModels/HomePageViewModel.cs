using EssentialUIKit.AppLayout.Models;
using EssentialUIKit.DataService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.AppLayout.ViewModels
{
    [Preserve(AllMembers = true)]
    public class HomePageViewModel
    {
        public string UserLogged { get; set; }
        public string DescAlumno { get; set; }

        private const string FunctionalitiesList = "EssentialUIKit.AppLayout.Menu.xml";

        public List<Category> Templates { get; set; }

        public Category SelectedCategory
        {
            set
            {
                if (value == null) return;
            }
        }

        public HomePageViewModel()
        {
            Templates = new List<Category>();

            PopulateList();

            InitPerfil();
        }
        private void InitPerfil()
        {
            var api = new RestAPI();
            api.getPerfil(RestAPI.Cedula);

            UserLogged = RestAPI.perfilResponse.Nombres + " " + RestAPI.perfilResponse.Apellidos;

            

            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            var textInfo = cultureInfo.TextInfo;
            UserLogged = textInfo.ToTitleCase(UserLogged.ToLower());
            DescAlumno = UserLogged + " futur";
            DescAlumno += RestAPI.perfilResponse.Sexo.Contains("M") ? "o" : "a";
            DescAlumno += " profesional de ";

            var carrera = "";
            for (var i = 0; i < RestAPI.perfilResponse.Carreras.Count; i++)
            {
                if (i == 0)
                    carrera += RestAPI.perfilResponse.Carreras[i].CarreraPerfil;
                /*else if (i == RestAPI.perfilDS_response.Carreras.Count - 1)
                    carrera += " y " + RestAPI.perfilDS_response.Carreras[i].CarreraPerfil;
                else if (i > 0)
                    carrera += ", " + RestAPI.perfilDS_response.Carreras[i].CarreraPerfil;*/
            }
            DescAlumno += carrera + ". En este portal encontrarás toda la información sobre tu estadía en la Universidad";

            Application.Current.Resources["Description"] = DescAlumno;
        }

        private void PopulateList()
        {
            Templates.Clear();

            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(FunctionalitiesList);

            using (var reader = new StreamReader(stream))
            {
                var xmlReader = XmlReader.Create(reader);
                xmlReader.Read();
                Category category = null;
                var runtimePlatform = Device.RuntimePlatform.ToLower();

                while (!xmlReader.EOF)
                {
                    switch (xmlReader.Name)
                    {
                        case "Category" when xmlReader.IsStartElement():
                            {

                                var platform = GetDataFromXmlReader(xmlReader, "Platform");
                                if (string.IsNullOrEmpty(platform) || platform.ToLower().Contains(runtimePlatform))
                                {
                                    var categoryName = GetDataFromXmlReader(xmlReader, "Name");
                                    var description = GetDataFromXmlReader(xmlReader, "Description");
                                    var pageName = GetDataFromXmlReader(xmlReader, "PageName");
                                    var icon = $"EssentialUIKit.AppLayout.Icons.{GetDataFromXmlReader(xmlReader, "Icon")}";

                                    category = new Category(categoryName, icon, description, pageName);

                                    Routing.RegisterRoute(categoryName,
                                        assembly.GetType($"EssentialUIKit.{pageName}"));
                                }
                                Templates.Add(category);

                                break;
                            }
                    }

                    xmlReader.Read();
                }
            }
        }

        public static string GetDataFromXmlReader(XmlReader reader, string attribute)
        {
            reader.MoveToAttribute(attribute);
            return reader.Value;
        }
    }
}