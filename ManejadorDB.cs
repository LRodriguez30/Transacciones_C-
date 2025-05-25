using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Transacciones_C_.ManejadoresDB;
using Transacciones_C_.Interfaces;
using System.Drawing.Text;

namespace Transacciones_C_
{
    public class ManejadorDB
    {
        // Propiedades que permiten acceder a las funcionalidades del programa

        public CargadorDB cargador; // Carga entidades
        public RegistrarDB registrador; // Realiza una inserción de entidades
        public OperacionDB operador; // Realiza actualizaciones a las entidades
        public BusquedaDB buscador; // Realiza un filtro para cargar entidades


        // Inicializa las clases que contienen la funcionalidad del programa
        public ManejadorDB(DataGridView grv, ToolStripProgressBar TlStripPrgBar)
        {
            cargador = CargadorDB.CrearCargadorDB(this, grv, TlStripPrgBar);
            registrador = RegistrarDB.CrearRegistradorDB(this);
            operador = OperacionDB.CrearOperadorDB(this); ;
            buscador = BusquedaDB.CrearBuscadorDB(this); ;
        }
    }
}
