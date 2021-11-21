using System;
using System.Collections.Generic;
using System.Linq;

namespace Operators_05
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
            internal int IdExternoEmpleado;

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
            Console.WriteLine("Operator 05");
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

            var nPayment = new List<Pago>
            {
                new Pago
                {
                    Descripcion = "Quincena Junio",
                    Fecha = new DateTime(2020,06,15),
                    Monto = 12000.95f,
                    Procesado = true,
                    IdExternoEmpleado = 2
                },
                new Pago
                {
                    Descripcion = "Quincena Septiembre",
                    Fecha = new DateTime(2020,06,30),
                    Monto = 22000.95f,
                    Procesado = false,
                    IdExternoEmpleado = 3
                },
                new Pago
                {
                    Descripcion = "Bono Diciembre",
                    Fecha = new DateTime(2020,12,15),
                    Monto = 50000.00f,
                    Procesado = true,
                    IdExternoEmpleado = 3
                }
            };

            //Join
            var empleadosPagos = employees.Join(nPayment,
                                     emp => emp.IdExterno,
                                     pago => pago.IdExternoEmpleado,
                                     (emp, pago) => new
                                     {
                                         emp.Nombre,
                                         pago.Monto
                                     });
            var empleadosPagosGrupo = employees.GroupJoin(nPayment,
                emp => emp.IdExterno,
                pago => pago.IdExternoEmpleado,
                (emp, pagos) => new
                {
                    Empleado = emp.Nombre,
                    PagosAgregados = pagos
                });

            foreach (var e in empleadosPagosGrupo)
            {
                if (e.PagosAgregados.Count() > 0)
                    Console.WriteLine(e.Empleado);
                foreach (var p in e.PagosAgregados)
                    Console.WriteLine(p.Monto);
            }
        }
    }
}
