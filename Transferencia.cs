using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Transacciones_C_
{
    public partial class Transferencia : Form
    {
        // Definimos una bandera para controlar los eventos de un control
        private bool ignorarEvento = false;

        private BancoDB db;
        private ManejadorDB manejadorDB;

        public Transferencia(BancoDB db, ManejadorDB manejadorDB)
        {
            InitializeComponent();

            this.db = db;
            this.manejadorDB = manejadorDB;
        }


        // Confirma el proceso de realizar la transferencia
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Se toma la cuenta de origen seleccionada
            string? referenciaCOrigen = cmbBxCOrigen.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(referenciaCOrigen))
            {
                // Se obtiene el id de la cuenta origen
                var cuentaOrigenId = db.Cuentas
                        .Where(c => c.NumeroCuenta == referenciaCOrigen)
                        .Select(c => c.CuentaId)
                        .FirstOrDefault();

                // Se toma la cuenta de destino seleccionada
                string? referenciaCDestino = cmbBxCDestino.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(referenciaCDestino))
                {
                    // Se obtiene el id de la cuenta destino
                    var cuentaDestinoId = db.Cuentas
                        .Where(c => c.NumeroCuenta == referenciaCDestino)
                        .Select(c => c.CuentaId)
                        .FirstOrDefault();

                    decimal Monto = 0;

                    try
                    {
                        Monto = Convert.ToDecimal(txtBxSaldo.Text.Substring(2));
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show(
                            "El valor ingresado tiene un formato nùmerico incorrecto.",
                            "Bancanet",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return;
                    }

                    // Verificar que sea un monto válido
                    if (Monto > 0)
                    {
                        // Realizar la transferencia
                        var exitoso = manejadorDB.operador.Transferir(db, cuentaOrigenId, cuentaDestinoId, Monto);

                        // Verificar si todo se realizó correctamente
                        if (exitoso)
                        {
                            // Marcamos el diàlogo como èxitoso
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(
                                "La transferencia fue cancelada.\n\n" +
                                "Ha ocurrido un error al realizar la transferencia. Por favor, intente nuevamente",
                                "Bancane / Transferencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "El monto a depositar debe ser válido.",
                            "Bancanet / Transferencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Por favor, seleccione una cuenta de destino.",
                        "Bancanet / Transferencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            else
            {
                MessageBox.Show(
                        "Por favor, seleccione una cuenta de origen.",
                        "Bancanet / Transferencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                );
            }
        }




        // CRITERIO DE BÚSQUEDA POR NOMBRE - ORIGEN
        // Verificamos el criterio de búsqueda cada vez que se ingresa un valor diferente
        private void txtBxBuscarACOrigen_TextChanged(object sender, EventArgs e)
        {
            // Ignoramos evento
            if (ignorarEvento) return;

            if (!string.IsNullOrEmpty(txtBxBuscarACOrigen.Text))
            {
                string cuentaOrigen = txtBxBuscarACOrigen.Text;

                // Reescribir formato si contiene caracteres no válidos
                if (Regex.IsMatch(cuentaOrigen, @"[^a-zA-ZáéíóúÁÉÍÓÚñÑ\s\-'.]"))
                {
                    // Nos ayuda a evitar recursividad al activar el evento TextChanged
                    ignorarEvento = true;

                    // Activa el evento TextChanged
                    txtBxBuscarACOrigen.Text = $"{Regex.Replace(cuentaOrigen, @"[^a-zA-ZáéíóúÁÉÍÓÚñÑ\s\-'.]", "")}";

                    // Definimos que el evento se ejecutará completo luego de la operación
                    ignorarEvento = false;
                    return;
                }
            }

            // Verificar que no esté vació el criterio de búsqueda
            if (!string.IsNullOrEmpty(txtBxBuscarACOrigen.Text))
            {
                txtBxBuscarACDestino.Enabled = true;
                txtBxBuscarCCOrigen.Enabled = false;
                manejadorDB.buscador.BusquedaCuentas(txtBxBuscarACOrigen, cmbBxCOrigen, "Origen", txtBxAliasCOrigen, cmbBxCOrigen, txtBxBuscarACDestino);

                if (cmbBxCOrigen.Items.Count > 0)
                {
                    cmbBxCOrigen.SelectedIndex = 0;
                }
            }
            else
            {
                txtBxBuscarACDestino.Enabled = false;
                txtBxBuscarCCOrigen.Enabled = true;
                cmbBxCOrigen.Items.Clear();
                cmbBxCDestino.Items.Clear();
                txtBxAliasCOrigen.Text = "";
                txtBxAliasCDestino.Text = "";
            }
        }


        // CRITERIO DE BÚSQUEDA POR CUENTA - ORIGEN
        // Verificamos el criterio de búsqueda cada vez que se ingresa un valor diferente
        private void txtBxCCOrigen_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBxBuscarCCOrigen.Text))
            {
                txtBxBuscarACOrigen.Enabled = false;
            }
            else
            {
                txtBxBuscarACOrigen.Enabled = true;
            }
        }



        // CRITERIO DE BÚSQUEDA POR NOMBRE - DESTINO
        // Verificamos el criterio de búsqueda cada vez que se ingresa un valor diferente
        private void txtBxBuscarACDestino_TextChanged(object sender, EventArgs e)
        {
            // Ignoramos a propósito el evento para evitar recursividad no controlada
            if (ignorarEvento) return;

            if (!string.IsNullOrEmpty(txtBxBuscarACDestino.Text))
            {
                string cuentaDestino = txtBxBuscarACDestino.Text;

                // Reescribir formato si contiene caracteres no válido
                if (Regex.IsMatch(cuentaDestino, @"[^a-zA-ZáéíóúÁÉÍÓÚñÑ\s\-'.]"))
                {
                    // Nos ayuda a evitar recursividad al activar el evento TextChanged
                    ignorarEvento = true;

                    // Activa el evento TextChanged
                    txtBxBuscarACDestino.Text = $"{Regex.Replace(cuentaDestino, @"[^a-zA-ZáéíóúÁÉÍÓÚñÑ\s\-'.]", "")}";

                    // Definimos que el evento se ejecutará completo luego de la operación
                    ignorarEvento = false;
                    return;
                }
            }

            // Verificar que no esté vació el criterio de búsqueda
            if (!string.IsNullOrEmpty(txtBxBuscarACDestino.Text))
            {
                manejadorDB.buscador.BusquedaCuentas(txtBxBuscarACDestino, cmbBxCDestino, "Destino", txtBxAliasCDestino, cmbBxCOrigen, txtBxBuscarACDestino);

                if (cmbBxCDestino.Items.Count > 0)
                {
                    cmbBxCDestino.SelectedIndex = 0;
                }
                else
                {
                    txtBxBuscarACDestino.Enabled = true;
                }
            }
            else
            {
                cmbBxCDestino.Items.Clear();
                txtBxAliasCDestino.Text = "";
            }
        }

        // CRITERIO DE BÚSQUEDA POR CUENTA - DESTINO
        // Verificamos el criterio de búsqueda cada vez que se ingresa un valor diferente
        private void txtBxBuscarCCDestino_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBxBuscarCCDestino.Text))
            {
                txtBxBuscarACDestino.Enabled = false;
            }
            else
            {
                txtBxBuscarACDestino.Enabled = true;
            }
        }



        // ORIGEN
        // Verificar cada selección de la cuenta origen
        private void cmbBxCOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener la cuenta seleccionada
            var numeroCuenta = cmbBxCOrigen.SelectedItem?.ToString();

            using (var db = new BancoDB())

                txtBxAliasCOrigen.Text = db.Cuentas
                        .Where(c => c.NumeroCuenta == numeroCuenta)
                        .Select(cl => cl.Cliente.Nombre)
                        .FirstOrDefault();

            // Verificar si el criterio de búsqueda no está vacío
            if (!string.IsNullOrEmpty(txtBxBuscarACDestino.Text))
            {
                // Verificar si ya se tiene un criterio de busqueda para la cuenta de destino
                manejadorDB.buscador.BusquedaCuentas(txtBxBuscarACDestino, cmbBxCDestino, "Destino", null, cmbBxCOrigen, txtBxBuscarACDestino);
                cmbBxCDestino.SelectedIndex = 0;
            }
            else
            {
                cmbBxCDestino.Items.Clear();
            }
        }

        // DESTINO
        // Verificar cada selección de la cuenta destino
        private void cmbBxCDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener la cuenta seleccionada
            var numeroCuenta = cmbBxCDestino.SelectedItem?.ToString();

            txtBxAliasCDestino.Text = db.Cuentas
                    .Where(c => c.NumeroCuenta == numeroCuenta)
                    .Select(cl => cl.Cliente.Nombre)
                    .FirstOrDefault();
        }



        // Revisa y reescribe el formato ingresado en el saldo
        private void txtBxSaldo_TextChanged(object sender, EventArgs e)
        {
            if (txtBxSaldo.Text.StartsWith("C$"))
            {
                string Saldo = txtBxSaldo.Text.Substring(2);

                // Detectar si se ingresaron valores no númericos
                if (Saldo.Any(char.IsLetter) || Saldo.Any(char.IsPunctuation) || Saldo.Any(char.IsSymbol))
                {
                    if (Saldo.StartsWith("."))
                    {
                        txtBxSaldo.Text = "C$";
                    }
                    else if (Saldo.EndsWith("."))
                    {
                        // Eliminar simbolos especiales para evitar errores
                        txtBxSaldo.Text = $"C${Regex.Replace(Saldo, @"[^a-zA-Z0-9\s.$]", "")}";
                    }
                    else
                    {
                        // Obtener los números luego del punto
                        string numeroDecimal = Saldo.Substring(Saldo.IndexOf(".") + 1);

                        // Eliminar caracteres no válidos y reescribir el monto
                        txtBxSaldo.Text = $"C${new string(Saldo.Where(c => char.IsDigit(c) || c == '.').ToArray())}";
                    }
                }
            }
            else if (txtBxSaldo.Text.StartsWith("."))
            {
                string Precio = txtBxSaldo.Text.Substring(1);

                txtBxSaldo.Text = $"C${Precio}";
            }
            else
            {
                txtBxSaldo.Text = $"C$";
            }
        }
    }
}
