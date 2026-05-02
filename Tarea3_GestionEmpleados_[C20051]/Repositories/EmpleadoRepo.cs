using Microsoft.EntityFrameworkCore;
using Tarea3_GestionEmpleados__C20051_.Models;
using Tarea3_GestionEmpleados__C20051_.Data;

namespace Tarea3_GestionEmpleados__C20051_.Repositories
{
  

    public class EmpleadoRepo : IEmpleadoRepo
    {
        private readonly AppDbContext _context;

        public EmpleadoRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Empleado> ObtenerTodos()
        {
            return _context.Empleados.ToList();
        }

        public Empleado ObtenerPorId(int id)
        {
            return _context.Empleados.Find(id);
        }

        public IEnumerable<Empleado> BuscarPorNombreODepartamento(string termino)
        {
            return _context.Empleados
                .Where(e => e.Nombre.ToLower().Contains(termino.ToLower()) ||
                            e.Apellido.ToLower().Contains(termino.ToLower()) ||
                            e.Departamento.ToLower().Contains(termino.ToLower()))
                .ToList();
        }

        public IEnumerable<Empleado> ObtenerPaginado(int pagina, int tamano, string busqueda)
        {
            var query = _context.Empleados.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(e =>
                    e.Nombre.ToLower().Contains(busqueda.ToLower()) ||
                    e.Apellido.ToLower().Contains(busqueda.ToLower()) ||
                    e.Departamento.ToLower().Contains(busqueda.ToLower()));
            }

            return query
                .Skip((pagina - 1) * tamano)
                .Take(tamano)
                .ToList();
        }

        public int ContarTotal(string busqueda)
        {
            var query = _context.Empleados.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(e =>
                    e.Nombre.ToLower().Contains(busqueda.ToLower()) ||
                    e.Apellido.ToLower().Contains(busqueda.ToLower()) ||
                    e.Departamento.ToLower().Contains(busqueda.ToLower()));
            }

            return query.Count();
        }

        public void Agregar(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
        }

        public void Actualizar(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var emp = _context.Empleados.Find(id);
            if (emp != null)
            {
                _context.Empleados.Remove(emp);
                _context.SaveChanges();
            }
        }
    }
}
