using Login.Entidades;
using Login.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace Login
{
    public partial class Login : System.Windows.Forms.Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Loginbutton_Click(object sender, EventArgs e)
        {
            int paso = 0;
            Expression<Func<Usuario, bool>> filtrar = x =>true;
            List<Usuario> user = new List<Usuario>();

            limpiarError();
            filtrar = t => t.NUsuario.Contains(UsuariologtextBox.Text);
            user = BLL.UsuarioBLL.GetList(filtrar);
            if(UsuariologtextBox.Text==string.Empty )
            {
                paso = 1;
                UsuarioerrorProvider.SetError(UsuariologtextBox, "Incorrecto");
                
            }
            if(ClavetextBox.Text == string.Empty)
            {
                paso = 1;
                ClaveerrorProvider.SetError(ClavetextBox, "Incorrecto");
               
            }
            if(paso ==1)
            {
                MessageBox.Show("Campos Vacios!!");
                return;
            }

            if(user.Exists(x => x.NUsuario == UsuariologtextBox.Text)&& user.Exists(x => x.Clave == ClavetextBox.Text))
            {
                Rusuarios abrir = new Rusuarios();
                abrir.Show();
                
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrecta!!");
                ClaveerrorProvider.SetError(ClavetextBox, "Incorrecto");
                UsuarioerrorProvider.SetError(UsuariologtextBox, "Incorrecto");

            }
            ClavetextBox.MaxLength = 14;

        }

        void limpiarError()
        {
            ClaveerrorProvider.Clear();
            UsuarioerrorProvider.Clear();
        }
       
    }
}
