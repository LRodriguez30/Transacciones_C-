using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacciones_C_.ClasesDB;

namespace Transacciones_C_.ManejadoresDB
{
    public class RegistrarDB
    {
        // Crea un nuevo cliente
        public Cliente NuevoCliente(BancoDB db, TextBox txtBxNombre, TextBox txtBxIdentificacion)
        {
            var cliente = new Cliente
            {
                Nombre = txtBxNombre.Text,
                Identificacion = txtBxIdentificacion.Text,
            };

            db.Clientes.Add(cliente);
            db.SaveChanges();

            return cliente;
        }

        // Crea una nueva cuenta
        public void NuevaCuenta(BancoDB db, Cliente cliente, TextBox txtBxNumeroC, TextBox txtBxSaldoI)
        {
            var cuenta = new Cuenta()
            {
                NumeroCuenta = txtBxNumeroC.Text,
                Saldo = Convert.ToDecimal(txtBxSaldoI.Text.Substring(2)),
                Estado = true,
                ClienteId = cliente.ClienteId,
                Cliente = cliente
            };

            db.Cuentas.Add(cuenta);
            db.SaveChanges();
        }
    }
}
