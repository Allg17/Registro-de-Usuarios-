using Login.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace Login.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> user { get; set; }

        public Contexto() : base("ConStr")
        {
        }
    }
}
