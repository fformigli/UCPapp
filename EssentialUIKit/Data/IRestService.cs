using EssentialUIKit.Models.Rendimiento;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EssentialUIKit.Data
{
    public interface IRestService
    {
         Task<AsistenciaResult> GetMateriaAsistenciaAlumnoAsync(String nroDoc);
 
    }
}
