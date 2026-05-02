namespace Tarea3_GestionEmpleados__C20051_.Models {
    using System.ComponentModel.DataAnnotations;

    public class Empleado
    {
        public int Id { get; set;}

        [Required]
        [StringLength(100)]
        public string Nombre { get; set;}

        [Required]
        [StringLength(100)]
        public string Apellido { get; set;}

        [Required]
        public string Departamento { get; set;}

        [Required]
        [Range(400000, 10000000)]
        public decimal Salario { get; set;}

        public DateTime FechaIngreso { get; set;}

        public bool Activo { get; set;}

        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}
