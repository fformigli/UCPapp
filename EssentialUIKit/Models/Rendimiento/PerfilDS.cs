using System;
using System.Collections.Generic;
using System.Text;

namespace EssentialUIKit.Models.Rendimiento.Perfil
{
     

    public class Carrera
    {
        public string carrera { get; set; }
        public string estado { get; set; }
    }

    public class PerfilResult
    {
        public string apellidos { get; set; }
        public List<Carrera> carreras { get; set; }
        public string nombres { get; set; }
        public string sexo { get; set; }
    }
}
