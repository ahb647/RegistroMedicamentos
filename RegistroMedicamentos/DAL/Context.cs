using RegistroMedicamentos.Models;
using Microsoft.EntityFrameworkCore;



namespace RegistroMedicamentos.DAL
{
    
        public class Context : DbContext
        {

            public Context(DbContextOptions<Context> options) : base(options) { }

            public DbSet<Medicamentos> medicamentos { get; set; }

        }
    

}
