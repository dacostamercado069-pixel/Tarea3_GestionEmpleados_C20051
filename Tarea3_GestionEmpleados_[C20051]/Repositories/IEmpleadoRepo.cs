using Tarea3_GestionEmpleados__C20051_.Models;
namespace Tarea3_GestionEmpleados__C20051_.Repositories
{
    public interface IEmpleadoRepo
    {
        IEnumerable<Empleado> ObtenerTodos();
        Empleado ObtenerPorId(int id);

        IEnumerable<Empleado> BuscarPorNombreODepartamento(string termino);

        IEnumerable<Empleado> ObtenerPaginado(int pagina, int tamano, string busqueda);
        int ContarTotal(string busqueda);

        void Agregar(Empleado empleado);
        void Actualizar(Empleado empleado);
        void Eliminar(int id);
    }
}
