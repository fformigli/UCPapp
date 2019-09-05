using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EssentialUIKit.Models.Rendimiento.Horarios
{
    public class Feriado
    {
        public string fechaFeriado { get; set; }
        public string motivoFeriado { get; set; }
        public string tipoFeriado { get; set; }
    }

    public class Horario
    {
        public string descripcion_aula { get; set; }
        public string dia { get; set; }
        public string edificio { get; set; }
        public string fecha { get; set; }
        public string horaFin { get; set; }
        public string horaInicio { get; set; }
        public string nombre_aula { get; set; }
        public string piso_aula { get; set; }
        public string profesorApellidosYNombres { get; set; }
    }

    public class Materia
    {
        public string curso { get; set; }
        public List<Horario> horario { get; set; }
        public string nombreCarrera { get; set; }
        public string nombreMateria { get; set; }
        public string seccion { get; set; }
        public string semestre { get; set; }
        public string turno { get; set; }
        public string descripcion { get {
                string respuesta = "";
                for (int i = 0; i < this.horario.Count; i++) {
                    Horario horario = this.horario[i];
                    respuesta += "Materia: "+nombreMateria+", Aula: " + horario.nombre_aula + ", Piso: " + horario.piso_aula + ", Edificio: " + horario.edificio + ", Día: " + horario.dia + ". De " + horario.horaInicio.Substring(0,5) + " a " + horario.horaFin.Substring(0, 5) + " Horas.\n";
                }
                return respuesta;

            }  }

        public string profesores { get {
                string respuesta = "";
                int cantTeacher = 0;
                for (int i = 0; i < this.horario.Count; i++)
                {
                    Horario horario = this.horario[i];
                    if (!respuesta.Contains(horario.profesorApellidosYNombres)) {
                        cantTeacher++;
                        respuesta += horario.profesorApellidosYNombres+". ";
                    }
                   
                }
                var regex = new Regex(Regex.Escape(","));
                respuesta = regex.Replace(respuesta, "", 1);

                if (cantTeacher >= 2)
                {              
                
                    respuesta = respuesta.Remove(respuesta.LastIndexOf(","), 1).Insert(respuesta.LastIndexOf(","), " y");
                    
                }

                if (cantTeacher > 1)
                {
                    respuesta = "Profesores: "+respuesta;
                }
                else
                {
                    respuesta = "Profesor: "+respuesta;
                }
                return respuesta;
            } }
    }

    public class HorariosResult
    {
        public List<Feriado> feriados { get; set; }
        public List<Materia> materia { get; set; }
    }
}
