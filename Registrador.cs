using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transacciones_C_.ClasesDB;

namespace Transacciones_C_
{
    public partial class Registrador : Form
    {
        private ManejadorDB manejadorDB;
        public Registrador()
        {
            InitializeComponent();
            manejadorDB = new ManejadorDB();
        }

        // Registramos tanto al cliente como la cuenta
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            using (var db = new BancoDB())

            try
            {
                Cliente cliente = manejadorDB.registrador.NuevoCliente(db, txtBxNombre, txtBxIdentificacion);
                manejadorDB.registrador.NuevaCuenta(db, cliente, txtBxNumeroC, txtBxSaldoI);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Ha ocurrido un error...",
                    "Bancanet / Registrador",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Declaramos el diálogo como éxitoso
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Verifica y reescribe constantemente el formato ingresado en el saldo
        private void txtBxSaldoI_TextChanged(object sender, EventArgs e)
        {
            if (txtBxSaldoI.Text.StartsWith("C$"))
            {
                // No tomamos en cuenta las iniciales C$
                string Saldo = txtBxSaldoI.Text.Substring(2);

                // Detectar si se ingresaron valores no númericos
                if (Saldo.Any(char.IsLetter) || Saldo.Any(char.IsPunctuation) || Saldo.Any(char.IsSymbol))
                {
                    if (Saldo.StartsWith("."))
                    {
                        txtBxSaldoI.Text = "C$";
                        //VerificarDatos();
                    }
                    else if (Saldo.EndsWith("."))
                    {
                        // Eliminar simbolos especiales para evitar errores
                        txtBxSaldoI.Text = $"C${Regex.Replace(Saldo, @"[^a-zA-Z0-9\s.$]", "")}";
                        //VerificarDatos();
                    }
                    else
                    {
                        // Obtener los números luego del punto
                        string numeroDecimal = Saldo.Substring(Saldo.IndexOf(".") + 1);

                        // Eliminar caracteres no válidos y reescribir el monto
                        txtBxSaldoI.Text = $"C${new string(Saldo.Where(c => char.IsDigit(c) || c == '.').ToArray())}";
                        //VerificarDatos();
                    }
                }
            }
            else if (txtBxSaldoI.Text.StartsWith("."))
            {
                string Precio = txtBxSaldoI.Text.Substring(1);

                txtBxSaldoI.Text = $"C${Precio}";
                //VerificarDatos();
            }
            else
            {
                txtBxSaldoI.Text = $"C$";
                //VerificarDatos();
            }
        }
    }
}
