using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Transacciones_C_.Interfaces;
using Microsoft.EntityFrameworkCore;
using Transacciones_C_.ClasesDB;

namespace Transacciones_C_.ManejadoresDB
{
    public class BusquedaDB : IBusquedaDB
    {
        // INSTANCIABLE DESDE "ManejadorDB"
        private BusquedaDB() {}

        // Crear clase desde "ManejadorDB"
        internal static BusquedaDB CrearBuscadorDB(ManejadorDB manejador)
        {
            return new BusquedaDB();
        }

        // Realiza una búsqueda parametrizada
        public void BusquedaCuentas(TextBox txtBxCriterio, ComboBox cmbBx, string cuenta, TextBox? txtBxAlias, ComboBox cmbBxCOrigen, TextBox txtBxBuscarACDestino)
        {
            // INICIO DE LA BÚSQUEDA

            // Se limpia el combo box por cada actualiación
            cmbBx.Items.Clear();

            using (var db = new BancoDB())
            {
                // Obtenemos las cuentas que cumplan con el criterio de búsqueda
                var results = db.Cuentas
                    .Where(c =>
                        EF.Functions.Like(c.Cliente.Nombre, $"{txtBxCriterio.Text}%")
                    )
                    .Select(c =>
                        c.NumeroCuenta
                    ).ToList();

                // Verificamos si hay resultados
                if (results.Count > 0)
                {
                    // Añadimos resultados
                    foreach (var result in results)
                    {
                        if (cuenta == "Origen")
                        {
                            // Se añaden todas las cuentas disponibles para ese criterio
                            cmbBx.Items.Add(result);
                        }
                        else if (cuenta == "Destino")
                        {
                            // Se integran todos los resultados menos el ya seleccionado en la cuenta de origen
                            if (result != cmbBxCOrigen.SelectedItem?.ToString())
                            {
                                cmbBx.Items.Add(result);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(
                        "No se encontraron coincidencias.",
                        "Bancanet / Buscador",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    if (txtBxAlias != null)
                    {
                        txtBxAlias.Text = "";
                    }

                    txtBxBuscarACDestino.Enabled = false;
                    return;
                }
            }
        }
    }
}
