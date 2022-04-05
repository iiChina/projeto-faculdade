using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto.Context
{
    public class Contexto : DbContext
    {
        public Contexto() : base("Projeto")
        {
        }

        public DbSet<FilmeModel> Filmes { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
    }
}