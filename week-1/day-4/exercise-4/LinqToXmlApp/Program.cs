using System.Xml.Linq;

namespace LinqToXmlApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Assume there is an XML document with the following structure:
            // <Books>
            //     <Book>
            //         <Title>Book Title 1</Title>
            //         <Author>Author 1</Author>
            //         <Genre>Genre 1</Genre>
            //     </Book>
            //     ...
            // </Books>
            // Write above book structure as a c# string
            string xmlString = @"<Books>
                                    <Book>
                                        <Title>Book Title 1</Title>
                                        <Author>Author 1</Author>
                                        <Genre>Genre 1</Genre>
                                    </Book>
                                    <Book>
                                        <Title>Book Title 2</Title>
                                        <Author>Author 2</Author>
                                        <Genre>Genre 2</Genre>
                                    </Book>
                                    <Book>
                                        <Title>Book Title 3</Title>
                                        <Author>Author 3</Author>
                                        <Genre>Genre 3</Genre>
                                    </Book>
                                </Books>";

            // Create an XDocument object from the XML string
            // Write the title of all books to the console
            // Write the title of all books with genre "Genre 1" to the console

            // Create an XDocument object from the XML string
            XDocument xdoc = XDocument.Parse(xmlString);

            // Write the title of all books to the console
            Console.WriteLine("Titles of all books:");
            foreach (var titleElement in xdoc.Descendants("Title"))
            {
                Console.WriteLine(titleElement.Value);
            }

            Console.WriteLine();

            // Write the title of all books with genre "Genre 1" to the console
            Console.WriteLine("Titles of books with genre 'Genre 1':");
            foreach (var bookElement in xdoc.Descendants("Book"))
            {
                XElement? genreElement = bookElement.Element("Genre");
                if (genreElement != null && genreElement.Value == "Genre 1")
                {
                    XElement? titleElement = bookElement.Element("Title");
                    if (titleElement != null)
                    {
                        Console.WriteLine(titleElement.Value);
                    }
                }
            }

        }
    }
}