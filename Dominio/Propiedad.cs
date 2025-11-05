using Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace Dominio
{
    public abstract class Propiedad : IValidable
    {
        private int _id;
        private static int s_ultId;
        private Direccion _direccion;
        private List<Mantenimiento> _mantenimientos = new List<Mantenimiento>();
        private static decimal s_costoBaseComision = 1000;
        private DateTime _fechaConstruccion;

        public int Id
        {
            get { return _id; }
        }

        public Direccion Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public DateTime FechaConstruccion
        {
            get { return _fechaConstruccion; }
            set { _fechaConstruccion = value; }
        }

        public List<Mantenimiento> Mantenimientos
        {
            get
            {
                List<Mantenimiento> listado = new List<Mantenimiento>();
                foreach (Mantenimiento mantenimiento in _mantenimientos)
                {
                    listado.Add(mantenimiento);
                }
                return listado;
            }
        }

        public Propiedad()
        {
            _id = s_ultId++;
        }

        public Propiedad(Direccion direccion, DateTime fechaConstruccion) : this()
        {
            _direccion = direccion;
            _fechaConstruccion = fechaConstruccion;
        }

        public Barrio Barrio
        {
            get { return _direccion.Barrio; }
        }

        public void Validar()
        {
            ValidarDireccion();
        }

        private void ValidarDireccion()
        {
            if (_direccion == null)
                throw new Exception("La dirección no puede estar vacía");
            _direccion.Validar();
        }


        public void AgregarMantenimiento(Mantenimiento mantenimiento)
        {
            if (mantenimiento == null)
                throw new Exception("El mantenimiento recibido no tiene datos");
            mantenimiento.Validar();
            _mantenimientos.Add(mantenimiento);
        }

        public abstract string TipoPropiedad();

        public virtual decimal Comision()
        {
            return s_costoBaseComision + _mantenimientos.Count > 10 ? 500 : 0;
        }

        public override string ToString()
        {
            string texto = $"Propiedad {this.Id} - Direccion: {this.Direccion} -  Tipo: {this.TipoPropiedad()} - Comision: $U {this.Comision()}\n";

            if (Mantenimientos.Count == 0)
            {
                texto += "La propiedad no tiene mantenimientos registrados";
            }
            else
            {
                texto += $"Tiene {Mantenimientos.Count} mantenimientos realizados. Detalle: \n";
                foreach (Mantenimiento mantenimiento in Mantenimientos)
                {
                    texto += $" Fecha: {mantenimiento.Fecha} - Servicio: ({mantenimiento.Servicio.Id}) {mantenimiento.Servicio.Nombre} \n";
                }
            }
            return texto;
        }

    }
}
