using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsultOperators
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
        class Pago
        {
            public string Descripcion { get; set; }
            public DateTime Fecha { get; set; }
            public double Monto { get; set; }
            public bool Procesado { get; set; }
        }
        class Empleado
        {
            public Guid Id { get; } = Guid.NewGuid();
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public Departamento Departamento { get; set; }
            public int Edad { get; internal set; }
            public int IdExterno { get; internal set; }
            public List<Pago> Pagos { get; internal set; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Consult Operators");
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

            var emp = employees.Where(u => u.Departamento == Departamento.Desarrollo
                                && u.Nombre.ToLower().Contains("f")).OrderBy(u => u.Id);
            //Consult
            var filter = employees.Where(u => u.Departamento == Departamento.Desarrollo
                                && u.Nombre.ToLower().Contains("f"))
                                   .OrderBy(u => u.Id)
                                   .Select(u => new
                                   {
                                       u.Id,
                                       u.Nombre,
                                       InicialAp = u.Apellido.Substring(0, 1),
                                       Depto = u.Departamento.ToString()
                                   });
            //Sub Colsult
            var subq = employees.Where(e => e.Apellido.Split()
            .LastOrDefault().StartsWith("V"));

            var encabezado = string.Format("{0,-40} {1,-10} {2,-10} {3}",
               "ID", "Nombre", "Apellido", "Departamento");

            Console.WriteLine(encabezado);

            foreach (var f in emp)
            {
                string fila = string.Format("{0,-40} {1,-10} {2,-10} {3}",
                    f.Id, f.Nombre, f.Id, f.Nombre);
                Console.WriteLine(fila);
            }


            foreach (var f in filter)
            {
                string fila = string.Format("{0,-40} {1,-10} {2,-10} {3}",
                    f.Id, f.Nombre, f.InicialAp, f.Depto);
                Console.WriteLine(fila);
            }

        }
    }
}
