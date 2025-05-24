using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Transactions;
using System.Windows.Forms;

namespace Transacciones_C_
{
    public partial class Bancanet : Form
    {
        private ManejadorDB manejadorDB;

        public Bancanet()
        {
            InitializeComponent();
            manejadorDB = new ManejadorDB();
            CargarBancanet();
        }

        // Método para cargar asincronicamente las entidades
        private async void CargarBancanet()
        {
            await manejadorDB.cargador.CargarDB("Clientes", grvBanco, TlStrip_prgBar);
        }

        // Menú desplegable para transacciones
        private void TlStrip_btnTransacciones_ButtonClick(object sender, EventArgs e)
        {
            // Se despliegan las opciones al presionar su boton principal
            TlStrip_btnTransacciones.ShowDropDown();
        }

        // Realiza transferencias en otro formulario
        private async void TlStrip_btn3MP_Click(object sender, EventArgs e)
        {
            // Crear y mostrar el formulario de transferencia
            var transferencia = new Transferencia();
            var result = transferencia.ShowDialog();

            // Cargar los datos en relación al resultado del diálogo
            if (result != DialogResult.Cancel)
            {
                // Cargar si se realizó la transacción
                await manejadorDB.cargador.CargarDB("Transacciones", grvBanco, TlStrip_prgBar);
            }
            else
            {
                await manejadorDB.cargador.CargarDB("Cuentas", grvBanco, TlStrip_prgBar);
            }
        }

        // Menú desplegable para registro de datos
        private void TlStrip_btnInfo_ButtonClick(object sender, EventArgs e)
        {
            // Se despliegan las opciones al presionar su boton principal
            TlStrip_btnInfo.ShowDropDown();
        }

        // Realiza un nuevo registro a través de otro formulario
        private async void TlStrip_btnRegistrarC_Click(object sender, EventArgs e)
        {
            // Crear y mostrar el formulario de registro
            var registrador = new Registrador();
            var result = registrador.ShowDialog();

            // Cargar datos únicamente si se agregó correctamente la cuenta y cliente
            if (result != DialogResult.Cancel)
            {
                await manejadorDB.cargador.CargarDB("Cuentas", grvBanco, TlStrip_prgBar);
            }
        }

        // Menú desplegable para mostrar información
        private void TlStrip_btnMostrar_ButtonClick(object sender, EventArgs e)
        {
            TlStrip_btnMostrar.ShowDropDown();
        }

        // Carga los clientes en el grvBanco
        private async void TlStrip_btnMClientes_Click(object sender, EventArgs e)
        {
            await manejadorDB.cargador.CargarDB("Clientes", grvBanco, TlStrip_prgBar);
        }

        // Carga las cuentas en el grvBanco
        private async void TlStrip_btnMCuentas_Click(object sender, EventArgs e)
        {
            await manejadorDB.cargador.CargarDB("Cuentas", grvBanco, TlStrip_prgBar);
        }

        // Carga las transacciones en el grvBanco
        private async void TlStrip_btnMTransacciones_Click(object sender, EventArgs e)
        {
            await manejadorDB.cargador.CargarDB("Transacciones", grvBanco, TlStrip_prgBar);
        }
    }
}
