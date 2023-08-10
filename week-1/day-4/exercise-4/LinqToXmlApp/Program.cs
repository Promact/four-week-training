using System;
using System.Linq;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace Day4_Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XElement xmlDoc = XElement.Load("C:\\Users\\admin\\source\\repos\\Hiren\\four-weeks-training\\week-1\\day-4\\exercise-4\\LinqToXmlApp\\Temp.xml");
            Console.WriteLine(xmlDoc);

            string targetGenre = "Novel";
            var booksInGenre = xmlDoc.Descendants("Book")
                                     .Where(book => (string)book.Element("Genre") == targetGenre);

            Console.WriteLine($"Books in the '{targetGenre}' genre:");
            foreach (var book in booksInGenre)
            {
                Console.WriteLine($"Title: {book.Element("Title").Value}");
                Console.WriteLine($"Author: {book.Element("Author").Value}");
                Console.WriteLine($"Genre: {book.Element("Genre").Value}");
                Console.WriteLine();
            }

            string myXML = @"
                        <Books>
                        <Book>
		                <Title>To Kill a Wolf</Title>
		                        <Author>Harry Styles</Author>
		                        <Genre>Novel</Genre>
	                    </Book>
                        </Books>";

            XDocument xdoc = new XDocument();
            xdoc = XDocument.Parse(myXML);

            var result = xdoc.Element("Books").Descendants();

            Console.WriteLine("After adding new element : ");
            foreach (XElement item in result)
            {
                Console.WriteLine(item.Value);
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();

        }
    }
}