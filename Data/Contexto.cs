using JuegoTotalApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoTotalApi.Data
{
    public class Contexto : DbContext
    {
        public Contexto()
        {

        }

        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {

        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<RoleGame> RoleGames { get; set; }
        public DbSet<JuegoTotalApi.Models.Playing> Playing { get; set; }



    }
}
