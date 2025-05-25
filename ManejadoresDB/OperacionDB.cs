using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Transacciones_C_.ClasesDB;
using Transacciones_C_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Transacciones_C_.ManejadoresDB
{
    public class OperacionDB : IOperacionDB
    {
        private OperacionDB() {}

        internal static OperacionDB CrearOperadorDB(ManejadorDB manejador)
        {
            return new OperacionDB();
        }

        // Realiza una transacción
        public bool Transferir(BancoDB db, int CuentaOrigenId, int CuentaDestinoId, decimal Monto)
        {
            // Empezar transacción
            using (var transaccion = db.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))

            try
            {
                // Obtenemos ambas cuentas
                var CuentaOrigen = db.Cuentas.FirstOrDefault(c => c.CuentaId == CuentaOrigenId);
                var CuentaDestino = db.Cuentas.FirstOrDefault(c => c.CuentaId == CuentaDestinoId);

                // Verificamentos que el monto es valido
                if (CuentaOrigen?.Saldo < Monto)
                {
                    MessageBox.Show(
                        "Saldo insuficiente para efectuar la transferencia.",
                        "Transferencia / Bancanet",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return false;
                }

                // Actualizar ambas cuentas
                CuentaOrigen!.Saldo -= Monto;
                CuentaDestino!.Saldo += Monto;

                // Registrar como entidad
                db.Transacciones.Add(new Transaccion
                {
                    Monto = Monto,
                    Fecha = DateTime.Now,
                    Descripcion = "Transferencia a terceros mismo país.",
                    CuentaOrigenId = CuentaOrigen.CuentaId,
                    CuentaDestinoId = CuentaDestino.CuentaId,
                    CuentaOrigen = CuentaOrigen,
                    CuentaDestino = CuentaDestino
                });

                db.SaveChanges();

                // Realizar la transacción
                transaccion.Commit();
                MessageBox.Show(
                    "Transferencia realizada con éxito.",
                    "Transferencia / Bancanet",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                // Reversión de transacciones
                transaccion.Rollback();
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }
    }
}
