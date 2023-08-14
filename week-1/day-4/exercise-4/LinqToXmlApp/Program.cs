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
            XDocument xDocument = XDocument.Parse(xmlString);

            // Write the title of all books to the console
            var allTitles = from book in xDocument.Descendants("Book")
                            select book.Element("Title").Value;

            Console.WriteLine("All Book Titles:");
            foreach (var title in allTitles)
            {
                Console.WriteLine(title);
            }

            Console.WriteLine();

            // Write the title of all books with genre "Genre 1" to the console
            var genre1Titles = from book in xDocument.Descendants("Book")
                               where book.Element("Genre").Value == "Genre 1"
                               select book.Element("Title").Value;

            Console.WriteLine("Book Titles in Genre 1:");
            foreach (var title in genre1Titles)
            {
                Console.WriteLine(title);
            }

        }
    }
}
