using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacciones_C_.ManejadoresDB;

namespace Transacciones_C_.Interfaces
{
    // Interfas para cargar los datos
    public interface ICargadorDB
    {
        Task CargarClientes();
        Task CargarCuentas();
        Task CargarTransacciones();
    }
}
