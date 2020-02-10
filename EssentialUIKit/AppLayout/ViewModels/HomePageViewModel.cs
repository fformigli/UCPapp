using EssentialUIKit.AppLayout.Models;
using EssentialUIKit.Data;
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
        public string userLogged { get; set; }

        private const string functionalitiesList = "EssentialUIKit.AppLayout.Menu.xml";

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


            string descAlumno;
            RestAPI api = new RestAPI();
            api.PerfilDS2_response("6948405");

            userLogged = api.perfilDS_response.nombres + " " + api.perfilDS_response.apellidos;
            descAlumno = api.perfilDS_response.nombres + " " + api.perfilDS_response.apellidos;

            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            userLogged = textInfo.ToTitleCase(userLogged.ToLower());
            descAlumno = textInfo.ToTitleCase(descAlumno.ToLower());

            if (api.perfilDS_response.sexo.Contains("M"))
            {
                descAlumno += " futuro";
            }
            else
            {
                descAlumno += " futura";
            }
            descAlumno += " profesional de ";
            string carrera = "";
            for (int i = 0; i < api.perfilDS_response.carreras.Count; i++)
            {
                if (i == 0)
                {
                    carrera += api.perfilDS_response.carreras[i].carrera;
                }
                else if (i == api.perfilDS_response.carreras.Count - 1)
                {
                    carrera += " y " + api.perfilDS_response.carreras[i].carrera;
                }
                else if (i > 0)
                {
                    carrera += ", " + api.perfilDS_response.carreras[i].carrera;
                }

            }
            descAlumno += carrera + ". En este portal encontrarás toda la información sobre tu estadía en la Universidad";
            Application.Current.Resources["Description"] = descAlumno;
            Application.Current.Resources["userLogged"] = userLogged;
            Console.Out.WriteLine(userLogged);
        }

        private void PopulateList()
        {
            Templates.Clear();

            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(functionalitiesList);

            using (var reader = new StreamReader(stream))
            {
                var xmlReader = XmlReader.Create(reader);
                xmlReader.Read();
                Category category = null;
                var runtimePlatform = Device.RuntimePlatform.ToLower();

                while (!xmlReader.EOF)
                {
                    Console.WriteLine("iterating: "+ xmlReader.Name +" "+ xmlReader.IsStartElement()+" "+ xmlReader.HasAttributes);
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