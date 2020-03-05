using System.Collections.Generic;
using Xamarin.Forms.Internals;
using Xamarin.Forms;
using EssentialUIKit.Models;
using EssentialUIKit.DataService;
using System.Collections.ObjectModel;

namespace EssentialUIKit.ViewModels
{
    [Preserve(AllMembers = true)]
    class AsistenciaPageViewModel : ContentPage
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
            api.GetAsistencia();

            Materias.Clear();
            Materias = RestAPI.AsistenciaResponse.MateriaAsistenciaAlumno;
        }
    }
}
