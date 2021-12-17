using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_ProyectoFinal;
using BLL_ProyectoFinal;
using System.Globalization;

namespace PL_ProyectoFinal.Pantallas.Principal
{
    public partial class frmPrincipal : Form
    {
        //public clsTipoServiciosBLL TipoServiciosBLL;
        DAL_ProyectoFinal.clsTipoServicioDAL TipoServicioDAL = new DAL_ProyectoFinal.clsTipoServicioDAL();
        DAL_ProyectoFinal.clsSucursalDAL SucursalDAL = new DAL_ProyectoFinal.clsSucursalDAL();
        DAL_ProyectoFinal.clsProveedorDAL ProveedorDAL = new DAL_ProyectoFinal.clsProveedorDAL();
        DAL_ProyectoFinal.clsVehiculoDAL VehiculoDAL = new DAL_ProyectoFinal.clsVehiculoDAL();
        DAL_ProyectoFinal.clsModeloDAL ModeloDAL = new DAL_ProyectoFinal.clsModeloDAL();
        DAL_ProyectoFinal.clsMarcaDAL MarcaDAL = new DAL_ProyectoFinal.clsMarcaDAL();
        DAL_ProyectoFinal.clsColaboradorDAL ColaboradorDAL = new DAL_ProyectoFinal.clsColaboradorDAL();
        DAL_ProyectoFinal.clsClienteDAL ClienteDAL = new DAL_ProyectoFinal.clsClienteDAL();
        DAL_ProyectoFinal.clsTelefonoDAL TelefonoDAL = new DAL_ProyectoFinal.clsTelefonoDAL();
        DAL_ProyectoFinal.clsInventarioDAL InventarioDAL = new DAL_ProyectoFinal.clsInventarioDAL();
        DAL_ProyectoFinal.clsOrdenTrabajoDAL OrdenTrabajoDAL = new DAL_ProyectoFinal.clsOrdenTrabajoDAL();
        DAL_ProyectoFinal.clsFacturacionDAL FacturacionDAL = new DAL_ProyectoFinal.clsFacturacionDAL();
        DAL_ProyectoFinal.clsAgendaDAL AgendaDAL = new DAL_ProyectoFinal.clsAgendaDAL();
        DAL_ProyectoFinal.clsUsuarioDAL UsuarioDAL = new DAL_ProyectoFinal.clsUsuarioDAL();
        
        clsTipoServiciosBLL TipoServicioBLL = new clsTipoServiciosBLL();
        clsSucursalBLL SucursalBLL = new clsSucursalBLL();
        clsProveedorBLL ProveedorBLL = new clsProveedorBLL();
        clsVehiculoBLL VehiculoBLL = new clsVehiculoBLL();
        clsModeloBLL ModeloBLL = new clsModeloBLL();
        clsMarcaBLL MarcaBLL = new clsMarcaBLL();
        clsColaboradorBLL ColaboradorBLL = new clsColaboradorBLL();
        clsClienteBLL ClienteBLL = new clsClienteBLL();
        clsTelefonoBLL TelefonoBLL = new clsTelefonoBLL();
        clsInventarioBLL InventarioBLL = new clsInventarioBLL();
        clsOrdenTrabajoBLL OrdenTrabajoBLL = new clsOrdenTrabajoBLL();
        clsFacturacionBLL FacturacionBLL = new clsFacturacionBLL();
        clsAgendaBLL AgendaBLL = new clsAgendaBLL();
        clsLoginBLL UsuarioBLL = new clsLoginBLL();

        private clsConexion clsConexion;

        public frmPrincipal()
        {
            InitializeComponent();
            //TipoServiciosBLL = new clsTipoServiciosBLL();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            cargarDataGridViewAgenda();
            var colorFondo = Color.FromArgb(200, 54, 54, 54);
            tsHeader.BackColor = colorFondo;
            pViewAgenda.BackColor = colorFondo;
            pViewFacturar.BackColor = colorFondo;
            pViewOrdenTrabajo.BackColor = colorFondo;
            pViewInventario.BackColor = colorFondo;
            pViewCliente.BackColor = colorFondo;
            pViewColaborador.BackColor = colorFondo;
            pViewMarca.BackColor = colorFondo;
            pViewModelo.BackColor = colorFondo;
            pViewVehiculo.BackColor = colorFondo;
            pViewProveedor.BackColor = colorFondo;
            pViewSucursal.BackColor = colorFondo;
            pViewTipoServicio.BackColor = colorFondo;

            pNewModelo.BackColor = colorFondo;
            pEditModelo.BackColor = colorFondo;
            pNewMarca.BackColor = colorFondo;
            pEditMarca.BackColor = colorFondo;
            pNewVehiculo.BackColor = colorFondo;
            pEditVehiculo.BackColor = colorFondo;
            pNewProveedor.BackColor = colorFondo;
            pEditProveedor.BackColor = colorFondo;
            pNewSucursal.BackColor = colorFondo;
            pEditSucursal.BackColor = colorFondo;
            pNewTipoServicio.BackColor = colorFondo;
            pEditTipoServicio.BackColor = colorFondo;
            pNewColaborador.BackColor = colorFondo;
            pEditColaborador.BackColor = colorFondo;
            pNewClienteFisico.BackColor = colorFondo;
            pEditClienteFisico.BackColor = colorFondo;
            pNewClienteJuridico.BackColor = colorFondo;
            pEditClienteJuridico.BackColor = colorFondo;
            pNewTelefono.BackColor = colorFondo;
            pEditTelefono.BackColor = colorFondo;
            pNewInventario.BackColor = colorFondo;
            pEditInventario.BackColor = colorFondo;

            var colorGris = Color.FromArgb(97,97,97);
            tsViewClientesMenu.BackColor = colorGris;
            tsViewClienteFisico.BackColor = colorGris;
            tsViewClienteJuridico.BackColor = colorGris;
            tsViewTelefono.BackColor = colorGris;


            #region Permisos
            //Administradores
            if (Login.frmLogin.sArea == "A0001")
            {
                //lblCargo.Text = "Aministrador";
            }
            //Secretarias
            else if (Login.frmLogin.sArea == "A0002")
            {
                //Botones
                tsbFacturacion.Visible = false;
                tsbUsuario.Visible = false;

                //Separar clientes, facturas, y teléfonos

                //Funcionalidades
                tsbViewEliminarOrdenTrabajo.Enabled = false;
                tsbViewEliminarInventario.Enabled = false;
                tsbViewEliminarClienteFisico.Enabled = false;
                tsbViewEliminarColaborador.Enabled = false;
                tsbViewEliminarProveedor.Enabled = false;
                //Eliminar facturas
                //eliminar clientes

                tsbViewAgregarSucursal.Enabled = false;
                tsbViewEliminarSucursal.Enabled = false;

                //Lineas
                tssMod2.Visible = false;


                //lblCargo.Text = "Secretaria";
            }
            //Mecánicos
            else if (Login.frmLogin.sArea == "A0003")
            {
                tsbCliente.Visible = false;
                tsbVehiculos.Visible = false;
                tsbModelos.Visible = false;
                tsbMarcas.Visible = false;
                tsbModelos.Visible = false;
                tsbColaboradores.Visible = false;
                tsbOrdenTrabajo.Visible = true;
                tsbAgenda.Visible = true;
                tsbSucursales.Visible = false;
                tsbFacturacion.Visible = false;
                tsbProveedores.Visible = false;
                tsbTiposServicio.Visible = false;
                tsbInventario.Visible = false;
                tsbUsuario.Visible = false;

                //Separar clientes, facturas, y teléfonos

                //Funcionalidades
                tsbViewAgregarAgenda.Enabled = false;
                tsbViewModificarAgenda.Enabled = false;
                tsbViewEliminarAgenda.Enabled = false;

                //Lineas
                tssMod2.Visible = false;
                tssMod3.Visible = false;
                tssMod4.Visible = false;
                tssMod5.Visible = false;
                tssMod6.Visible = false;
                tsssMod7.Visible = false;
                tssMod8.Visible = false;
                tssMod9.Visible = false;
                tssMod10.Visible = false;
                tssMod11.Visible = false;


                //lblCargo.Text = "Mecánico";
            }
            #endregion

        }

        #region Menu Principal

        #region Menu 

        private void tsbAgenda_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewAgenda;
            cargarDataGridViewAgenda();
        }

        private void tsbFacturacion_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewFacturar;
            cargarDataGridViewFacturar();
        }

        private void tsbOrdenTrabajo_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewOrdenTrabajo;
            cargarDataGridViewOrdenTrabajo();
        }

        private void tsbInventario_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewInventario;
            cargarDataGridViewInventario();
        }

        private void tsbCliente_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewCliente;
            cargarDataGridViewClientes();
        }

        private void tsbColaboradores_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewColaborador;
            cargarDataGridViewColaborador();
        }

        private void tsbMarcas_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewMarca;
            cargarDataGridViewMarca();
        }

        private void tsbModelos_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewModelo;
            cargarDataGridViewModelo();
        }

        private void tsbVehiculos_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewVehiculo;
            cargarDataGridViewVehiculo();
        }

        private void tsbProveedores_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewProveedor;
            cargarDataGridViewProveedor();
        }

        private void tsbSucursales_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewSucursal;
            cargarDataGridViewSucursal();
        }

        private void tsbTiposServicio_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewTipoServicio;
            cargarDataGridViewTipoServicio();
        }
        private void tsbUsuario_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewUsuario;
            cargarDataGridViewUsuario();
        }

        #endregion

        #region SubMenus
        private void tsbViewClienteFisico_Click(object sender, EventArgs e)
        {
            tcCliente.SelectedTab = tpViewClienteFisico;
            cargarDataGridViewClientes();
        }

        private void tsbViewClienteJuridico_Click(object sender, EventArgs e)
        {
            tcCliente.SelectedTab = tpViewClienteJuridico;
            cargarDataGridViewClientes();
        }

        private void tsbViewTelefono_Click(object sender, EventArgs e)
        {
            tcCliente.SelectedTab = tpViewTelefono;
            cargarDataGridViewClientes();
            //cbNewCodClienteJuridicoTelefono.Visible = true;
            //lblNewCodClienteJuridicoTelefono.Visible = true;
            //cbNewCodClienteFisicoTelefono.Visible = true;
            //lblNewCodClienteFisicoTelefono.Visible = true;
        }
        #endregion

        #region Agenda
        #region Agenda View
        private void tsbViewAgregarAgenda_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpNewAgenda;
        }

        private void tsbViewModificarAgenda_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpEditAgenda;
        }

        private void tsbViewEliminarAgenda_Click(object sender, EventArgs e)
        {

        }

        private void tsbViewActualizarAgenda_Click(object sender, EventArgs e)
        {
            cargarDataGridViewAgenda();
        }

        private void txtViewBuscarAgenda_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dgvAgenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        #region Agenda New

        #endregion

        #region Agenda Edit

        #endregion

        #region Agenda Metodos
        public void cargarComboBoxAgenda() 
        {
            cmbPlaca
        
        
        }
        public void cargarDataGridViewAgenda() 
        {
            dgvAgenda.DataSource = AgendaBLL.readAgendaBLL();
        }
        #endregion

        #endregion

        #region Facturar
        #region Facturar View
        private void tsbViewAgregarFacturar_Click(object sender, EventArgs e)
        {

        }

        private void tsbViewModificarFacturar_Click(object sender, EventArgs e)
        {

        }

        private void tsbViewEliminarFacturar_Click(object sender, EventArgs e)
        {

        }

        private void tsbViewActualizarFacturar_Click(object sender, EventArgs e)
        {
            cargarDataGridViewFacturar();
        }

        private void dgvFacturar_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtViewBuscarFacturar_KeyUp(object sender, KeyEventArgs e)
        {

        }
        #endregion

        #region Facturar New

        #endregion

        #region Facturar Edit

        #endregion

        #region Facturar Metodos
        public void cargarDataGridViewFacturar()
        {
            dgvFacturar.DataSource = FacturacionBLL.readFacturaEncabezadoBLL();
        }
        #endregion

        #endregion

        #region OrdenTrabajo

        #region OrdenTrabajo View
        private void tsbViewAgregarOrdenTrabajo_Click(object sender, EventArgs e)
        {

        }

        private void tsbViewModificarOrdenTrabajo_Click(object sender, EventArgs e)
        {

        }

        private void tsbViewEliminarOrdenTrabajo_Click(object sender, EventArgs e)
        {

        }

        private void tsbViewActualizarOrdenTrabajo_Click(object sender, EventArgs e)
        {
            cargarDataGridViewOrdenTrabajo();
        }


        #endregion

        #region OrdenTrabajo New

        #endregion

        #region OrdenTrabajo Edit

        #endregion

        #region OrdenTrabajo Metodos
        public void cargarDataGridViewOrdenTrabajo()
        {
            dgvOrdenTrabajo.DataSource = OrdenTrabajoBLL.readOrdenTrabajoDetalleBLL();
        }
        #endregion

        #endregion

        #region Inventario

        #region Inventario View
        private void tsbViewAgregarInventario_Click(object sender, EventArgs e)
        {
            cargarComboBoxInventario();
            tcPrincipal.SelectedTab = tpNewIventario;
        }

        private void tsbViewModificarInventario_Click(object sender, EventArgs e)
        {
            cargarComboBoxInventario();
            cargarCamposEditInventario();
            tcPrincipal.SelectedTab = tpEditIventario;
        }

        private void tsbViewEliminarInventario_Click(object sender, EventArgs e)
        {
            InventarioBLL.deleteInventarioBLL(InventarioDAL);
            cargarDataGridViewInventario();
            if (InventarioDAL.bBandera == true)
            {
                MessageBox.Show("Fue Eliminado");
            }
            else { MessageBox.Show("No fue Eliminado"); }
            limpiarMemoriaVehiculo();
        }

        private void tsbViewActualizarInventario_Click(object sender, EventArgs e)
        {
            cargarDataGridViewInventario();
        }

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvInventario.Rows[e.RowIndex];
                InventarioDAL.sIdObjetoInventario      = row.Cells[0].Value.ToString();
                InventarioDAL.sNombreObjetoInventario   = row.Cells[1].Value.ToString();
                InventarioDAL.iCantidadObjetoInventario  = Int32.Parse(row.Cells[2].Value.ToString());
                InventarioDAL.iCodSucursalInventario  = Int32.Parse(row.Cells[3].Value.ToString());
            }
        }

        private void txtViewBuscarInventario_KeyUp(object sender, KeyEventArgs e)
        {
            filtroDataGridViewInventario();
        }
        #endregion

        #region Inventario New
        private void tsbNewGuardarInventario_Click(object sender, EventArgs e)
        {
            InventarioDAL.sIdObjetoInventario = txtCodProducto.Text;
            InventarioDAL.sNombreObjetoInventario = txtNombreProducto.Text;
            InventarioDAL.iCantidadObjetoInventario =  Int32.Parse(txtNewCantidadInventario.Text);
            InventarioDAL.iCodSucursalInventario = (int)cbNewCodigoSucursalInventario.SelectedValue;
            InventarioBLL.createInventarioBLL(InventarioDAL);
            tcPrincipal.SelectedTab = tpViewInventario;
            cargarDataGridViewInventario();
            if (InventarioDAL.bBandera == true)
            {
                MessageBox.Show("Fue Creado");
            }
            else { MessageBox.Show("No fue Creado"); }
            limpiarCamposNewInventario();
            limpiarMemoriaInventario();

        }

        private void tsbNewCancelarInventario_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewInventario;
            limpiarCamposNewInventario();
        }

        #endregion

        #region Inventario Edit
        private void tsbEditGuardarInventario_Click(object sender, EventArgs e)
        {
            InventarioDAL.sIdObjetoInventario = txtEditCodigoInventario.Text;
            InventarioDAL.sNombreObjetoInventario = txtEditNombreInventario.Text;
            InventarioDAL.iCantidadObjetoInventario = Int32.Parse(txtEditCantidadInventario.Text);
            InventarioDAL.iCodSucursalInventario = (int)cbEditCodigoSucursalInventario.SelectedValue;
            InventarioBLL.updateInventarioBLL(InventarioDAL);
            tcPrincipal.SelectedTab = tpViewInventario;
            cargarDataGridViewInventario();
            if (InventarioDAL.bBandera == true)
            {
                MessageBox.Show("Fue Actualizado");
            }
            else { MessageBox.Show("No fue Actualizado"); }
            limpiarCamposEditInventario();
            limpiarMemoriaInventario();
        }

        private void tsbEditCancelarInventario_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewInventario;
            limpiarCamposEditInventario();
        }
        #endregion

        #region Inventario Metodos
        public void cargarComboBoxInventario()
        {
            cbNewCodigoSucursalInventario.DataSource = SucursalBLL.readSucursalBLL();
            cbNewCodigoSucursalInventario.DisplayMember = "Ubicación de la Sucursal";
            cbNewCodigoSucursalInventario.ValueMember = "Código de la Sucursal";

            cbEditCodigoSucursalInventario.DataSource = SucursalBLL.readSucursalBLL();
            cbEditCodigoSucursalInventario.DisplayMember = "Ubicación de la Sucursal";
            cbEditCodigoSucursalInventario.ValueMember = "Código de la Sucursal";

        }
        public void cargarDataGridViewInventario()
        {
            dgvInventario.DataSource = InventarioBLL.readInventarioBLL();
        }
        public void filtroDataGridViewInventario()
        {
            if (txtViewBuscarInventario.Text != "")
            {
                DataView dv = InventarioBLL.readInventarioBLL().DefaultView;
                //MessageBox.Show("Header: "+ dgvVehiculo.Columns[1].Name);
                dv.RowFilter = string.Format("[{0}] like '%{1}%'", dgvInventario.Columns[1].Name, txtViewBuscarInventario.Text);
                dgvInventario.DataSource = dv.ToTable();
            }
            else
            {
                dgvInventario.DataSource = InventarioBLL.readInventarioBLL();
            }
        }
        public void limpiarCamposNewInventario()
        {
            txtCodProducto.Text = String.Empty;
            txtNombreProducto.Text = String.Empty;
            txtNewCantidadInventario.Text = String.Empty;
            cbNewCodigoSucursalInventario.Text = String.Empty;
        }
        public void limpiarCamposEditInventario()
        {
            txtEditCodigoInventario.Text = String.Empty;
            txtEditNombreInventario.Text = String.Empty;
            txtEditCantidadInventario.Text = String.Empty;
            cbEditCodigoSucursalInventario.Text = String.Empty;

        }
        public void limpiarMemoriaInventario()
        {
            InventarioDAL.sIdObjetoInventario = string.Empty;
            InventarioDAL.sNombreObjetoInventario = string.Empty;
            InventarioDAL.iCantidadObjetoInventario = 0;
            InventarioDAL.iCodSucursalInventario = 0;
            InventarioDAL.bBandera = false;
        }
        public void cargarCamposEditInventario()
        {
            txtEditCodigoInventario.Text = InventarioDAL.sIdObjetoInventario;
            txtEditNombreInventario.Text = InventarioDAL.sNombreObjetoInventario;
            txtEditCantidadInventario.Text = Convert.ToString(InventarioDAL.iCantidadObjetoInventario);
            cbEditCodigoSucursalInventario.SelectedValue = InventarioDAL.iCodSucursalInventario;

        }
            #endregion

            #endregion

        #region Cliente

            #region ClienteFisico View
            private void tsbViewAgregarClienteFisico_Click(object sender, EventArgs e)
        {
            tcCliente.SelectedTab = tpNewClienteFisico;
        }
        private void tsbViewVisualizarClienteFisico_Click(object sender, EventArgs e)
        {
            cargarCamposEditCliente();
            tcCliente.SelectedTab = tpEditClienteFisico;
        }

        private void tsbViewEliminarClienteFisico_Click(object sender, EventArgs e)
        {
            ClienteBLL.deleteClienteFisicoBLL(ClienteDAL);
            cargarDataGridViewClientes();
            if (ClienteDAL.bBandera == true)
            {
                MessageBox.Show("Fue Eliminado");
            }
            else { MessageBox.Show("No fue Eliminado"); }
            limpiarMemoriaCliente();
        }

        private void ttsbViewActualizarClienteFisico_Click(object sender, EventArgs e)
        {
            cargarDataGridViewClientes();
        }
        private void txtViewBuscarClienteFisico_KeyUp(object sender, KeyEventArgs e)
        {
            filtroDataGridViewCliente();
        }

        #endregion

        #region ClienteFisico New
        private void tsbNewGuardarClienteFisico_Click(object sender, EventArgs e)
        {
            ClienteDAL.sIdClienteFisico = txtNewCodigoClienteFisico.Text;
            ClienteDAL.sNombreClienteFisico = txtNewNombreClienteFisico.Text;
            ClienteDAL.sPrimerApellidoClienteFisico = txtNewPrimerApellidoClienteFisico.Text;
            ClienteDAL.sSegundoApellidoClienteFisico = txtNewSegundoApellidoClienteFisico.Text;
            ClienteDAL.sCorreoClienteFisico = txtNewCorreoClienteFisico.Text;
            ClienteDAL.sDireccionClienteFisico = txtNewDireccionClienteFisico.Text;
            ClienteBLL.createClienteFisicoBLL(ClienteDAL);
            tcCliente.SelectedTab = tpViewClienteFisico;
            cargarDataGridViewClientes();
            if (ClienteDAL.bBandera == true)
            {
                MessageBox.Show("Fue Creado");
            }
            else { MessageBox.Show("No fue Creado"); }
            limpiarCamposNewCliente();
            limpiarMemoriaCliente();

        }

        private void tsbNewCancelarClienteFisico_Click(object sender, EventArgs e)
        {
            tcCliente.SelectedTab = tpViewClienteFisico;
            limpiarCamposNewCliente();
        }
        #endregion

        #region ClienteFisico Edit
        private void btnEditModificarClienteFisico_Click(object sender, EventArgs e)
        {
            txtEditNombreClienteFisico.Enabled = true;
            txtEditPrimerApellidoClienteFisico.Enabled = true;
            txtEditSegundoApellidoClienteFisico.Enabled = true;
            txtEditCorreoClienteFisico.Enabled = true;
            txtEditDireccionClienteFisico.Enabled = true;
            btnEditGuardarClienteFisico.Visible = true;
            gbVisualizarClienteFisico.Text = "Modificar Cliente Fisico";
        }

        private void btnEditGuardarClienteFisico_Click(object sender, EventArgs e)
        {
            ClienteDAL.sIdClienteFisico = txtEditCodigoClienteFisico.Text;
            ClienteDAL.sNombreClienteFisico = txtEditNombreClienteFisico.Text;
            ClienteDAL.sPrimerApellidoClienteFisico = txtEditPrimerApellidoClienteFisico.Text;
            ClienteDAL.sSegundoApellidoClienteFisico = txtEditSegundoApellidoClienteFisico.Text;
            ClienteDAL.sCorreoClienteFisico = txtEditCorreoClienteFisico.Text;
            ClienteDAL.sDireccionClienteFisico = txtEditDireccionClienteFisico.Text;
            ClienteBLL.updateClienteFisicoBLL(ClienteDAL);
            cargarDataGridViewClientes();
            if (ClienteDAL.bBandera == true)
            {
                MessageBox.Show("Fue Actualizado");
            }
            else { MessageBox.Show("No fue Actualizado"); }

            limpiarMemoriaCliente();


            txtEditNombreClienteFisico.Enabled = false;
            txtEditPrimerApellidoClienteFisico.Enabled = false;
            txtEditSegundoApellidoClienteFisico.Enabled = false;
            txtEditCorreoClienteFisico.Enabled = false;
            txtEditDireccionClienteFisico.Enabled = false;
            btnEditGuardarClienteFisico.Visible = false;
            gbVisualizarClienteFisico.Text = "Visualizar Cliente Fisico";
        }
        
        private void btnEditAgregarClienteFisico_Click(object sender, EventArgs e)
        {
            //cargarComboBoxTelefono();
            //cbNewCodClienteFisicoTelefono.SelectedValue = ClienteDAL.sIdClienteFisico;
            //cbNewCodClienteJuridicoTelefono.Text = string.Empty;
            //cbNewCodClienteJuridicoTelefono.Visible = false;
            //lblNewCodClienteJuridicoTelefono.Visible = false;
            //tcCliente.SelectedTab = tpNewTelefono;
        }

        private void btnEditSalirClienteFisico_Click(object sender, EventArgs e)
        {
            limpiarCamposEditCliente();
            tcCliente.SelectedTab = tpViewClienteFisico;
            txtEditNombreClienteFisico.Enabled = false;
            txtEditPrimerApellidoClienteFisico.Enabled = false;
            txtEditSegundoApellidoClienteFisico.Enabled = false;
            txtEditCorreoClienteFisico.Enabled = false;
            txtEditDireccionClienteFisico.Enabled = false;
            btnEditGuardarClienteFisico.Visible = false;
            gbVisualizarClienteFisico.Text = "Visualizar Cliente Fisico";
        }
        #endregion

        #region ClienteJuridico View
        private void tsbViewAgregarClienteJuridico_Click(object sender, EventArgs e)
        {
            cargarComboBoxCliente();
            tcCliente.SelectedTab = tpNewClienteJuridico;
        }

        private void tsbViewModificarClienteJuridico_Click(object sender, EventArgs e)
        {
            cargarComboBoxCliente();
            cargarCamposEditCliente();
            tcCliente.SelectedTab = tpEditClienteJuridico;
        }

        private void tsbViewEliminarClienteJuridico_Click(object sender, EventArgs e)
        {
            ClienteBLL.deleteClienteJuridicoBLL(ClienteDAL);
            cargarDataGridViewClientes();
            if (ClienteDAL.bBandera == true)
            {
                MessageBox.Show("Fue Eliminado");
            }
            else { MessageBox.Show("No fue Eliminado"); }
            limpiarMemoriaCliente();
        }

        private void tsbViewActualizarClienteJuridico_Click(object sender, EventArgs e)
        {
            cargarDataGridViewClientes();
        }

        private void txtViewBuscarClienteJuridico_KeyUp(object sender, KeyEventArgs e)
        {
            filtroDataGridViewCliente();
        }
        #endregion

        #region ClienteJuridico New
        private void tsbNewGuardarClienteJuridico_Click(object sender, EventArgs e)
        {
            ClienteDAL.sIdClienteJuridico = txtNewCodigoClienteJuridico.Text;
            ClienteDAL.sNombreLegalClienteJuridico = txtNewNombreLegalClienteJuridico.Text;
            ClienteDAL.sNombreFantasiaClienteJuridico = txtNewNombreFantasiaClienteJuridico.Text;
            ClienteDAL.sNombreRepresentanteClienteJuridico = txtNewNombreRepresentanteClienteJuridico.Text;
            ClienteDAL.sCorreoClienteJuridico = txtNewCorreoClienteJuridico.Text;
            ClienteDAL.sTelefonoClienteJuridico = txtNewTelefonoClienteJuridico.Text;
            ClienteDAL.sDireccionClienteJuridico = txtNewDireccionClienteJuridico.Text;
            ClienteDAL.iCodClienteFisicoClienteJuridico = (int)cbNewCodClienteFisicoClienteJuridico.SelectedValue;
            ClienteBLL.createClienteJuridicoBLL(ClienteDAL);
            tcCliente.SelectedTab = tpViewClienteJuridico;
            cargarDataGridViewClientes();
            if (ClienteDAL.bBandera == true)
            {
                MessageBox.Show("Fue Actualizado");
            }
            else { MessageBox.Show("No fue Actualizado"); }
            limpiarCamposNewCliente();
            limpiarMemoriaCliente();

        }

        private void tsbNewCancelarClienteJuridico_Click(object sender, EventArgs e)
        {
            tcCliente.SelectedTab = tpViewClienteJuridico;
            limpiarCamposNewCliente();
        }
        #endregion

        #region ClienteJuridico Edit
        private void btnEditModificarClienteJuridico_Click(object sender, EventArgs e)
        {
            txtEditNombreLegalClienteJuridico.Enabled = true;
            txtEditNombreFantasiaClienteJuridico.Enabled = true;
            txtEditNombreRepresentanteClienteJuridico.Enabled = true;
            txtEditCorreoClienteJuridico.Enabled = true;
            txtEditTelefonoClienteJuridico.Enabled = true;
            txtEditDireccionClienteJuridico.Enabled = true;
            cbEditCodClienteFisicoClienteJuridico.Enabled = true;
            btnEditGuardarClienteJuridico.Visible = true;
            gbVisualizarClienteJuridico.Text = "Modificar Cliente Juridico";
        }

        private void btnEditGuardarClienteJuridico_Click(object sender, EventArgs e)
        {
            ClienteDAL.sIdClienteJuridico = txtEditCodigoClienteJuridico.Text;
            ClienteDAL.sNombreLegalClienteJuridico = txtEditNombreLegalClienteJuridico.Text;
            ClienteDAL.sNombreFantasiaClienteJuridico = txtEditNombreFantasiaClienteJuridico.Text;
            ClienteDAL.sNombreRepresentanteClienteJuridico = txtEditNombreRepresentanteClienteJuridico.Text;
            ClienteDAL.sCorreoClienteJuridico = txtEditCorreoClienteJuridico.Text;
            ClienteDAL.sTelefonoClienteJuridico = txtEditTelefonoClienteJuridico.Text;
            ClienteDAL.sDireccionClienteJuridico = txtEditDireccionClienteJuridico.Text;
            ClienteDAL.iCodClienteFisicoClienteJuridico = (int)cbEditCodClienteFisicoClienteJuridico.SelectedValue;
            ClienteBLL.updateClienteJuridicoBLL(ClienteDAL);
            cargarDataGridViewClientes();
            if (ClienteDAL.bBandera == true)
            {
                MessageBox.Show("Fue Actualizado");
            }
            else { MessageBox.Show("No fue Actualizado"); }

            limpiarMemoriaCliente();


            txtEditNombreLegalClienteJuridico.Enabled = false;
            txtEditNombreFantasiaClienteJuridico.Enabled = false;
            txtEditNombreRepresentanteClienteJuridico.Enabled = false;
            txtEditCorreoClienteJuridico.Enabled = false;
            txtEditTelefonoClienteJuridico.Enabled = false;
            txtEditDireccionClienteJuridico.Enabled = false;
            cbEditCodClienteFisicoClienteJuridico.Enabled = false;
            btnEditGuardarClienteJuridico.Visible = false;
            gbVisualizarClienteJuridico.Text = "Visualizar Cliente Juridico";
        }
       
        private void btnEditAgregarClienteJuridico_Click(object sender, EventArgs e)
        {
            //cargarComboBoxTelefono();
            //cbNewCodClienteJuridicoTelefono.SelectedValue = ClienteDAL.sIdClienteJuridico;
            //cbNewCodClienteFisicoTelefono.Text = string.Empty;
            //tcCliente.SelectedTab = tpNewTelefono;
        }
        
        private void btnEditSalirClienteJuridico_Click(object sender, EventArgs e)
        {    
            limpiarCamposEditCliente();
            tcCliente.SelectedTab = tpViewClienteJuridico;
            txtEditNombreLegalClienteJuridico.Enabled = false;
            txtEditNombreFantasiaClienteJuridico.Enabled = false;
            txtEditNombreRepresentanteClienteJuridico.Enabled = false;
            txtEditCorreoClienteJuridico.Enabled = false;
            txtEditTelefonoClienteJuridico.Enabled = false;
            txtEditDireccionClienteJuridico.Enabled = false;
            cbEditCodClienteFisicoClienteJuridico.Enabled = false;
            btnEditGuardarClienteJuridico.Visible = false;
            gbVisualizarClienteFisico.Text = "Visualizar Cliente Juridico";
        }
        #endregion

        #region Cliente Metodos
        public void cargarComboBoxCliente()
        {
            cbNewCodClienteFisicoClienteJuridico.DataSource = ClienteBLL.readClienteFisicoBLL();
            cbNewCodClienteFisicoClienteJuridico.DisplayMember = "Nombre del cliente";
            cbNewCodClienteFisicoClienteJuridico.ValueMember = "Codigo del cliente";

            cbEditCodClienteFisicoClienteJuridico.DataSource = ClienteBLL.readClienteFisicoBLL();
            cbEditCodClienteFisicoClienteJuridico.DisplayMember = "Nombre del cliente";
            cbEditCodClienteFisicoClienteJuridico.ValueMember = "Codigo del cliente";
        }
            public void cargarDataGridViewClientes()
        {
            dgvClienteFisico.DataSource = ClienteBLL.readClienteFisicoBLL();
            dgvClientesJuridicos.DataSource = ClienteBLL.readClienteJuridicoBLL();
            cargarDataGridViewTelefono();
        }
        public void limpiarCamposNewCliente() 
        {
            txtNewCodigoClienteFisico.Text = String.Empty;
            txtNewNombreClienteFisico.Text = String.Empty;
            txtNewPrimerApellidoClienteFisico.Text = String.Empty;
            txtNewSegundoApellidoClienteFisico.Text = String.Empty;
            txtNewCorreoClienteFisico.Text = String.Empty;
            txtNewDireccionClienteFisico.Text = String.Empty;

            txtNewCodigoClienteJuridico.Text = String.Empty;
            txtNewNombreLegalClienteJuridico.Text = String.Empty;
            txtNewNombreFantasiaClienteJuridico.Text = String.Empty;
            txtNewNombreRepresentanteClienteJuridico.Text = String.Empty;
            txtNewCorreoClienteJuridico.Text = String.Empty;
            txtNewTelefonoClienteJuridico.Text = String.Empty;
            txtNewDireccionClienteJuridico.Text = String.Empty;
            cbNewCodClienteFisicoClienteJuridico.Text = String.Empty;
        }
        public void limpiarCamposEditCliente()
        {
            txtEditCodigoClienteFisico.Text = String.Empty;
            txtEditNombreClienteFisico.Text = String.Empty;
            txtEditPrimerApellidoClienteFisico.Text = String.Empty;
            txtEditSegundoApellidoClienteFisico.Text = String.Empty;
            txtEditCorreoClienteFisico.Text = String.Empty;
            txtEditDireccionClienteFisico.Text = String.Empty;

            txtEditCodigoClienteJuridico.Text = String.Empty;
            txtEditNombreLegalClienteJuridico.Text = String.Empty;
            txtEditNombreFantasiaClienteJuridico.Text = String.Empty;
            txtEditNombreRepresentanteClienteJuridico.Text = String.Empty;
            txtEditCorreoClienteJuridico.Text = String.Empty;
            txtEditTelefonoClienteJuridico.Text = String.Empty;
            txtEditDireccionClienteJuridico.Text = String.Empty;
            cbEditCodClienteFisicoClienteJuridico.Text = String.Empty;

        }
        public void limpiarMemoriaCliente() 
        {
            ClienteDAL.sIdClienteJuridico = String.Empty;
            ClienteDAL.sNombreLegalClienteJuridico = String.Empty;
            ClienteDAL.sNombreFantasiaClienteJuridico = String.Empty;
            ClienteDAL.sNombreRepresentanteClienteJuridico = String.Empty;
            ClienteDAL.sCorreoClienteJuridico = String.Empty;
            ClienteDAL.sTelefonoClienteJuridico = String.Empty;
            ClienteDAL.sDireccionClienteJuridico = String.Empty;
            ClienteDAL.iCodClienteFisicoClienteJuridico = 0;
            ClienteDAL.sIdClienteFisico = String.Empty;
            ClienteDAL.sNombreClienteFisico = String.Empty;
            ClienteDAL.sPrimerApellidoClienteFisico = String.Empty;
            ClienteDAL.sSegundoApellidoClienteFisico = String.Empty;
            ClienteDAL.sCorreoClienteFisico = String.Empty;
            ClienteDAL.sDireccionClienteFisico = String.Empty;
            ClienteDAL.bBandera = false;

        }
        public void cargarCamposEditCliente()
        {
            txtEditCodigoClienteFisico.Text = ClienteDAL.sIdClienteFisico;
            txtEditNombreClienteFisico.Text = ClienteDAL.sNombreClienteFisico;
            txtEditPrimerApellidoClienteFisico.Text = ClienteDAL.sPrimerApellidoClienteFisico;
            txtEditSegundoApellidoClienteFisico.Text = ClienteDAL.sSegundoApellidoClienteFisico;
            txtEditCorreoClienteFisico.Text = ClienteDAL.sCorreoClienteFisico;
            txtEditDireccionClienteFisico.Text = ClienteDAL.sDireccionClienteFisico;

            dgvClienteFisicoDetail.DataSource = TelefonoBLL.readTelefonoBLL();
            DataView dv = TelefonoBLL.readTelefonoBLL().DefaultView;
            dv.RowFilter = string.Format("CONVERT([{0}], System.String) like '%{1}%'", dgvClienteFisicoDetail.Columns[3].Name, ClienteDAL.sIdClienteFisico) ;
            dgvClienteFisicoDetail.DataSource = dv.ToTable();

            txtEditCodigoClienteJuridico.Text = ClienteDAL.sIdClienteJuridico;
            txtEditNombreLegalClienteJuridico.Text = ClienteDAL.sNombreLegalClienteJuridico;
            txtEditNombreFantasiaClienteJuridico.Text = ClienteDAL.sNombreFantasiaClienteJuridico;
            txtEditNombreRepresentanteClienteJuridico.Text = ClienteDAL.sNombreRepresentanteClienteJuridico;
            txtEditCorreoClienteJuridico.Text = ClienteDAL.sCorreoClienteJuridico;
            txtEditTelefonoClienteJuridico.Text = ClienteDAL.sTelefonoClienteJuridico;
            txtEditDireccionClienteJuridico.Text = ClienteDAL.sDireccionClienteJuridico;
            cbEditCodClienteFisicoClienteJuridico.SelectedValue = ClienteDAL.iCodClienteFisicoClienteJuridico;

            dgvClienteJuridicoDetail.DataSource = TelefonoBLL.readTelefonoBLL();
            DataView dv1 = TelefonoBLL.readTelefonoBLL().DefaultView;
            dv1.RowFilter = string.Format("CONVERT([{0}], System.String) like '%{1}%'", dgvClienteJuridicoDetail.Columns[3].Name, ClienteDAL.iCodClienteFisicoClienteJuridico);
            dgvClienteJuridicoDetail.DataSource = dv1.ToTable();

        }
        public void filtroDataGridViewCliente()
        {
            if (txtViewBuscarClienteFisico.Text != "")
            {
                DataView dv = ClienteBLL.readClienteFisicoBLL().DefaultView;
                //MessageBox.Show("Header: "+ dgvTipoServicio.Columns[1].Name);
                dv.RowFilter = string.Format("[{0}] like '%{1}%'", dgvClienteFisico.Columns[1].Name, txtViewBuscarClienteFisico.Text);
                dgvClienteFisico.DataSource = dv.ToTable();
            }
            else
            {
                dgvClienteFisico.DataSource = ClienteBLL.readClienteFisicoBLL();
            }


            if (txtViewBuscarClienteJuridico.Text != "")
            {
                DataView dv1 = ClienteBLL.readClienteJuridicoBLL().DefaultView;
                //MessageBox.Show("Header: "+ dgvTipoServicio.Columns[1].Name);
                dv1.RowFilter = string.Format("[{0}] like '%{1}%'", dgvClientesJuridicos.Columns[1].Name, txtViewBuscarClienteJuridico.Text);
                dgvClientesJuridicos.DataSource = dv1.ToTable();
            }
            else
            {
                dgvClientesJuridicos.DataSource = ClienteBLL.readClienteJuridicoBLL();
            }


        }
        private void dgvClienteFisico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvClienteFisico.Rows[e.RowIndex];
                ClienteDAL.sIdClienteFisico                 = row.Cells[0].Value.ToString();
                ClienteDAL.sNombreClienteFisico             = row.Cells[1].Value.ToString();
                ClienteDAL.sPrimerApellidoClienteFisico     = row.Cells[2].Value.ToString();
                ClienteDAL.sSegundoApellidoClienteFisico    = row.Cells[3].Value.ToString();
                ClienteDAL.sCorreoClienteFisico             = row.Cells[4].Value.ToString();
                ClienteDAL.sDireccionClienteFisico          = row.Cells[5].Value.ToString();
            }
        }
        
        
        private void dgvClientesJuridicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvClientesJuridicos.Rows[e.RowIndex];
                ClienteDAL.sIdClienteJuridico = row.Cells[0].Value.ToString();
                ClienteDAL.sNombreLegalClienteJuridico = row.Cells[1].Value.ToString();
                ClienteDAL.sNombreFantasiaClienteJuridico = row.Cells[2].Value.ToString();
                ClienteDAL.sNombreRepresentanteClienteJuridico = row.Cells[3].Value.ToString();
                ClienteDAL.sCorreoClienteJuridico = row.Cells[4].Value.ToString();
                ClienteDAL.sTelefonoClienteJuridico = row.Cells[5].Value.ToString();
                ClienteDAL.sDireccionClienteJuridico = row.Cells[6].Value.ToString();
                ClienteDAL.iCodClienteFisicoClienteJuridico = Int32.Parse(row.Cells[7].Value.ToString());
            }
        }
        #endregion

        #endregion

        #region Telefono

        #region Telefono View
        private void tsbViewAgregarTelefono_Click(object sender, EventArgs e)
        {
            cargarComboBoxTelefono();
            tcCliente.SelectedTab = tpNewTelefono;
        }

        private void tsbViewModificarTelefono_Click(object sender, EventArgs e)
        {
            cargarComboBoxTelefono();
            cargarCamposEditTelefono();
            tcCliente.SelectedTab = tpEditTelefono;
        }

        private void tsbViewEliminarTelefono_Click(object sender, EventArgs e)
        {
            TelefonoBLL.deleteTelefonoBLL(TelefonoDAL);
            cargarDataGridViewTelefono();
            if (TelefonoDAL.bBandera == true)
            {
                MessageBox.Show("Fue Eliminado");
            }
            else { MessageBox.Show("No fue Eliminado"); }
            limpiarMemoriaTelefono();
        }

        private void tsbViewActualizarTelefono_Click(object sender, EventArgs e)
        {
            cargarDataGridViewTelefono();
        }
        private void txtViewBuscarTelefono_KeyUp(object sender, KeyEventArgs e)
        {
            filtroDataGridViewTelefono();
        }

        private void dgvTelefonos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTelefonos.Rows[e.RowIndex];
                TelefonoDAL.sCodTelefono =                  row.Cells[0].Value.ToString();
                TelefonoDAL.sNombrePropietarioTelefono =    row.Cells[1].Value.ToString();
                TelefonoDAL.sDescripcionTelefono =          row.Cells[2].Value.ToString();
                TelefonoDAL.iIdClienteFisico =  Int32.Parse(row.Cells[3].Value.ToString());
            }
        }


        #endregion

        #region Telefono New
        private void tsbNewGuardarTelefono_Click(object sender, EventArgs e)
        {
            TelefonoDAL.sCodTelefono = txtNewCodigoTelefono.Text;
            TelefonoDAL.sNombrePropietarioTelefono = txtNewNombrePropietarioTelefono.Text;
            TelefonoDAL.sDescripcionTelefono = txtNewDescripcionTelefono.Text;
            TelefonoDAL.iIdClienteFisico = (int)cbNewCodClienteFisicoTelefono.SelectedValue;
            //TelefonoDAL.iIdClienteJuridico = (int)cbNewCodClienteJuridicoTelefono.SelectedValue;
            TelefonoBLL.createTelefonoBLL(TelefonoDAL);
            tcCliente.SelectedTab = tpViewTelefono;
            cargarDataGridViewTelefono();
            if (TelefonoDAL.bBandera == true)
            {
                MessageBox.Show("Fue Creado");
            }
            else { MessageBox.Show("No fue Creado"); }
            limpiarCamposNewTelefono();
            limpiarMemoriaTelefono();
        }

        private void tsbNewCancelarTelefono_Click(object sender, EventArgs e)
        {
            tcCliente.SelectedTab = tpViewTelefono;
            limpiarCamposNewTelefono();
        }
        #endregion

        #region Telefono Edit
        private void tsbEditGuardarTelefono_Click(object sender, EventArgs e)
        {
            TelefonoDAL.sCodTelefono = txtEditCodigoTelefono.Text;
            TelefonoDAL.sNombrePropietarioTelefono = txtEditNombrePropietarioTelefono.Text;
            TelefonoDAL.sDescripcionTelefono = txtEditDescripcionTelefono.Text;
            TelefonoDAL.iIdClienteFisico = (int)cbEditCodClienteFisicoTelefono.SelectedValue;
            //TelefonoDAL.iIdClienteJuridico = (int)cbNewCodClienteJuridicoTelefono.SelectedValue;
            TelefonoBLL.updateTelefonoBLL(TelefonoDAL);
            tcCliente.SelectedTab = tpViewTelefono;
            cargarDataGridViewTelefono();
            if (TelefonoDAL.bBandera == true)
            {
                MessageBox.Show("Fue Actualizado");
            }
            else { MessageBox.Show("No fue Actualizado"); }
            limpiarCamposEditTelefono();
            limpiarMemoriaTelefono();
        }

        private void tsbEditCancelarTelefono_Click(object sender, EventArgs e)
        {
            tcCliente.SelectedTab = tpViewTelefono;
            limpiarCamposEditTelefono();
        }
        #endregion

        #region Telefono Metodos
        public void cargarComboBoxTelefono()
        {   
            cbNewCodClienteFisicoTelefono.DataSource = ClienteBLL.readClienteFisicoBLL();
            cbNewCodClienteFisicoTelefono.DisplayMember = "Nombre del cliente";
            cbNewCodClienteFisicoTelefono.ValueMember = "Codigo del cliente";

            cbNewCodClienteJuridicoTelefono.DataSource = ClienteBLL.readClienteJuridicoBLL();
            cbNewCodClienteJuridicoTelefono.DisplayMember = "Nombre Legal";
            cbNewCodClienteJuridicoTelefono.ValueMember = "Nombre del Cliente Jurídico";

            cbEditCodClienteFisicoTelefono.DataSource = ClienteBLL.readClienteFisicoBLL();
            cbEditCodClienteFisicoTelefono.DisplayMember = "Nombre del cliente";
            cbEditCodClienteFisicoTelefono.ValueMember = "Codigo del cliente";

            cbEditCodClienteJuridicoTelefono.DataSource = ClienteBLL.readClienteJuridicoBLL();
            cbEditCodClienteJuridicoTelefono.DisplayMember = "Nombre Legal";
            cbEditCodClienteJuridicoTelefono.ValueMember = "Nombre del Cliente Jurídico";
        }
        public void cargarDataGridViewTelefono()
        {
            dgvTelefonos.DataSource = TelefonoBLL.readTelefonoBLL();
        }
        public void filtroDataGridViewTelefono()
        {
            if (txtViewBuscarTelefono.Text != "")
            {
                DataView dv = TelefonoBLL.readTelefonoBLL().DefaultView;
                //MessageBox.Show("Header: "+ dgvVehiculo.Columns[1].Name);
                dv.RowFilter = string.Format("CONVERT([{0}], System.String) like '%{1}%'", dgvTelefonos.Columns[0].Name, txtViewBuscarTelefono.Text);
                dgvTelefonos.DataSource = dv.ToTable();
            }
            else
            {
                dgvTelefonos.DataSource = TelefonoBLL.readTelefonoBLL();
            }
        }
        public void limpiarCamposNewTelefono()
        {
            txtNewCodigoTelefono.Text = String.Empty;
            txtNewNombrePropietarioTelefono.Text = String.Empty;
            txtNewDescripcionTelefono.Text = String.Empty;
            cbNewCodClienteFisicoTelefono.Text = String.Empty;
            cbNewCodClienteJuridicoTelefono.Text = String.Empty;
        }
        public void limpiarCamposEditTelefono()
        {
            txtEditCodigoTelefono.Text = String.Empty;
            txtEditNombrePropietarioTelefono.Text = String.Empty;
            txtEditDescripcionTelefono.Text = String.Empty;
            cbEditCodClienteFisicoTelefono.Text = String.Empty;
            cbEditCodClienteJuridicoTelefono.Text = String.Empty;

        }
        public void limpiarMemoriaTelefono()
        {
            TelefonoDAL.sCodTelefono = string.Empty;
            TelefonoDAL.sNombrePropietarioTelefono = string.Empty;
            TelefonoDAL.sDescripcionTelefono = string.Empty;
            TelefonoDAL.iIdClienteFisico = 0;
            TelefonoDAL.iIdClienteJuridico = 0;
        }
        public void cargarCamposEditTelefono()
        {
            txtEditCodigoTelefono.Text              = TelefonoDAL.sCodTelefono;
            txtEditNombrePropietarioTelefono.Text = TelefonoDAL.sNombrePropietarioTelefono;
            txtEditDescripcionTelefono.Text = TelefonoDAL.sDescripcionTelefono;
            cbEditCodClienteFisicoTelefono.SelectedValue   = TelefonoDAL.iIdClienteFisico;
            
        }
        #endregion

        #endregion

        #region Colaboradores

        #region Colaboradores View
        private void tsbViewAgregarColaborador_Click(object sender, EventArgs e)
        {
            cargarComboBoxColaborador();
            tcPrincipal.SelectedTab = tpNewColaborador;
        }

        private void tsbViewModificarColaborador_Click(object sender, EventArgs e)
        {
            cargarComboBoxColaborador();
            cargarCamposEditColaborador();
            tcPrincipal.SelectedTab = tpEditColaborador;
        }

        private void tsbViewEliminarColaborador_Click(object sender, EventArgs e)
        {
            ColaboradorBLL.deleteColaboradorBLL(ColaboradorDAL);
            cargarDataGridViewColaborador();
            if (ColaboradorDAL.bBandera == true)
            {
                MessageBox.Show("Fue Eliminado");
            }
            else { MessageBox.Show("No fue Eliminado"); }
            limpiarMemoriaColaborador();
        }

        private void tsbViewActualizarColaborador_Click(object sender, EventArgs e)
        {
            cargarDataGridViewColaborador();
        }

        #endregion

        #region Colaboradores New
        private void tsbNewGuardarColaborador_Click(object sender, EventArgs e)
        {
            ColaboradorDAL.sIdColaborador = txtNewIdColaborador.Text;
            ColaboradorDAL.sNombreColaborador = txtNewNombreColborador.Text;
            ColaboradorDAL.sPrimerApellidoColaborador = txtNewPrimerApellidoColaborador.Text;
            ColaboradorDAL.sSegundoApellidoColaborador = txtNewSegundoApellidoColaborador.Text;
            ColaboradorDAL.sCorreoColaborador = txtNewCorreoColaborador.Text;
            ColaboradorDAL.sTelefonoColaborador = txtNewTelefonoColaborador.Text;
            ColaboradorDAL.sDireccionColaborador = txtNewDireccionColaborador.Text;
            ColaboradorDAL.sRolColaborador = cbNewRolColaborador.Text;
            ColaboradorDAL.iCodSucursal = (int)cbNewIdSucursalColaborador.SelectedValue;
            ColaboradorBLL.createColaboradorBLL(ColaboradorDAL);
            tcPrincipal.SelectedTab = tpViewColaborador;
            cargarDataGridViewColaborador();
            if (ColaboradorDAL.bBandera == true)
            {
                MessageBox.Show("Fue Creado");
            }
            else { MessageBox.Show("No fue Creado"); }
            limpiarCamposNewColaborador();
            limpiarMemoriaColaborador();
        }
        private void tsbNewCancelarColaborador_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewColaborador;
            limpiarCamposNewColaborador();
        }
        #endregion

        #region Colaboradores Edit
        private void tsbEditGuardarColaborador_Click(object sender, EventArgs e)
        {
            ColaboradorDAL.sIdColaborador = txtEditIdColaborador.Text;
            ColaboradorDAL.sNombreColaborador = txtEditNombreColaborador.Text;
            ColaboradorDAL.sPrimerApellidoColaborador = txtEditPrimerApellidoColaborador.Text;
            ColaboradorDAL.sSegundoApellidoColaborador = txtEditSegundoApellidoColaborador.Text;
            ColaboradorDAL.sCorreoColaborador = txtEditCorreoColaborador.Text;
            ColaboradorDAL.sTelefonoColaborador = txtEditTelefonoColaborador.Text;
            ColaboradorDAL.sDireccionColaborador = txtEditDireccionColaborador.Text;
            ColaboradorDAL.sRolColaborador = cbEditRolColaborador.Text;
            ColaboradorDAL.iCodSucursal = (int)cbEditIdSucursalColaborador.SelectedValue;
            ColaboradorBLL.updateColaboradorBLL(ColaboradorDAL);
            tcPrincipal.SelectedTab = tpViewColaborador;
            cargarDataGridViewColaborador();
            if (ColaboradorDAL.bBandera == true)
            {
                MessageBox.Show("Fue Actualizado");
            }
            else { MessageBox.Show("No fue Actualizado"); }
            limpiarCamposEditColaborador();
            limpiarMemoriaColaborador();
        }
        private void tsbEditCancelarColaborador_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewColaborador;
            limpiarCamposEditColaborador();
        }
        #endregion

        #region Colaboradores Metodos
        public void cargarComboBoxColaborador()
        {
            cbNewIdSucursalColaborador.DataSource = SucursalBLL.readSucursalBLL();
            cbNewIdSucursalColaborador.DisplayMember = "Ubicación de la Sucursal";
            cbNewIdSucursalColaborador.ValueMember = "Código de la Sucursal";

            cbEditIdSucursalColaborador.DataSource = SucursalBLL.readSucursalBLL();
            cbEditIdSucursalColaborador.DisplayMember = "Ubicación de la Sucursal";
            cbEditIdSucursalColaborador.ValueMember = "Código de la Sucursal";

            cbNewRolColaborador.SelectedIndex = 0;
        }
        public void cargarDataGridViewColaborador()
        {
            dgvColaborador.DataSource = ColaboradorBLL.readColaboradorBLL();
        }
        public void filtroDataGridViewColaborador()
        {
            if (txtViewBuscarColaborador.Text != "")
            {
                DataView dv = ColaboradorBLL.readColaboradorBLL().DefaultView;
                //MessageBox.Show("Header: " + dgvColaborador.Columns[1].Name);
                dv.RowFilter = string.Format("[{0}] like '%{1}%'", dgvColaborador.Columns[1].Name, txtViewBuscarColaborador.Text);
                dgvColaborador.DataSource = dv.ToTable();
            }
            else
            {
                dgvColaborador.DataSource = ColaboradorBLL.readColaboradorBLL();
            }
        }
        public void limpiarCamposNewColaborador() 
        {
            txtNewIdColaborador.Text = string.Empty;
            txtNewNombreColborador.Text = string.Empty;
            txtNewPrimerApellidoColaborador.Text = string.Empty;
            txtNewSegundoApellidoColaborador.Text = string.Empty;
            txtNewCorreoColaborador.Text = string.Empty;
            txtNewTelefonoColaborador.Text = string.Empty;
            txtNewDireccionColaborador.Text = string.Empty;
            cbNewRolColaborador.SelectedIndex = 0;
            cbNewIdSucursalColaborador.Text = "Seleccione";
        }
        public void limpiarCamposEditColaborador()
        {
            txtEditIdColaborador.Text = string.Empty;
            txtEditNombreColaborador.Text = string.Empty;
            txtEditPrimerApellidoColaborador.Text = string.Empty;
            txtEditSegundoApellidoColaborador.Text = string.Empty;
            txtEditCorreoColaborador.Text = string.Empty;
            txtEditTelefonoColaborador.Text = string.Empty;
            txtEditDireccionColaborador.Text = string.Empty;
            cbEditRolColaborador.SelectedIndex = 0;
            cbEditIdSucursalColaborador.Text = "Seleccione";
        }
        public void limpiarMemoriaColaborador()
        {
            ColaboradorDAL.sIdColaborador = string.Empty;
            ColaboradorDAL.sNombreColaborador = string.Empty;
            ColaboradorDAL.sPrimerApellidoColaborador = string.Empty;
            ColaboradorDAL.sSegundoApellidoColaborador = string.Empty;
            ColaboradorDAL.sCorreoColaborador = string.Empty;
            ColaboradorDAL.sTelefonoColaborador = string.Empty;
            ColaboradorDAL.sTelefonoColaborador = string.Empty;
            ColaboradorDAL.sDireccionColaborador = string.Empty;
            ColaboradorDAL.sRolColaborador = string.Empty;
            ColaboradorDAL.iCodSucursal = 0;
            ColaboradorDAL.bBandera = false;

        }
        public void cargarCamposEditColaborador()
        {
            txtEditIdColaborador.Text = ColaboradorDAL.sIdColaborador;
            txtEditNombreColaborador.Text = ColaboradorDAL.sNombreColaborador;
            txtEditPrimerApellidoColaborador.Text = ColaboradorDAL.sPrimerApellidoColaborador;
            txtEditSegundoApellidoColaborador.Text = ColaboradorDAL.sSegundoApellidoColaborador;
            txtEditCorreoColaborador.Text = ColaboradorDAL.sCorreoColaborador;
            txtEditTelefonoColaborador.Text = ColaboradorDAL.sTelefonoColaborador;
            txtEditDireccionColaborador.Text = ColaboradorDAL.sDireccionColaborador;
            cbEditRolColaborador.Text = ColaboradorDAL.sRolColaborador;
            cbEditIdSucursalColaborador.SelectedValue = ColaboradorDAL.iCodSucursal;
        }
        private void dgvColaborador_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvColaborador.Rows[e.RowIndex];
                ColaboradorDAL.sIdColaborador = row.Cells[0].Value.ToString();
                ColaboradorDAL.sNombreColaborador = row.Cells[1].Value.ToString();
                ColaboradorDAL.sPrimerApellidoColaborador = row.Cells[2].Value.ToString();
                ColaboradorDAL.sSegundoApellidoColaborador = row.Cells[3].Value.ToString();
                ColaboradorDAL.sCorreoColaborador = row.Cells[4].Value.ToString();
                ColaboradorDAL.sTelefonoColaborador = row.Cells[5].Value.ToString();
                ColaboradorDAL.sDireccionColaborador = row.Cells[6].Value.ToString();
                ColaboradorDAL.sRolColaborador = row.Cells[7].Value.ToString();
                ColaboradorDAL.iCodSucursal = Int32.Parse(row.Cells[8].Value.ToString());

            }
        }
        private void txtViewBuscarColaborador_KeyUp(object sender, KeyEventArgs e)
        {
            filtroDataGridViewColaborador();
        }
        #endregion

        #endregion

        #region Marca
        #region Marca View
        private void tsbViewAgregarMarca_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpNewMarca;
        }

        private void tsbViewModificarMarca_Click(object sender, EventArgs e)
        {
            cargarCamposEditMarca();
            tcPrincipal.SelectedTab = tpEditMarca;
        }

        private void tsbViewEliminarMarca_Click(object sender, EventArgs e)
        {
            MarcaBLL.deleteMarcaBLL(MarcaDAL);
            cargarDataGridViewMarca();
            if (MarcaDAL.bBandera == true)
            {
                MessageBox.Show("Fue Eliminado");
            }
            else { MessageBox.Show("No fue Eliminado"); }
            limpiarMemoriaMarca();
        }

        private void tsbViewActualizarMarca_Click(object sender, EventArgs e)
        {
            cargarDataGridViewMarca();
        }


        #endregion

        #region Marca New
        private void tsbNewGuardarMarca_Click(object sender, EventArgs e)
        {
            MarcaDAL.sIdMarca = txtNewIdMarca.Text;
            MarcaDAL.sNombreMarca = txtNewNombreMarca.Text;
            MarcaBLL.createMarcaBLL(MarcaDAL);
            tcPrincipal.SelectedTab = tpViewMarca;
            cargarDataGridViewMarca();
            if (MarcaDAL.bBandera == true)
            {
                MessageBox.Show("Fue Creado");
            }
            else { MessageBox.Show("No fue Creado"); }
            limpiarCamposNewMarca();
            limpiarMemoriaMarca();
        }

        private void tsbNewCancelarMarca_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewMarca;
            limpiarCamposNewMarca();
        }
        #endregion

        #region Marca Edit
        private void tsbEditGuardarMarca_Click(object sender, EventArgs e)
        {
            MarcaDAL.sIdMarca = txtEditIdMarca.Text;
            MarcaDAL.sNombreMarca = txtEditNombreMarca.Text;
            MarcaBLL.updateMarcaBLL(MarcaDAL);
            tcPrincipal.SelectedTab = tpViewMarca;
            cargarDataGridViewMarca();
            if (MarcaDAL.bBandera == true)
            {
                MessageBox.Show("Fue Actualizado");
            }
            else { MessageBox.Show("No fue Actualizado"); }
            limpiarCamposEditMarca();
            limpiarMemoriaMarca();
        }

        private void tsbEditCancelarMarca_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewMarca;
            limpiarCamposEditMarca();
        }
        #endregion

        #region Marca Metodos
        public void cargarDataGridViewMarca() 
        {
            dgvMarca.DataSource = MarcaBLL.readMarcaBLL();
        }
        public void filtroDataGridViewMarca()
        {
            if (txtViewBuscarMarca.Text != "")
            {
                DataView dv = MarcaBLL.readMarcaBLL().DefaultView;
                //MessageBox.Show("Header: "+ dgvTipoServicio.Columns[1].Name);
                dv.RowFilter = string.Format("[{0}] like '%{1}%'", dgvMarca.Columns[1].Name, txtViewBuscarMarca.Text);
                dgvMarca.DataSource = dv.ToTable();
            }
            else
            {
                dgvMarca.DataSource = MarcaBLL.readMarcaBLL();
            }
        }
        public void limpiarCamposNewMarca() 
        {
            txtNewIdMarca.Text = string.Empty;
            txtNewNombreMarca.Text = string.Empty;
        }
        public void limpiarCamposEditMarca()
        {
            txtEditIdMarca.Text = string.Empty;
            txtEditNombreMarca.Text = string.Empty;
        }
        public void limpiarMemoriaMarca() 
        {
            MarcaDAL.sIdMarca = string.Empty;
            MarcaDAL.sNombreMarca = string.Empty;
            MarcaDAL.bBandera = false;
        }
        public void cargarCamposEditMarca()
        {
            txtEditIdMarca.Text = MarcaDAL.sIdMarca;
            txtEditNombreMarca.Text = MarcaDAL.sNombreMarca;
        }
        private void dgvMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMarca.Rows[e.RowIndex];
                MarcaDAL.sIdMarca = row.Cells[0].Value.ToString();
                MarcaDAL.sNombreMarca = row.Cells[1].Value.ToString();
            }
        }

        private void txtViewBuscarMarca_KeyUp(object sender, KeyEventArgs e)
        {
            filtroDataGridViewMarca();
        }
        #endregion

        #endregion

        #region Modelo
        #region Modelo View
        private void tsbViewAgregarModelo_Click(object sender, EventArgs e)
        {
            cargarComboBoxModelo();
            tcPrincipal.SelectedTab = tpNewModelo;
        }

        private void tsbViewModificarModelo_Click(object sender, EventArgs e)
        {
            cargarComboBoxModelo();
            cargarCamposEditModelo();
            tcPrincipal.SelectedTab = tpEditModelo;
        }

        private void tsbViewEliminarModelo_Click(object sender, EventArgs e)
        {
            ModeloBLL.deleteModeloBLL(ModeloDAL);
            cargarDataGridViewModelo();
            if (ModeloDAL.bBandera == true)
            {
                MessageBox.Show("Fue Eliminado");
            }
            else { MessageBox.Show("No fue Eliminado"); }
            limpiarMemoriaModelo();
        }

        private void tsbViewActualizarModelo_Click(object sender, EventArgs e)
        {
            cargarDataGridViewModelo();
        }


        #endregion

        #region Modelo New
        private void tsbNewGuardarModelo_Click(object sender, EventArgs e)
        {
            ModeloDAL.sIdModelo = txtNewIdModelo.Text;
            ModeloDAL.sNombreModelo = txtNewNombreModelo.Text;
            ModeloDAL.iCodMarcaModelo = (int)cbNewIdMarcaModelo.SelectedValue;
            ModeloBLL.createModeloBLL(ModeloDAL);
            tcPrincipal.SelectedTab = tpViewModelo;
            cargarDataGridViewModelo();
            if (ModeloDAL.bBandera == true)
            {
                MessageBox.Show("Fue Creado");
            }
            else { MessageBox.Show("No fue Creado"); }
            limpiarCamposNewModelo();
            limpiarMemoriaModelo();

        }

        private void tsbNewCancelarModelo_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewModelo;
            limpiarCamposNewModelo();
        }
        #endregion

        #region Modelo Edit
        private void tsbEditGuardarModelo_Click(object sender, EventArgs e)
        {
            ModeloDAL.sIdModelo = txtEditIdModelo.Text;
            ModeloDAL.sNombreModelo = txtEditNombreModelo.Text;
            ModeloDAL.iCodMarcaModelo = (int)cbEditIdMarcaModelo.SelectedValue;
            ModeloBLL.updateModeloBLL(ModeloDAL);
            tcPrincipal.SelectedTab = tpViewModelo;
            cargarDataGridViewModelo();
            if (ModeloDAL.bBandera == true)
            {
                MessageBox.Show("Fue Creado");
            }
            else { MessageBox.Show("No fue Creado"); }
            limpiarCamposEditModelo();
            limpiarMemoriaModelo();
        }

        private void tsbEditCancelarModelo_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewModelo;
            limpiarCamposEditModelo();
        }

        #endregion

        #region Modelo Metodos
        public void cargarComboBoxModelo()
        {
            cbNewIdMarcaModelo.DataSource = MarcaBLL.readMarcaBLL();
            cbNewIdMarcaModelo.DisplayMember = "Nombre de la marca";
            cbNewIdMarcaModelo.ValueMember = "Codigo de la marca";
            cbEditIdMarcaModelo.DataSource = MarcaBLL.readMarcaBLL();
            cbEditIdMarcaModelo.DisplayMember = "Nombre de la marca";
            cbEditIdMarcaModelo.ValueMember = "Codigo de la marca";
        }
        public void cargarDataGridViewModelo() 
        {
            dgvModelo.DataSource = ModeloBLL.readModeloBLL();
        }
        public void filtroDataGridViewModelo()
        {
            if (txtViewBuscarModelo.Text != "")
            {
                DataView dv = ModeloBLL.readModeloBLL().DefaultView;
                //MessageBox.Show("Header: "+ dgvTipoServicio.Columns[1].Name);
                dv.RowFilter = string.Format("[{0}] like '%{1}%'", dgvModelo.Columns[1].Name, txtViewBuscarModelo.Text);
                dgvModelo.DataSource = dv.ToTable();
            }
            else
            {
                dgvModelo.DataSource = ModeloBLL.readModeloBLL();
            }
        }
        public void limpiarCamposNewModelo()
        {
            txtNewIdModelo.Text = string.Empty;
            txtNewNombreModelo.Text = string.Empty;
            cbNewIdMarcaModelo.SelectedValue = 0;
        }
        public void limpiarCamposEditModelo() 
        {
            txtEditIdModelo.Text = string.Empty;
            txtEditNombreModelo.Text = string.Empty;
            cbEditIdMarcaModelo.SelectedValue = 0;
        }
        public void limpiarMemoriaModelo() 
        {
            ModeloDAL.sIdModelo = string.Empty;
            ModeloDAL.sNombreModelo = string.Empty;
            ModeloDAL.iCodMarcaModelo = 0;
            ModeloDAL.bBandera = false;
        }
        public void cargarCamposEditModelo() 
        {
            txtEditIdModelo.Text = ModeloDAL.sIdModelo;
            txtEditNombreModelo.Text = ModeloDAL.sNombreModelo;
            cbEditIdMarcaModelo.SelectedValue = ModeloDAL.iCodMarcaModelo;
        }
        private void dgvModelo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvModelo.Rows[e.RowIndex];
                ModeloDAL.sIdModelo = row.Cells[0].Value.ToString();
                ModeloDAL.sNombreModelo = row.Cells[1].Value.ToString();
                ModeloDAL.iCodMarcaModelo = Int32.Parse(row.Cells[2].Value.ToString());
            }
        }

        private void txtViewBuscarModelo_KeyUp(object sender, KeyEventArgs e)
        {
            filtroDataGridViewModelo();

        }
        #endregion

        #endregion

        #region Vehiculo

        #region Vehiculo View
        private void tsbViewAgregarVehiculo_Click(object sender, EventArgs e)
        {
            cargarComboBoxVehiculo();
            tcPrincipal.SelectedTab = tpNewVehiculo;
        }

        private void tsbViewNodificarVehiculo_Click(object sender, EventArgs e)
        {
            cargarComboBoxVehiculo();
            cargarCamposEditVehiculo();
            tcPrincipal.SelectedTab = tpEditVehiculo;
        }

        private void tsbViewEliminarVehiculo_Click(object sender, EventArgs e)
        {
            VehiculoBLL.deleteVehiculoBLL(VehiculoDAL);
            cargarDataGridViewVehiculo();
            if (VehiculoDAL.bBandera == true)
            {
                MessageBox.Show("Fue Eliminado");
            }
            else { MessageBox.Show("No fue Eliminado"); }
            limpiarMemoriaVehiculo();
        }

        private void tsbViewActualizarVehiculo_Click(object sender, EventArgs e)
        {
            cargarDataGridViewVehiculo();
        }


        #endregion

        #region Vehiculo New
        private void tsbNewGuardarVehiculo_Click(object sender, EventArgs e)
        {
            VehiculoDAL.sPlacaVehiculo = txtNewPlacaVehiculo.Text;
            VehiculoDAL.iCodMarcaVehiculo = (int)cbNewCodMarcaVehiculo.SelectedValue;
            VehiculoDAL.iCodModeloVehiculo = (int)cbNewCodModeloVehiculo.SelectedValue;
            VehiculoDAL.iCodFisicoVehiculo = (int)cbNewCodFisicoVehiculo.SelectedValue;
            VehiculoDAL.sTipoVehiculo = txtNewTipoVehiculo.Text;
            VehiculoDAL.sTipoMotorVehiculo = txtNewTipoMotorVehiculo.Text;
            VehiculoDAL.sTipoCilindrajeVehiculo = txtNewCilindrajeVehiculo.Text;
            VehiculoDAL.sTipoTransmicionVehiculo = cbNewTrasmisionVehiculo.Text;
            VehiculoDAL.sAnhioVehiculo = txtNewAnoVehiculo.Text;
            VehiculoDAL.sTipoGasolinaVehiculo = cbNewGasolinaVehiculo.Text;
            VehiculoDAL.sNumeroPuertasVehiculo = txtNewNumeroPuertasVehiculo.Text;
            VehiculoBLL.createVehiculoBLL(VehiculoDAL);
            tcPrincipal.SelectedTab = tpViewVehiculo;
            cargarDataGridViewVehiculo();
            if (VehiculoDAL.bBandera == true)
            {
                MessageBox.Show("Fue Creado");
            }
            else { MessageBox.Show("No fue Creado"); }
            limpiarCamposNewVehiculo();
            limpiarMemoriaVehiculo();



        }

        private void tsbNewCancelarVehiculo_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewVehiculo;
            limpiarCamposNewVehiculo();
        }

        #endregion

        #region Vehiculo Edit
        private void tsbEditGuardarVehiculo_Click(object sender, EventArgs e)
        {
            VehiculoDAL.sPlacaVehiculo = txtEditPlacaVehiculo.Text;
            VehiculoDAL.iCodMarcaVehiculo = (int)cbEditCodMarcaVehiculo.SelectedValue;
            VehiculoDAL.iCodModeloVehiculo = (int)cbEditCodModeloVehiculo.SelectedValue;
            VehiculoDAL.iCodFisicoVehiculo = (int)cbEditCodFisicoVehiculo.SelectedValue;
            VehiculoDAL.sTipoVehiculo = txtEditTipoVehiculo.Text;
            VehiculoDAL.sTipoMotorVehiculo = txtEditTipoMotorVehiculo.Text;
            VehiculoDAL.sTipoCilindrajeVehiculo = txtEditCilindrajeVehiculo.Text;
            VehiculoDAL.sTipoTransmicionVehiculo = cbEditTrasmicionVehiculo.Text;
            VehiculoDAL.sAnhioVehiculo = txtEditAnoVehiculo.Text;
            VehiculoDAL.sTipoGasolinaVehiculo = cbEditTipoGasolinaVehiculo.Text;
            VehiculoDAL.sNumeroPuertasVehiculo = txtEditNumeroPuertasVehiculo.Text;
            VehiculoBLL.updateVehiculoBLL(VehiculoDAL);
            tcPrincipal.SelectedTab = tpViewVehiculo;
            cargarDataGridViewVehiculo();
            if (VehiculoDAL.bBandera == true)
            {
                MessageBox.Show("Fue Actualizado");
            }
            else { MessageBox.Show("No fue Actualizado"); }
            limpiarCamposEditVehiculo();
            limpiarMemoriaVehiculo();
        }

        private void tsbEditCancelarVehiculo_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewVehiculo;
            limpiarCamposEditVehiculo();
        }

        #endregion

        #region Vehiculo Metodos
        public void cargarComboBoxVehiculo() 
        {

            cbNewCodMarcaVehiculo.DataSource = MarcaBLL.readMarcaBLL();
            cbNewCodMarcaVehiculo.DisplayMember = "Nombre de la marca";
            cbNewCodMarcaVehiculo.ValueMember = "Codigo de la marca";
            

            cbNewCodModeloVehiculo.DataSource = ModeloBLL.readModeloBLL();
            cbNewCodModeloVehiculo.DisplayMember = "Nombre del Modelo";
            cbNewCodModeloVehiculo.ValueMember = "Código del Modelo";

            cbNewCodFisicoVehiculo.DataSource = ClienteBLL.readClienteFisicoBLL();
            cbNewCodFisicoVehiculo.DisplayMember = "Nombre del cliente";
            cbNewCodFisicoVehiculo.ValueMember = "Codigo del cliente";

            cbEditCodMarcaVehiculo.DataSource = MarcaBLL.readMarcaBLL();
            cbEditCodMarcaVehiculo.DisplayMember = "Nombre de la marca";
            cbEditCodMarcaVehiculo.ValueMember = "Codigo de la marca";

            cbEditCodModeloVehiculo.DataSource = ModeloBLL.readModeloBLL();
            cbEditCodModeloVehiculo.DisplayMember = "Nombre del Modelo";
            cbEditCodModeloVehiculo.ValueMember = "Código del Modelo";

            cbEditCodFisicoVehiculo.DataSource = ClienteBLL.readClienteFisicoBLL();
            cbEditCodFisicoVehiculo.DisplayMember = "Nombre del cliente";
            cbEditCodFisicoVehiculo.ValueMember = "Codigo del cliente";

        }
        public void cargarDataGridViewVehiculo() 
        {
            dgvVehiculo.DataSource = VehiculoBLL.readVehiculoBLL();
        
        }
        public void filtroDataGridViewVehiculo()
        {
            if (txtViewBuscarVehiculo.Text != "")
            {
                DataView dv = VehiculoBLL.readVehiculoBLL().DefaultView;
                //MessageBox.Show("Header: "+ dgvVehiculo.Columns[1].Name);
                dv.RowFilter = string.Format("[{0}] like '%{1}%'", dgvVehiculo.Columns[0].Name, Int32.Parse(txtViewBuscarVehiculo.Text));
                dgvVehiculo.DataSource = dv.ToTable();
            }
            else
            {
                dgvVehiculo.DataSource = VehiculoBLL.readVehiculoBLL();
            }
        }
        public void limpiarCamposNewVehiculo() 
        {
           txtNewPlacaVehiculo.Text = string.Empty;
           cbNewCodMarcaVehiculo.Text = "Seleccione";
           cbNewCodModeloVehiculo.Text = "Seleccione";
           cbNewCodFisicoVehiculo.Text = "Seleccione";
           txtNewTipoVehiculo.Text = string.Empty;
           txtNewTipoMotorVehiculo.Text = string.Empty;
           txtNewCilindrajeVehiculo.Text = string.Empty;
           cbNewTrasmisionVehiculo.Text = "Seleccione";
           txtNewAnoVehiculo.Text = string.Empty;
           cbNewGasolinaVehiculo.Text = "Seleccione";
           txtNewNumeroPuertasVehiculo.Text = string.Empty;
        }
        public void limpiarCamposEditVehiculo()
        {
            txtEditPlacaVehiculo.Text = string.Empty;
            cbEditCodMarcaVehiculo.Text = "Seleccione";
            cbEditCodModeloVehiculo.Text = "Seleccione";
            cbEditCodFisicoVehiculo.Text = "Seleccione";
            txtEditTipoVehiculo.Text = string.Empty;
            txtEditTipoMotorVehiculo.Text = string.Empty;
            txtEditCilindrajeVehiculo.Text = string.Empty;
            cbEditTrasmicionVehiculo.Text = "Seleccione";
            txtEditAnoVehiculo.Text = string.Empty;
            cbEditTipoGasolinaVehiculo.Text = "Seleccione";
            txtEditNumeroPuertasVehiculo.Text = string.Empty;
        }
        public void limpiarMemoriaVehiculo() 
        {

            VehiculoDAL.sPlacaVehiculo = string.Empty;
            VehiculoDAL.iCodMarcaVehiculo = 0;
            VehiculoDAL.iCodModeloVehiculo = 0;
            VehiculoDAL.iCodFisicoVehiculo = 0;
            VehiculoDAL.sTipoMotorVehiculo = string.Empty;
            VehiculoDAL.sTipoMotorVehiculo = string.Empty;
            VehiculoDAL.sTipoCilindrajeVehiculo = string.Empty;
            VehiculoDAL.sTipoTransmicionVehiculo = string.Empty;
            VehiculoDAL.sAnhioVehiculo = string.Empty;
            VehiculoDAL.sTipoGasolinaVehiculo = string.Empty;
            VehiculoDAL.sNumeroPuertasVehiculo = string.Empty;
            VehiculoDAL.bBandera = false;

        }
        public void cargarCamposEditVehiculo()
        {
            txtEditPlacaVehiculo.Text =              VehiculoDAL.sPlacaVehiculo;
            cbEditCodMarcaVehiculo.SelectedValue =   VehiculoDAL.iCodMarcaVehiculo;
            cbEditCodModeloVehiculo.SelectedValue =  VehiculoDAL.iCodModeloVehiculo;
            cbEditCodFisicoVehiculo.SelectedValue =  VehiculoDAL.iCodFisicoVehiculo;
            txtEditTipoVehiculo.Text =               VehiculoDAL.sTipoMotorVehiculo;
            txtEditTipoMotorVehiculo.Text =          VehiculoDAL.sTipoMotorVehiculo;
            txtEditCilindrajeVehiculo.Text =         VehiculoDAL.sTipoCilindrajeVehiculo;
            cbEditTrasmicionVehiculo.Text =          VehiculoDAL.sTipoTransmicionVehiculo;
            txtEditAnoVehiculo.Text =                VehiculoDAL.sAnhioVehiculo;
            cbEditTipoGasolinaVehiculo.Text =        VehiculoDAL.sTipoGasolinaVehiculo;
            txtEditNumeroPuertasVehiculo.Text =      VehiculoDAL.sNumeroPuertasVehiculo;
        }
        private void dgvVehiculo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVehiculo.Rows[e.RowIndex];
                VehiculoDAL.sPlacaVehiculo     =        row.Cells[0].Value.ToString();
                VehiculoDAL.iCodMarcaVehiculo  =        Int32.Parse(row.Cells[1].Value.ToString());
                VehiculoDAL.iCodModeloVehiculo =        Int32.Parse(row.Cells[2].Value.ToString());
                VehiculoDAL.iCodFisicoVehiculo =        Int32.Parse(row.Cells[3].Value.ToString());
                VehiculoDAL.sTipoVehiculo      =        row.Cells[4].Value.ToString();
                VehiculoDAL.sTipoMotorVehiculo =        row.Cells[5].Value.ToString();
                VehiculoDAL.sTipoCilindrajeVehiculo =   row.Cells[6].Value.ToString();
                VehiculoDAL.sTipoTransmicionVehiculo =  row.Cells[7].Value.ToString();
                VehiculoDAL.sAnhioVehiculo =            row.Cells[8].Value.ToString();
                VehiculoDAL.sTipoGasolinaVehiculo =     row.Cells[9].Value.ToString();
                VehiculoDAL.sNumeroPuertasVehiculo =    row.Cells[10].Value.ToString();
            }
        }

        private void txtViewBuscarVehiculo_KeyUp(object sender, KeyEventArgs e)
        {
            filtroDataGridViewVehiculo();
        }
        #endregion

        #endregion

        #region Proveedores
        #region Proveedores View
        private void tsbViewAgregarProveedor_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpNewProveedor;
        }

        private void tsbViewModificarProveedor_Click(object sender, EventArgs e)
        {
            cargarCamposEditTipoProveedor();
            tcPrincipal.SelectedTab = tpEditProveedor;
        }

        private void tsbViewEliminarProveedor_Click(object sender, EventArgs e)
        {
            ProveedorBLL.deleteProveedorBLL(ProveedorDAL);
            cargarDataGridViewProveedor();
            if (ProveedorDAL.bBandera == true)
            {
                MessageBox.Show("Fue Eliminado");
            }
            else { MessageBox.Show("No fue Eliminado"); }
            limpiarMemoriaProveedor();
        }

        private void tsbViewActualizarProveedor_Click(object sender, EventArgs e)
        {
            cargarDataGridViewProveedor();
        }

        #endregion

        #region Proveedores New
        private void tsbNewGuardarProveedor_Click(object sender, EventArgs e)
        {
            ProveedorDAL.sIdProveedor           = txtNewIdProveedor.Text;
            ProveedorDAL.sNombreProveedor       = txtNewNombreProveedor.Text;
            ProveedorDAL.sCorreoProveedor       = txtNewCorreoProveedor.Text;
            ProveedorDAL.sTelefonoProveedor     = txtNewTelefonoProveedor.Text;
            ProveedorDAL.sUbicacionProveedor    = txtNewUbicacionProveedor.Text;
            ProveedorBLL.createProveedorBLL(ProveedorDAL);
            tcPrincipal.SelectedTab = tpViewProveedor;
            cargarDataGridViewProveedor();
            if (ProveedorDAL.bBandera == true)
            {
                MessageBox.Show("Fue Creado");
            }
            else { MessageBox.Show("No fue Creado"); }
            limpiarCamposNewProveedor();
            limpiarMemoriaProveedor();
        }

        private void tsbNewCancelarProveedor_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewProveedor;
            limpiarCamposNewProveedor();
        }
        #endregion

        #region Proveedores Edit
        private void tsbEditGuadarProveedor_Click(object sender, EventArgs e)
        {
            ProveedorDAL.sIdProveedor = txtEditIdProveedor.Text;
            ProveedorDAL.sNombreProveedor = txtEditNombreProveedor.Text;
            ProveedorDAL.sCorreoProveedor = txtEditCorreoProveedor.Text;
            ProveedorDAL.sTelefonoProveedor = txtEditTelefonoProveedor.Text;
            ProveedorDAL.sUbicacionProveedor = txtEditUbicacionProveedor.Text;
            ProveedorBLL.updateProveedorBLL(ProveedorDAL);
            tcPrincipal.SelectedTab = tpViewProveedor;
            cargarDataGridViewProveedor();
            if (ProveedorDAL.bBandera == true)
            {
                MessageBox.Show("Fue Creado");
            }
            else { MessageBox.Show("No fue Creado"); }
            limpiarCamposEditProveedor();
            limpiarMemoriaProveedor();
        }

        private void tsbEditCancelarProveedor_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewProveedor;
            limpiarCamposEditProveedor();
        }
        #endregion

        #region Proveedores Metodos
        public void cargarDataGridViewProveedor()
        {
            dgvProveedor.DataSource = ProveedorBLL.readProveedorBLL();
        }
        public void filtroDataGridViewProveedor()
        {
            if (txtViewBuscarProveedor.Text != "")
            {
                DataView dv = ProveedorBLL.readProveedorBLL().DefaultView;
                //MessageBox.Show("Header: "+ dgvTipoServicio.Columns[1].Name);
                dv.RowFilter = string.Format("[{0}] like '%{1}%'", dgvProveedor.Columns[1].Name, txtViewBuscarProveedor.Text);
                dgvProveedor.DataSource = dv.ToTable();
            }
            else
            {
                dgvProveedor.DataSource = ProveedorBLL.readProveedorBLL();
            }
        }

        public void limpiarCamposNewProveedor()
        {
            txtNewIdProveedor.Text = string.Empty;
            txtNewNombreProveedor.Text = string.Empty;
            txtNewCorreoProveedor.Text = string.Empty;
            txtNewTelefonoProveedor.Text = string.Empty;
            txtNewUbicacionProveedor.Text = string.Empty;

        }
        public void limpiarCamposEditProveedor()
        {
            txtEditIdProveedor.Text = string.Empty;
            txtEditNombreProveedor.Text = string.Empty;
            txtEditCorreoProveedor.Text = string.Empty;
            txtEditTelefonoProveedor.Text = string.Empty;
            txtEditUbicacionProveedor.Text = string.Empty;

        }
        public void limpiarMemoriaProveedor()
        {
            ProveedorDAL.sIdProveedor = string.Empty;
            ProveedorDAL.sNombreProveedor = string.Empty;
            ProveedorDAL.sCorreoProveedor = string.Empty;
            ProveedorDAL.sTelefonoProveedor = string.Empty;
            ProveedorDAL.sUbicacionProveedor = string.Empty;
            ProveedorDAL.bBandera = false;
        }
        public void cargarCamposEditTipoProveedor()
        {
            txtEditIdProveedor.Text = ProveedorDAL.sIdProveedor;
            txtEditNombreProveedor.Text = ProveedorDAL.sNombreProveedor;
            txtEditCorreoProveedor.Text = ProveedorDAL.sCorreoProveedor;
            txtEditTelefonoProveedor.Text = ProveedorDAL.sTelefonoProveedor;
            txtEditUbicacionProveedor.Text = ProveedorDAL.sUbicacionProveedor;
        }
        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProveedor.Rows[e.RowIndex];
                ProveedorDAL.sIdProveedor = row.Cells[0].Value.ToString();
                ProveedorDAL.sNombreProveedor = row.Cells[1].Value.ToString();
                ProveedorDAL.sCorreoProveedor = row.Cells[2].Value.ToString();
                ProveedorDAL.sTelefonoProveedor = row.Cells[3].Value.ToString();
                ProveedorDAL.sUbicacionProveedor = row.Cells[4].Value.ToString();


            }
        }

        private void txtViewBuscarProveedor_KeyUp(object sender, KeyEventArgs e)
        {
            filtroDataGridViewProveedor();
        }

        #endregion

        #endregion

        #region Sucursal

        #region Sucursal View
        private void tsbViewAgregarSucursal_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpNewSucursal;
        }

        private void tsbViewModificarSucursal_Click(object sender, EventArgs e)
        {
            cargarCamposEditSucursal();
            tcPrincipal.SelectedTab = tpEditSucursal;
        }

        private void tsbViewEliminarSucursal_Click(object sender, EventArgs e)
        {
            SucursalBLL.deleteSucursalBLL(SucursalDAL);
            cargarDataGridViewSucursal();
            if (SucursalDAL.bBandera == true)
            {
                MessageBox.Show("Fue Eliminado");
            }
            else { MessageBox.Show("No fue Eliminado"); }
            limpiarMemoriaSucursal();
        }

        private void tsbViewActualizarSucursal_Click(object sender, EventArgs e)
        {
            cargarDataGridViewSucursal();
        }


        #endregion

        #region Sucursal New
        private void tsbNewGuardarSucursal_Click(object sender, EventArgs e)
        {
            SucursalDAL.sIdSucursal = txtNewIdSucursal.Text;
            SucursalDAL.sHorarioSucursal = txtNewHorarioSucursal.Text;
            SucursalDAL.sUbicacionSucursal = txtNewUbicacionSucursal.Text;
            SucursalDAL.sCorreoSucursal = txtNewCorreoSucursal.Text;
            SucursalDAL.sTelefonoSucursal = txtNewTelefonoSucursal.Text;
            SucursalBLL.createSucursalBLL(SucursalDAL);
            tcPrincipal.SelectedTab = tpViewSucursal;
            cargarDataGridViewSucursal();
            if (SucursalDAL.bBandera == true)
            {
                MessageBox.Show("Fue Creado");
            }
            else { MessageBox.Show("No fue Creado"); }
            limpiarCamposNewSucursal();
            limpiarMemoriaSucursal();

        }

        private void tsbNewCancelarSucursal_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewSucursal;
            limpiarCamposNewSucursal();
        }
        #endregion

        #region Sucursal Edit
        private void tsbEditGuardarSucursal_Click(object sender, EventArgs e)
        {
            SucursalDAL.sIdSucursal         = txtEditIdSucursal.Text;
            SucursalDAL.sHorarioSucursal    = txtEditHorarioSucursal.Text;
            SucursalDAL.sUbicacionSucursal  = txtEditUbicacionSucursal.Text;
            SucursalDAL.sCorreoSucursal     = txtEditCorreoSucursal.Text;
            SucursalDAL.sTelefonoSucursal   = txtEditTelefonoSucursal.Text;
            SucursalBLL.updateSucursalBLL(SucursalDAL);
            tcPrincipal.SelectedTab = tpViewSucursal;
            cargarDataGridViewSucursal();
            if (SucursalDAL.bBandera == true)
            {
                MessageBox.Show("Fue Actualizado");
            }
            else
            {
                MessageBox.Show("No fue Actualizado ");
            }
            limpiarCamposEditSucursal();
            limpiarMemoriaSucursal();

        }

        private void tsbEditCancelarSucursal_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewSucursal;
            limpiarCamposEditSucursal();
        }
        #endregion

        #region Sucursal Metodos
        public void cargarDataGridViewSucursal()
        {
            dgvSucursal.DataSource = SucursalBLL.readSucursalBLL();
            
        }
        public void filtroDataGridViewSucursal() 
        {
            if (txtViewBuscarSucursal.Text != "")
            {
                DataView dv = SucursalBLL.readSucursalBLL().DefaultView;
                //MessageBox.Show("Header: "+ dgvTipoServicio.Columns[1].Name);
                dv.RowFilter = string.Format("[{0}] like '%{1}%'", dgvSucursal.Columns[2].Name, txtViewBuscarSucursal.Text);
                dgvSucursal.DataSource = dv.ToTable();
            }
            else
            {
                dgvSucursal.DataSource = SucursalBLL.readSucursalBLL();
            }
        }
        public void limpiarCamposNewSucursal()
        {
            txtNewIdSucursal.Text = string.Empty;
            txtNewHorarioSucursal.Text = string.Empty;
            txtNewUbicacionSucursal.Text = string.Empty;
            txtNewCorreoSucursal.Text = string.Empty;
            txtNewTelefonoSucursal.Text = string.Empty;

        }
        public void limpiarCamposEditSucursal()
        {
            txtEditIdSucursal.Text = string.Empty;
            txtEditHorarioSucursal.Text = string.Empty;
            txtEditUbicacionSucursal.Text = string.Empty;
            txtEditCorreoSucursal.Text = string.Empty;
            txtEditTelefonoSucursal.Text = string.Empty;

        }
        public void limpiarMemoriaSucursal()
        {
            SucursalDAL.sIdSucursal = string.Empty;
            SucursalDAL.sHorarioSucursal = string.Empty;
            SucursalDAL.sUbicacionSucursal = string.Empty;
            SucursalDAL.sCorreoSucursal = string.Empty;
            SucursalDAL.sTelefonoSucursal = string.Empty;
            SucursalDAL.bBandera = false;
        }
        public void cargarCamposEditSucursal()
        {
            txtEditIdSucursal.Text = SucursalDAL.sIdSucursal;
            txtEditHorarioSucursal.Text = SucursalDAL.sHorarioSucursal;
            txtEditUbicacionSucursal.Text = SucursalDAL.sUbicacionSucursal;
            txtEditCorreoSucursal.Text = SucursalDAL.sCorreoSucursal;
            txtEditTelefonoSucursal.Text = SucursalDAL.sTelefonoSucursal;
        }
        private void dgvSucursal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSucursal.Rows[e.RowIndex];
                SucursalDAL.sIdSucursal = row.Cells[0].Value.ToString();
                SucursalDAL.sHorarioSucursal = row.Cells[1].Value.ToString();
                SucursalDAL.sUbicacionSucursal = row.Cells[2].Value.ToString();
                SucursalDAL.sCorreoSucursal = row.Cells[3].Value.ToString();
                SucursalDAL.sTelefonoSucursal = row.Cells[4].Value.ToString();
                //MessageBox.Show(SucursalDAL.sIdSucursal + "\n"+ SucursalDAL.sHorarioSucursal );

            }
        }
        private void txtViewBuscarSucursal_KeyUp(object sender, KeyEventArgs e)
        {
            filtroDataGridViewSucursal();
        }


        #endregion

        #endregion

        #region TipoServicio

        #region TipoServicio View
        private void tsbViewAgregarTipoServicio_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpNewTipoServicio;
        }

        private void tsbViewModificarTipoServicio_Click(object sender, EventArgs e)
        {
            cargarCamposEditTipoServicio();
            tcPrincipal.SelectedTab = tpEditTipoServicio;
        }

        private void tsbViewEliminarTipoServicio_Click(object sender, EventArgs e)
        {
            TipoServicioBLL.deleteTipoServicioBLL(TipoServicioDAL);
            cargarDataGridViewTipoServicio();
            if (TipoServicioDAL.bBandera == true)
            {
                MessageBox.Show("Fue Eliminado");
            }
            else { MessageBox.Show("No fue Eliminado"); }
            limpiarMemoriaTipoServicio();
        }

        private void tsbViewActualizarTipoServicio_Click(object sender, EventArgs e)
        {
            cargarDataGridViewTipoServicio();
        }

        #endregion

        #region TipoServicio New
        private void tsbNewGuardarTipoServicio_Click(object sender, EventArgs e)
        {
            TipoServicioDAL.sIdTipoServicio             = txtNewIdTipoServicio.Text;
            TipoServicioDAL.sDrescipcionTipoServicio    = txtNewDescripcionTipoServicio.Text;
            TipoServicioDAL.sTiempoPromedio             = txtNewTiempoPomedioTipoServicio.Text;
            TipoServicioBLL.createTipoServicioBLL(TipoServicioDAL);
            tcPrincipal.SelectedTab = tpViewTipoServicio;
            cargarDataGridViewTipoServicio();
            if (TipoServicioDAL.bBandera == true)
            {
                MessageBox.Show("Fue Creado");
            }
            else { MessageBox.Show("No fue Creado"); }
            limpiarCamposNewTiposServicio();
            limpiarMemoriaTipoServicio();
        }

        private void tsbNewCancelarTipoServicio_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewTipoServicio;
            limpiarCamposNewTiposServicio();
        }
        #endregion

        #region TipoServicio Edit
        private void tsbEditGuardarTipoServicio_Click(object sender, EventArgs e)
        {
            TipoServicioDAL.sIdTipoServicio             = txtEditIdTipoServicio.Text;
            TipoServicioDAL.sDrescipcionTipoServicio    = txtEditDescripcionTipoServicio.Text;
            TipoServicioDAL.sTiempoPromedio             = txtEditTiempoPomedioTipoServicio.Text;
            //MessageBox.Show(TipoServicioDAL.sIdTipoServicio + "\n" + TipoServicioDAL.sDrescipcionTipoServicio);
            TipoServicioBLL.updateTipoServicioBLL(TipoServicioDAL);
            tcPrincipal.SelectedTab = tpViewTipoServicio;
            cargarDataGridViewTipoServicio();
            if (TipoServicioDAL.bBandera == true)
            {
                MessageBox.Show("Fue Actualizado");
            }
            else 
            { 
                MessageBox.Show("No fue Actualizado");
            }
            limpiarCamposEditTiposServicio();
            limpiarMemoriaTipoServicio();

        }

        private void tsbEditCancelarTipoServicio_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewTipoServicio;
            limpiarCamposEditTiposServicio();
        }
        #endregion

        #region TipoServicio Metodos

        public void cargarDataGridViewTipoServicio()
        {
            dgvTipoServicio.DataSource = TipoServicioBLL.readTipoServicioBLL();
            
        }

        public void filtroDataGridViewTipoServicio() 
        {
            if (txtViewBuscarTipoServicio.Text != "")
            {
                DataView dv = TipoServicioBLL.readTipoServicioBLL().DefaultView;
                //MessageBox.Show("Header: "+ dgvTipoServicio.Columns[1].Name);
                dv.RowFilter = string.Format("[{0}] like '%{1}%'", dgvTipoServicio.Columns[1].Name, txtViewBuscarTipoServicio.Text);
                dgvTipoServicio.DataSource = dv.ToTable();
            }
            else
            {
                dgvTipoServicio.DataSource = TipoServicioBLL.readTipoServicioBLL();
            }
        }

        public void limpiarCamposNewTiposServicio() {
            txtNewIdTipoServicio.Text = string.Empty;
            txtNewDescripcionTipoServicio.Text = string.Empty;
            txtNewTiempoPomedioTipoServicio.Text = string.Empty;
        }

        public void limpiarCamposEditTiposServicio()
        {
            txtEditIdTipoServicio.Text = string.Empty;
            txtEditDescripcionTipoServicio.Text = string.Empty;
            txtEditTiempoPomedioTipoServicio.Text = string.Empty;
        }

        public void limpiarMemoriaTipoServicio() 
        {
            TipoServicioDAL.sIdTipoServicio = string.Empty;
            TipoServicioDAL.sDrescipcionTipoServicio = string.Empty;
            TipoServicioDAL.sTiempoPromedio = string.Empty;
            TipoServicioDAL.bBandera = false;
        }

        public void cargarCamposEditTipoServicio()
        {
            txtEditIdTipoServicio.Text = TipoServicioDAL.sIdTipoServicio;
            txtEditDescripcionTipoServicio.Text = TipoServicioDAL.sDrescipcionTipoServicio;
            txtEditTiempoPomedioTipoServicio.Text = TipoServicioDAL.sTiempoPromedio;
        }

        private void dgvTipoServicio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTipoServicio.Rows[e.RowIndex];
                TipoServicioDAL.sIdTipoServicio = row.Cells[0].Value.ToString();
                TipoServicioDAL.sDrescipcionTipoServicio = row.Cells[1].Value.ToString();
                TipoServicioDAL.sTiempoPromedio = row.Cells[2].Value.ToString();
            }
        }

        private void txtViewBuscarTipoServicio_KeyUp(object sender, KeyEventArgs e)
        {
            filtroDataGridViewTipoServicio();
        }



































        #endregion

        #endregion

        #region Usuario
        #region Usuario View
        private void tsbViewAgregarUsuario_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpNewUsuario;
        }

        private void tsbViewModificarUsuario_Click(object sender, EventArgs e)
        {
            cargarCamposEditUsuario();
            tcPrincipal.SelectedTab = tpEditUsuario;
        }

        private void tsbViewEliminarUsuario_Click(object sender, EventArgs e)
        {
            UsuarioBLL.deleteUsuarioBLL(UsuarioDAL);
            cargarDataGridViewUsuario();
            if (UsuarioDAL.bBandera == true)
            {
                MessageBox.Show("Fue Eliminado");
            }
            else { MessageBox.Show("No fue Eliminado"); }
            limpiarMemoriaUsuario();
        }

        private void tsbViewActualizarUsuario_Click(object sender, EventArgs e)
        {
            cargarDataGridViewUsuario();
        }

        private void txtViewBuscarUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            filtroDataGridViewUsuario();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];
                UsuarioDAL.sCodAreaUsuario = row.Cells[0].Value.ToString();
                UsuarioDAL.sCodEmpleadoUsuario = row.Cells[1].Value.ToString();
                UsuarioDAL.sNombreUsuario = row.Cells[2].Value.ToString();
                UsuarioDAL.sUsuario = row.Cells[3].Value.ToString();
                UsuarioDAL.sContrasena = row.Cells[4].Value.ToString();
            }
        }
            #endregion
        #region Usuario New
        private void tsbNewGuardarUsuario_Click(object sender, EventArgs e)
        {
            UsuarioDAL.sCodAreaUsuario = txtArea_Usuario.Text;
            UsuarioDAL.sCodEmpleadoUsuario = txtCodEmpleado_Usuario.Text;
            UsuarioDAL.sNombreUsuario = txtNombre_Usuario.Text;
            UsuarioDAL.sUsuario = txtUsuario_Usuario.Text;
            UsuarioDAL.sContrasena = txtContrasena_Usuario.Text;
            UsuarioBLL.createUsuarioBLL(UsuarioDAL);
            tcPrincipal.SelectedTab = tpViewUsuario;
            cargarDataGridViewUsuario();
            if (UsuarioDAL.bBandera == true)
            {
                MessageBox.Show("Fue Creado");
            }
            else { MessageBox.Show("No fue Creado"); }
            limpiarCamposNewUsuario();
            limpiarMemoriaUsuario();

        }

        private void tsbNewCancelarUsuario_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewUsuario;
            limpiarCamposNewUsuario();
        }
        #endregion
        #region Usuario Edit
        private void tsbEditGuardarUsuario_Click(object sender, EventArgs e)
        {
            UsuarioDAL.sCodAreaUsuario = txtArea_ModificarUsuario.Text;
            UsuarioDAL.sCodEmpleadoUsuario = txtCodEmpleado_ModificarUsuario.Text;
            UsuarioDAL.sNombreUsuario = txtNombre_ModificarUsuario.Text;
            UsuarioDAL.sUsuario = txtUsuario_ModificarUsuario.Text;
            UsuarioDAL.sContrasena = txtContrasena_ModificarUsuario.Text;
            UsuarioBLL.updateUsuarioBLL(UsuarioDAL);
            tcPrincipal.SelectedTab = tpViewUsuario;
            cargarDataGridViewUsuario();
            if (UsuarioDAL.bBandera == true)
            {
                MessageBox.Show("Fue Actualizado");
            }
            else { MessageBox.Show("No fue Actualizado"); }
            limpiarCamposEditUsuario();
            limpiarMemoriaUsuario();
        }

        private void tsbEditCancelarUsuario_Click(object sender, EventArgs e)
        {
            tcPrincipal.SelectedTab = tpViewUsuario;
            limpiarCamposEditUsuario();
        }
        #endregion
        #region Usuario Metodo
        public void cargarDataGridViewUsuario()
        {
            dgvUsuarios.DataSource = UsuarioBLL.readUsuarioBLL();
        }
        public void filtroDataGridViewUsuario()
        {
            if (txtViewBuscarUsuario.Text != "")
            {
                DataView dv = UsuarioBLL.readUsuarioBLL().DefaultView;
                //MessageBox.Show("Header: "+ dgvTipoServicio.Columns[1].Name);
                dv.RowFilter = string.Format("[{0}] like '%{1}%'", dgvUsuarios.Columns[2].Name, txtViewBuscarUsuario.Text);
                dgvUsuarios.DataSource = dv.ToTable();
            }
            else
            {
                dgvUsuarios.DataSource = UsuarioBLL.readUsuarioBLL();
            }
        }
        public void limpiarCamposNewUsuario()
        {
            txtArea_Usuario.Text = string.Empty;
            txtCodEmpleado_Usuario.Text = string.Empty;
            txtNombre_Usuario.Text = string.Empty;
            txtUsuario_Usuario.Text = string.Empty;
            txtContrasena_Usuario.Text = string.Empty;
        }
        public void limpiarCamposEditUsuario()
        {
            txtArea_ModificarUsuario.Text = string.Empty;
            txtCodEmpleado_ModificarUsuario.Text = string.Empty;
            txtNombre_ModificarUsuario.Text = string.Empty;
            txtUsuario_ModificarUsuario.Text = string.Empty;
            txtContrasena_ModificarUsuario.Text = string.Empty;
        }
    
         public void limpiarMemoriaUsuario()
        {
            UsuarioDAL.sCodAreaUsuario = string.Empty;
            UsuarioDAL.sCodEmpleadoUsuario = string.Empty;
            UsuarioDAL.sNombreUsuario = string.Empty;
            UsuarioDAL.sUsuario = string.Empty;
            UsuarioDAL.sContrasena = string.Empty;
        }
        public void cargarCamposEditUsuario()
        {
            txtArea_ModificarUsuario.Text = UsuarioDAL.sCodAreaUsuario;
            txtCodEmpleado_ModificarUsuario.Text = UsuarioDAL.sCodEmpleadoUsuario;
            txtNombre_ModificarUsuario.Text = UsuarioDAL.sNombreUsuario;
            txtUsuario_ModificarUsuario.Text = UsuarioDAL.sUsuario;
            txtContrasena_ModificarUsuario.Text = UsuarioDAL.sContrasena;
        }
        #endregion
        #endregion

        #endregion




        #region Validación Keypress

        #region MétodosValidación
        private void ValidarNumeros(TextBox txt, KeyPressEventArgs evt)
        {
            if (char.IsNumber(evt.KeyChar))
            {
                evt.Handled = false;
            }
            else
            {
                if (evt.KeyChar == 8) //Espacio
                {
                    evt.Handled = false;
                }
                else
                {
                    if (evt.KeyChar == Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString().Trim())) //SeparadorDecimal
                    {
                        if (txt.Text.Contains(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString()))
                        {
                            evt.Handled = true;
                        }
                        else
                        {
                            if ((txt.SelectionStart != 0) && (txt.SelectionStart != txt.Text.Length))
                            {
                                evt.Handled = false;
                            }
                            else
                            {
                                evt.Handled = true;
                            }
                        }
                    }
                    else
                    {
                        if (evt.KeyChar == 45) //SignoNegativo
                        {
                            if (txt.Text.Contains("-"))
                            {
                                evt.Handled = true;
                            }
                            else
                            {
                                if (txt.SelectionStart != 0)
                                {
                                    evt.Handled = true;
                                }
                                else
                                {
                                    evt.Handled = false;
                                }
                            }
                        }
                        else
                        {
                            evt.Handled = true;
                        }
                    }
                }
            }
        }

        private void ValidarLetras(TextBox txt, KeyPressEventArgs evt)
        {
            if (char.IsLetter(evt.KeyChar))
            {
                evt.Handled = false;
            }
            else
            {
                if (char.IsNumber(evt.KeyChar))
                {
                    evt.Handled = true;
                }

            }

        }

        #endregion

        #region AgregarProductos
        private void txtCodProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeros(txtCodProducto, e);
        }

        private void txtNombreProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarLetras(txtCodProducto, e);
        }

        private void txtNewCantidadInventario_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeros(txtCodProducto, e);
        }










        #endregion

        #endregion

        
    }
}
