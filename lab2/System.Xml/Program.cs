using System;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        XmlDocument xml_doc = new XmlDocument();
        xml_doc.Load("lab.xml");

        XmlNodeList nodes = xml_doc.SelectNodes("/garden/flower");

        foreach (XmlNode flower_node in nodes)
        {
            string flower = flower_node.SelectSingleNode("title").InnerText;
            string country = flower_node.SelectSingleNode("country").InnerText;
            Console.WriteLine("Name of flower: " + flower);
            Console.WriteLine("Country: " + country);
            Console.WriteLine();
        }
    }
}
