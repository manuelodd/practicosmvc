using Dominio.Interfaces;
using System;

namespace Dominio
{
    public class Servicio : IValidable
    {
        private int _id;
        private static int s_ultId;
        private string _tipo;
        private decimal _costoBase;
        private string _nombre;

        public int Id
        {
            get { return _id; }
        }

        public string Nombre
        {
            get { return _nombre; }
        }

        public string Tipo
        {
            get { return _tipo; }
        }

        public decimal CostoBase
        {
            get { return _costoBase; }
        }

        public Servicio(string tipo, decimal costoBase, string nombre)
        {
            _id = s_ultId++;
            _tipo = tipo;
            _costoBase = costoBase;
            _nombre = nombre;
        }

        public void Validar()
        {
            ValidarNombre();
            ValidarTipo();
            ValidarCostoBase();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(_nombre.Trim()))
                throw new Exception("El nombre no puede estar vacío");
        }

        private void ValidarTipo()
        {
            if (string.IsNullOrEmpty(_tipo.Trim()))
                throw new Exception("El tipo no puede estar vacío");
        }

        private void ValidarCostoBase()
        {
            if (_costoBase < 0)
                throw new Exception("El costo base debe ser positivo");
        }

    }
}
