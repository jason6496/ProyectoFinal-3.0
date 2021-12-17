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

namespace PL_ProyectoFinal.Pantallas.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        clsLoginDAL LoginDAL = new clsLoginDAL();
        clsLoginBLL LoginBLL = new clsLoginBLL();
        Pantallas.Principal.frmPrincipal Principal = new Pantallas.Principal.frmPrincipal();

        public static string sUsuarioNombre, sArea;

        private void frmLogin_Load(object sender, EventArgs e)
        {
            var color = Color.FromArgb(200, 54, 54, 54);
            pLogin.BackColor = color;
            txtContrasena.PasswordChar = '*';
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Pantallas.Principal.frmPrincipal principal = new Pantallas.Principal.frmPrincipal();
            //principal.ShowDialog();
            login();
        }

      


        #region Login Metodos
        public void login() 
        {
            DataTable dt = new DataTable();
            LoginDAL.sUsuario = txtUsuario.Text;
            LoginDAL.sClave = txtContrasena.Text;

            dt = LoginBLL.filtrarLoginBLL(LoginDAL);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bienvenid@ " + dt.Rows[0][1].ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sUsuarioNombre = dt.Rows[0][1].ToString();
                sArea = dt.Rows[0][0].ToString();

                Principal.ShowDialog();

                frmLogin login = new frmLogin();
                login.ShowDialog();

                if (login.DialogResult == DialogResult.OK)
                    Application.Run(new Pantallas.Principal.frmPrincipal());

                txtUsuario.Clear();
                txtContrasena.Clear();

            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrecta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }
        #endregion
    }
}
