using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacciones_C_.ClasesDB
{
    // Tabla de clientes 
    public class Cliente
    {
        public int ClienteId { get; set; }
        public required string Nombre { get; set; }
        public required string Identificacion { get; set; }
        public List<Cuenta> Cuentas { get; set; } = new List<Cuenta>();
    }
}
