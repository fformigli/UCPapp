using System.Collections.Generic;
using Xamarin.Forms.Internals;
using Xamarin.Forms;
using EssentialUIKit.Models;
using EssentialUIKit.DataService;

namespace EssentialUIKit.ViewModels
{
    [Preserve(AllMembers = true)]
    class InscripcionPageViewModel : ContentPage
    {
        public List<MateriaAsistenciaAlumno> Materias { get; set; }

        public InscripcionPageViewModel()
        {
            Materias = new List<MateriaAsistenciaAlumno>();

            InitInscripciones();

        }

        private void InitInscripciones()
        {
            var api = new RestAPI();
            api.GetAsistencia();

            Materias.Clear();
            Materias = RestAPI.AsistenciaResponse.MateriaAsistenciaAlumno;
        }
    }
}
