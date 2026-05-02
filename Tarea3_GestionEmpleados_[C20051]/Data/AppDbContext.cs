namespace Tarea3_GestionEmpleados__C20051_.Data
{
    using Microsoft.EntityFrameworkCore;
    using Tarea3_GestionEmpleados__C20051_.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) 
        { }
        public DbSet<Empleado> Empleados { get; set;}

    }
}
