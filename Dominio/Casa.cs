using System;

namespace Dominio
{
    public class Casa : Propiedad
    {
        private int _metrosFrente;
        private int _metrosFondo;
        private decimal _costoContribucion;
        private decimal _impuestoPrimaria;

        public int MtFrente
        {
            get { return _metrosFrente; }
            set { _metrosFrente = value; }
        }

        public int MtFondo
        {
            get { return _metrosFondo; }
            set { _metrosFondo = value; }
        }

        public decimal CostoContribucion
        {
            get { return _costoContribucion; }
            set { _costoContribucion = value; }
        }

        public decimal ImpuestoPrimaria
        {
            get { return _impuestoPrimaria; }
            set { _impuestoPrimaria = value; }
        }

        public Casa() { }

        public Casa(int mtFrente, int mtFondo, decimal costoContribucion, decimal impuestoPrimaria, Direccion direccion, DateTime fechaConstruccion) : base(direccion, fechaConstruccion)
        {
            _metrosFondo = mtFondo;
            _metrosFrente = mtFrente;
            _costoContribucion = costoContribucion;
            _impuestoPrimaria = impuestoPrimaria;
        }

        public override decimal Comision()
        {
            return base.Comision() + (_costoContribucion + _impuestoPrimaria) / 12;
        }

        public override string TipoPropiedad()
        {
            return "Casa";
        }
    }
}
