using System.Collections.Generic;

namespace EssentialUIKit.Models.Rendimiento
{
    public class MateriaAsistenciaAlumno
    {
        public string cantidadDeAusencias { get; set; }
        public string curso { get; set; }
        public string nombreCarrera { get; set; }
        public string nombreMateria { get; set; }
        public string porcentajeDeAsistencia { get; set; }
        public string seccion { get; set; }
        public string semestre { get; set; }
        public string topeDeAusencias { get; set; }
        public string turno { get; set; }
    }

    public class AsistenciaResult
    {
        public List<MateriaAsistenciaAlumno> materiaAsistenciaAlumno { get; set; }
    }
}
