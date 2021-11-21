using System;
using System.Linq;
using System.Xml.Linq;

namespace LinqXml
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"C:\Users\YOUR-PATH\source\repos\ConsoleApp1\payments.xml";
            var docXml = XDocument.Load(file);

            var pagos = docXml.Descendants("payment").
                Where(p => p.Attribute("process")?.Value == "true")
                //Using Tupple
                .Select(p => new Tuple<string, bool, string, float>
                    (
                        p.Attribute("idEmpleado").Value,
                        bool.Parse(p.Attribute("firmado").Value),
                        p.Element("descripcion").Value,
                        float.Parse(p.Element("montoBase").Value)
                    ));
        }
    }
}
