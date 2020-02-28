using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;
using EssentialUIKit.Models;
using EssentialUIKit.DataService;

namespace EssentialUIKit.ViewModels
{
    [Preserve(AllMembers = true)]
    class AsistenciaPageViewModel
    {
        public List<MateriaAsistenciaAlumno> Materias { get; set; }

        public AsistenciaPageViewModel()
        {
            Materias = new List<MateriaAsistenciaAlumno>();

            InitAsistencia();
        }

        private void InitAsistencia()
        {
            var api = new RestAPI();
            api.getAsistencia();
            foreach (var item in RestAPI.AsistenciaResponse.MateriaAsistenciaAlumno)
            {
                Console.Write(item.NombreMateria);
            }

            Materias.Clear();
            Materias = RestAPI.AsistenciaResponse.MateriaAsistenciaAlumno;
        }
    }
}
