using System.Collections.Generic;
using Xamarin.Forms.Internals;
using Xamarin.Forms;
using EssentialUIKit.Models;
using EssentialUIKit.DataService;

namespace EssentialUIKit.ViewModels
{
    [Preserve(AllMembers = true)]
    class FinancieroPageViewModel : ContentPage
    {
        public List<DetalleFinancieroAlumnoResult> Financieros { get; set; }

        public FinancieroPageViewModel()
        {
            Financieros = new List<DetalleFinancieroAlumnoResult>();

            InitFinanciero();

        }

        private void InitFinanciero()
        {
            var api = new RestAPI();
            api.GetFinanciero();

            Financieros.Clear();
            Financieros = RestAPI.FinancieroResponse.DetalleFinancieroAlumno;
        }
    }
}
