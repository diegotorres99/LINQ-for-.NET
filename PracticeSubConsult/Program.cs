using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeSubConsult
{
    public enum Departamento
    {
        RH = 201,
        Desarrollo = 520,
        Soporte = 402,
        Admin = 309
    }
    class Empleado
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Departamento Departamento { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Empleado> employees = new List<Empleado>()
            {
                new Empleado {
                    Nombre = "Daniela",
                    Apellido = "Pérez",
                    Departamento = Departamento.Desarrollo
                },
                new Empleado {
                    Nombre = "José",
                    Apellido = "Lima Rico",
                    Departamento = Departamento.Admin
                },
                 new Empleado {
                    Nombre = "Fernanda",
                    Apellido = "Vega Valle",
                    Departamento = Departamento.Desarrollo
                },
                  new Empleado {
                    Nombre = "Fabiola",
                    Apellido = "Cortés Vázquez",
                    Departamento = Departamento.Desarrollo
                },
                   new Empleado {
                    Nombre = "Mónica",
                    Apellido = "Correa",
                    Departamento = Departamento.Soporte
                },
            };
            var newEmployees = new List<Empleado>
            {
                new Empleado
                {
                    Nombre = "Fabricio",
                    Apellido = "Cordero",
                    Departamento = Departamento.Desarrollo
                },
                new Empleado
                {
                    Nombre = "Julia",
                    Apellido = "Lombardo",
                    Departamento = Departamento.Admin
                },
            };
            // Add new
            employees.AddRange(newEmployees);
            /*var subq = empleados.Where(e => e.Nombre.Length == empleados
                                            .OrderBy(eb => eb.Apellido.Length)
                                            .Select(eb => eb.Apellido.Length)
                                            .First());*/
            /*var subq = from e in empleados
                       where e.Nombre.Length ==
                       (from eb in empleados
                        orderby eb.Apellido.Length
                        select eb.Apellido.Length
                       ).First()
                       select e;*/

            var subq = from e in employees
                       where e.Nombre.Length ==
                        employees.OrderBy(eb => eb.Apellido.Length).First().Apellido.Length
                       select e;

            var encabezado = string.Format("{0,-20} {1}",
                            "Nombre", "Apellido");
            Console.WriteLine(encabezado);

            foreach (var f in subq)
            {
                string fila = string.Format("{0,-20} {1}",
                    f.Nombre, f.Apellido);
                Console.WriteLine(fila);
            }
        }
    }
}
