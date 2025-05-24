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
        private bool skipEvent = false;
        private ManejadorDB manejadorDB;

        public Transferencia()
        {
            InitializeComponent();
            manejadorDB = new ManejadorDB();
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
                        //VerificarDatos();
                    }
                    else if (Saldo.EndsWith("."))
                    {
                        // Eliminar simbolos especiales para evitar errores
                        txtBxSaldo.Text = $"C${Regex.Replace(Saldo, @"[^a-zA-Z0-9\s.$]", "")}";
                        //VerificarDatos();
                    }
                    else
                    {
                        // Obtener los números luego del punto
                        string numeroDecimal = Saldo.Substring(Saldo.IndexOf(".") + 1);

                        // Eliminar caracteres no válidos y reescribir el monto
                        txtBxSaldo.Text = $"C${new string(Saldo.Where(c => char.IsDigit(c) || c == '.').ToArray())}";
                        //VerificarDatos();
                    }
                }
            }
            else if (txtBxSaldo.Text.StartsWith("."))
            {
                string Precio = txtBxSaldo.Text.Substring(1);

                txtBxSaldo.Text = $"C${Precio}";
                //VerificarDatos();
            }
            else
            {
                txtBxSaldo.Text = $"C$";
                //VerificarDatos();
            }
        }

        // CRITERIO DE BÚSQUEDA POR NOMBRE - ORIGEN
        // Verificamos el criterio de búsqueda cada vez que se ingresa un valor diferente
        private void txtBxBuscarACOrigen_TextChanged(object sender, EventArgs e)
        {
            // Ignoramos evento
            if (skipEvent) return;

            if (!string.IsNullOrEmpty(txtBxBuscarACOrigen.Text))
            {
                string cuentaOrigen = txtBxBuscarACOrigen.Text;

                // Reescribir formato si contiene caracteres no válidos
                if (Regex.IsMatch(cuentaOrigen, @"[^a-zA-ZáéíóúÁÉÍÓÚñÑ\s\-'.]"))
                {
                    skipEvent = true;
                    txtBxBuscarACOrigen.Text = $"{Regex.Replace(cuentaOrigen, @"[^a-zA-ZáéíóúÁÉÍÓÚñÑ\s\-'.]", "")}";
                    skipEvent = false;
                    return;
                }
            }

            // Verificar que no esté vació el criterio de búsqueda
            if (!string.IsNullOrEmpty(txtBxBuscarACOrigen.Text))
            {
                txtBxBuscarACDestino.Enabled = true;
                txtBxBuscarCCOrigen.Enabled = false;
                manejadorDB.busqueda.Busqueda(txtBxBuscarACOrigen, cmbBxCOrigen, "Origen", txtBxAliasCOrigen, cmbBxCOrigen, txtBxBuscarACDestino);

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

        // CRITERIO DE´BÚSQUEDA POR CUENTA - ORIGEN
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

        // CRITERIO DE´BÚSQUEDA POR NOMBRE - DESTINO
        // Verificamos el criterio de búsqueda cada vez que se ingresa un valor diferente
        private void txtBxBuscarACDestino_TextChanged(object sender, EventArgs e)
        {
            // Ignoramos evento
            if (skipEvent) return;

            if (!string.IsNullOrEmpty(txtBxBuscarACDestino.Text))
            {
                string cuentaDestino = txtBxBuscarACDestino.Text;

                // Reescribir formato si contiene caracteres no válido
                if (Regex.IsMatch(cuentaDestino, @"[^a-zA-ZáéíóúÁÉÍÓÚñÑ\s\-'.]"))
                {
                    skipEvent = true;
                    txtBxBuscarACDestino.Text = $"{Regex.Replace(cuentaDestino, @"[^a-zA-ZáéíóúÁÉÍÓÚñÑ\s\-'.]", "")}";
                    skipEvent = false;
                    return;
                }
            }

            // Verificar que no esté vació el criterio de búsqueda
            if (!string.IsNullOrEmpty(txtBxBuscarACDestino.Text))
            {
                manejadorDB.busqueda.Busqueda(txtBxBuscarACDestino, cmbBxCDestino, "Destino", txtBxAliasCDestino, cmbBxCOrigen, txtBxBuscarACDestino);

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

        // ORIGEN
        // Verificar cada selección de la cuenta origen
        private void cmbBxCOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener la cuenta seleccionada
            var numeroCuenta = cmbBxCOrigen.SelectedItem?.ToString();

            using (var db = new BancoDB())

            txtBxAliasCOrigen.Text = db.Cuentas
                .Where(c =>
                    c.NumeroCuenta == numeroCuenta
                ).Select(cl =>
                    cl.Cliente.Nombre
                ).FirstOrDefault();

            // Verificar si el criterio de búsqueda no está vacío
            if (!string.IsNullOrEmpty(txtBxBuscarACDestino.Text))
            {
                // Verificar si ya se tiene un criterio de busqueda para la cuenta de destino
                manejadorDB.busqueda.Busqueda(txtBxBuscarACDestino, cmbBxCDestino, "Destino", null, cmbBxCOrigen, txtBxBuscarACDestino);
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

            using (var db = new BancoDB())

            txtBxAliasCDestino.Text = db.Cuentas
                .Where(c =>
                    c.NumeroCuenta == numeroCuenta
                ).Select(cl =>
                    cl.Cliente.Nombre
                ).FirstOrDefault();
        }

        // Confirma el proceso de realizar la transferencia
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            using var db = new BancoDB();

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
                    }

                    if (Monto >= 0)
                    {
                        var exitoso = manejadorDB.transaccion.Transferir(cuentaOrigenId, cuentaDestinoId, Monto);

                        if (exitoso)
                        {
                            // Marcamos el diàlogo como èxitoso
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
