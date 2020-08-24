using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevIO.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public IConfiguration Configuration { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public DbSet<DevIO.App.ViewModels.FornecedorViewModel> FornecedorViewModel { get; set; }

        public DbSet<DevIO.App.ViewModels.ProdutoViewModel> ProdutoViewModel { get; set; }
    }
}
