using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacciones_C_.ManejadoresDB
{
    public class CargadorDB
    {
        // Se cargan las entidades de la tabla específicada
        public async Task CargarDB(string tabla, DataGridView grvBanco, ToolStripProgressBar TlStrip_prgBar)
        {
            using (var db = new BancoDB())
            {
                // Limpiamos el grvBanco
                grvBanco.DataSource = null;
                grvBanco.Columns.Clear();
                grvBanco.Rows.Clear();

                // Restablecemos la configuración del progress bar
                TlStrip_prgBar.Value = 0;
                TlStrip_prgBar.Minimum = 0;

                switch (tabla)
                {
                    case "Clientes":
                        {
                            // Obtenemos todos los clientes
                            var clientes = db.Clientes.Select(cl => new
                            {
                                Id = cl.ClienteId,
                                cl.Nombre,
                                cl.Identificacion
                            }).ToList();

                            // Verificamos que existan registros
                            if (clientes.Count > 0)
                            {
                                TlStrip_prgBar.Maximum = clientes.Count;

                                // Establecer columnas con los campos antes de agregar filas
                                grvBanco.Columns.Add("ClienteId", "Id");
                                grvBanco.Columns.Add("Nombre", "Nombre");
                                grvBanco.Columns.Add("Identificacion", "Identificación");

                                // Llenar el grvBanco
                                foreach (var cliente in clientes)
                                {
                                    grvBanco.Rows.Add(cliente.Id, cliente.Nombre, cliente.Identificacion);
                                    TlStrip_prgBar.Value++;
                                    await Task.Delay(150);
                                }
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

                            break;
                        }

                    case "Cuentas":
                        {
                            // Obtenemos todas las cuentas
                            var cuentas = db.Cuentas.Select(t => new
                            {
                                Id = t.CuentaId,
                                t.NumeroCuenta,
                                t.Saldo,
                                t.Estado,
                                Cliente = t.Cliente.Nombre
                            }).ToList();

                            // Verificamos que existan registros
                            if (cuentas.Count > 0)
                            {
                                TlStrip_prgBar.Maximum = cuentas.Count;

                                // Establecer columnas con los campos antes de agregar filas
                                grvBanco.Columns.Add("CuentaId", "Id");
                                grvBanco.Columns.Add("NumeroDeCuenta", "Número de Cuenta");
                                grvBanco.Columns.Add("Saldo", "Saldo");
                                grvBanco.Columns.Add("Estado", "Estado");
                                grvBanco.Columns.Add("Cliente", "Cliente");

                                // Llenar el grvBanco
                                foreach (var cuenta in cuentas)
                                {
                                    TlStrip_prgBar.Value++;
                                    grvBanco.Rows.Add(cuenta.Id, cuenta.NumeroCuenta, cuenta.Saldo, cuenta.Estado, cuenta.Cliente);
                                    await Task.Delay(150);
                                }
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

                            break;
                        }

                    case "Transacciones":
                        {
                            // Obtenemos todas las transacciones
                            var transacciones = db.Transacciones.Select(t => new
                            {
                                Id = t.TransaccionId,
                                t.Monto,
                                t.Fecha,
                                t.Descripcion,
                                CuentaOrigen = t.CuentaOrigen.NumeroCuenta,
                                CuentaDestino = t.CuentaDestino.NumeroCuenta
                            }).ToList();

                            // Verificamos si existen registros
                            if (transacciones.Count > 0)
                            {
                                TlStrip_prgBar.Maximum = transacciones.Count;

                                // Establecer columnas con los campos antes de agregar filas 
                                grvBanco.Columns.Add("TransaccionId", "Id");
                                grvBanco.Columns.Add("Monto", "Monto");
                                grvBanco.Columns.Add("Fecha", "Fecha");
                                grvBanco.Columns.Add("Descripcion", "Descripción");
                                grvBanco.Columns.Add("CuentaOrigen", "Cuenta de Origen");
                                grvBanco.Columns.Add("CuentaDestino", "Cuenta de Destino");

                                // Llenar el grvBanco
                                foreach (var transaccion in transacciones)
                                {
                                    TlStrip_prgBar.Value++;
                                    grvBanco.Rows.Add(transaccion.Id, transaccion.Monto, transaccion.Fecha,
                                                      transaccion.Descripcion, transaccion.CuentaOrigen, transaccion.CuentaDestino);
                                    await Task.Delay(150);
                                }
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

                            break;
                        }

                    default:
                        MessageBox.Show(
                            "No se encontró la tabla dentro de la base de datos.",
                            "Bancanet",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        break;
                }

                // Esperamos cierto tiempo antes de restablecer el progress bar
                await Task.Delay(500);
                TlStrip_prgBar.Value = 0;
            }
        }
    }
}
