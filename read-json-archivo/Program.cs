using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace read_json_archivo
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"C:\Users\ADD-YOUR-PATH\source\repos\ConsoleApp1\empleados.json";
            //Get Employees
            var emloployee = GetEmployees(file);
            //Filter using LINQ and Lambda
            var name = emloployee.Where(e => e.age <= 20)
                                  .Select(e => e.Nombre).FirstOrDefault();
            Console.WriteLine(name);

        }

        /// <summary>
        /// Read and deserialize .json file into Object
        /// </summary>
        /// <param name="file">Path of .json file</param>
        /// <returns> List of Employees</returns>
        static List<Employee> GetEmployees(string file)
        {
            List<Employee> listE = new List<Employee>();
            using (System.IO.StreamReader r = new System.IO.StreamReader(file))
            {
                string json = r.ReadToEnd();
                //Use JSON NewtonSoft
                listE = JsonConvert.DeserializeObject<List<Employee>>(json);
            }
            return listE;
        }
        //Employees Class
        public enum Departamento
        {
            RH = 201,
            Desarrollo = 520,
            Soporte = 402,
            Admin = 309
        }
        class Employee
        {
            public Guid Id { get; } = Guid.NewGuid();
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int age { get; set; }
            public Departamento Departamento { get; set; }
        }
    }
}
