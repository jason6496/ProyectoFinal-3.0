using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_ProyectoFinal;
using System.Data;

namespace BLL_ProyectoFinal
{
    public class clsConexion
    {
        string Query;
        static SqlConnection conectar = new SqlConnection();
        static SqlCommand comando = new SqlCommand();

        clsTipoServicioDAL tipoServicioDal = new clsTipoServicioDAL();
        clsSucursalDAL sucursalDal = new clsSucursalDAL();
        clsProveedorDAL proveedorDal = new clsProveedorDAL();
        clsVehiculoDAL vehiculoDal = new clsVehiculoDAL();
        clsModeloDAL modeloDal = new clsModeloDAL();
        clsMarcaDAL marcaDal = new clsMarcaDAL();
        clsColaboradorDAL colaboradorDal = new clsColaboradorDAL();
        clsClienteDAL clienteDal = new clsClienteDAL();
        clsTelefonoDAL telefonoDal = new clsTelefonoDAL();
        clsInventarioDAL inventarioDal = new clsInventarioDAL();
        clsOrdenTrabajoDAL ordenTrabajoDal = new clsOrdenTrabajoDAL();
        clsFacturacionDAL facturacionDal = new clsFacturacionDAL();
        clsAgendaDAL agendaDal = new clsAgendaDAL();
        clsLoginDAL loginDal = new clsLoginDAL();
        clsUsuarioDAL usuarioDal = new clsUsuarioDAL();



        public Boolean mConectar()
        {
            Boolean Estado = true;
            try
            {
                conectar.ConnectionString = "Data Source=DESKTOP-5RA3405;Initial Catalog=BD_RipKings;Integrated Security=True";
                conectar.Open();
            }
            catch (Exception ex)
            {
                Estado = false;
                throw;
            }
            return Estado;

        }
        public void mDesconectar()
        {
            conectar.Close();
        }

        #region Tipo Servicio

        #region Create Tipo Servicio
        public Boolean createTipoServicioBLL(clsTipoServicioDAL tipoServicio)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_TIPOSERVICIO] @IDTipoServicio, @DescripcionServicio, @TiempoPromedio";

                SqlParameter IDTipoServicio = new SqlParameter("@IDTipoServicio", tipoServicio.sIdTipoServicio);
                SqlParameter DescripcionServicio = new SqlParameter("@DescripcionServicio", tipoServicio.sDrescipcionTipoServicio);
                SqlParameter TiempoPromedio = new SqlParameter("@TiempoPromedio", tipoServicio.sTiempoPromedio);

                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(IDTipoServicio);
                command.Parameters.Add(DescripcionServicio);
                command.Parameters.Add(TiempoPromedio);
                command.ExecuteNonQuery();

                tipoServicio.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                tipoServicio.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return tipoServicio.bBandera;
        }
        #endregion

        #region Read Tipo Servicio
        public DataTable readTipoServicioBLL()
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar())
                {

                    Query = @"[dbo].[SP_ACTUALIZAR_TIPOSERVICIO]";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query, conectar);
                    tipoServicioDal.dtViewTipoServicio = new DataTable();
                    sqlAdapter.Fill(tipoServicioDal.dtViewTipoServicio);

                    //Console.WriteLine("Agregado");
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return tipoServicioDal.dtViewTipoServicio;
        }
        #endregion

        #region Update Tipo Servicio
        public Boolean updateTipoServicioBLL(clsTipoServicioDAL tipoServicio)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_MODIFICAR_TIPOSERVICIO] @IDTipoServicio, @DescripcionServicio, @TiempoPromedio";

                SqlParameter IDTipoServicio = new SqlParameter("@IDTipoServicio", tipoServicio.sIdTipoServicio);
                SqlParameter DescripcionServicio = new SqlParameter("@DescripcionServicio", tipoServicio.sDrescipcionTipoServicio);
                SqlParameter TiempoPromedio = new SqlParameter("@TiempoPromedio", tipoServicio.sTiempoPromedio);

                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(IDTipoServicio);
                command.Parameters.Add(DescripcionServicio);
                command.Parameters.Add(TiempoPromedio);
                command.ExecuteNonQuery();

                tipoServicio.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                tipoServicio.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return tipoServicio.bBandera;
        }
        #endregion

        #region Delete Tipo Servicio
        public Boolean deleteTipoServicioBLL(clsTipoServicioDAL tipoServicio)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_ELIMINAR_TIPOSERVICIO] @IDTipoServicio";

                SqlParameter IDTipoServicio = new SqlParameter("@IDTipoServicio", tipoServicio.sIdTipoServicio);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(IDTipoServicio);
                command.ExecuteNonQuery();

                tipoServicio.bBandera = true;
                Console.WriteLine("Eliminado");
            }
            catch (Exception)
            {
                tipoServicio.bBandera = false;
                Console.WriteLine("No Eliminado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return tipoServicio.bBandera;
        }
        #endregion

        #endregion

        #region Sucursal

        #region Create Sucursal
        public Boolean createSucursalBLL(clsSucursalDAL sucursal)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_SUCURSAL] @CodSucursal, @HorarioSucursal, @UbicacionSucursal, @CorreoSucursal, @TelefonoSucursal";

                SqlParameter CodSucursal = new SqlParameter("@CodSucursal", sucursal.sIdSucursal);
                SqlParameter HorarioSucursal = new SqlParameter("@HorarioSucursal", sucursal.sHorarioSucursal);
                SqlParameter UbicacionSucursal = new SqlParameter("@UbicacionSucursal", sucursal.sUbicacionSucursal);
                SqlParameter CorreoSucursal = new SqlParameter("@CorreoSucursal", sucursal.sCorreoSucursal);
                SqlParameter TelefonoSucursal = new SqlParameter("@TelefonoSucursal", sucursal.sTelefonoSucursal);

                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodSucursal);
                command.Parameters.Add(HorarioSucursal);
                command.Parameters.Add(UbicacionSucursal);
                command.Parameters.Add(CorreoSucursal);
                command.Parameters.Add(TelefonoSucursal);
                command.ExecuteNonQuery();

                sucursal.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                sucursal.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return sucursal.bBandera;
        }
        #endregion

        #region Read Sucursal
        public DataTable readSucursalBLL()
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar())
                {

                    Query = @"[dbo].[SP_ACTUALIZAR_SUCURSAL]";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query, conectar);
                    sucursalDal.dtViewSucursal = new DataTable();
                    sqlAdapter.Fill(sucursalDal.dtViewSucursal);

                    //Console.WriteLine("Agregado");
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return sucursalDal.dtViewSucursal;
        }
        #endregion

        #region Update Sucursal
        public Boolean updateSucursalBLL(clsSucursalDAL sucursal)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_MODIFICAR_SUCURSAL] @CodSucursal, @HorarioSucursal, @UbicacionSucursal, @CorreoSucursal, @TelefonoSucursal";

                SqlParameter CodSucursal = new SqlParameter("@CodSucursal", sucursal.sIdSucursal);
                SqlParameter HorarioSucursal = new SqlParameter("@HorarioSucursal", sucursal.sHorarioSucursal);
                SqlParameter UbicacionSucursal = new SqlParameter("@UbicacionSucursal", sucursal.sUbicacionSucursal);
                SqlParameter CorreoSucursal = new SqlParameter("@CorreoSucursal", sucursal.sCorreoSucursal);
                SqlParameter TelefonoSucursal = new SqlParameter("@TelefonoSucursal", sucursal.sTelefonoSucursal);

                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodSucursal);
                command.Parameters.Add(HorarioSucursal);
                command.Parameters.Add(UbicacionSucursal);
                command.Parameters.Add(CorreoSucursal);
                command.Parameters.Add(TelefonoSucursal);
                command.ExecuteNonQuery();

                sucursal.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                sucursal.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return sucursal.bBandera;
        }
        #endregion

        #region Delete Sucursal
        public Boolean deleteSucursalBLL(clsSucursalDAL sucursal)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_ELIMINAR_SUCURSAL] @CodSucursal";

                SqlParameter CodSucursal = new SqlParameter("@CodSucursal", sucursal.sIdSucursal);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodSucursal);
                command.ExecuteNonQuery();

                sucursal.bBandera = true;
                Console.WriteLine("Eliminado");
            }
            catch (Exception)
            {
                sucursal.bBandera = false;
                Console.WriteLine("No Eliminado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return sucursal.bBandera;
        }
        #endregion

        #endregion

        #region Proveedor

        #region Create Proveedor
        public Boolean createProveedorBLL(clsProveedorDAL proveedor)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_PROVEEDOR] @CodProveedor, @NombreProveedor, @CorreoProveedor, @TelefonoProveedor, @UbicacionProveedor";

                SqlParameter CodProveedor = new SqlParameter("@CodProveedor", proveedor.sIdProveedor);
                SqlParameter NombreProveedor = new SqlParameter("@NombreProveedor", proveedor.sNombreProveedor);
                SqlParameter CorreoProveedor = new SqlParameter("@CorreoProveedor", proveedor.sCorreoProveedor);
                SqlParameter TelefonoProveedor = new SqlParameter("@TelefonoProveedor", proveedor.sTelefonoProveedor);
                SqlParameter UbicacionProveedor = new SqlParameter("@UbicacionProveedor", proveedor.sUbicacionProveedor);

                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodProveedor);
                command.Parameters.Add(NombreProveedor);
                command.Parameters.Add(CorreoProveedor);
                command.Parameters.Add(TelefonoProveedor);
                command.Parameters.Add(UbicacionProveedor);
                command.ExecuteNonQuery();

                proveedor.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                proveedor.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return proveedor.bBandera;
        }
        #endregion

        #region Read Proveedor
        public DataTable readProveedorBLL()
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar())
                {

                    Query = @"[dbo].[SP_ACTUALIZAR_PROVEEDOR]";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query, conectar);
                    proveedorDal.dtViewProveedor = new DataTable();
                    sqlAdapter.Fill(proveedorDal.dtViewProveedor);

                    //Console.WriteLine("Agregado");
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return proveedorDal.dtViewProveedor;
        }
        #endregion

        #region Update Proveedor
        public Boolean updateProveedorBLL(clsProveedorDAL proveedor)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_MODIFICAR_PROVEEDOR] @CodProveedor, @NombreProveedor, @CorreoProveedor, @TelefonoProveedor, @UbicacionProveedor";

                SqlParameter CodProveedor = new SqlParameter("@CodProveedor", proveedor.sIdProveedor);
                SqlParameter NombreProveedor = new SqlParameter("@NombreProveedor", proveedor.sNombreProveedor);
                SqlParameter CorreoProveedor = new SqlParameter("@CorreoProveedor", proveedor.sCorreoProveedor);
                SqlParameter TelefonoProveedor = new SqlParameter("@TelefonoProveedor", proveedor.sTelefonoProveedor);
                SqlParameter UbicacionProveedor = new SqlParameter("@UbicacionProveedor", proveedor.sUbicacionProveedor);

                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodProveedor);
                command.Parameters.Add(NombreProveedor);
                command.Parameters.Add(CorreoProveedor);
                command.Parameters.Add(TelefonoProveedor);
                command.Parameters.Add(UbicacionProveedor);
                command.ExecuteNonQuery();

                proveedor.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                proveedor.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return proveedor.bBandera;
        }
        #endregion

        #region Delete Proveedor
        public Boolean deleteProveedorBLL(clsProveedorDAL proveedor)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_ELIMINAR_PROVEEDOR] @CodProveedor";

                SqlParameter CodProveedor = new SqlParameter("@CodProveedor", proveedor.sIdProveedor);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodProveedor);
                command.ExecuteNonQuery();

                proveedor.bBandera = true;
                Console.WriteLine("Eliminado");
            }
            catch (Exception)
            {
                proveedor.bBandera = false;
                Console.WriteLine("No Eliminado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return proveedor.bBandera;
        }
        #endregion

        #endregion

        #region Vehiculo

        #region Create Vehiculo
        public Boolean createVehiculoBLL(clsVehiculoDAL vehiculo)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_VEHICULO] @Placa, @CodMarca, @CodModelo, @CodFisico, @TipoVehiculo, @TipoMotor, @Cilindraje, @TipoTransmicion, @Anhio, @TipoGasolina, @NumeroPuertas";

                SqlParameter Placa = new SqlParameter("@Placa", vehiculo.sPlacaVehiculo);
                SqlParameter CodMarca = new SqlParameter("@CodMarca", vehiculo.iCodMarcaVehiculo);
                SqlParameter CodModelo = new SqlParameter("@CodModelo", vehiculo.iCodModeloVehiculo);
                SqlParameter CodFisico = new SqlParameter("@CodFisico", vehiculo.iCodFisicoVehiculo);
                SqlParameter TipoVehiculo = new SqlParameter("@TipoVehiculo", vehiculo.sTipoVehiculo);
                SqlParameter TipoMotor = new SqlParameter("@TipoMotor", vehiculo.sTipoMotorVehiculo);
                SqlParameter Cilindraje = new SqlParameter("@Cilindraje", vehiculo.sTipoCilindrajeVehiculo);
                SqlParameter TipoTransmicion = new SqlParameter("@TipoTransmicion", vehiculo.sTipoTransmicionVehiculo);
                SqlParameter Anhio = new SqlParameter("@Anhio", vehiculo.sAnhioVehiculo);
                SqlParameter TipoGasolina = new SqlParameter("@TipoGasolina", vehiculo.sTipoGasolinaVehiculo);
                SqlParameter NumeroPuertas = new SqlParameter("@NumeroPuertas", vehiculo.sNumeroPuertasVehiculo);

                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(Placa);
                command.Parameters.Add(CodMarca);
                command.Parameters.Add(CodModelo);
                command.Parameters.Add(CodFisico);
                command.Parameters.Add(TipoVehiculo);
                command.Parameters.Add(TipoMotor);
                command.Parameters.Add(Cilindraje);
                command.Parameters.Add(TipoTransmicion);
                command.Parameters.Add(Anhio);
                command.Parameters.Add(TipoGasolina);
                command.Parameters.Add(NumeroPuertas);
                command.ExecuteNonQuery();

                vehiculo.bBandera = true;
                Console.WriteLine("Agregado" + vehiculo.sTipoVehiculo);
            }
            catch (Exception)
            {
                vehiculo.bBandera = false;
                Console.WriteLine("No Agregado" + vehiculo.sTipoVehiculo);
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return vehiculo.bBandera;
        }
        #endregion

        #region Read Vehiculo
        public DataTable readVehiculoBLL()
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar())
                {

                    Query = @"[dbo].[SP_ACTUALIZAR_VEHICULO]";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query, conectar);
                    vehiculoDal.dtViewVehiculo = new DataTable();
                    sqlAdapter.Fill(vehiculoDal.dtViewVehiculo);

                    //Console.WriteLine("Agregado");
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return vehiculoDal.dtViewVehiculo;
        }
        #endregion

        #region Update Vehiculo
        public Boolean updateVehiculoBLL(clsVehiculoDAL vehiculo)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_MODIFICAR_VEHICULO] @Placa, @CodMarca, @CodModelo, @CodFisico, @TipoVehiculo, @TipoMotor, @Cilindraje, @TipoTransmicion, @Anhio, @TipoGasolina, @NumeroPuertas";

                SqlParameter Placa = new SqlParameter("@Placa", vehiculo.sPlacaVehiculo);
                SqlParameter CodMarca = new SqlParameter("@CodMarca", vehiculo.iCodMarcaVehiculo);
                SqlParameter CodModelo = new SqlParameter("@CodModelo", vehiculo.iCodModeloVehiculo);
                SqlParameter CodFisico = new SqlParameter("@CodFisico", vehiculo.iCodFisicoVehiculo);
                SqlParameter TipoVehiculo = new SqlParameter("@TipoVehiculo", vehiculo.sTipoVehiculo);
                SqlParameter TipoMotor = new SqlParameter("@TipoMotor", vehiculo.sTipoMotorVehiculo);
                SqlParameter Cilindraje = new SqlParameter("@Cilindraje", vehiculo.sTipoCilindrajeVehiculo);
                SqlParameter TipoTransmicion = new SqlParameter("@TipoTransmicion", vehiculo.sTipoTransmicionVehiculo);
                SqlParameter Anhio = new SqlParameter("@Anhio", vehiculo.sAnhioVehiculo);
                SqlParameter TipoGasolina = new SqlParameter("@TipoGasolina", vehiculo.sTipoGasolinaVehiculo);
                SqlParameter NumeroPuertas = new SqlParameter("@NumeroPuertas", vehiculo.sNumeroPuertasVehiculo);

                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(Placa);
                command.Parameters.Add(CodMarca);
                command.Parameters.Add(CodModelo);
                command.Parameters.Add(CodFisico);
                command.Parameters.Add(TipoVehiculo);
                command.Parameters.Add(TipoMotor);
                command.Parameters.Add(Cilindraje);
                command.Parameters.Add(TipoTransmicion);
                command.Parameters.Add(Anhio);
                command.Parameters.Add(TipoGasolina);
                command.Parameters.Add(NumeroPuertas);
                command.ExecuteNonQuery();

                vehiculo.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                vehiculo.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return vehiculo.bBandera;
        }
        #endregion

        #region Delete Vehiculo
        public Boolean deleteVehiculoBLL(clsVehiculoDAL vehiculo)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_ELIMINAR_VEHICULO] @Placa";

                SqlParameter Placa = new SqlParameter("@Placa", vehiculo.sPlacaVehiculo);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(Placa);
                command.ExecuteNonQuery();

                vehiculo.bBandera = true;
                Console.WriteLine("Eliminado");
            }
            catch (Exception)
            {
                vehiculo.bBandera = false;
                Console.WriteLine("No Eliminado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return vehiculo.bBandera;
        }
        #endregion

        #endregion

        #region Modelo

        #region Create Modelo
        public Boolean createModeloBLL(clsModeloDAL modelo)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_MODELO] @CodModelo, @NombreModelo, @CodMarca";

                SqlParameter CodModelo = new SqlParameter("@CodModelo", modelo.sIdModelo);
                SqlParameter NombreModelo = new SqlParameter("@NombreModelo", modelo.sNombreModelo);
                SqlParameter CodMarca = new SqlParameter("@CodMarca", modelo.iCodMarcaModelo);

                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodModelo);
                command.Parameters.Add(NombreModelo);
                command.Parameters.Add(CodMarca);
                command.ExecuteNonQuery();

                modelo.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                modelo.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return modelo.bBandera;
        }
        #endregion

        #region Read Modelo
        public DataTable readModeloBLL()
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar())
                {

                    Query = @"[dbo].[SP_ACTUALIZAR_MODELO]";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query, conectar);
                    modeloDal.dtViewModelo = new DataTable();
                    sqlAdapter.Fill(modeloDal.dtViewModelo);

                    //Console.WriteLine("Agregado");
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return modeloDal.dtViewModelo;
        }
        #endregion

        #region Update Modelo
        public Boolean updateModeloBLL(clsModeloDAL modelo)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_MODIFICAR_MODELO] @CodModelo, @NombreModelo, @CodMarca";

                SqlParameter CodModelo = new SqlParameter("@CodModelo", modelo.sIdModelo);
                SqlParameter NombreModelo = new SqlParameter("@NombreModelo", modelo.sNombreModelo);
                SqlParameter CodMarca = new SqlParameter("@CodMarca", modelo.iCodMarcaModelo);

                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodModelo);
                command.Parameters.Add(NombreModelo);
                command.Parameters.Add(CodMarca);
                command.ExecuteNonQuery();

                modelo.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                modelo.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return modelo.bBandera;
        }
        #endregion

        #region Delete Modelo
        public Boolean deleteModeloBLL(clsModeloDAL modelo)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_ELIMINAR_MODELO] @CodModelo";

                SqlParameter CodModelo = new SqlParameter("@CodModelo", modelo.sIdModelo);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodModelo);
                command.ExecuteNonQuery();

                modelo.bBandera = true;
                Console.WriteLine("Eliminado");
            }
            catch (Exception)
            {
                modelo.bBandera = false;
                Console.WriteLine("No Eliminado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return modelo.bBandera;
        }
        #endregion

        #endregion

        #region Marca

        #region Create Marca
        public Boolean createMarcaBLL(clsMarcaDAL marca)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_MARCA] @CodMarca, @NombreMarca";

                SqlParameter CodMarca = new SqlParameter("@CodMarca", marca.sIdMarca);
                SqlParameter NombreMarca = new SqlParameter("@NombreMarca", marca.sNombreMarca);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodMarca);
                command.Parameters.Add(NombreMarca);
                command.ExecuteNonQuery();

                marca.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                marca.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return marca.bBandera;
        }
        #endregion

        #region Read Marca
        public DataTable readMarcaBLL()
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar())
                {

                    Query = @"[dbo].[SP_ACTUALIZAR_MARCA]";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query, conectar);
                    marcaDal.dtViewMarca = new DataTable();
                    sqlAdapter.Fill(marcaDal.dtViewMarca);

                    //Console.WriteLine("Agregado");
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return marcaDal.dtViewMarca;
        }
        #endregion

        #region Update Marca
        public Boolean updateMarcaBLL(clsMarcaDAL marca)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_MODIFICAR_MARCA] @CodMarca, @NombreMarca";

                SqlParameter CodMarca = new SqlParameter("@CodMarca", marca.sIdMarca);
                SqlParameter NombreMarca = new SqlParameter("@NombreMarca", marca.sNombreMarca);

                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodMarca);
                command.Parameters.Add(NombreMarca);
                command.ExecuteNonQuery();

                marca.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                marca.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return marca.bBandera;
        }
        #endregion

        #region Delete Marca
        public Boolean deleteMarcaBLL(clsMarcaDAL marca)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_ELIMINAR_MARCA] @CodMarca";

                SqlParameter CodMarca = new SqlParameter("@CodMarca", marca.sIdMarca);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodMarca);
                command.ExecuteNonQuery();

                marca.bBandera = true;
                Console.WriteLine("Eliminado");
            }
            catch (Exception)
            {
                marca.bBandera = false;
                Console.WriteLine("No Eliminado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return marca.bBandera;
        }
        #endregion

        #endregion

        #region Colaborador

        #region Create Colaborador
        public Boolean createColaboradorBLL(clsColaboradorDAL colaborador)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_COLABORADOR] @CodColaborador, @NombreColaborador, @PrimerApeColaborador, @SegundoApeColaborador, @CorreoColaborador, @TelefonoColaborador, @DireccionColaborador, @RolColaborador, @CodSucursal";

                SqlParameter CodColaborador = new SqlParameter("@CodColaborador", colaborador.sIdColaborador);
                SqlParameter NombreColaborador = new SqlParameter("@NombreColaborador", colaborador.sNombreColaborador);
                SqlParameter PrimerApeColaborador = new SqlParameter("@PrimerApeColaborador", colaborador.sPrimerApellidoColaborador);
                SqlParameter SegundoApeColaborador = new SqlParameter("@SegundoApeColaborador", colaborador.sSegundoApellidoColaborador);
                SqlParameter CorreoColaborador = new SqlParameter("@CorreoColaborador", colaborador.sCorreoColaborador);
                SqlParameter TelefonoColaborador = new SqlParameter("@TelefonoColaborador", colaborador.sTelefonoColaborador);
                SqlParameter DireccionColaborador = new SqlParameter("@DireccionColaborador", colaborador.sDireccionColaborador);
                SqlParameter RolColaborador = new SqlParameter("@RolColaborador", colaborador.sRolColaborador);
                SqlParameter CodSucursal = new SqlParameter("@CodSucursal", colaborador.iCodSucursal);

                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodColaborador);
                command.Parameters.Add(NombreColaborador);
                command.Parameters.Add(PrimerApeColaborador);
                command.Parameters.Add(SegundoApeColaborador);
                command.Parameters.Add(CorreoColaborador);
                command.Parameters.Add(TelefonoColaborador);
                command.Parameters.Add(DireccionColaborador);
                command.Parameters.Add(RolColaborador);
                command.Parameters.Add(CodSucursal);
                command.ExecuteNonQuery();

                colaborador.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                colaborador.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return colaborador.bBandera;
        }
        #endregion

        #region Read Colaborador
        public DataTable readColaboradorBLL()
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar())
                {

                    Query = @"[dbo].[SP_ACTUALIZAR_COLABORADOR]";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query, conectar);
                    colaboradorDal.dtViewColaborador = new DataTable();
                    sqlAdapter.Fill(colaboradorDal.dtViewColaborador);

                    //Console.WriteLine("Agregado");
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return colaboradorDal.dtViewColaborador;
        }
        #endregion

        #region Update Colaborador
        public Boolean updateColaboradorBLL(clsColaboradorDAL colaborador)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_MODIFICAR_COLABORADOR] @CodColaborador, @NombreColaborador, @PrimerApeColaborador, @SegundoApeColaborador, @CorreoColaborador, @TelefonoColaborador, @DireccionColaborador, @RolColaborador, @CodSucursal";

                SqlParameter CodColaborador = new SqlParameter("@CodColaborador", colaborador.sIdColaborador);
                SqlParameter NombreColaborador = new SqlParameter("@NombreColaborador", colaborador.sNombreColaborador);
                SqlParameter PrimerApeColaborador = new SqlParameter("@PrimerApeColaborador", colaborador.sPrimerApellidoColaborador);
                SqlParameter SegundoApeColaborador = new SqlParameter("@SegundoApeColaborador", colaborador.sSegundoApellidoColaborador);
                SqlParameter CorreoColaborador = new SqlParameter("@CorreoColaborador", colaborador.sCorreoColaborador);
                SqlParameter TelefonoColaborador = new SqlParameter("@TelefonoColaborador", colaborador.sTelefonoColaborador);
                SqlParameter DireccionColaborador = new SqlParameter("@DireccionColaborador", colaborador.sDireccionColaborador);
                SqlParameter RolColaborador = new SqlParameter("@RolColaborador", colaborador.sRolColaborador);
                SqlParameter CodSucursal = new SqlParameter("@CodSucursal", colaborador.iCodSucursal);

                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodColaborador);
                command.Parameters.Add(NombreColaborador);
                command.Parameters.Add(PrimerApeColaborador);
                command.Parameters.Add(SegundoApeColaborador);
                command.Parameters.Add(CorreoColaborador);
                command.Parameters.Add(TelefonoColaborador);
                command.Parameters.Add(DireccionColaborador);
                command.Parameters.Add(RolColaborador);
                command.Parameters.Add(CodSucursal);
                command.ExecuteNonQuery();

                colaborador.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                colaborador.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return colaborador.bBandera;
        }
        #endregion

        #region Delete Colaborador
        public Boolean deleteColaboradorBLL(clsColaboradorDAL colaborador)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_ELIMINAR_COLABORADOR] @CodColaborador";

                SqlParameter CodColaborador = new SqlParameter("@CodColaborador", colaborador.sIdColaborador);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodColaborador);
                command.ExecuteNonQuery();

                colaborador.bBandera = true;
                Console.WriteLine("Eliminado");
            }
            catch (Exception)
            {
                colaborador.bBandera = false;
                Console.WriteLine("No Eliminado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return colaborador.bBandera;
        }
        #endregion

        #endregion

        #region Cliente

        #region Create Cliente Fisico
        public Boolean createClienteFisicoBLL(clsClienteDAL cliente)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_CFISICO] @CodFisico, @NombreFisico, @PrimerApellido, @SegundoApellido, @Correo, @Direccion";

                SqlParameter CodFisico = new SqlParameter("@CodFisico", cliente.sIdClienteFisico);
                SqlParameter NombreFisico = new SqlParameter("@NombreFisico", cliente.sNombreClienteFisico);
                SqlParameter PrimerApellido = new SqlParameter("@PrimerApellido", cliente.sPrimerApellidoClienteFisico);
                SqlParameter SegundoApellido = new SqlParameter("@SegundoApellido", cliente.sSegundoApellidoClienteFisico);
                SqlParameter Correo = new SqlParameter("@Correo", cliente.sCorreoClienteFisico);
                SqlParameter Direccion = new SqlParameter("@Direccion", cliente.sDireccionClienteFisico);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodFisico);
                command.Parameters.Add(NombreFisico);
                command.Parameters.Add(PrimerApellido);
                command.Parameters.Add(SegundoApellido);
                command.Parameters.Add(Correo);
                command.Parameters.Add(Direccion);
                command.ExecuteNonQuery();

                cliente.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                cliente.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return cliente.bBandera;
        }
        #endregion

        #region Read Cliente Fisico
        public DataTable readClienteFisicoBLL()
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar())
                {

                    Query = @"[dbo].[SP_ACTUALIZAR_CFISICO]";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query, conectar);
                    clienteDal.dtViewClienteFisico = new DataTable();
                    sqlAdapter.Fill(clienteDal.dtViewClienteFisico);

                    //Console.WriteLine("Agregado");
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return clienteDal.dtViewClienteFisico;
        }
        #endregion

        #region Update Cliente Fisico
        public Boolean updateClienteFisicoBLL(clsClienteDAL cliente)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_MODIFICAR_CFISICO] @CodFisico, @NombreFisico, @PrimerApellido, @SegundoApellido, @Correo, @Direccion";

                SqlParameter CodFisico = new SqlParameter("@CodFisico", cliente.sIdClienteFisico);
                SqlParameter NombreFisico = new SqlParameter("@NombreFisico", cliente.sNombreClienteFisico);
                SqlParameter PrimerApellido = new SqlParameter("@PrimerApellido", cliente.sPrimerApellidoClienteFisico);
                SqlParameter SegundoApellido = new SqlParameter("@SegundoApellido", cliente.sSegundoApellidoClienteFisico);
                SqlParameter Correo = new SqlParameter("@Correo", cliente.sCorreoClienteFisico);
                SqlParameter Direccion = new SqlParameter("@Direccion", cliente.sDireccionClienteFisico);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodFisico);
                command.Parameters.Add(NombreFisico);
                command.Parameters.Add(PrimerApellido);
                command.Parameters.Add(SegundoApellido);
                command.Parameters.Add(Correo);
                command.Parameters.Add(Direccion);
                command.ExecuteNonQuery();

                cliente.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                cliente.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return cliente.bBandera;
        }
        #endregion

        #region Delete Cliente Fisico
        public Boolean deleteClienteFisicoBLL(clsClienteDAL cliente)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_ELIMINAR_CFISICO] @CodFisico";

                SqlParameter CodFisico = new SqlParameter("@CodFisico", cliente.sIdClienteFisico);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodFisico);
                command.ExecuteNonQuery();

                cliente.bBandera = true;
                Console.WriteLine("Eliminado");
            }
            catch (Exception)
            {
                cliente.bBandera = false;
                Console.WriteLine("No Eliminado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return cliente.bBandera;
        }
        #endregion

        #region Create Cliente Juridico
        public Boolean createClienteJuridicoBLL(clsClienteDAL cliente)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_CJURIDICO] @CodClienteJuridico, @NombreLegal, @NombreFantasia, @NombreRepresentante, @CorreoJuridico, @TelefonoJuridico, @DireccionJuridico, @CodClienteFisico";

                SqlParameter CodClienteJuridico = new SqlParameter("@CodClienteJuridico", cliente.sIdClienteJuridico);
                SqlParameter NombreLegal = new SqlParameter("@NombreLegal", cliente.sNombreLegalClienteJuridico);
                SqlParameter NombreFantasia = new SqlParameter("@NombreFantasia", cliente.sNombreFantasiaClienteJuridico);
                SqlParameter NombreRepresentante = new SqlParameter("@NombreRepresentante", cliente.sNombreRepresentanteClienteJuridico);
                SqlParameter CorreoJuridico = new SqlParameter("@CorreoJuridico", cliente.sCorreoClienteJuridico);
                SqlParameter TelefonoJuridico = new SqlParameter("@TelefonoJuridico", cliente.sTelefonoClienteJuridico);
                SqlParameter DireccionJuridico = new SqlParameter("@DireccionJuridico", cliente.sDireccionClienteJuridico);
                SqlParameter CodClienteFisico = new SqlParameter("@CodClienteFisico", cliente.iCodClienteFisicoClienteJuridico);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodClienteJuridico);
                command.Parameters.Add(NombreLegal);
                command.Parameters.Add(NombreFantasia);
                command.Parameters.Add(NombreRepresentante);
                command.Parameters.Add(CorreoJuridico);
                command.Parameters.Add(TelefonoJuridico);
                command.Parameters.Add(DireccionJuridico);
                command.Parameters.Add(CodClienteFisico);
                command.ExecuteNonQuery();

                cliente.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception ex)
            {
                cliente.bBandera = false;
                Console.WriteLine("No Agregado" + ex);
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return cliente.bBandera;
        }
        #endregion

        #region Read Cliente Juridico
        public DataTable readClienteJuridicoBLL()
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar())
                {

                    Query = @"[dbo].[SP_ACTUALIZAR_CJURIDICO]";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query, conectar);
                    clienteDal.dtViewClienteJuridico = new DataTable();
                    sqlAdapter.Fill(clienteDal.dtViewClienteJuridico);

                    //Console.WriteLine("Agregado");
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return clienteDal.dtViewClienteJuridico;
        }
        #endregion

        #region Update Cliente Juridico
        public Boolean updateClienteJuridicoBLL(clsClienteDAL cliente)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_MODIFICAR_CJURIDICO] @CodClienteJuridico, @NombreLegal, @NombreFantasia, @NombreRepresentante, @CorreoJuridico, @TelefonoJuridico, @DireccionJuridico, @CodClienteFisico";

                SqlParameter CodClienteJuridico = new SqlParameter("@CodClienteJuridico", cliente.sIdClienteJuridico);
                SqlParameter NombreLegal = new SqlParameter("@NombreLegal", cliente.sNombreLegalClienteJuridico);
                SqlParameter NombreFantasia = new SqlParameter("@NombreFantasia", cliente.sNombreFantasiaClienteJuridico);
                SqlParameter NombreRepresentante = new SqlParameter("@NombreRepresentante", cliente.sNombreRepresentanteClienteJuridico);
                SqlParameter CorreoJuridico = new SqlParameter("@CorreoJuridico", cliente.sCorreoClienteJuridico);
                SqlParameter TelefonoJuridico = new SqlParameter("@TelefonoJuridico", cliente.sTelefonoClienteJuridico);
                SqlParameter DireccionJuridico = new SqlParameter("@DireccionJuridico", cliente.sDireccionClienteJuridico);
                SqlParameter CodClienteFisico = new SqlParameter("@CodClienteFisico", cliente.iCodClienteFisicoClienteJuridico);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodClienteJuridico);
                command.Parameters.Add(NombreLegal);
                command.Parameters.Add(NombreFantasia);
                command.Parameters.Add(NombreRepresentante);
                command.Parameters.Add(CorreoJuridico);
                command.Parameters.Add(TelefonoJuridico);
                command.Parameters.Add(DireccionJuridico);
                command.Parameters.Add(CodClienteFisico);
                command.ExecuteNonQuery();

                cliente.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                cliente.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return cliente.bBandera;
        }
        #endregion

        #region Delete Cliente Juridico
        public Boolean deleteClienteJuridicoBLL(clsClienteDAL cliente)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_ELIMINAR_CJURIDICO] @CodClienteJuridico";

                SqlParameter CodClienteJuridico = new SqlParameter("@CodClienteJuridico", cliente.sIdClienteJuridico);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodClienteJuridico);
                command.ExecuteNonQuery();

                cliente.bBandera = true;
                Console.WriteLine("Eliminado");
            }
            catch (Exception)
            {
                cliente.bBandera = false;
                Console.WriteLine("No Eliminado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return cliente.bBandera;
        }
        #endregion

        #endregion

        #region Telefono

        #region Create Telefono
        public Boolean createTelefonoBLL(clsTelefonoDAL telefono)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_TELEFONO] @CodTelefono, @NombrePropietario, @DescripcionTelefono, @IDClienteFisico";

                SqlParameter CodTelefono = new SqlParameter("@CodTelefono", telefono.sCodTelefono);
                SqlParameter NombrePropietario = new SqlParameter("@NombrePropietario", telefono.sNombrePropietarioTelefono);
                SqlParameter DescripcionTelefono = new SqlParameter("@DescripcionTelefono", telefono.sDescripcionTelefono);
                SqlParameter IDClienteFisico = new SqlParameter("@IDClienteFisico", telefono.iIdClienteFisico);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodTelefono);
                command.Parameters.Add(NombrePropietario);
                command.Parameters.Add(DescripcionTelefono);
                command.Parameters.Add(IDClienteFisico);
                command.ExecuteNonQuery();

                telefono.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                telefono.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return telefono.bBandera;
        }
        #endregion

        #region Read Telefono
        public DataTable readTelefonoBLL()
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar())
                {

                    Query = @"[dbo].[SP_ACTUALIZAR_TELEFONO]";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query, conectar);
                    telefonoDal.dtViewTelefono = new DataTable();
                    sqlAdapter.Fill(telefonoDal.dtViewTelefono);

                    //Console.WriteLine("Agregado");
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return telefonoDal.dtViewTelefono;
        }
        #endregion

        #region Update Telefono
        public Boolean updateTelefonoBLL(clsTelefonoDAL telefono)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_MODIFICAR_TELEFONO] @CodTelefono, @NombrePropietario, @DescripcionTelefono, @IDClienteFisico";

                SqlParameter CodTelefono = new SqlParameter("@CodTelefono", telefono.sCodTelefono);
                SqlParameter NombrePropietario = new SqlParameter("@NombrePropietario", telefono.sNombrePropietarioTelefono);
                SqlParameter DescripcionTelefono = new SqlParameter("@DescripcionTelefono", telefono.sDescripcionTelefono);
                SqlParameter IDClienteFisico = new SqlParameter("@IDClienteFisico", telefono.iIdClienteFisico);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodTelefono);
                command.Parameters.Add(NombrePropietario);
                command.Parameters.Add(DescripcionTelefono);
                command.Parameters.Add(IDClienteFisico);
                command.ExecuteNonQuery();

                telefono.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                telefono.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return telefono.bBandera;
        }
        #endregion

        #region Delete Telefono
        public Boolean deleteTelefonoBLL(clsTelefonoDAL telefono)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_ELIMINAR_TELEFONO] @CodTelefono";

                SqlParameter CodTelefono = new SqlParameter("@CodTelefono", telefono.sCodTelefono);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodTelefono);
                command.ExecuteNonQuery();

                telefono.bBandera = true;
                Console.WriteLine("Eliminado");
            }
            catch (Exception)
            {
                telefono.bBandera = false;
                Console.WriteLine("No Eliminado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return telefono.bBandera;
        }
        #endregion

        #endregion

        #region Inventario

        #region Create Inventario
        public Boolean createInventarioBLL(clsInventarioDAL inventario)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_INVENTARIO] @CodObjeto, @NombreObjeto,  @CantidadObjeto, @CodSucursal";

                SqlParameter CodObjeto = new SqlParameter("@CodObjeto", inventario.sIdObjetoInventario);
                SqlParameter NombreObjeto = new SqlParameter("@NombreObjeto", inventario.sNombreObjetoInventario);
                SqlParameter CantidadObjeto = new SqlParameter("@CantidadObjeto", inventario.iCantidadObjetoInventario);
                SqlParameter CodSucursal = new SqlParameter("@CodSucursal", inventario.iCodSucursalInventario);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodObjeto);
                command.Parameters.Add(NombreObjeto);
                command.Parameters.Add(CantidadObjeto);
                command.Parameters.Add(CodSucursal);
                command.ExecuteNonQuery();

                inventario.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                inventario.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return inventario.bBandera;
        }
        #endregion

        #region Read Inventario
        public DataTable readInventarioBLL()
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar())
                {

                    Query = @"[dbo].[SP_ACTUALIZAR_INVENTARIO]";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query, conectar);
                    inventarioDal.dtViewInventario = new DataTable();
                    sqlAdapter.Fill(inventarioDal.dtViewInventario);

                    //Console.WriteLine("Agregado");
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return inventarioDal.dtViewInventario;
        }
        #endregion

        #region Update Inventario
        public Boolean updateInventarioBLL(clsInventarioDAL inventario)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_MODIFICAR_INVENTARIO] @CodObjeto, @NombreObjeto,  @CantidadObjeto, @CodSucursal";

                SqlParameter CodObjeto = new SqlParameter("@CodObjeto", inventario.sIdObjetoInventario);
                SqlParameter NombreObjeto = new SqlParameter("@NombreObjeto", inventario.sNombreObjetoInventario);
                SqlParameter CantidadObjeto = new SqlParameter("@CantidadObjeto", inventario.iCantidadObjetoInventario);
                SqlParameter CodSucursal = new SqlParameter("@CodSucursal", inventario.iCodSucursalInventario);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodObjeto);
                command.Parameters.Add(NombreObjeto);
                command.Parameters.Add(CantidadObjeto);
                command.Parameters.Add(CodSucursal);
                command.ExecuteNonQuery();

                inventario.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                inventario.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return inventario.bBandera;
        }
        #endregion

        #region Delete Inventario
        public Boolean deleteInventarioBLL(clsInventarioDAL inventario)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_ELIMINAR_INVENTARIO] @CodObjeto";

                SqlParameter CodObjeto = new SqlParameter("@CodObjeto", inventario.sIdObjetoInventario);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodObjeto);
                command.ExecuteNonQuery();

                inventario.bBandera = true;
                Console.WriteLine("Eliminado");
            }
            catch (Exception)
            {
                inventario.bBandera = false;
                Console.WriteLine("No Eliminado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return inventario.bBandera;
        }
        #endregion

        #endregion

        #region OrdenTrabajo

        #region OrdenTrabajoEncabezado

        #region Create 
        public Boolean createOrdenTrabajoBLL(clsOrdenTrabajoDAL ordentrabajo)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_OTRABAJO] @CodOrden, @CodColaborador, @Placa,
					@Repuestos, @Diagnostico, @DuracionTotal, @TrabajoCompletado, @TotalAdelantado";

                SqlParameter CodOrden = new SqlParameter("@CodOrden", ordentrabajo.IdOrdenEncabezado);
                SqlParameter CodColaborador = new SqlParameter("@CodColaborador", ordentrabajo.CodColaboradorOrdenEncabezado);
                SqlParameter Placa = new SqlParameter("@Placa", ordentrabajo.PlacaOrdenEncabezado);
                SqlParameter Repuestos = new SqlParameter("@Repuestos", ordentrabajo.RepuestosTotalOrdenEncabezado);
                SqlParameter Diagnostico = new SqlParameter("@Diagnostico", ordentrabajo.DiagnosticoOrdenEncabezado);
                SqlParameter DuracionTotal = new SqlParameter("@DuracionTotal", ordentrabajo.DuracionTotalOrdenEncabezado);
                SqlParameter TrabajoCompletado = new SqlParameter("@TrabajoCompletado", ordentrabajo.TrabajoCompletadoOrdenEncabezado);
                SqlParameter TotalAdelantado = new SqlParameter("@TotalAdelantado", ordentrabajo.TotalAdelantoOrdenEncabezado);

                SqlCommand command = new SqlCommand(Query, conectar);

                command.Parameters.Add(CodOrden);
                command.Parameters.Add(CodColaborador);
                command.Parameters.Add(Placa);
                command.Parameters.Add(Repuestos);
                command.Parameters.Add(Diagnostico);
                command.Parameters.Add(DuracionTotal);
                command.Parameters.Add(TrabajoCompletado);
                command.Parameters.Add(TotalAdelantado);

                command.ExecuteNonQuery();

                ordentrabajo.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                ordentrabajo.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return ordentrabajo.bBandera;
        }

        #endregion

        #region Read OrdenTrabajo
        public DataTable readOrdenTrabajoBLL()
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar())
                {

                    Query = @"[dbo].[SP_ACTUALIZAR_OTRABAJO]";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query, conectar);
                    ordenTrabajoDal.dtViewOrdenEncabezado = new DataTable();
                    sqlAdapter.Fill(ordenTrabajoDal.dtViewOrdenEncabezado);

                    //Console.WriteLine("Agregado");
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return ordenTrabajoDal.dtViewOrdenEncabezado;
        }
        #endregion

        #region Update OrdenTrabajo
        public Boolean updateOrdenTrabajoBLL(clsOrdenTrabajoDAL ordentrabajo)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_MODIFICAR_OTRABAJO]  @CodOrden, @CodColaborador, @Placa,
					@Repuestos, @Diagnostico, @DuracionTotal, @TrabajoCompletado, @TotalAdelantado";

                SqlParameter CodOrden = new SqlParameter("@CodOrden", ordentrabajo.IdOrdenEncabezado);
                SqlParameter CodColaborador = new SqlParameter("@CodColaborador", ordentrabajo.CodColaboradorOrdenEncabezado);
                SqlParameter Placa = new SqlParameter("@Placa", ordentrabajo.PlacaOrdenEncabezado);
                SqlParameter Repuestos = new SqlParameter("@Repuestos", ordentrabajo.RepuestosTotalOrdenEncabezado);
                SqlParameter Diagnostico = new SqlParameter("@Diagnostico", ordentrabajo.DiagnosticoOrdenEncabezado);
                SqlParameter DuracionTotal = new SqlParameter("@DuracionTotal", ordentrabajo.DuracionTotalOrdenEncabezado);
                SqlParameter TrabajoCompletado = new SqlParameter("@TrabajoCompletado", ordentrabajo.TrabajoCompletadoOrdenEncabezado);
                SqlParameter TotalAdelantado = new SqlParameter("@TotalAdelantado", ordentrabajo.TotalAdelantoOrdenEncabezado);

                SqlCommand command = new SqlCommand(Query, conectar);

                command.Parameters.Add(CodOrden);
                command.Parameters.Add(CodColaborador);
                command.Parameters.Add(Placa);
                command.Parameters.Add(Repuestos);
                command.Parameters.Add(Diagnostico);
                command.Parameters.Add(DuracionTotal);
                command.Parameters.Add(TrabajoCompletado);
                command.Parameters.Add(TotalAdelantado);
                command.ExecuteNonQuery();

                ordentrabajo.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                ordentrabajo.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return ordentrabajo.bBandera;
        }
        #endregion

        #region Delete OrdenTrabajo
        public Boolean deleteOrdenTrabajoBLL(clsOrdenTrabajoDAL ordentrabajo)
        {
            clsConexion objConex = new clsConexion();
            try

            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_ELIMINAR_OTRABAJO] @CodOrden";

                SqlParameter CodOrden = new SqlParameter("@CodOrden", ordentrabajo.IdOrdenEncabezado);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodOrden);
                command.ExecuteNonQuery();

                ordentrabajo.bBandera = true;
                Console.WriteLine("Eliminado");
            }
            catch (Exception)
            {
                ordentrabajo.bBandera = false;
                Console.WriteLine("No Eliminado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return ordentrabajo.bBandera;
        }
        #endregion

        #endregion

        //-----------------------------------------------------------------------------------		 

        #region OrdenTrabajoDetalle

        #region Create OrdenTrabajoDetalle
        public Boolean createOrdenTrabajoDetalleBLL(clsOrdenTrabajoDAL ordentrabajo)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_OTDETALLE] @CodDetalleOT, @CodProveedor, @CodTipoServicio, @DetalleTrabajo,
					@CodObjeto, @CantInventario, @CodOrden, @TiempoTrabajo, @CostoRepuesto 
					@CostoServicio, @CostoDetalle, @RepuestoPropio, @Adelanto";

                SqlParameter CodDetalleOT = new SqlParameter("@CodDetalleOT", ordentrabajo.IdOrdenDetalle);
                SqlParameter CodProveedor = new SqlParameter("@CodProveedor", ordentrabajo.CodProveedorOrdenDetalle);
                SqlParameter CodTipoServicio = new SqlParameter("@CodTipoServicio", ordentrabajo.CodTipoServicioOrdenDetalle);
                SqlParameter DetalleTrabajo = new SqlParameter("@DetalleTrabajo", ordentrabajo.DetalleOrdenDetalle);
                SqlParameter CodObjeto = new SqlParameter("@CodObjeto", ordentrabajo.CantInventarioEncabezadoOrdenDetalle);
                SqlParameter CantInventario = new SqlParameter("@CantInventario", ordentrabajo.CantInventarioEncabezadoOrdenDetalle);
                SqlParameter CodOrden = new SqlParameter("@CodOrden", ordentrabajo.CodOrdenEncabezadoOrdenDetalle);
                SqlParameter TiempoTrabajo = new SqlParameter("@TiempoTrabajo", ordentrabajo.TiempoTrabajoOrdenDetalle);
                SqlParameter CostoRepuesto = new SqlParameter("@CostoRepuesto", ordentrabajo.CostoRepuestoOrdenDetalle);
                SqlParameter CostoServicio = new SqlParameter("@CostoServicio", ordentrabajo.CostoServicioOrdenDetalle);
                SqlParameter CostoDetalle = new SqlParameter("@CostoDetalle", ordentrabajo.CostoDetalleOrdenDetalle);
                SqlParameter RepuestoPropio = new SqlParameter("@RepuestoPropio", ordentrabajo.RepuestoPropioOrdenDetalle);
                SqlParameter Adelanto = new SqlParameter("@Adelanto", ordentrabajo.AdelantoOrdenDetalle);

                SqlCommand command = new SqlCommand(Query, conectar);

                command.Parameters.Add(CodDetalleOT);
                command.Parameters.Add(CodProveedor);
                command.Parameters.Add(CodTipoServicio);
                command.Parameters.Add(DetalleTrabajo);
                command.Parameters.Add(CodObjeto);
                command.Parameters.Add(CantInventario);
                command.Parameters.Add(CodOrden);
                command.Parameters.Add(TiempoTrabajo);
                command.Parameters.Add(CostoRepuesto);
                command.Parameters.Add(CostoServicio);
                command.Parameters.Add(CostoDetalle);
                command.Parameters.Add(RepuestoPropio);
                command.Parameters.Add(Adelanto);

                command.ExecuteNonQuery();

                ordentrabajo.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                ordentrabajo.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return ordentrabajo.bBandera;
        }
        #endregion

        #region Read OrdenTrabajoDetalle
        public DataTable readOrdenTrabajoDetalleBLL()
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar())
                {

                    Query = @"[dbo].[SP_ACTUALIZAR_OTDETALLE]";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query, conectar);
                    ordenTrabajoDal.dtViewOrdenDetalle = new DataTable();
                    sqlAdapter.Fill(ordenTrabajoDal.dtViewOrdenDetalle);

                    //Console.WriteLine("Agregado");
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return ordenTrabajoDal.dtViewOrdenDetalle;
        }
        #endregion

        #region Update OrdenTrabajoDetalle
        public Boolean updateOrdenTrabajoDetalleBLL(clsOrdenTrabajoDAL ordentrabajo)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_MODIFICAR_OTDETALLE]  @CodDetalleOT, @CodProveedor, @CodTipoServicio, @DetalleTrabajo,
					@CodObjeto, @CantInventario, @CodOrden, @TiempoTrabajo, @CostoRepuesto 
					@CostoServicio, @CostoDetalle, @RepuestoPropio, @Adelanto";

                SqlParameter CodDetalleOT = new SqlParameter("@CodDetalleOT", ordentrabajo.IdOrdenDetalle);
                SqlParameter CodProveedor = new SqlParameter("@CodProveedor", ordentrabajo.CodProveedorOrdenDetalle);
                SqlParameter CodTipoServicio = new SqlParameter("@CodTipoServicio", ordentrabajo.CodTipoServicioOrdenDetalle);
                SqlParameter DetalleTrabajo = new SqlParameter("@DetalleTrabajo", ordentrabajo.DetalleOrdenDetalle);
                SqlParameter CodObjeto = new SqlParameter("@CodObjeto", ordentrabajo.CantInventarioEncabezadoOrdenDetalle);
                SqlParameter CantInventario = new SqlParameter("@CantInventario", ordentrabajo.CantInventarioEncabezadoOrdenDetalle);
                SqlParameter CodOrden = new SqlParameter("@CodOrden", ordentrabajo.CodOrdenEncabezadoOrdenDetalle);
                SqlParameter TiempoTrabajo = new SqlParameter("@TiempoTrabajo", ordentrabajo.TiempoTrabajoOrdenDetalle);
                SqlParameter CostoRepuesto = new SqlParameter("@CostoRepuesto", ordentrabajo.CostoRepuestoOrdenDetalle);
                SqlParameter CostoServicio = new SqlParameter("@CostoServicio", ordentrabajo.CostoServicioOrdenDetalle);
                SqlParameter CostoDetalle = new SqlParameter("@CostoDetalle", ordentrabajo.CostoDetalleOrdenDetalle);
                SqlParameter RepuestoPropio = new SqlParameter("@RepuestoPropio", ordentrabajo.RepuestoPropioOrdenDetalle);
                SqlParameter Adelanto = new SqlParameter("@Adelanto", ordentrabajo.AdelantoOrdenDetalle);

                SqlCommand command = new SqlCommand(Query, conectar);

                command.Parameters.Add(CodDetalleOT);
                command.Parameters.Add(CodProveedor);
                command.Parameters.Add(CodTipoServicio);
                command.Parameters.Add(DetalleTrabajo);
                command.Parameters.Add(CodObjeto);
                command.Parameters.Add(CantInventario);
                command.Parameters.Add(CodOrden);
                command.Parameters.Add(TiempoTrabajo);
                command.Parameters.Add(CostoRepuesto);
                command.Parameters.Add(CostoServicio);
                command.Parameters.Add(CostoDetalle);
                command.Parameters.Add(RepuestoPropio);
                command.Parameters.Add(Adelanto);

                command.ExecuteNonQuery();

                ordentrabajo.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                ordentrabajo.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return ordentrabajo.bBandera;
        }
        #endregion

        #region Delete OrdenTrabajoDetalle
        public Boolean deleteOrdenTrabajoDetalleBLL(clsOrdenTrabajoDAL ordentrabajo)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_ELIMINAR_OTRABAJO] @CodDetalleOT";

                SqlParameter CodDetalleOT = new SqlParameter("@CodDetalleOT", ordentrabajo.IdOrdenDetalle);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodDetalleOT);
                command.ExecuteNonQuery();

                ordentrabajo.bBandera = true;
                Console.WriteLine("Eliminado");
            }
            catch (Exception)
            {
                ordentrabajo.bBandera = false;
                Console.WriteLine("No Eliminado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return ordentrabajo.bBandera;
        }
        #endregion


        #endregion


        #endregion

        #region Facturacion

        #region Facturacion Encabezado

        #region Create Facturacion Encabezado
        public Boolean createFacturaEncabezadoBLL(clsFacturacionDAL facturacion)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_FENCABEZADO] @CodFacturaEncabezado, @Fechafactura, @CodColaborador, @TotalFacturaEncabezado, @CodSucursal, @CodFisico, @MetodoPago, @TasaCero, @CodOrden";

                SqlParameter CodFacturaEncabezado = new SqlParameter("@CodFacturaEncabezado", facturacion.IdFacturaEncabezado);
                SqlParameter Fechafactura = new SqlParameter("@Fechafactura", facturacion.FechafacturaFacturaEncabezado);
                SqlParameter CodColaborador = new SqlParameter("@CodColaborador", facturacion.IdColaboradorFacturaEncabezado);
                SqlParameter TotalFacturaEncabezado = new SqlParameter("@TotalFacturaEncabezado", facturacion.TotalFacturaEncabezado);
                SqlParameter CodSucursal = new SqlParameter("@CodSucursal", facturacion.IdSucursalFacturaEncabezado);
                SqlParameter CodFisico = new SqlParameter("@CodFisico", facturacion.IdClienteFisicoFacturaEncabezado);
                SqlParameter MetodoPago = new SqlParameter("@MetodoPago", facturacion.MetodoPagoFacturaEncabezado);
                SqlParameter TasaCero = new SqlParameter("@TasaCero", facturacion.TasaCeroFacturaEncabezado);
                SqlParameter CodOrden = new SqlParameter("@CodOrden", facturacion.IdOrdenFacturaEncabezado);

                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodFacturaEncabezado);
                command.Parameters.Add(Fechafactura);
                command.Parameters.Add(CodColaborador);
                command.Parameters.Add(TotalFacturaEncabezado);
                command.Parameters.Add(CodSucursal);
                command.Parameters.Add(CodFisico);
                command.Parameters.Add(MetodoPago);
                command.Parameters.Add(TasaCero);
                command.Parameters.Add(CodOrden);
                command.ExecuteNonQuery();

                facturacion.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                facturacion.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return facturacion.bBandera;
        }
        #endregion

        #region Read Facturacion Encabezado
        public DataTable readFacturaEncabezadoBLL()
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar())
                {

                    Query = @"[dbo].[SP_ACTUALIZAR_FENCABEZADO]";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query, conectar);
                    facturacionDal.dtViewFacturaEncabezado = new DataTable();
                    sqlAdapter.Fill(facturacionDal.dtViewFacturaEncabezado);

                    //Console.WriteLine("Agregado");
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return facturacionDal.dtViewFacturaEncabezado;
        }
        #endregion

        #region Update Facturacion Encabezado
        public Boolean updateFacturaEncabezadoBLL(clsFacturacionDAL facturacion)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_MODIFICAR_FENCABEZADO] @CodFacturaEncabezado, @Fechafactura, @CodColaborador, @TotalFacturaEncabezado, @CodSucursal, @CodFisico, @MetodoPago, @TasaCero, @CodOrden";

                SqlParameter CodFacturaEncabezado = new SqlParameter("@CodFacturaEncabezado", facturacion.IdFacturaEncabezado);
                SqlParameter Fechafactura = new SqlParameter("@Fechafactura", facturacion.FechafacturaFacturaEncabezado);
                SqlParameter CodColaborador = new SqlParameter("@CodColaborador", facturacion.IdColaboradorFacturaEncabezado);
                SqlParameter TotalFacturaEncabezado = new SqlParameter("@TotalFacturaEncabezado", facturacion.TotalFacturaEncabezado);
                SqlParameter CodSucursal = new SqlParameter("@CodSucursal", facturacion.IdSucursalFacturaEncabezado);
                SqlParameter CodFisico = new SqlParameter("@CodFisico", facturacion.IdClienteFisicoFacturaEncabezado);
                SqlParameter MetodoPago = new SqlParameter("@MetodoPago", facturacion.MetodoPagoFacturaEncabezado);
                SqlParameter TasaCero = new SqlParameter("@TasaCero", facturacion.TasaCeroFacturaEncabezado);
                SqlParameter CodOrden = new SqlParameter("@CodOrden", facturacion.IdOrdenFacturaEncabezado);

                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodFacturaEncabezado);
                command.Parameters.Add(Fechafactura);
                command.Parameters.Add(CodColaborador);
                command.Parameters.Add(TotalFacturaEncabezado);
                command.Parameters.Add(CodSucursal);
                command.Parameters.Add(CodFisico);
                command.Parameters.Add(MetodoPago);
                command.Parameters.Add(TasaCero);
                command.Parameters.Add(CodOrden);
                command.ExecuteNonQuery();

                facturacion.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                facturacion.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return facturacion.bBandera;
        }
        #endregion

        #region Delete Facturacion Encabezado
        public Boolean deleteFacturaEncabezadoBLL(clsFacturacionDAL facturacion)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_ELIMINAR_FENCABEZADO] @CodFacturaEncabezado";

                SqlParameter CodFacturaEncabezado = new SqlParameter("@CodFacturaEncabezado", facturacion.IdFacturaEncabezado);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodFacturaEncabezado);
                command.ExecuteNonQuery();

                facturacion.bBandera = true;
                Console.WriteLine("Eliminado");
            }
            catch (Exception)
            {
                facturacion.bBandera = false;
                Console.WriteLine("No Eliminado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return facturacion.bBandera;
        }
        #endregion

        #endregion

        #region Facturacion Detalle

        #region Create Facturacion Detalle
        public Boolean createFacturaDetalleBLL(clsFacturacionDAL facturacion)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_FDETALLE]
				@CodFacturaDetalle, @Detalle, @CantidadDetalle, @CostoDetalle, 
				@CodOrden, @AdelantoProveedor, @Impuesto, @CodFacturaEncabezado,
				@CodTipoServicio, @CodInventario";

                SqlParameter CodFacturaDetalle = new SqlParameter("@CodFacturaDetalle", facturacion.IdFacturaDetalle);
                SqlParameter Detalle = new SqlParameter("@Detalle", facturacion.DetaelleFacturaDetalle);
                SqlParameter CantidadDetalle = new SqlParameter("@CantidadDetalle", facturacion.CantidadFacturaDetalle);
                SqlParameter CostoDetalle = new SqlParameter("@CostoDetalle", facturacion.CostoFacturaDetalle);
                SqlParameter CodOrden = new SqlParameter("@CodOrden", facturacion.IdOrdenFacturaDetalle);
                SqlParameter AdelantoProveedor = new SqlParameter("@AdelantoProveedor", facturacion.AdelantoProveedorFacturaDetalle);
                SqlParameter Impuesto = new SqlParameter("@Impuesto", facturacion.ImpuestoFacturaDetalle);
                SqlParameter CodFacturaEncabezado = new SqlParameter("@CodFacturaEncabezado", facturacion.CostoFacturaDetalle);
                SqlParameter CodTipoServicio = new SqlParameter("@CodTipoServicio", facturacion.IdTipoServicioFacturaDetalle);
                SqlParameter CodInventario = new SqlParameter("@CodInventario", facturacion.IdInventarioFacturaDetalle);

                SqlCommand command = new SqlCommand(Query, conectar);

                command.Parameters.Add(CodFacturaDetalle);
                command.Parameters.Add(Detalle);
                command.Parameters.Add(CantidadDetalle);
                command.Parameters.Add(CostoDetalle);
                command.Parameters.Add(CodOrden);
                command.Parameters.Add(AdelantoProveedor);
                command.Parameters.Add(Impuesto);
                command.Parameters.Add(CodFacturaEncabezado);
                command.Parameters.Add(CodTipoServicio);
                command.Parameters.Add(CodInventario);

                command.ExecuteNonQuery();

                facturacion.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                facturacion.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return facturacion.bBandera;
        }
        #endregion

        #region Read Facturacion Detalle
        public DataTable readFacturaDetalleBLL()
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar())
                {

                    Query = @"[dbo].[SP_ACTUALIZAR_FDETALLE]";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query, conectar);
                    facturacionDal.dtViewFacturaDetalle = new DataTable();
                    sqlAdapter.Fill(facturacionDal.dtViewFacturaDetalle);

                    //Console.WriteLine("Agregado");re
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return facturacionDal.dtViewFacturaDetalle;
        }
        #endregion

        #region Update Facturacion Detalle
        public Boolean updateFacturaDetalleBLL(clsFacturacionDAL facturacion)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_MODIFICAR_FDETALLE]
				@CodFacturaDetalle, @Detalle, @CantidadDetalle, @CostoDetalle, 
				@CodOrden, @AdelantoProveedor, @Impuesto, @CodFacturaEncabezado,
				@CodTipoServicio, @CodInventario";

                SqlParameter CodFacturaDetalle = new SqlParameter("@CodFacturaDetalle", facturacion.IdFacturaDetalle);
                SqlParameter Detalle = new SqlParameter("@Detalle", facturacion.DetaelleFacturaDetalle);
                SqlParameter CantidadDetalle = new SqlParameter("@CantidadDetalle", facturacion.CantidadFacturaDetalle);
                SqlParameter CostoDetalle = new SqlParameter("@CostoDetalle", facturacion.CostoFacturaDetalle);
                SqlParameter CodOrden = new SqlParameter("@CodOrden", facturacion.IdOrdenFacturaDetalle);
                SqlParameter AdelantoProveedor = new SqlParameter("@AdelantoProveedor", facturacion.AdelantoProveedorFacturaDetalle);
                SqlParameter Impuesto = new SqlParameter("@Impuesto", facturacion.ImpuestoFacturaDetalle);
                SqlParameter CodFacturaEncabezado = new SqlParameter("@CodFacturaEncabezado", facturacion.CostoFacturaDetalle);
                SqlParameter CodTipoServicio = new SqlParameter("@CodTipoServicio", facturacion.IdTipoServicioFacturaDetalle);
                SqlParameter CodInventario = new SqlParameter("@CodInventario", facturacion.IdInventarioFacturaDetalle);

                SqlCommand command = new SqlCommand(Query, conectar);

                command.Parameters.Add(CodFacturaDetalle);
                command.Parameters.Add(Detalle);
                command.Parameters.Add(CantidadDetalle);
                command.Parameters.Add(CostoDetalle);
                command.Parameters.Add(CodOrden);
                command.Parameters.Add(AdelantoProveedor);
                command.Parameters.Add(Impuesto);
                command.Parameters.Add(CodFacturaEncabezado);
                command.Parameters.Add(CodTipoServicio);
                command.Parameters.Add(CodInventario);

                command.ExecuteNonQuery();

                facturacion.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                facturacion.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return facturacion.bBandera;
        }
        #endregion

        #region Delete Facturacion Detalle
        public Boolean deleteFacturaDetalleBLL(clsFacturacionDAL facturacion)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_ELIMINAR_FDETALLE] @CodFacturaDetalle";

                SqlParameter CodFacturaDetalle = new SqlParameter("@CodFacturaDetalle", facturacion.IdFacturaDetalle);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodFacturaDetalle);
                command.ExecuteNonQuery();

                facturacion.bBandera = true;
                Console.WriteLine("Eliminado");
            }
            catch (Exception)
            {
                facturacion.bBandera = false;
                Console.WriteLine("No Eliminado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return facturacion.bBandera;
        }
        #endregion

        #endregion

        #endregion

        #region Agenda

        #region Create Agenda
        public Boolean createAgendaBLL(clsAgendaDAL agenda)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_AGENDA]
				@CodCita, @CodPlaca, @CodColaborador, @TipoCita, 
				@TiempoInicio, @DuracionAprox, @CodOrden, @MotivoCita, @TipoServicio";

                SqlParameter IDAgenda = new SqlParameter("@CodCita", agenda.iIdAgenda);
                SqlParameter Placa = new SqlParameter("@CodPlaca", agenda.sPlaca);
                SqlParameter IDColaborador = new SqlParameter("@CodColaborador", agenda.iCodColaboradorAgenda);
                SqlParameter TipoCita = new SqlParameter("@TipoCita", agenda.bTipoAgenda);
                SqlParameter TiempoInicio = new SqlParameter("@TiempoInicio", agenda.dTiempoInicioAgenda);
                SqlParameter DuracionAprox = new SqlParameter("@DuracionAprox", agenda.sDuracionAproxAgenda);
                SqlParameter IDOrdenAgenda = new SqlParameter("@CodOrden", agenda.iCodOrdenAgenda);
                SqlParameter MotivoAgenda = new SqlParameter("@MotivoCita", agenda.sMotivoAgenda);
                SqlParameter TipoServicioAgenda = new SqlParameter("@TipoServicio", agenda.iTipoServicioAgenda);


                SqlCommand command = new SqlCommand(Query, conectar);

                command.Parameters.Add(IDAgenda);
                command.Parameters.Add(Placa);
                command.Parameters.Add(IDColaborador);
                command.Parameters.Add(TipoCita);
                command.Parameters.Add(TiempoInicio);
                command.Parameters.Add(DuracionAprox);
                command.Parameters.Add(IDOrdenAgenda);
                command.Parameters.Add(MotivoAgenda);
                command.Parameters.Add(TipoServicioAgenda);

                command.ExecuteNonQuery();

                agenda.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                agenda.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return agenda.bBandera;
        }
        #endregion

        #region Read Agenda
        public DataTable readAgendaBLL()
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar())
                {

                    Query = @"[dbo].[SP_ACTUALIZAR_AGENDA]";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query, conectar);
                    agendaDal.dtViewAgenda = new DataTable();
                    sqlAdapter.Fill(agendaDal.dtViewAgenda);

                    //Console.WriteLine("Agregado");
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return agendaDal.dtViewAgenda;
        }
        #endregion

        #region Update Agenda
        public Boolean updateAgendaBLL(clsAgendaDAL agenda)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_AGENDA]
				@CodCita, @CodPlaca, @CodColaborador, @TipoCita, 
				@TiempoInicio, @DuracionAprox, @CodOrden, @MotivoCita, @TipoServicio";

                SqlParameter IDAgenda = new SqlParameter("@CodCita", agenda.iIdAgenda);
                SqlParameter Placa = new SqlParameter("@CodPlaca", agenda.sPlaca);
                SqlParameter IDColaborador = new SqlParameter("@CodColaborador", agenda.iCodColaboradorAgenda);
                SqlParameter TipoCita = new SqlParameter("@TipoCita", agenda.bTipoAgenda);
                SqlParameter TiempoInicio = new SqlParameter("@TiempoInicio", agenda.dTiempoInicioAgenda);
                SqlParameter DuracionAprox = new SqlParameter("@DuracionAprox", agenda.sDuracionAproxAgenda);
                SqlParameter IDOrdenAgenda = new SqlParameter("@CodOrden", agenda.iCodOrdenAgenda);
                SqlParameter MotivoAgenda = new SqlParameter("@MotivoCita", agenda.sMotivoAgenda);
                SqlParameter TipoServicioAgenda = new SqlParameter("@TipoServicio", agenda.iTipoServicioAgenda);


                SqlCommand command = new SqlCommand(Query, conectar);

                command.Parameters.Add(IDAgenda);
                command.Parameters.Add(Placa);
                command.Parameters.Add(IDColaborador);
                command.Parameters.Add(TipoCita);
                command.Parameters.Add(TiempoInicio);
                command.Parameters.Add(DuracionAprox);
                command.Parameters.Add(IDOrdenAgenda);
                command.Parameters.Add(MotivoAgenda);
                command.Parameters.Add(TipoServicioAgenda);

                command.ExecuteNonQuery();

                agenda.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                agenda.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return agenda.bBandera;
        }
        #endregion

        #region Delete Agenda
        public Boolean deleteAgendaBLL(clsAgendaDAL agenda)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_ELIMINAR_AGENDA] @CodCita";

                SqlParameter IDAgenda = new SqlParameter("@CodCita", agenda.iIdAgenda);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(IDAgenda);
                command.ExecuteNonQuery();

                agenda.bBandera = true;
                Console.WriteLine("Eliminado");
            }
            catch (Exception)
            {
                agenda.bBandera = false;
                Console.WriteLine("No Eliminado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return agenda.bBandera;
        }
        #endregion

        #endregion

        #region Login

        #region Create Login
        public Boolean createUsuarioBLL(clsUsuarioDAL usuario)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_AGREGAR_USUARIO] @CodArea, @CodEmpelado, @NombreUsuario, @Usuario, @Contraseña";

                SqlParameter CodArea = new SqlParameter("@CodArea", usuario.sCodAreaUsuario);
                SqlParameter CodEmpelado = new SqlParameter("@CodEmpelado", usuario.sCodEmpleadoUsuario);
                SqlParameter NombreUsuario = new SqlParameter("@NombreUsuario", usuario.sNombreUsuario);
                SqlParameter Usuario = new SqlParameter("@Usuario", usuario.sUsuario);
                SqlParameter Contraseña = new SqlParameter("@Contraseña", usuario.sContrasena);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodArea);
                command.Parameters.Add(CodEmpelado);
                command.Parameters.Add(NombreUsuario);
                command.Parameters.Add(Usuario);
                command.Parameters.Add(Contraseña);
                command.ExecuteNonQuery();

                usuario.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                usuario.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return usuario.bBandera;
        }
        #endregion

        #region Read Login

        public DataTable readUsuarioBLL()
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar())
                {

                    Query = @"[dbo].[SP_ACTUALIZAR_USUARIO]";

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(Query, conectar);
                    usuarioDal.dtViewUsuario = new DataTable();
                    sqlAdapter.Fill(usuarioDal.dtViewUsuario);

                    //Console.WriteLine("Agregado");
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return usuarioDal.dtViewUsuario;
        }
        #endregion

        #region Update Login
        public Boolean updateUsuarioBLL(clsUsuarioDAL usuario)
        {

            clsConexion objConex = new clsConexion();

            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_MODIFICAR_USUARIO] @CodArea, @CodEmpelado, @NombreUsuario, @Usuario, @Contraseña";

                SqlParameter CodArea = new SqlParameter("@CodArea", usuario.sCodAreaUsuario);
                SqlParameter CodEmpelado = new SqlParameter("@CodEmpelado", usuario.sCodEmpleadoUsuario);
                SqlParameter NombreUsuario = new SqlParameter("@NombreUsuario", usuario.sNombreUsuario);
                SqlParameter Usuario = new SqlParameter("@Usuario", usuario.sUsuario);
                SqlParameter Contraseña = new SqlParameter("@Contraseña", usuario.sContrasena);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodArea);
                command.Parameters.Add(CodEmpelado);
                command.Parameters.Add(NombreUsuario);
                command.Parameters.Add(Usuario);
                command.Parameters.Add(Contraseña);
                command.ExecuteNonQuery();

                usuario.bBandera = true;
                Console.WriteLine("Agregado");
            }
            catch (Exception)
            {
                usuario.bBandera = false;
                Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return usuario.bBandera;
        }
        #endregion

        #region Delete Login
        public Boolean deleteUsuarioBLL(clsUsuarioDAL usuario)
        {
            clsConexion objConex = new clsConexion();
            try
            {

                if (objConex.mConectar()) { }

                Query = @"Execute [dbo].[SP_ELIMINAR_USUARIO] @CodEmpleado";

                SqlParameter CodUsuario = new SqlParameter("@CodEmpleado", usuario.sCodEmpleadoUsuario);
                SqlCommand command = new SqlCommand(Query, conectar);
                command.Parameters.Add(CodUsuario);
                command.ExecuteNonQuery();

                usuario.bBandera = true;
                Console.WriteLine("Eliminado");
            }
            catch (Exception)
            {
                usuario.bBandera = false;
                Console.WriteLine("No Eliminado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return usuario.bBandera;
        }
        #endregion

        #region Filter Login
        public DataTable filtrarLoginBLL(clsLoginDAL login)
        {
            clsConexion objConex = new clsConexion();
            DataTable dt = new DataTable();
            try
            {

                if (objConex.mConectar())
                {

                    Query = @"SP_LOGUEO";

                    SqlCommand cmd = new SqlCommand(Query, conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario", login.sUsuario);
                    cmd.Parameters.AddWithValue("@clave", login.sClave);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dt);

                }
            }
            catch (Exception)
            {

                //Console.WriteLine("No Agregado");
                throw;
            }
            finally
            {
                Query = string.Empty;
                objConex.mDesconectar();

            }
            return dt;
        }
        #endregion

        #endregion

    }

}