using Login.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace Login.FormUsuarios
{
    public partial class CUsuarios : Form
    {
        public CUsuarios()
        {
            InitializeComponent();
        }

        private void Consultabutton_Click(object sender, EventArgs e)
        {
            int id;


            Expression<Func<Usuario, bool>> filtrar = x => true;

            switch (TipocomboBox.SelectedIndex)
            {
                //ID
                case 0:
                    id = int.Parse(CriteriotextBox.Text);
                    filtrar = t => t.Id == id;
                    break;
                //Nombre
                case 1:
                   
                    filtrar = t => t.Nombre.Contains(CriteriotextBox.Text);
                    break;
                //fecha
                case 2:
                        filtrar = t => (t.Fecha >= AHoradateTimePicker1.Value) && (t.Fecha <= FInaldateTimePicker2.Value);
                    break;
                //Usuario
                case 3:
                    
                    filtrar = t => t.NUsuario.Contains(CriteriotextBox.Text);
                    break;
                //Clave
                case 4:
                    
                    filtrar = t => t.Clave.Contains(CriteriotextBox.Text);
                    break;
                //Comentario
                case 5:
                 
                    filtrar = t => t.Comentario.Contains(CriteriotextBox.Text);
                    break;
            }


            ConsultadataGridView.DataSource = BLL.UsuarioBLL.GetList(filtrar);
        }
    }
}
