using System;
using System.Collections.Generic;
using System.Linq;

namespace Sub_Consult
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
            List<Empleado> employees = new List<Empleado>()
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

            var subC = employees.Where(e => e.Apellido.Split()
            .LastOrDefault().StartsWith("V"));

            var encabezado = string.Format("{0,-20} {1,-20} {2}",
                            "Nombre", "Apellido", "Codigo Depto");
            Console.WriteLine(encabezado);

            foreach (var f in subC)
            {
                string fila = string.Format("{0,-20} {1,-20} {2}",
                    f.Nombre, f.Apellido, f.Departamento);
                Console.WriteLine(fila);
            }
        }
    }
}
