using System;
using System.Collections.Generic;
using System.Text;

namespace EssentialUIKit.Models.Rendimiento. Financiero
{
    public class DetalleFinancieroAlumno
    {
        public string asignatura { get; set; }
        public string curso { get; set; }
        public string descuento { get; set; }
        public string descuentoDescripcion { get; set; }
        public string fechaVencimiento { get; set; }
        public string monto { get; set; }
        public string nroCuota { get; set; }
        public List<object> pago { get; set; }
        public string saldo { get; set; }
        public string semestre { get; set; }
        public string turno { get; set; }
    }

    public class CabeceraFinancieroAlumno
    {
        public string cantidadDeCuotas { get; set; }
        public List<DetalleFinancieroAlumno> detalleFinancieroAlumno { get; set; }
        public string nombreArancel { get; set; }
    }

    public class FinancieroResult
    {
        public List<CabeceraFinancieroAlumno> cabeceraFinancieroAlumno { get; set; }
    }
}
