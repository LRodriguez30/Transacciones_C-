using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Transacciones_C_.Interfaces
{
    // Una interfas para el manejador de busqueda
    public interface IBusquedaDB
    {
        void BusquedaCuentas(TextBox txtBxCriterio, ComboBox cmbBx, string tabla, TextBox? txtBxAlias, ComboBox cmbBxCOrigen, TextBox txtBxBuscarACDestino, TextBox txtBcBuscarCCDestino, string filtro);
    }
}
