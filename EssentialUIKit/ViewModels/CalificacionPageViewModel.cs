using System.Collections.Generic;
using Xamarin.Forms.Internals;
using Xamarin.Forms;
using System;
using EssentialUIKit.Models;
using EssentialUIKit.DataService;

namespace EssentialUIKit.ViewModels
{
    [Preserve(AllMembers = true)]
    class CalificacionPageViewModel : ContentPage
    {
        public List<MateriaCalificacion> Materias { get; set; }

        public CalificacionPageViewModel()
        {
            Materias = new List<MateriaCalificacion>();

            InitCalificacion();

        }

        private void InitCalificacion()
        {
            var api = new RestAPI();
            api.GetCalificacion();

            Materias.Clear();
            Materias = RestAPI.CalificacionResponse.MateriaCalificacion;

            Console.WriteLine(Materias.Count);
        }
    }
}
