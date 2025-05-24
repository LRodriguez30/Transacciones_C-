using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacciones_C_.ManejadoresDB;

namespace Transacciones_C_
{
    public class ManejadorDB
    {
        public CargadorDB cargador = new CargadorDB();
        public RegistrarDB registrador = new RegistrarDB();
        public TransaccionDB transaccion = new TransaccionDB();
        public BusquedaDB busqueda = new BusquedaDB();
    }
}
