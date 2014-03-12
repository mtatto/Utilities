using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace XmlParser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            XmlReader reader = XmlReader.Create(new StringReader(Resource1.String1));
            XElement root1 = XElement.Load(reader);

            XmlReader reader2 = XmlReader.Create(new StringReader(Resource1.String1));
            XElement root2 = XElement.Load(reader2);

            XmlReader reader3 = XmlReader.Create(new StringReader(Resource1.String1));
            XElement root3 = XElement.Load(reader3);

            Console.WriteLine("-------Orginal XML File------");
            Console.WriteLine(root1);
            root2.UpdateSingleXmLElement("//lab[@type='hemo']/foo", "UpdatedValue");
            Console.WriteLine();
            Console.WriteLine("-------Single Value Changed XML File------");
            Console.WriteLine(root2);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-------Orginal XML File------");
            Console.WriteLine(root1);

            var xpathsValues = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("//lab[@type='hemo']/bar", "ABCDEF"),
                new Tuple<string, string>("//lab[@type='hemo1']/order", "COOL"),
                new Tuple<string, string>("//lab[@type='hemo2']/foo", "BAAAAAA")
            };

            root2.UpdateXmLElements(xpathsValues);
            Console.WriteLine(root3);

            Console.WriteLine("-------Compare XML Files------");
            bool areEqual = String.Equals(root1.ToString(), root2.ToString(), StringComparison.Ordinal);
            Console.WriteLine("{0}and {1} are equal? {2}", "root1", "root2", areEqual);

            //Another way to compare
            Console.WriteLine(XNode.DeepEquals(root1, root2));

            Console.ReadLine();
        }
    }
}