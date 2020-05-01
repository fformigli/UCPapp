using System.Collections.Generic;

namespace EssentialUIKit.Models
{
    public class MateriaInscripcionAlumno : Materia
    {
        public string CantidadDeAusencias { get; set; }
        public string PorcentajeDeAsistencia { get; set; }
        public string TopeDeAusencias { get; set; }

    }

    public class InscripcionResult
    {
        public List<MateriaInscripcionAlumno> MateriaInscripcionAlumno { get; set; }
    }
}
