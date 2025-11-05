using Dominio.Interfaces;
using System;

namespace Dominio
{
    public class Direccion : IValidable
    {
        private string _calle;
        private Barrio _barrio;

        public string Calle
        {
            get { return _calle; }
            set { _calle = value; }
        }

        public Barrio Barrio
        {
            get { return _barrio; }
            set { _barrio = value; }
        }

        public Direccion() { }

        public Direccion(string calle, Barrio barrio)
        {
            _calle = calle;
            _barrio = barrio;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_calle?.Trim()))
                throw new Exception("La calle no es correcta");
            if (_barrio == null)
                throw new Exception("El barrio no puede estar vacío");
        }

        public override string ToString()
        {
            return $"{Calle} - {Barrio.Nombre}";
        }
    }

}
