using System;

public class Empleado
{
    public enum Departamento
    {
        RH = 201,
        Desarrollo = 520,
        Soporte = 402,
        Admin = 309
    }
    class Empleados
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Departamento Departamento { get; set; }
    }
}
