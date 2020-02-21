using System;
using System.Collections.Generic;
using System.Text;

namespace EssentialUIKit.Models
{
    public class ExamenRendimiento
    {
        public string Fecha { get; set; }

        public string Materia { get; set; }
        public string TipoExamen { get; set; }

    }
    public class CarreraRendimiento
    {
        public string DuracionCarrera { get; set; }
    }
    public class RendimientoResult
    {
        public int DeudaTotal { get; set; }
        public float PromedioActual { get; set; }
        public List<CarreraRendimiento> CarrerasRendimiento { get; set; }
        public List<ExamenRendimiento> ExamenesProximos { get; set; }

    }
}
