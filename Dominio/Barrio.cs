using Dominio.Interfaces;
using System;

namespace Dominio
{
    public class Barrio : IValidable, IEquatable<Barrio>
    {
        private int _codigo;
        private string _nombre;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public Barrio() { }

        public Barrio(int codigo)
        {
            _codigo = codigo;
        }

        public Barrio(int codigo, string nombre)
        {
            _codigo = codigo;
            _nombre = nombre;
        }

        public void Validar()
        {
            ValidarCodigo();
            ValidarNombre();
        }

        private void ValidarCodigo()
        {
            if (_codigo <= 100)
                throw new Exception("El código del barrio debe ser mayor que 100");
        }

        private void ValidarNombre()
        {
            if (_nombre.Length <= 3)
                throw new Exception("El nombre del barrio debe tener al menos 4 caracteres");
        }

        public override int GetHashCode()
        {
            return _codigo;
        }

        public bool Equals(Barrio otroB)
        {
            return otroB != null && _codigo == otroB._codigo;
        }


        /*
         * <ul>
            @foreach(Barrio unB in ViewBag.ListadoDeBarrios)
            {
            <li>@unB.Nombre @unB.Codigo</li>
            }
            </ul>
         */

    }
}