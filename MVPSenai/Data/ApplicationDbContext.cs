using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVPSenai.Models;

namespace MVPSenai.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Setor> setores { get; set; }
        public DbSet<Funcionario> funcionarios { get; set; }
        public DbSet<Logs> logs { get; set; }
    }
}