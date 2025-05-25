using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacciones_C_.ClasesDB;

namespace Transacciones_C_.Interfaces
{
    // Interfas para el manejador de registro
    public interface IRegistrarDB
    {
        Cliente NuevoCliente(BancoDB db, TextBox txtBxNombre, TextBox txtBxIdentificacion);
        void NuevaCuenta(BancoDB db, Cliente cliente, TextBox txtBxNumeroC, TextBox txtBxSaldoI);
    }
}
