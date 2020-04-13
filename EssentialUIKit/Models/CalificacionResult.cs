using System.Collections.Generic;

namespace EssentialUIKit.Models
{
    public class NotaParcial
    {
        public string Ausente { get; set; }
        public string AusenteRecuperatorio { get; set; }
        public string FechaExamen { get; set; }
        public string Nota { get; set; }
        public string NotaRecuperatorio { get; set; }
        public string PuntajeTrabajoEnClase { get; set; }
        public string PuntajeTrabajoPractico { get; set; }
        public string PuntosEvaluacion { get; set; }
        public string TipoExamen { get; set; }
    }

    public class NotaFinal
    {
        public string FechaExamen { get; set; }
        public string NombreLargo { get; set; }
        public string NotaPlanilla { get; set; }
        public string Periodo { get; set; }
        public string PuntajeFinal { get; set; }
        public string PuntajeParcial { get; set; }
        public string SumaFinal { get; set; }
        public string TipoExamen { get; set; }
    }

    public class MateriaCalificacion : Materia
    {
        public NotaParcial NotaParcial { get; set; }
        public List<NotaFinal> NotasFinales { get; set; }
        public NotaFinal UltimaNota { get; set; }
    }

    public class CalificacionResult
    {
        public List<MateriaCalificacion> MateriaCalificacion { get; set; }
    }
}
