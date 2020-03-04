using System.Collections.Generic;

namespace EssentialUIKit.Models
{
    public class Feriado
    {
        public string FechaFeriado { get; set; }
        public string MotivoFeriado { get; set; }
        public string TipoFeriado { get; set; }
    }

    public class Horario
    {
        public string Descripcion_aula { get; set; }
        public string Dia { get; set; }
        public string Edificio { get; set; }
        public string Fecha { get; set; }
        public string HoraFin { get; set; }
        public string HoraInicio { get; set; }
        public string Nombre_aula { get; set; }
        public string Piso_aula { get; set; }
        public string ProfesorApellidosYNombres { get; set; }
    }

    public class MateriaHorario : Materia
    {
        public List<Horario> Horario { get; set; }
    }

    public class HorariosResult
    {
        public List<Feriado> Feriados { get; set; }
        public List<MateriaHorario> Materia { get; set; }
    }
}
