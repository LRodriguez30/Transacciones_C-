using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacciones_C_.Interfaces;

namespace Transacciones_C_.ManejadoresDB
{
    // INSTANCIABLE DESDE "ManejadorDB"
    public class CargadorDB : ICargadorDB
    {
        private DataGridView grvBanco { get; set; }
        private ToolStripProgressBar TlStrip_prgBar { get; set; }
        private BancoDB db { get; set; }
        private string[][] columnas = [];


        private CargadorDB(DataGridView grv, ToolStripProgressBar TlStripPrgBar)
        {
            grvBanco = grv;
            TlStrip_prgBar = TlStripPrgBar;

            db = new BancoDB();
        }

        // Crear la clase del cargador únicamente si se tiene un manejador
        internal static CargadorDB CrearCargadorDB(ManejadorDB manejador, DataGridView grv, ToolStripProgressBar TlStripPrgBar)
        {
            return new CargadorDB(grv, TlStripPrgBar);
        }


        // Limpia y define los valores inciales de los controles
        private void EstablecerConfig()
        {
            // Limpiamos el grvBanco
            grvBanco.DataSource = null;
            grvBanco.Columns.Clear();
            grvBanco.Rows.Clear();

            // Limpiamos el arreglo de columnas
            columnas = [];

            // Restablecemos la configuración del progress bar
            TlStrip_prgBar.Value = 0;
            TlStrip_prgBar.Minimum = 0;
        }

        // Define el tiempo para marcar el progreso como terminado
        private async void TerminarTarea()
        {
            await Task.Delay(500);
            TlStrip_prgBar.Value = 0;
        }

        // Llenar columnas del "grvBanco"
        private void LlenarColumnas(string[][] columnas)
        {
            foreach (var columna in columnas)
            {
                // Establecer columnas con los campos antes de agregar filas
                grvBanco.Columns.Add(columna[0], columna[1]);
            }
        }


        // Realizan la carga de las entidades
        public async Task CargarClientes()
        {
            EstablecerConfig();

            // Obtenemos todos los clientes
            var clientes = db.Clientes.Select(cl => new
            {
                Id = cl.ClienteId,
                cl.Nombre,
                cl.Identificacion
            })
            .OrderBy(cl => cl.Nombre).ToList();

            // Verificamos que existan registros
            if (clientes.Count > 0)
            {
                TlStrip_prgBar.Maximum = clientes.Count;

                columnas = [
                    ["ClienteId", "Id"],
                    ["Nombre", "Nombre"],
                    ["Identificacion", "Identificación"],
                ];

                LlenarColumnas(columnas);

                // Llenar el grvBanco
                foreach (var cliente in clientes)
                {
                    grvBanco.Rows.Add(cliente.Id, cliente.Nombre, cliente.Identificacion);
                    TlStrip_prgBar.Value++;
                    await Task.Delay(150);
                }

                TerminarTarea();
            }
            else
            {
                MessageBox.Show(
                    "No se han registrado clientes.",
                    "Bancanet",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        public async Task CargarCuentas()
        {
            EstablecerConfig();

            // Obtenemos todas las cuentas
            var cuentas = db.Cuentas.Select(c => new
            {
                Id = c.CuentaId,
                c.NumeroCuenta,
                c.Saldo,
                c.Estado,
                Cliente = c.Cliente.Nombre
            })
            .OrderByDescending(c => c.NumeroCuenta).ToList();

            // Verificamos que existan registros
            if (cuentas.Count > 0)
            {
                TlStrip_prgBar.Maximum = cuentas.Count;

                columnas = [
                    ["CuentaId", "Id"],
                    ["Cliente", "Cliente"],
                    ["NumeroDeCuenta", "Número de Cuenta"],
                    ["Saldo", "Saldo"],
                    ["Estado", "Estado"]
                ];

                LlenarColumnas(columnas);

                // Llenar el grvBanco
                foreach (var cuenta in cuentas)
                {
                    TlStrip_prgBar.Value++;
                    grvBanco.Rows.Add(cuenta.Id, cuenta.Cliente, cuenta.NumeroCuenta, cuenta.Saldo, cuenta.Estado);
                    await Task.Delay(150);
                }

                TerminarTarea();
            }
            else
            {
                MessageBox.Show(
                    "No se han registrado cuentas.",
                    "Bancanet",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        public async Task CargarTransacciones()
        {
            EstablecerConfig();
            // Obtenemos todas las transacciones
            var transacciones = db.Transacciones.Select(t => new
            {
                Id = t.TransaccionId,
                t.Monto,
                t.Fecha,
                t.Descripcion,
                CuentaOrigen = t.CuentaOrigen.NumeroCuenta,
                CuentaDestino = t.CuentaDestino.NumeroCuenta
            })
            .OrderByDescending(t => t.Fecha).ToList();

            // Verificamos si existen registros
            if (transacciones.Count > 0)
            {
                TlStrip_prgBar.Maximum = transacciones.Count;

                columnas = [
                    ["TransaccionId", "Id"],
                    ["Monto", "Monto"],
                    ["Fecha", "Fecha"],
                    ["Descripcion", "Descripción"],
                    ["CuentaOrigen", "Cuenta de Origen"],
                    ["CuentaDestino", "Cuenta de Destino"]
                ];

                LlenarColumnas(columnas);

                // Llenar el grvBanco
                foreach (var transaccion in transacciones)
                {
                    TlStrip_prgBar.Value++;
                    grvBanco.Rows.Add(transaccion.Id, transaccion.Monto, transaccion.Fecha,
                                        transaccion.Descripcion, transaccion.CuentaOrigen, transaccion.CuentaDestino);
                    await Task.Delay(150);
                }

                TerminarTarea();
            }
            else
            {
                MessageBox.Show(
                    "No se han registrado transacciones.",
                    "Bancanet",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}
