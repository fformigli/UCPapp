using EssentialUIKit.Models.Rendimiento;
using System;
using System.Threading.Tasks;

namespace EssentialUIKit.DataService
{
    public interface IRestService
    {
        Task<AsistenciaResult> GetMateriaAsistenciaAlumnoAsync(String nroDoc);

    }
}
