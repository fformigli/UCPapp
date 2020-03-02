﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;
using Xamarin.Forms;
using EssentialUIKit.Models;
using EssentialUIKit.DataService;

namespace EssentialUIKit.ViewModels
{
    [Preserve(AllMembers = true)]
    class AsistenciaPageViewModel : ContentPage
    {
        public List<MateriaAsistenciaAlumno> Materias { get; set; }
        public string Test { get; set; }

        public AsistenciaPageViewModel()
        {
            Materias = new List<MateriaAsistenciaAlumno>();

            InitAsistencia();

        }

        private void InitAsistencia()
        {
            var api = new RestAPI();
            api.getAsistencia();

            Materias.Clear();
            Materias.AddRange(RestAPI.AsistenciaResponse.MateriaAsistenciaAlumno);
        }
    }
}
