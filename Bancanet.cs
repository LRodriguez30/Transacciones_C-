using System.Transactions;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Transacciones_C_.ManejadoresDB;

namespace Transacciones_C_
{
    public partial class Bancanet : Form
    {
        private BancoDB db;
        private ManejadorDB manejadorDB;

        public Bancanet()
        {
            InitializeComponent();

            // Definimos las clases a utilizar en todo el programa
            db = new BancoDB();
            manejadorDB = new ManejadorDB(grvBanco, TlStrip_prgBar);

            // Cargar por defecto la tabla del bancanet
            CargarBancanet();
        }
        
        private async void CargarBancanet()
        {
            await manejadorDB.cargador.CargarClientes();
        }


        // Men� desplegable para registro de datos
        private void TlStrip_btnInfo_ButtonClick(object sender, EventArgs e)
        {
            // Se despliegan las opciones al presionar su boton principal
            TlStrip_btnInfo.ShowDropDown();
        }

        // Realiza un nuevo registro a trav�s de otro formulario
        private async void TlStrip_btnRegistrarC_Click(object sender, EventArgs e)
        {
            // Crear y mostrar el formulario de registro
            var registrador = new Registrador(db, manejadorDB);
            var result = registrador.ShowDialog();

            // Cargar datos �nicamente si se agreg� correctamente la cuenta y cliente
            if (result != DialogResult.Cancel)
            {
                await manejadorDB.cargador.CargarCuentas();
            }
        }



        // Men� desplegable para transacciones
        private void TlStrip_btnTransacciones_ButtonClick(object sender, EventArgs e)
        {
            // Se despliegan las opciones al presionar su boton principal
            TlStrip_btnTransacciones.ShowDropDown();
        }

        // Realiza transferencias en otro formulario
        private async void TlStrip_btn3MP_Click(object sender, EventArgs e)
        {
            // Crear y mostrar el formulario de transferencia
            var transferencia = new Transferencia(db, manejadorDB);
            var result = transferencia.ShowDialog();

            // Cargar los datos en relaci�n al resultado del di�logo
            if (result != DialogResult.Cancel)
            {
                // Cargar si se realiz� la transacci�n
                await manejadorDB.cargador.CargarTransacciones();
            }
            else
            {
                await manejadorDB.cargador.CargarCuentas();
            }
        }



        // Men� desplegable para mostrar informaci�n
        private void TlStrip_btnMostrar_ButtonClick(object sender, EventArgs e)
        {
            TlStrip_btnMostrar.ShowDropDown();
        }

        // Carga los clientes en el grvBanco
        private async void TlStrip_btnMClientes_Click(object sender, EventArgs e)
        {
            await manejadorDB.cargador.CargarClientes();
        }

        // Carga las cuentas en el grvBanco
        private async void TlStrip_btnMCuentas_Click(object sender, EventArgs e)
        {
            await manejadorDB.cargador.CargarCuentas();
        }

        // Carga las transacciones en el grvBanco
        private async void TlStrip_btnMTransacciones_Click(object sender, EventArgs e)
        {
            await manejadorDB.cargador.CargarTransacciones();
        }
    }
}
