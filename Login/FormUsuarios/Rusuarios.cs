using Login.Entidades;
using Login.FormUsuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Login.Usuarios
{
    public partial class Rusuarios : System.Windows.Forms.Form
    {
        public Rusuarios()
        {
            InitializeComponent();
            MensajeerrorProvider.SetError(ContraseñatextBox, "Solo se permiten 6 Caracteres!!");
            MensajeerrorProvider.SetError(ConfirmartextBox, "Solo se permiten 6 Caracteres!!");

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IDnumericUpDown.Value = 0;
            UsuariotextBox.Clear();
            NombretextBox.Clear();
            ContraseñatextBox.Clear();
            ConfirmartextBox.Clear();
            FechadateTimePicker.Value = DateTime.Now;
            ComentariotextBox.Clear();
            LimpiarError();
        }

        private void LimpiarError()
        {
            IDerrorProvider.Clear();
            UsuarioerrorProvider.Clear();
            NombreerrorProvider.Clear();
            ContraseñaerrorProvider.Clear();
            ComentarioerrorProvider.Clear();
        }

        private int SetError(int error)
        {
            int paso = 0;
            List<Usuario> user = new List<Usuario>();
            if(error ==1&& IDnumericUpDown.Value == 0)
            {
               
                IDerrorProvider.SetError(IDnumericUpDown, "Llenar Campo!!");
                paso = 1;
                return paso;
                    
                
            }
            if(error ==2&& UsuariotextBox.Text==string.Empty)
            {
                UsuarioerrorProvider.SetError(UsuariotextBox, "Llenar Campo!!");
                paso = 1;
               
            }
            if(error==2&& NombretextBox.Text==string.Empty)
            {
                NombreerrorProvider.SetError(NombretextBox, "Llenar Campo!!");
                paso = 1;
            }
            if (error == 2 && ContraseñatextBox.Text == string.Empty)
            {
                ContraseñaerrorProvider.SetError(ContraseñatextBox, "Llenar Campo!!");
                paso = 1;
            }
            if (error == 2 && ConfirmartextBox.Text == string.Empty)
            {
                ContraseñaerrorProvider.SetError(ConfirmartextBox, "Llenar Campo!!");
                paso = 1;
            }
            if (error == 2 && ComentariotextBox.Text == string.Empty)
            {
                ComentarioerrorProvider.SetError(ComentariotextBox, "Llenar Campo!!");
                paso = 1;
            }
            if(error ==3 && ContraseñatextBox.Text != ConfirmartextBox.Text)
            {
                ContraseñaerrorProvider.SetError(ConfirmartextBox, "Llenar Campo!!");
                ContraseñaerrorProvider.SetError(ContraseñatextBox, "Llenar Campo!!");
                paso = 1;
            }

            if(error ==4 &&BLL.UsuarioBLL.GetList(t => t.NUsuario == UsuariotextBox.Text).Exists(t => t.NUsuario == UsuariotextBox.Text))
            {
                UsuarioerrorProvider.SetError(UsuariotextBox, "Debe de crear otro usuario!!");
                paso = 1;
            }


            return paso;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            LimpiarError();
            if(SetError(2)==1)
            {
                MessageBox.Show("Campos Vacios!!");
                return;
            }
            if (SetError(4) == 1)
            {
                MessageBox.Show("Usuario existente!!");
                return;
            }
            Usuario user = LlenaClase();
            if(IDnumericUpDown.Value ==0)
            {
                if(user ==null)
                {
                    return;
                }

                if(BLL.UsuarioBLL.Guardar(user))
                 {
                     MessageBox.Show("Guardado!!");
                 }
            }
            else
            {
                if (user == null)
                {
                    return;
                }
                if(SetError(1)==1)
                {
                    MessageBox.Show("Campos Vacios!!");
                    return;
                }
                if (BLL.UsuarioBLL.Modificar(LlenaClase()))
                {
                    MessageBox.Show("Modificado!!");
                }
            }

        }

        private Usuario LlenaClase()
        {
            Usuario user = new Usuario();
            user.Id = Convert.ToInt32(IDnumericUpDown.Value);
            user.NUsuario = UsuariotextBox.Text;
            user.Nombre= NombretextBox.Text;
            if(SetError(3)==0)
            {
                user.Clave = ContraseñatextBox.Text;
            }
            else
            {
                MessageBox.Show("Las contraseñas son diferentes");
                user = null;
                return user;
            }
            user.Fecha = FechadateTimePicker.Value;
            user.Comentario = ComentariotextBox.Text;





            return user;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            if(SetError(1)==1)
            {
                MessageBox.Show("Campos Vacios!!");
                return;
            }
            if(BLL.UsuarioBLL.Buscar(Convert.ToInt32(IDnumericUpDown.Value))==null)
            {
                MessageBox.Show("Usuario no encontrado");
                return;
            }
           var user =  BLL.UsuarioBLL.Buscar(Convert.ToInt32(IDnumericUpDown.Value));
            UsuariotextBox.Text = user.NUsuario;
            NombretextBox.Text = user.Nombre;
            ConfirmartextBox.Text = user.Clave;
            ContraseñatextBox.Text = user.Clave;
            FechadateTimePicker.Value = user.Fecha;
            ComentariotextBox.Text = user.Comentario;
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if(SetError(1)==1)
            {
                MessageBox.Show("Campos Vacios!!");
                return;
            }
            if(BLL.UsuarioBLL.Eliminar(Convert.ToInt32(IDnumericUpDown.Value)))
            {
                MessageBox.Show("Eliminado");
            }
        }

        private void Consultabutton_Click(object sender, EventArgs e)
        {
            CUsuarios abrir = new CUsuarios();
            abrir.Show();
        }
    }
}
