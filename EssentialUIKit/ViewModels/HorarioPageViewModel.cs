using System.Collections.Generic;
using System;
using Xamarin.Forms.Internals;
using Xamarin.Forms;
using EssentialUIKit.Models;
using EssentialUIKit.DataService;

namespace EssentialUIKit.ViewModels
{
    [Preserve(AllMembers = true)]
    class HorarioPageViewModel : ContentPage
    {
        public HorariosResult Horarios { get; set; }

        public HorarioPageViewModel()
        {
            Horarios = new HorariosResult();

            InitAsistencia();

        }

        private void InitAsistencia()
        {
            var api = new RestAPI();
            api.GetAsistencia();

            Horarios = RestAPI.HorarioResponse;

            foreach (var item in Horarios.Materia)
            {
                Console.WriteLine(item.NombreMateria);
                foreach (var item2 in item.Horario)
                {
                    Console.WriteLine("-----------"+ item2.HoraInicio+ " " + item2.HoraFin);
                }
            }
        }
    }
}
