using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Transacciones_C_.ClasesDB;
using Transacciones_C_.Interfaces;

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
        public void BusquedaCuentas(TextBox txtBxCriterio, ComboBox cmbBx, string cuenta, TextBox? txtBxAlias, ComboBox cmbBxCOrigen, TextBox txtBxBuscarACDestino, TextBox txtBxBuscarCCDestino, string filtro)
        {
            // INICIO DE LA BÚSQUEDA

            // Se limpia el combo box por cada actualiación
            cmbBx.Items.Clear();

            using (var db = new BancoDB())
            {
                // Obtenemos las cuentas que cumplan con el criterio de búsqueda

                List<string> resultados = new List<string>();

                if (filtro == "NumeroCuenta") {
                    resultados = db.Cuentas
                        .Where(c =>
                            EF.Functions.Like(c.NumeroCuenta, $"{txtBxCriterio.Text}%")
                        )
                        .Select(c =>
                            c.NumeroCuenta
                        ).ToList();
                }
                else if (filtro == "NombreCliente")
                {
                    resultados = db.Cuentas
                        .Where(c =>
                            EF.Functions.Like(c.Cliente.Nombre, $"{txtBxCriterio.Text}%")
                        )
                        .Select(c =>
                            c.NumeroCuenta
                        ).ToList();
                }

                // Verificamos si hay resultados
                if (resultados.Count > 0)
                {
                    // Añadimos resultados
                    foreach (var resultado in resultados)
                    {
                        if (cuenta == "Origen")
                        {
                            // Se añaden todas las cuentas disponibles para ese criterio
                            cmbBx.Items.Add(resultado);
                        }
                        else if (cuenta == "Destino")
                        {
                            // Se integran todos los resultados menos el ya seleccionado en la cuenta de origen
                            if (resultado != cmbBxCOrigen.SelectedItem?.ToString())
                            {
                                cmbBx.Items.Add(resultado);
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

                    return;
                }
            }
        }
    }
}
