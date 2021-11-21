using System;
using System.Collections.Generic;
using System.Linq;

namespace Operators_01
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
            public int Edad { get; internal set; }
            public int IdExterno { get; internal set; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Operator 1");
            List<Empleado> empleados = new List<Empleado>()
            {
                new Empleado {
                    Nombre = "Daniela",
                    Apellido = "Pérez",
                    Departamento = Departamento.Desarrollo,
                    Edad = 29,
                    IdExterno = 1
                },
                new Empleado {
                    Nombre = "José",
                    Apellido = "Lima Rico",
                    Departamento = Departamento.Admin,
                    Edad = 40,
                    IdExterno = 2
                },
                 new Empleado {
                    Nombre = "Fernanda",
                    Apellido = "Vega Valle",
                    Departamento = Departamento.Desarrollo,
                    Edad = 35,
                    IdExterno = 3
                },
                  new Empleado {
                    Nombre = "Fabiola",
                    Apellido = "Cortés Vázquez",
                    Departamento = Departamento.Desarrollo,
                    Edad = 25,
                    IdExterno = 4,

                },
                   new Empleado {
                    Nombre = "Mónica",
                    Apellido = "Correa",
                    Departamento = Departamento.Soporte,
                    Edad = 22,
                    IdExterno = 5,
                },
            };
            //Reverse
            var filter = empleados.Where(e => e.Edad <= 30).Reverse();
            PrintEmployees(filter, "Using Reverse");
            //Skip Filter
            var fs = filter.Skip(1);
            PrintEmployees(fs, "Using Skip");
            //Take While
            var ftw = filter.TakeWhile(e => e.Edad <= 25);
            PrintEmployees(ftw, "Using TakeWhile");
            //Group, order and filter --->
            var fog = empleados.Where(e => e.Edad <= 30)
                .OrderBy(e => e.Nombre)
                .GroupBy(e => e.Departamento);
            PrintEmployees((IEnumerable<Empleado>)fog, "Using Several Extension Methods");
        }
        static void PrintEmployees(IEnumerable<Empleado> list, string v, string title = "/** --- ** /")
        {
          

            Console.WriteLine(title);
            var encabezado = string.Format("{0,-40} {1,-10} {2,-20} {3,-10} {4}",
                           "ID", "Nombre", "Apellido", "Edad", "Departamento");
            Console.WriteLine(encabezado);
            foreach (var el in list)
            {
                PrintEmployee(el);
            }
        }

        private static void PrintEmployee(Empleado e)
        {
            string fila = string.Format("{0,-40} {1,-10} {2,-20} {3,-10} {4}",
                   e.Id, e.Nombre, e.Apellido, e.Edad, e.Departamento);
            Console.WriteLine(fila);
        }
    }
}

