﻿using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using EssentialUIKit.AppLayout.Models;
using EssentialUIKit.Data;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace EssentialUIKit.AppLayout.ViewModels
{
    [Preserve(AllMembers = true)]
    public class HomePageViewModel
    {
        public string userLogged { get; set; }

        private const string sampleListFile = "EssentialUIKit.AppLayout.TemplateList.xml";

        public List<Category> Templates { get; set; }

        public Category SelectedCategory
        {
            set
            {
                if (value == null) return;

                //XmlSerializer xmlSerializer = new XmlSerializer(typeof(Category));

                //using (StringWriter textWriter = new StringWriter())
                //{
                //    xmlSerializer.Serialize(textWriter, value);

                //    var url = HttpUtility.UrlEncode(textWriter.ToString());

                //    Shell.Current.GoToAsync($@"templatepage?data1={url}", true);
                //}
            }
        }

        public HomePageViewModel()
        {
            Templates = new List<Category>();

            PopulateList();


            initPerfil();



        }
        private void initPerfil() {
            

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
            var stream = assembly.GetManifestResourceStream(sampleListFile);

            using (var reader = new StreamReader(stream))
            {
                var xmlReader = XmlReader.Create(reader);
                xmlReader.Read();
                Category category = null;
                var hasAdded = false;
                var runtimePlatform = Device.RuntimePlatform.ToLower();

                while (!xmlReader.EOF)
                {
                    switch (xmlReader.Name)
                    {
                        case "Category" when xmlReader.IsStartElement() && xmlReader.HasAttributes:
                        {
                            if (!hasAdded && category != null)
                            {
                                Templates.Add(category);
                                category = null;
                                hasAdded = true;
                            }

                            var platform = GetDataFromXmlReader(xmlReader, "Platform");
                            if (string.IsNullOrEmpty(platform) || platform.ToLower().Contains(runtimePlatform))
                            {
                                var categoryName = GetDataFromXmlReader(xmlReader, "Name");
                                var description = GetDataFromXmlReader(xmlReader, "Description");
                                var icon =
                                    $"EssentialUIKit.AppLayout.Icons.{GetDataFromXmlReader(xmlReader, "Icon")}";

                                category = new Category(categoryName, icon, description);
                            }

                            break;
                        }

                        case "Page" when xmlReader.IsStartElement() && xmlReader.HasAttributes && category != null:
                        {
                            var platform = GetDataFromXmlReader(xmlReader, "Platform");

                            if (string.IsNullOrEmpty(platform) || platform.ToLower().Contains(runtimePlatform))
                            {
                                var templateName = GetDataFromXmlReader(xmlReader, "Name");
                                var description = GetDataFromXmlReader(xmlReader, "Description");
                                var pageName = GetDataFromXmlReader(xmlReader, "PageName");
                                bool.TryParse(GetDataFromXmlReader(xmlReader, "LayoutFullscreen"),
                                    out var layoutFullScreen);

                                var template = new Template(templateName, description, pageName, layoutFullScreen);
                                Routing.RegisterRoute(templateName,
                                    assembly.GetType($"EssentialUIKit.{pageName}"));

                                category.Pages.Add(template);
                                hasAdded = false;
                            }

                            break;
                        }
                    }

                    xmlReader.Read();
                }

                if (!hasAdded)
                {
                    Templates.Add(category);
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