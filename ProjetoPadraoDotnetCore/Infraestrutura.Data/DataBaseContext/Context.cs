using System.Reflection;
using Infraestrutura.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.DataBaseContext
{
    public class Context : DbContext
    {
        // option passado na DependcyInjectory no build da apresentation 
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // para reconhecer o mapping automatico, não precisa injetar
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //Injeção dos dataSets
        public DbSet<SkillUsuario> SkillUsuario { get; set; } = null;
        public DbSet<Usuario> Usuario { get; set; } = null;

    }
}