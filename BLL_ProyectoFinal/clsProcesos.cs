using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DAL_ProyectoFinal;

namespace BLL_ProyectoFinal
{
    public class clsTipoServiciosBLL
    {
        private clsConexion Conexion;

        public clsTipoServiciosBLL()
        {
            Conexion = new clsConexion();
        }

        #region Create Tipo Servicio
        public clsTipoServicioDAL createTipoServicioBLL(clsTipoServicioDAL tipoServicio)
        {
            Conexion.createTipoServicioBLL(tipoServicio);
            return tipoServicio;
        }
        #endregion

        #region Read Tipo Servicio
        public DataTable readTipoServicioBLL()
        {
            return Conexion.readTipoServicioBLL();
        }
        //public DataTable filterTipoServicioBLL(clsTipoServicioDAL tipoServicio)
        //{
        //    return Conexion.filterTipoServicioBLL(tipoServicio);
        //}
        #endregion

        #region Update Tipo Servicio
        public clsTipoServicioDAL updateTipoServicioBLL(clsTipoServicioDAL tipoServicio)
        {
            Conexion.updateTipoServicioBLL(tipoServicio);
            return tipoServicio;
        }
        #endregion

        #region Delete Tipo Servicio
        public clsTipoServicioDAL deleteTipoServicioBLL(clsTipoServicioDAL tipoServicio)
        {
            Conexion.deleteTipoServicioBLL(tipoServicio);
            return tipoServicio;
        }
        #endregion

    }

    public class clsSucursalBLL
    {
        private clsConexion Conexion;

        public clsSucursalBLL()
        {
            Conexion = new clsConexion();
        }

        #region Create Sucursal
        public clsSucursalDAL createSucursalBLL(clsSucursalDAL sucursal)
        {
            Conexion.createSucursalBLL(sucursal);
            return sucursal;
        }
        #endregion

        #region Read Sucursal
        public DataTable readSucursalBLL()
        {
            return Conexion.readSucursalBLL();
        }

        #endregion

        #region Update Sucursal
        public clsSucursalDAL updateSucursalBLL(clsSucursalDAL sucursal)
        {
            Conexion.updateSucursalBLL(sucursal);
            return sucursal;
        }
        #endregion

        #region Delete Sucursal
        public clsSucursalDAL deleteSucursalBLL(clsSucursalDAL sucursal)
        {
            Conexion.deleteSucursalBLL(sucursal);
            return sucursal;
        }
        #endregion
    }

    public class clsProveedorBLL
    {
        private clsConexion Conexion;

        public clsProveedorBLL()
        {
            Conexion = new clsConexion();
        }

        #region Create Proveedor
        public clsProveedorDAL createProveedorBLL(clsProveedorDAL proveedor)
        {
            Conexion.createProveedorBLL(proveedor);
            return proveedor;
        }
        #endregion

        #region Read Proveedor
        public DataTable readProveedorBLL()
        {
            return Conexion.readProveedorBLL();
        }

        #endregion

        #region Update Proveedor
        public clsProveedorDAL updateProveedorBLL(clsProveedorDAL proveedor)
        {
            Conexion.updateProveedorBLL(proveedor);
            return proveedor;
        }
        #endregion

        #region Delete Proveedor
        public clsProveedorDAL deleteProveedorBLL(clsProveedorDAL proveedor)
        {
            Conexion.deleteProveedorBLL(proveedor);
            return proveedor;
        }
        #endregion
    }

    public class clsVehiculoBLL
    {
        private clsConexion Conexion;

        public clsVehiculoBLL()
        {
            Conexion = new clsConexion();
        }

        #region Create Vehiculo
        public clsVehiculoDAL createVehiculoBLL(clsVehiculoDAL vehiculo)
        {
            Conexion.createVehiculoBLL(vehiculo);
            return vehiculo;
        }
        #endregion

        #region Read Vehiculo
        public DataTable readVehiculoBLL()
        {
            return Conexion.readVehiculoBLL();
        }

        #endregion

        #region Update Vehiculo
        public clsVehiculoDAL updateVehiculoBLL(clsVehiculoDAL vehiculo)
        {
            Conexion.updateVehiculoBLL(vehiculo);
            return vehiculo;
        }
        #endregion

        #region Delete Vehiculo
        public clsVehiculoDAL deleteVehiculoBLL(clsVehiculoDAL vehiculo)
        {
            Conexion.deleteVehiculoBLL(vehiculo);
            return vehiculo;
        }
        #endregion
    }

    public class clsModeloBLL
    {
        private clsConexion Conexion;

        public clsModeloBLL()
        {
            Conexion = new clsConexion();
        }

        #region Create Modelo
        public clsModeloDAL createModeloBLL(clsModeloDAL modelo)
        {
            Conexion.createModeloBLL(modelo);
            return modelo;
        }
        #endregion

        #region Read Modelo
        public DataTable readModeloBLL()
        {
            return Conexion.readModeloBLL();
        }

        #endregion

        #region Update Modelo
        public clsModeloDAL updateModeloBLL(clsModeloDAL modelo)
        {
            Conexion.updateModeloBLL(modelo);
            return modelo;
        }
        #endregion

        #region Delete Modelo
        public clsModeloDAL deleteModeloBLL(clsModeloDAL modelo)
        {
            Conexion.deleteModeloBLL(modelo);
            return modelo;
        }
        #endregion
    }

    public class clsMarcaBLL
    {
        private clsConexion Conexion;

        public clsMarcaBLL()
        {
            Conexion = new clsConexion();
        }

        #region Create Marca
        public clsMarcaDAL createMarcaBLL(clsMarcaDAL marca)
        {
            Conexion.createMarcaBLL(marca);
            return marca;
        }
        #endregion

        #region Read Marca
        public DataTable readMarcaBLL()
        {
            return Conexion.readMarcaBLL();
        }

        #endregion

        #region Update Marca
        public clsMarcaDAL updateMarcaBLL(clsMarcaDAL marca)
        {
            Conexion.updateMarcaBLL(marca);
            return marca;
        }
        #endregion

        #region Delete Marca
        public clsMarcaDAL deleteMarcaBLL(clsMarcaDAL marca)
        {
            Conexion.deleteMarcaBLL(marca);
            return marca;
        }
        #endregion
    }

    public class clsColaboradorBLL
    {
        private clsConexion Conexion;

        public clsColaboradorBLL()
        {
            Conexion = new clsConexion();
        }

        #region Create Colaborador
        public clsColaboradorDAL createColaboradorBLL(clsColaboradorDAL colaborador)
        {
            Conexion.createColaboradorBLL(colaborador);
            return colaborador;
        }
        #endregion

        #region Read Colaborador
        public DataTable readColaboradorBLL()
        {
            return Conexion.readColaboradorBLL();
        }

        #endregion

        #region Update Colaborador
        public clsColaboradorDAL updateColaboradorBLL(clsColaboradorDAL colaborador)
        {
            Conexion.updateColaboradorBLL(colaborador);
            return colaborador;
        }
        #endregion

        #region Delete Colaborador
        public clsColaboradorDAL deleteColaboradorBLL(clsColaboradorDAL colaborador)
        {
            Conexion.deleteColaboradorBLL(colaborador);
            return colaborador;
        }
        #endregion
    }

    public class clsClienteBLL
    {
        private clsConexion Conexion;

        public clsClienteBLL()
        {
            Conexion = new clsConexion();
        }

        #region Create Cliente
        public clsClienteDAL createClienteFisicoBLL(clsClienteDAL cliente)
        {
            Conexion.createClienteFisicoBLL(cliente);
            return cliente;
        }
        public clsClienteDAL createClienteJuridicoBLL(clsClienteDAL cliente)
        {
            Conexion.createClienteJuridicoBLL(cliente);
            return cliente;
        }
        #endregion

        #region Read Cliente
        public DataTable readClienteFisicoBLL()
        {
            return Conexion.readClienteFisicoBLL();
        }
        public DataTable readClienteJuridicoBLL()
        {
            return Conexion.readClienteJuridicoBLL();
        }
        #endregion

        #region Update Cliente
        public clsClienteDAL updateClienteFisicoBLL(clsClienteDAL cliente)
        {
            Conexion.updateClienteFisicoBLL(cliente);
            return cliente;
        }
        public clsClienteDAL updateClienteJuridicoBLL(clsClienteDAL cliente)
        {
            Conexion.updateClienteJuridicoBLL(cliente);
            return cliente;
        }
        #endregion

        #region Delete Cliente
        public clsClienteDAL deleteClienteFisicoBLL(clsClienteDAL cliente)
        {
            Conexion.deleteClienteFisicoBLL(cliente);
            return cliente;
        }
        public clsClienteDAL deleteClienteJuridicoBLL(clsClienteDAL cliente)
        {
            Conexion.deleteClienteJuridicoBLL(cliente);
            return cliente;
        }
        #endregion
    }

    public class clsTelefonoBLL
    {
        private clsConexion Conexion;

        public clsTelefonoBLL()
        {
            Conexion = new clsConexion();
        }

        #region Create Telefono
        public clsTelefonoDAL createTelefonoBLL(clsTelefonoDAL telefono)
        {
            Conexion.createTelefonoBLL(telefono);
            return telefono;
        }
        #endregion

        #region Read Telefono
        public DataTable readTelefonoBLL()
        {
            return Conexion.readTelefonoBLL();
        }

        #endregion

        #region Update Telefono
        public clsTelefonoDAL updateTelefonoBLL(clsTelefonoDAL telefono)
        {
            Conexion.updateTelefonoBLL(telefono);
            return telefono;
        }
        #endregion

        #region Delete Telefono
        public clsTelefonoDAL deleteTelefonoBLL(clsTelefonoDAL telefono)
        {
            Conexion.deleteTelefonoBLL(telefono);
            return telefono;
        }
        #endregion
    }

    public class clsInventarioBLL
    {
        private clsConexion Conexion;

        public clsInventarioBLL()
        {
            Conexion = new clsConexion();
        }

        #region Create Inventario
        public clsInventarioDAL createInventarioBLL(clsInventarioDAL inventario)
        {
            Conexion.createInventarioBLL(inventario);
            return inventario;
        }
        #endregion

        #region Read Inventario
        public DataTable readInventarioBLL()
        {
            return Conexion.readInventarioBLL();
        }
        #endregion

        #region Update Inventario
        public clsInventarioDAL updateInventarioBLL(clsInventarioDAL inventario)
        {
            Conexion.updateInventarioBLL(inventario);
            return inventario;
        }
        #endregion

        #region Delete Inventario
        public clsInventarioDAL deleteInventarioBLL(clsInventarioDAL inventario)
        {
            Conexion.deleteInventarioBLL(inventario);
            return inventario;
        }
        #endregion
    }

    public class clsOrdenTrabajoBLL
    {
        private clsConexion Conexion;

        public clsOrdenTrabajoBLL()
        {
            Conexion = new clsConexion();
        }

        #region Create OrdenTrabajo
        public clsOrdenTrabajoDAL createOrdenTrabajoEncabezadoBLL(clsOrdenTrabajoDAL orden)
        {
            Conexion.createOrdenTrabajoBLL(orden);
            return orden;
        }
        public clsOrdenTrabajoDAL createOrdenTrabajoDetalleBLL(clsOrdenTrabajoDAL orden)
        {
            Conexion.createOrdenTrabajoDetalleBLL(orden);
            return orden;
        }
        #endregion

        #region Read OrdenTrabajo
        public DataTable readOrdenTrabajoEncabezadoBLL()
        {
            return Conexion.readOrdenTrabajoBLL();
        }
        public DataTable readOrdenTrabajoDetalleBLL()
        {
            return Conexion.readOrdenTrabajoDetalleBLL();
        }

        #endregion

        #region Update OrdenTrabajo
        public clsOrdenTrabajoDAL updateOrdenTrabajoEncabezadoBLL(clsOrdenTrabajoDAL orden)
        {
            Conexion.updateOrdenTrabajoBLL(orden);
            return orden;
        }
        public clsOrdenTrabajoDAL updateOrdenTrabajoDetalleBLL(clsOrdenTrabajoDAL orden)
        {
            Conexion.updateOrdenTrabajoDetalleBLL(orden);
            return orden;
        }
        #endregion

        #region Delete OrdenTrabajo
        public clsOrdenTrabajoDAL deleteOrdenTrabajoEncabezadoBLL(clsOrdenTrabajoDAL orden)
        {
            Conexion.deleteOrdenTrabajoBLL(orden);
            return orden;
        }
        public clsOrdenTrabajoDAL deleteOrdenTrabajoDetalleBLL(clsOrdenTrabajoDAL orden)
        {
            Conexion.deleteOrdenTrabajoDetalleBLL(orden);
            return orden;
        }
        #endregion
    }

    public class clsFacturacionBLL
    {
        private clsConexion Conexion;

        public clsFacturacionBLL()
        {
            Conexion = new clsConexion();
        }

        #region Create Facturacion
        public clsFacturacionDAL createFacturaEncabezadoBLL(clsFacturacionDAL facturacion)
        {
            Conexion.createFacturaEncabezadoBLL(facturacion);
            return facturacion;
        }
        public clsFacturacionDAL createFacturaDetallenBLL(clsFacturacionDAL facturacion)
        {
            Conexion.createFacturaDetalleBLL(facturacion);
            return facturacion;
        }
        #endregion

        #region Read Facturacion
        public DataTable readFacturaEncabezadoBLL()
        {
            return Conexion.readFacturaEncabezadoBLL();
        }
        public DataTable readFacturaDetalleBLL()
        {
            return Conexion.readFacturaDetalleBLL();
        }
        #endregion

        #region Update Facturacion
        public clsFacturacionDAL updateFacturaEncabezadoBLL(clsFacturacionDAL facturacion)
        {
            Conexion.updateFacturaEncabezadoBLL(facturacion);
            return facturacion;
        }
        public clsFacturacionDAL updateFacturaDetalleBLL(clsFacturacionDAL facturacion)
        {
            Conexion.updateFacturaDetalleBLL(facturacion);
            return facturacion;
        }
        #endregion

        #region Delete Facturacion
        public clsFacturacionDAL deleteFacturaEncabezadonBLL(clsFacturacionDAL facturacion)
        {
            Conexion.deleteFacturaEncabezadoBLL(facturacion);
            return facturacion;
        }
        public clsFacturacionDAL deleteFacturaDetalleBLL(clsFacturacionDAL facturacion)
        {
            Conexion.deleteFacturaDetalleBLL(facturacion);
            return facturacion;
        }
        #endregion
    }

    public class clsAgendaBLL
    {
        private clsConexion Conexion;

        public clsAgendaBLL()
        {
            Conexion = new clsConexion();
        }

        #region Create Agenda
        public clsAgendaDAL createAgendaBLL(clsAgendaDAL agenda)
        {
            Conexion.createAgendaBLL(agenda);
            return agenda;
        }
        #endregion

        #region Read Agenda
        public DataTable readAgendaBLL()
        {
            return Conexion.readAgendaBLL();
        }

        #endregion

        #region Update Agenda
        public clsAgendaDAL updateAgendaBLL(clsAgendaDAL agenda)
        {
            Conexion.updateAgendaBLL(agenda);
            return agenda;
        }
        #endregion

        #region Delete Agenda
        public clsAgendaDAL deleteAgendaBLL(clsAgendaDAL agenda)
        {
            Conexion.deleteAgendaBLL(agenda);
            return agenda;
        }
        #endregion
    }

    public class clsLoginBLL
    {

        private clsConexion Conexion;

        public clsLoginBLL()
        {
            Conexion = new clsConexion();
        }

        #region Create Login
        public clsUsuarioDAL createUsuarioBLL(clsUsuarioDAL usuario)
        {
            Conexion.createUsuarioBLL(usuario);
            return usuario;
        }
        #endregion

        #region Read Login
        public DataTable readUsuarioBLL()
        {
            return Conexion.readUsuarioBLL();
        }
        #endregion

        #region Update Login
        public clsUsuarioDAL updateUsuarioBLL(clsUsuarioDAL usuario)
        {
            Conexion.updateUsuarioBLL(usuario);
            return usuario;
        }
        #endregion

        #region Delete Login
        public clsUsuarioDAL deleteUsuarioBLL(clsUsuarioDAL usuario)
        {
            Conexion.deleteUsuarioBLL(usuario);
            return usuario;
        }
        #endregion

        #region Filter Login
        public DataTable filtrarLoginBLL(clsLoginDAL login)
        {
            return Conexion.filtrarLoginBLL(login);
        }
        #endregion
    }


}
