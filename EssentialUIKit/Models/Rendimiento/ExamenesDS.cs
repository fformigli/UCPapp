using System.Collections.Generic;

namespace EssentialUIKit.Models.Rendimiento.Examenes
{
    public class Examene
    {
        public string fechaExamen { get; set; }
        public string periodo { get; set; }
        public string tipoExamen { get; set; }
    }

    public class Materia
    {
        public string curso { get; set; }
        public List<Examene> examenes { get; set; }
        public string nombreCarrera { get; set; }
        public string nombreMateria { get; set; }
        public string seccion { get; set; }
        public string semestre { get; set; }
        public string turno { get; set; }
    }

    public class ExamenesResult
    {
        public List<Materia> materia { get; set; }
    }
}
