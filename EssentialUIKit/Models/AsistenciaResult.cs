using System.Collections.Generic;

namespace EssentialUIKit.Models
{
    public class MateriaAsistenciaAlumno : Materia
    {
        public string CantidadDeAusencias { get; set; }
        public string PorcentajeDeAsistencia { get; set; }
        public string TopeDeAusencias { get; set; }

        public MateriaAsistenciaAlumno(string a, string b, string c, string d, string e) : base(d, e)
        {
            this.CantidadDeAusencias = a;
            this.PorcentajeDeAsistencia = b;
            this.TopeDeAusencias = c;
        }
    }

    public class AsistenciaResult
    {
        public List<MateriaAsistenciaAlumno> MateriaAsistenciaAlumno { get; set; }
    }
}
