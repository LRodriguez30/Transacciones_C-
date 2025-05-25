using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Transacciones_C_.Interfaces
{
    // Interfas para el manejador de operaciones 
    public interface IOperacionDB
    {
        bool Transferir(BancoDB db, int CuentaOrigenId, int CuentaDestinoId, decimal Monto);
    }
}
