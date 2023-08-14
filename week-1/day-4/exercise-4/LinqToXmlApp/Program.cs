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
            XDocument doc = new XDocument();
            doc = XDocument.Parse(xmlString);

            // Write the title of all books to the console
            var title = doc.Element("Books").Descendants();
            Console.WriteLine("Titles of all books:");
            
            foreach ( var item in title ) 
            {
                Console.WriteLine(item.Value);
            }
            // Write the title of all books with genre "Genre 1" to the console
            var xdoc = doc.Element("Books").Descendants();

            Console.WriteLine("The title of all books with genre - Genre 1 is: ");

            foreach ( var item in xdoc )
            {
                XElement titlegenre = item.Element("Genre");
                if (titlegenre != null && titlegenre.Value == "Genre 1")
                {
                    Console.WriteLine(item.Value);
                }
            }
        }
    }
}