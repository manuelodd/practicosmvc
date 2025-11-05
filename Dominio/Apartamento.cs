using System;

namespace Dominio
{
    public class Apartamento : Propiedad, IComparable<Apartamento>
    {
        private int _numero;
        private bool _tieneVistaCalle;
        private decimal _gastosComunes;

        public int Numero
        {
            get { return _numero; }
        }

        public bool TieneVistaCalle
        {
            get { return _tieneVistaCalle; }
        }

        public decimal GastosComunes
        {
            get { return _gastosComunes; }
        }

        public Apartamento(int numero, bool vistaCalle, decimal gastosComunes, Direccion direccion, DateTime fechaConstruccion) : base(direccion, fechaConstruccion)
        {
            _numero = numero;
            _tieneVistaCalle = vistaCalle;
            _gastosComunes = gastosComunes;
        }

        public int CompareTo(Apartamento otroA)
        {
            return _gastosComunes.CompareTo(otroA._gastosComunes);
        }

        public override decimal Comision()
        {
            return base.Comision() + (_gastosComunes * 0.15m);
        }

        public override string TipoPropiedad()
        {
            return "Apartamento";
        }
    }
}
