using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Sistema
    {
        #region Atributos
        private List<Barrio> _barrios = new List<Barrio>();
        private List<Propiedad> _propiedades = new List<Propiedad>();
        private List<Servicio> _servicios = new List<Servicio>();
        private List<Factura> _facturas = new List<Factura>();
        private List<Usuario> _usuarios = new List<Usuario>();
        #endregion

        #region Singleton
        private static Sistema s_instancia;
        public static Sistema Instancia
        {
            get
            {
                if (s_instancia == null)
                    s_instancia = new Sistema();
                return s_instancia;
            }
        }

        private Sistema()
        {
            PrecargaServicios();
            PrecargaBarrios();
            PrecargarCasas();
            PrecargarApartamentos();
            PrecargarMantenimiento();
            PrecargarFacturas();
            PrecargarUsuarios();
        }
        #endregion

        public List<Barrio> GetBarrios()
        {
            List<Barrio> listado = new List<Barrio>();
            foreach (Barrio barrio in _barrios)
                listado.Add(barrio);
            return listado;
        }

        public List<Propiedad> GetPropiedades()
        {
            List<Propiedad> listado = new List<Propiedad>();
            foreach (Propiedad propiedad in _propiedades)
                listado.Add(propiedad);
            return listado;
        }

        public List<Factura> GetFacturas()
        {
            List<Factura> listado = new List<Factura>();
            foreach (Factura factura in _facturas)
                listado.Add(factura);
            return listado;
        }

        public List<Servicio> GetServicios()
        {
            List<Servicio> listado = new List<Servicio>();
            foreach (Servicio servicio in _servicios)
                listado.Add(servicio);
            return listado;
        }

        private void PrecargarCasas()
        {
            AgregarCasa(new Casa(100, 200, 1000, 3000, new Direccion("San Jose 1122", BuscarBarrio(101)), new System.DateTime(2000, 01, 01)));
            AgregarCasa(new Casa(120, 220, 1000, 3000, new Direccion("18 de julio 999 apto 102", BuscarBarrio(102)), new System.DateTime(2000, 01, 01)));
        }

        private void PrecargarApartamentos()
        {
            AgregarApartamento(new Apartamento(101, true, 1000, new Direccion("Rambla", BuscarBarrio(102)), new System.DateTime(2010, 01, 01)));
            AgregarApartamento(new Apartamento(201, false, 2000, new Direccion("Calle 18", BuscarBarrio(101)), new System.DateTime(2010, 01, 01)));
        }

        private void PrecargaBarrios()
        {
            AgregarBarrio(new Barrio(101, "Barrio 1"));
            AgregarBarrio(new Barrio(102, "Barrio 2"));
            AgregarBarrio(new Barrio(103, "Barrio 3"));
        }

        private void PrecargaServicios()
        {
            AgregarServicio(new Servicio("sanitario", 1000, "Servicio de limpieza"));
            AgregarServicio(new Servicio("aire", 1000, "Servicio de fitros"));
            AgregarServicio(new Servicio("electricista", 2000, "Servicio basico"));
        }

        private void PrecargarMantenimiento()
        {
            Propiedad unaP = BuscarPropiedad(1);
            unaP.AgregarMantenimiento(new Mantenimiento(DateTime.Now, 1000, BuscarServicio(1)));
            unaP.AgregarMantenimiento(new Mantenimiento(DateTime.Now, 2000, BuscarServicio(2)));
            unaP.AgregarMantenimiento(new Mantenimiento(DateTime.Now, 3000, BuscarServicio(0)));
        }

        private void PrecargarFacturas()
        {
            Propiedad unaP = BuscarPropiedad(1);
            AgregarFactura(new Factura(111, new DateTime(2000, 01, 01), Factura.Periodo.semanal, unaP));
            AgregarFactura(new Factura(222, new DateTime(2020, 02, 01), Factura.Periodo.mensual, unaP));
            AgregarFactura(new Factura(333, new DateTime(2022, 03, 01), Factura.Periodo.semanal, unaP));
        }

        private void PrecargarUsuarios()
        {
            _usuarios.Add(new Usuario("ana", "1234", RolUsuario.admin));
            _usuarios.Add(new Usuario("pepe", "1234", RolUsuario.usuario));
        }

        public void AgregarBarrio(Barrio barrio)
        {
            if (barrio == null)
                throw new Exception("El barrio recibido no tiene datos.");
            barrio.Validar();
            VerificarQueNoExisteElBarrio(barrio);
            _barrios.Add(barrio);
        }

        public void VerificarQueNoExisteFactura(Factura factura)
        {
            if (_facturas.Contains(factura))
                throw new Exception($"Ya existe la factura con el número {factura.Numero}");
        }

        public void AgregarFactura(Factura factura)
        {
            if (factura == null)
                throw new Exception("La factura recibida no tiene datos.");

            factura.CalcularImporte();
            factura.Validar();
            VerificarQueNoExisteFactura(factura);
            _facturas.Add(factura);
        }

        public void VerificarQueNoExisteElBarrio(Barrio barrio)
        {
            if (_barrios.Contains(barrio))
                throw new Exception($"Ya existe el barrio con código {barrio.Codigo}");
        }

        public Barrio BuscarBarrio(int codigo)
        {
            Barrio buscado = null;
            int i = 0;
            while (buscado == null && i < _barrios.Count)
            {
                if (_barrios[i].Codigo == codigo)
                    buscado = _barrios[i];
                i++;
            }
            if (buscado == null)
                throw new Exception($"El barrio con el código {codigo} no existe");
            return buscado;
        }

        public Servicio BuscarServicio(int id)
        {
            Servicio buscado = null;
            int i = 0;
            while (buscado == null && i < _servicios.Count)
            {
                if (_servicios[i].Id == id)
                    buscado = _servicios[i];
                i++;
            }
            if (buscado == null)
                throw new Exception($"El servicio con el id {id} no existe");
            return buscado;
        }

        public Propiedad BuscarPropiedad(int id)
        {
            Propiedad buscada = null;
            int i = 0;
            while (buscada == null && i < _propiedades.Count)
            {
                if (_propiedades[i].Id == id)
                    buscada = _propiedades[i];
                i++;
            }
            if (buscada == null)
                throw new Exception($"La propiedad con el id {id} no existe");
            return buscada;
        }

        public void AgregarCasa(Casa casa)
        {
            if (casa == null)
                throw new Exception("La casa recibida no tiene datos");

            AgregarPropiedad(casa);
        }

        public void AgregarApartamento(Apartamento apartamento)
        {
            if (apartamento == null)
                throw new Exception("El apartamento recibido no tiene datos.");

            AgregarPropiedad(apartamento);
        }

        private void AgregarPropiedad(Propiedad propiedad)
        {
            propiedad.Direccion.Barrio = BuscarBarrio(propiedad.Barrio.Codigo);
            propiedad.Validar();
            _propiedades.Add(propiedad);
        }

        public void AgregarServicio(Servicio servicio)
        {
            if (servicio == null)
                throw new Exception("El barrio recibido no tiene datos.");
            servicio.Validar();
            _servicios.Add(servicio);
        }

        public List<Casa> CasasPorMetro(int mt)
        {
            List<Casa> listado = new List<Casa>();
            foreach (Propiedad propiedad in _propiedades)
            {
                if (propiedad is Casa unaC && unaC.MtFrente > mt)
                    listado.Add(unaC);
            }
            return listado;
        }

        public List<Apartamento> GastosApartamentos()
        {
            List<Apartamento> listado = new List<Apartamento>();
            foreach (Propiedad propiedad in _propiedades)
            {
                if (propiedad is Apartamento unP)
                    listado.Add(unP);
            }
            listado.Sort();
            return listado;
        }

        public List<Factura> FacturasOrdenadasPorNumero()
        {
            List<Factura> listado = new List<Factura>();
            foreach (Factura factura in _facturas)
            {
                listado.Add(factura);
            }
            listado.Sort();
            return listado;
        }

        public List<Factura> FacturasPorFecha(DateTime desde, DateTime hasta)
        {
            List<Factura> listado = new List<Factura>();
            foreach (Factura factura in _facturas)
            {
                if (factura.Fecha >= desde && factura.Fecha <= hasta)
                    listado.Add(factura);
            }
            listado.Sort();
            return listado;
        }

        public void ModificarBarrio(Barrio barrio)
        {
            Barrio barrioSistema = BuscarBarrio(barrio.Codigo);
            barrioSistema.Nombre = barrio.Nombre;
        }

        public Usuario AutenticarUsuario(string nombre, string password)
        {
            Usuario buscado = null;
            int i = 0;
            while (buscado == null && i < _usuarios.Count)
            {
                if (_usuarios[i].Nombre == nombre)
                    buscado = _usuarios[i];
                i++;
            }

            if (buscado == null || buscado.Password != password)
                throw new Exception("Usuario o contraseña incorrectas");

            return buscado;
        }
    }
}
