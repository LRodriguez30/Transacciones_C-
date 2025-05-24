using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacciones_C_.ClasesDB
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        public required string NumeroCuenta { get; set; }
        public required decimal Saldo { get; set; }
        public bool Estado { get; set; } = true;
        public required int ClienteId { get; set; }
        public required Cliente Cliente { get; set; }
        public List<Transaccion> TransaccionesOrigen { get; set; } = new();
        public List<Transaccion> TransaccionesDestino { get; set; } = new();
    }
}
