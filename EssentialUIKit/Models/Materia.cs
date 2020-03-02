using System;
using System.Collections.Generic;
using System.Text;

namespace EssentialUIKit.Models
{
    public class Materia
    {
        public string Anho { get; set; }
        public string NombreMateria { get; set; }
        public string NombreCarrera { get; set; }
        public string Curso { get; set; }
        public string Turno { get; set; }
        public string Seccion { get; set; }
        public string Semestre { get; set; }

        public Materia(string a, string b)
        {
            this.Anho = a;
            this.NombreMateria = b;
        }
    }
}
