using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacciones_C_.ClasesDB
{
    // Tabla de transacciones
    public class Transaccion
    {
        public int TransaccionId { get; set; }
        public required decimal Monto { get; set; }
        public required DateTime Fecha { get; set; }
        public string? Descripcion { get; set; }
        public required int CuentaOrigenId { get; set; }
        public required int CuentaDestinoId { get; set; }
        public required Cuenta CuentaOrigen { get; set; }
        public required Cuenta CuentaDestino { get; set; }
    }
}
