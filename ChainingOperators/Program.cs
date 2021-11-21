using System;
using System.Collections.Generic;
using System.Linq;

namespace ChainingOperators
{
    class Program
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

        static void Main(string[] args)
        {
            List<Empleado> empleados = new List<Empleado>()
            {
                new Empleado {
                    Nombre = "Daniela",
                    Apellido = "Pérez",//5
                    Departamento = Departamento.Desarrollo
                },
                new Empleado {
                    Nombre = "José",
                    Apellido = "Lima Rico",//9
                    Departamento = Departamento.Admin
                },
                 new Empleado {
                    Nombre = "Fernanda",
                    Apellido = "Vega Valle",//10
                    Departamento = Departamento.Desarrollo
                },
                  new Empleado {
                    Nombre = "Fabiola",
                    Apellido = "Cortés Vázquez",//14
                    Departamento = Departamento.Desarrollo
                },
                   new Empleado {
                    Nombre = "Mónica",
                    Apellido = "Correa",//6
                    Departamento = Departamento.Soporte
                },
            };

            var filtro = empleados.Where(e => (e.Departamento == Departamento.Desarrollo
                                                || e.Departamento == Departamento.Soporte)
                                                && e.Apellido.ToLower().StartsWith("c"))
                .OrderByDescending(e => e.Nombre)
                .Select(e => new
                {
                    e.Nombre,
                    e.Apellido,
                    Depto = e.Departamento
                });
            //El largo del nombre del empleado sea igual al largo del apellido
            // más corto
            //Sub Consulta

            var subq = empleados.Where(e => e.Nombre.Length == empleados
                                            .OrderBy(eb => eb.Apellido.Length) //Order
                                            .Select(eb => eb.Apellido.Length)  //Take
                                            .First());
            //Sub Consult Expresions
            var subExpression = from e in empleados
                                where e.Nombre.Length ==
                                (from eb in empleados
                                 orderby eb.Apellido.Length
                                 select eb.Apellido.Length
                                ).First()
                                select e;
            //Other Way to obtain same result
            var subq1 = from e in empleados
                        where e.Nombre.Length ==
                        empleados.OrderBy(eb => eb.Apellido.Length).First().Apellido.Length
                        select e;
            var encabezado = string.Format("{0,-20} {1,-20} {2}",
                            "Nombre", "Apellido", "Codigo Depto");
            Console.WriteLine(encabezado);

            foreach (var f in subq)
            {
                string fila = string.Format("{0,-20} {1,-20} {2}",
                    f.Nombre, f.Apellido);
                Console.WriteLine(fila);
            }

            var qe = from e in empleados
                     where (e.Departamento == Departamento.Desarrollo
                            || e.Departamento == Departamento.Soporte)
                            && e.Apellido.ToLower().StartsWith("c")
                     orderby e.Nombre descending
                     select new
                     {
                         e.Nombre,
                         e.Apellido,
                         Depto = e.Departamento
                     };
            Console.WriteLine();
            foreach (var f in qe)
            {
                string fila = string.Format("{0,-20} {1,-20} {2}",
                    f.Nombre, f.Apellido, f.Depto);
                Console.WriteLine(fila);
            }


        }
    }
}
