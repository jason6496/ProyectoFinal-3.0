using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace DAL_ProyectoFinal
{
    public class clsTipoServicioDAL
    {
        public string sIdTipoServicio                           { get; set; }
        public string sDrescipcionTipoServicio                  { get; set; }
        public string sTiempoPromedio                           { get; set; }
        public DataTable dtViewTipoServicio                     { get; set; }
        public Boolean bBandera                                 { get; set; }      
    }
    public class clsSucursalDAL
    {
        public string sIdSucursal                               { get; set; }
        public string sHorarioSucursal                          { get; set; }
        public string sUbicacionSucursal                        { get; set; }
        public string sCorreoSucursal                           { get; set; }
        public string sTelefonoSucursal                         { get; set; }
        public DataTable dtViewSucursal                         { get; set; }
        public Boolean bBandera                                 { get; set; }
    }
    public class clsProveedorDAL
    {
        public string sIdProveedor                              { get; set; }
        public string sNombreProveedor                          { get; set; }
        public string sCorreoProveedor                          { get; set; }
        public string sTelefonoProveedor                        { get; set; }
        public string sUbicacionProveedor                       { get; set; }
        public DataTable dtViewProveedor                        { get; set; }
        public Boolean bBandera                                 { get; set; }
    }
    public class clsVehiculoDAL
    {
        public string sPlacaVehiculo                            { get; set; }
        public int iCodMarcaVehiculo                            { get; set; }
        public int iCodModeloVehiculo                           { get; set; }
        public int iCodFisicoVehiculo                           { get; set; }
        public string sTipoVehiculo                             { get; set; }
        public string sTipoMotorVehiculo                        { get; set; }
        public string sTipoCilindrajeVehiculo                   { get; set; }
        public string sTipoTransmicionVehiculo                  { get; set; }
        public string sAnhioVehiculo                            { get; set; }
        public string sTipoGasolinaVehiculo                     { get; set; }
        public string sNumeroPuertasVehiculo                    { get; set; }
        public DataTable dtViewVehiculo                         { get; set; }
        public Boolean bBandera                                 { get; set; }
    }
    public class clsModeloDAL
    {
        public string sIdModelo                                 { get; set; }
        public string sNombreModelo                             { get; set; }
        public int iCodMarcaModelo                              { get; set; }
        public DataTable dtViewModelo                           { get; set; }
        public Boolean bBandera                                 { get; set; }
    }
    public class clsMarcaDAL
    {
        public string sIdMarca                                  { get; set; }
        public string sNombreMarca                              { get; set; }
        public DataTable dtViewMarca                            { get; set; }
        public Boolean bBandera                                 { get; set; }
    }
    public class clsColaboradorDAL
    {
        public string sIdColaborador                            { get; set; }
        public string sNombreColaborador                        { get; set; }
        public string sPrimerApellidoColaborador                { get; set; }
        public string sSegundoApellidoColaborador               { get; set; }
        public string sCorreoColaborador                        { get; set; }
        public string sTelefonoColaborador                      { get; set; }
        public string sDireccionColaborador                     { get; set; }
        public string sRolColaborador                           { get; set; }
        public int iCodSucursal                                 { get; set; }
        public DataTable dtViewColaborador                      { get; set; }
        public Boolean bBandera                                 { get; set; }
    }
    public class clsClienteDAL
    {
        public string sIdClienteJuridico                        { get; set; }
        public string sNombreLegalClienteJuridico               { get; set; }
        public string sNombreFantasiaClienteJuridico            { get; set; }
        public string sNombreRepresentanteClienteJuridico       { get; set; }
        public string sCorreoClienteJuridico                    { get; set; }
        public string sTelefonoClienteJuridico                  { get; set; }
        public string sDireccionClienteJuridico                 { get; set; }
        public int iCodClienteFisicoClienteJuridico             { get; set; }
        public string sIdClienteFisico                          { get; set; }
        public string sNombreClienteFisico                      { get; set; }
        public string sPrimerApellidoClienteFisico              { get; set; }
        public string sSegundoApellidoClienteFisico             { get; set; }
        public string sCorreoClienteFisico                      { get; set; }
        public string sDireccionClienteFisico                   { get; set; }
        public DataTable dtViewClienteJuridico                  { get; set; }
        public DataTable dtViewClienteFisico                    { get; set; }
        public Boolean bBandera                                 { get; set; }
    }
    public class clsInventarioDAL
    {
        public string sIdObjetoInventario                       { get; set; }
        public string sNombreObjetoInventario                   { get; set; }
        public int iCantidadObjetoInventario                    { get; set; }
        public int iCodSucursalInventario                       { get; set; }
        public DataTable dtViewInventario                       { get; set; }
        public Boolean bBandera                                 { get; set; }
    }
    public class clsOrdenTrabajoDAL
    {
        public string sIdOrden { get; set; }
        public string IdOrdenEncabezado { get; set; }
        public string CodColaboradorOrdenEncabezado { get; set; }
        public int PlacaOrdenEncabezado { get; set; }
        public int RepuestosTotalOrdenEncabezado { get; set; }
        public int DiagnosticoOrdenEncabezado { get; set; }
        public int DuracionTotalOrdenEncabezado { get; set; }
        public string TrabajoCompletadoOrdenEncabezado { get; set; }
        public Boolean TotalAdelantoOrdenEncabezado { get; set; }
        public DataTable dtViewOrdenEncabezado { get; set; }

        public int IdOrdenDetalle { get; set; }
        public int CodProveedorOrdenDetalle { get; set; }
        public int CodTipoServicioOrdenDetalle { get; set; }
        public string DetalleOrdenDetalle { get; set; }
        public int CodInventarioOrdenDetalle { get; set; }
        public int CantInventarioEncabezadoOrdenDetalle { get; set; }
        public int CodOrdenEncabezadoOrdenDetalle { get; set; }
        public int TiempoTrabajoOrdenDetalle { get; set; }
        public int CostoRepuestoOrdenDetalle { get; set; }
        public int CostoServicioOrdenDetalle { get; set; }
        public int CostoDetalleOrdenDetalle { get; set; }
        public Boolean RepuestoPropioOrdenDetalle { get; set; }
        public int AdelantoOrdenDetalle { get; set; }
        public DataTable dtViewOrdenDetalle { get; set; }

        public Boolean bBandera { get; set; }


    }
    public class clsFacturacionDAL
    {
        public string IdFacturaEncabezado { get; set; }
        public string FechafacturaFacturaEncabezado { get; set; }
        public int IdColaboradorFacturaEncabezado { get; set; }
        public int TotalFacturaEncabezado { get; set; }
        public int IdSucursalFacturaEncabezado { get; set; }
        public int IdClienteFisicoFacturaEncabezado { get; set; }
        public string MetodoPagoFacturaEncabezado { get; set; }
        public Boolean TasaCeroFacturaEncabezado { get; set; }
        public int IdOrdenFacturaEncabezado { get; set; }
        public DataTable dtViewFacturaEncabezado { get; set; }

        public int IdFacturaDetalle { get; set; }
        public string DetaelleFacturaDetalle { get; set; }
        public int CantidadFacturaDetalle { get; set; }
        public int CostoFacturaDetalle { get; set; }
        public int IdOrdenFacturaDetalle { get; set; }
        public int AdelantoProveedorFacturaDetalle { get; set; }
        public int ImpuestoFacturaDetalle { get; set; }
        public int IdFacturaEncabezadoFacturaDetalle { get; set; }
        public int IdTipoServicioFacturaDetalle { get; set; }
        public int IdInventarioFacturaDetalle { get; set; }
        public DataTable dtViewFacturaDetalle { get; set; }

        public Boolean bBandera { get; set; }

    }
    public class clsAgendaDAL
    {
        public int iIdAgenda { get; set; }
        public string sPlaca { get; set; }
        public int iCodColaboradorAgenda { get; set; }
        public Boolean bTipoAgenda { get; set; }
        public string dTiempoInicioAgenda { get; set; }
        public string sDuracionAproxAgenda { get; set; }
        public int iCodOrdenAgenda { get; set; }
        public string sMotivoAgenda { get; set; }
        public int iTipoServicioAgenda { get; set; }
        public DataTable dtViewAgenda { get; set; }

        public Boolean bBandera { get; set; }

    }

    public class clsTelefonoDAL
    {
        public string sCodTelefono                              { get; set; }
        public string sNombrePropietarioTelefono                { get; set; }
        public string sDescripcionTelefono                      { get; set; }
        public int iIdClienteFisico                             { get; set; }
        public int iIdClienteJuridico                           { get; set; }
        public DataTable dtViewTelefono                         { get; set; }

        public Boolean bBandera                                 { get; set; }

    }

    public class clsLoginDAL
    {
        public string sUsuario                                  { get; set; }
        public string sClave                                    { get; set; }
   
    }

    public class clsUsuarioDAL
    {
        public string sCodAreaUsuario { get; set; }
        public string sCodEmpleadoUsuario { get; set; }
        public string sNombreUsuario { get; set; }
        public string sUsuario { get; set; }
        public string sContrasena { get; set; }
        public DataTable dtViewUsuario { get; set; }
        public Boolean bBandera { get; set; }
    }






}
