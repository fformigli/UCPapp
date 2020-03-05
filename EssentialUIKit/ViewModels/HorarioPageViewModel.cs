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
        public List<MateriaHorario> Materias { get; set; }

        public HorarioPageViewModel()
        {
            Materias = new List<MateriaHorario>();

            InitHorario();

        }

        private void InitHorario()
        {
            var api = new RestAPI();
            api.GetHorario();

            Materias = RestAPI.HorarioResponse.Materia;

            foreach (var item in Materias)
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
