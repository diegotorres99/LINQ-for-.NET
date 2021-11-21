using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace json_object
{
    class Program
    {
        static void Main(string[] args)
        {
            JObject obj = JObject.Parse(@"{
            'nombre': 'John Doe',
            'nivel':'Junior',
              'edad': 22,
              'lenguajes': [ '.NET', 'PHP' ]
            }");
            //Get value from JSON Obj
            string level = (string)obj["nivel"];
            Console.WriteLine(level);
            // Show all lenguages
            IList<string> lenguajes = obj["lenguajes"].Select(l => (string)l).ToList();
            foreach (var l in lenguajes)
            {
                Console.WriteLine(l);
            }
        }

    }
    
}
