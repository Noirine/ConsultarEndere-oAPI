using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultarEndereçoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultarEndereçoAPI.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }   
    }
}
