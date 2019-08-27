using System;
using System.Collections.Generic;
using System.Text;

namespace EssentialUIKit.Models.Rendimiento.Calificaciones
{
    public class NotaParcial
    {
        public string ausente { get; set; }
        public string ausenteRecuperatorio { get; set; }
        public string fechaExamen { get; set; }
        public string nota { get; set; }
        public string notaRecuperatorio { get; set; }
        public string puntajeTrabajoEnClase { get; set; }
        public string puntajeTrabajoPractico { get; set; }
        public string puntosEvaluacion { get; set; }
        public string tipoExamen { get; set; }
    }

    public class NotasFinale
    {
        public string fechaExamen { get; set; }
        public string nombreLargo { get; set; }
        public string notaPlanilla { get; set; }
        public string periodo { get; set; }
        public string puntajeFinal { get; set; }
        public string puntajeParcial { get; set; }
        public string sumaFinal { get; set; }
        public string tipoExamen { get; set; }
    }

    public class Materia
    {
        public string anho { get; set; }
        public string curso { get; set; }
        public string nombreCarrera { get; set; }
        public string nombreMateria { get; set; }
        public NotaParcial notaParcial { get; set; }
        public List<NotasFinale> notasFinales { get; set; }
        public string porcentajeAsistencia { get; set; }
        public string seccion { get; set; }
        public string semestre { get; set; }
        public string turno { get; set; }
    }

    public class CalificacionesResult
    {
        public List<Materia> materia { get; set; }
    }
}
