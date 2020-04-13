using System.Collections.Generic;
using System;
using Xamarin.Forms.Internals;
using Xamarin.Forms;
using EssentialUIKit.Models;
using EssentialUIKit.DataService;
using System.Collections.ObjectModel;

namespace EssentialUIKit.ViewModels
{
    [Preserve(AllMembers = true)]
    class HorarioPageViewModel : ContentPage
    {
        public List<MateriaHorarioList> Materias { get; set; }

        public HorarioPageViewModel()
        {
            Materias = new List<MateriaHorarioList>();

            InitHorario();
        }

        private void InitHorario()
        {
            var api = new RestAPI();
            api.GetHorario();

            foreach (var materia in RestAPI.HorarioResponse.Materia)
            {
                /*Materias.Add(new MateriaHorarioList
                {
                    Materia = materia
                });*/
                var Mhl = new MateriaHorarioList { Materia = materia };
                foreach (var horario in materia.Horario)
                {
                    Mhl.Add(horario);
                }
                Materias.Add(Mhl);

            }
        }
    }
}
