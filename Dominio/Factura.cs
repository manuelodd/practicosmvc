using Dominio.Interfaces;
using System;

namespace Dominio
{
    public class Factura : IValidable, IEquatable<Factura>, IComparable<Factura>
    {
        public enum Periodo { semanal = 7, quincenal = 15, mensual = 30 }

        private readonly decimal _importe;

        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public Propiedad Propiedad { get; set; }
        public Periodo CicloFacturacion { get; set; }

        public decimal Importe
        {
            get { return _importe; }
        }

        public Factura() { }

        public Factura(int numero, DateTime fecha, Periodo ciclo, Propiedad propiedad)
        {
            Numero = numero;
            Fecha = fecha;
            CicloFacturacion = ciclo;
            Propiedad = propiedad;
            _importe = CalcularImporte();
        }

        public void Validar()
        {
            // todo
        }

        public bool Equals(Factura other)
        {
            return other != null && Numero == other.Numero;
        }

        public decimal CalcularImporte()
        {
            if (Propiedad == null)
            {
                throw new Exception("La factura debe tener asociada una propiedad para poder calcular el importe");
            }
            if (CicloFacturacion == 0)
            {
                throw new Exception("La propiedad debe tener cargado un cicli de facturación para poder calcular el importe");
            }

            decimal valor = 0;

            switch (CicloFacturacion)
            {
                case Factura.Periodo.semanal:
                    valor = Propiedad.Comision() / 4;
                    break;
                case Factura.Periodo.quincenal:
                    valor = Propiedad.Comision() / 2;
                    break;
                case Factura.Periodo.mensual:
                    valor = Propiedad.Comision();
                    break;
            }
            return valor;
        }

        public int CompareTo(Factura otraF)
        {
            return Numero.CompareTo(otraF.Numero);
        }
    }
}
