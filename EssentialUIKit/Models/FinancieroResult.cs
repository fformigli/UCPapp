using System.Collections.Generic;

namespace EssentialUIKit.Models
{
    public class DetalleFinancieroAlumnoResult
    {
        public string Arancel { get; set; }
        public string Asignatura { get; set; }
        public string Curso { get; set; }
        public string Descuento { get; set; }
        public string DescuentoDescripcion { get; set; }
        public string FechaVencimiento { get; set; }
        public string Monto { get; set; }
        public string NroCuota { get; set; }
        public string Saldo { get; set; }
        public string Semestre { get; set; }
        public string Turno { get; set; }
        public string CantidadCuotas { get; set; }
    }

    public class FinancieroResult
    {
        public List<DetalleFinancieroAlumnoResult> DetalleFinancieroAlumno { get; set; }
    }
}
