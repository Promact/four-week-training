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
            XDocument bookDocument = XDocument.Parse(xmlString);

            // Write the title of all books to the console
            Console.WriteLine("Titles of all books:");
            foreach (var book in bookDocument.Descendants("Book"))
            {
                Console.WriteLine(book.Element("Title").Value);
            }

            // Write the title of all books with genre "Genre 1" to the console
            Console.WriteLine("\nTitles of books with genre 'Genre 1':");
            var genre1Books = bookDocument.Descendants("Book")
                .Where(book => book.Element("Genre").Value == "Genre 1");

            foreach (var book in genre1Books)
            {
                Console.WriteLine(book.Element("Title").Value);
            }
        }
    }
}