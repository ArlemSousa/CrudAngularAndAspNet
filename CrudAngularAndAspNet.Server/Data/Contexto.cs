using Microsoft.EntityFrameworkCore;

namespace CrudAngularAndAspNet.Server.Models
{
    public class Contexto : DbContext
    {

        public DbSet<Pessoa> pessoas { get; set; }  

        public Contexto(DbContextOptions<Contexto> options) : base(options) { 
        
        
        }

    }
}
