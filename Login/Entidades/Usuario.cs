using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Login.Entidades
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string NUsuario { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        

        public Usuario(int id,string usuario, string nombre, string clave, DateTime fecha, string comentario)
        {
            this.Id = id;
            this.NUsuario = usuario;
            this.Nombre = nombre;
            this.Clave = clave;
            this.Fecha = fecha;
            this.Comentario = comentario;
           
        }

        public Usuario()
        {
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Clave = string.Empty;
            this.Fecha = DateTime.Now;
            this.Comentario = string.Empty;
        }
    }
}
