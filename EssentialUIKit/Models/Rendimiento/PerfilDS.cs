using System.Collections.Generic;

namespace EssentialUIKit.Models.Rendimiento.Perfil
{


    public class Carrera
    {
        public string CarreraPerfil { get; set; }
        public string Estado { get; set; }
    }

    public class PerfilResult
    {
        public string Apellidos { get; set; }
        public List<Carrera> Carreras { get; set; }
        public string Nombres { get; set; }
        public string Sexo { get; set; }
    }
}
