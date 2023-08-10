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
                                        <Title>A Suitable Boy</Title>
                                        <Author>Vikram Seth</Author>
                                        <Genre>Novel</Genre>
                                    </Book>
                                    <Book>
                                        <Title>The Alchemist</Title>
                                        <Author>Paulo Coelho</Author>
                                        <Genre>Fiction</Genre>
                                    </Book>
                                    <Book>
                                        <Title>Turbulence</Title>
                                        <Author>Samit Basu</Author>
                                        <Genre>Science Fiction</Genre>
                                    </Book>
                                </Books>";

            // Create an XDocument object from the XML string
            XDocument doc = XDocument.Parse(xmlString);

            // Query for books in a specific genre.
            string genre = "Novel";
            var bookGener = doc.Root.Elements("Book").Where(book => book.Element("Genre").Value == genre);

            // Modify the XML document by adding a new book or updating existing book information.
            XElement newBook = new XElement("Book",
                new XElement("Title", "New Book"),
                new XElement("Author", "New Author"),
                new XElement("Genre", "Fantasy"));

            doc.Root.Add(newBook);

            // Updating existing book information.
            var updateBook = doc.Root.Elements("Book").FirstOrDefault(book => book.Element("Title").Value == "A Suitable Boy");

            if (updateBook != null)
            {
                updateBook.Element("Author").Value = "Updated Author";
            }

            // The Modified file savaed to this Location.
            doc.Save("C:\\Users\\admin\\source\\repos\\Day-2\\four-weeks-training\\week-1\\day-4\\exercise-4\\LinqToXmlApp\\Modified_Books.xml");

            Console.WriteLine($"Books in specific {genre} genre: ");
            foreach (var book in bookGener)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Title: {book.Element("Title").Value}");
                Console.WriteLine($"Author: {book.Element("Author").Value}");
                Console.WriteLine($"Genre: {book.Element("Genre").Value}");
                Console.ResetColor();
            }

        }
    }
}