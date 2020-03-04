using System.Collections.Generic;

namespace EssentialUIKit.Models
{
    public class MateriaAsistenciaAlumno : Materia
    {
        public string CantidadDeAusencias { get; set; }
        public string PorcentajeDeAsistencia { get; set; }
        public string TopeDeAusencias { get; set; }

    }

    public class AsistenciaResult
    {
        public List<MateriaAsistenciaAlumno> MateriaAsistenciaAlumno { get; set; }
    }
}
