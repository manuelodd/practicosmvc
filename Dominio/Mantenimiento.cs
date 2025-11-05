using Dominio.Interfaces;
using System;

namespace Dominio
{
    public class Mantenimiento : IValidable, IEquatable<Mantenimiento>
    {

        private static int s_uldId;
        public int Id { get; private set; }
        public DateTime Fecha { get; set; }
        public decimal CostoManoObra { get; set; }
        public Servicio Servicio { get; set; }

        public Mantenimiento()
        {
            Id = s_uldId++;
        }

        public Mantenimiento(DateTime fecha, Decimal costoManoObra, Servicio servicio) : this()
        {
            Fecha = fecha;
            CostoManoObra = costoManoObra;
            Servicio = servicio;
        }

        public decimal Total()
        {
            return CostoManoObra + Servicio.CostoBase;
        }

        public void Validar()
        {
            ValidarServicio();
            ValidarFecha();
            ValidarCostoManoObra();
        }

        private void ValidarServicio()
        {
            if (Servicio == null)
                throw new Exception("No se recibió un servicio válido");
        }

        private void ValidarCostoManoObra()
        {
            if (CostoManoObra <= 0)
                throw new Exception("El costo de mano de obra no es correcto");
        }

        private void ValidarFecha()
        {
            if (Fecha == DateTime.MinValue || Fecha == DateTime.MaxValue || Fecha < DateTime.Today)
                throw new Exception("No se recibió una fecha válida");
        }

        public bool Equals(Mantenimiento otroM)
        {
            return otroM != null && Fecha == otroM.Fecha && Servicio.Id == otroM.Servicio.Id;
        }

    }
}
