using Microsoft.EntityFrameworkCore;
using WebAPI_Video.Models;

namespace WebAPI_Video.DataContext
{
    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<FuncionarioModel> Funcionarios { get; set; }
    }
}
