using System;
using System.Collections.Generic;
using System.Linq;

namespace Operator_04
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
            internal int Monto;

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
            Console.WriteLine("Operators 4");
            List<Empleado> employees = new List<Empleado>()
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
                    Pagos = new List<Pago>
                    {
                        new Pago
                        {
                            Descripcion = "Quincena #1: Diciembre",
                            Fecha = new DateTime(2020,12,15),
                            Monto = 15000.95f,
                            Procesado = true,
                        },
                    }
                },
                   new Empleado {
                    Nombre = "Mónica",
                    Apellido = "Correa",
                    Departamento = Departamento.Soporte,
                    Edad = 22,
                    IdExterno = 5,
                    Pagos = new List<Pago>
                    {
                        new Pago
                        {
                            Descripcion = "Quincena #21: Noviembre",
                            Fecha = new DateTime(2020,11,15),
                            Monto = 18000.95f,
                            Procesado = true,
                        },
                        new Pago
                        {
                            Descripcion = "Quincena #22: Noviembre",
                            Fecha = new DateTime(2020,11,30),
                            Monto = 20000.95f,
                            Procesado = false,
                        }
                    }
                },
            };

            //First
            var payments = employees.FirstOrDefault(p => p.Monto < 500);
            //Single
            var singlePay = employees.SingleOrDefault(p => p.Monto == 200);
            //Element 
            var thePay = employees.ElementAt(1);
        }
    }
}
