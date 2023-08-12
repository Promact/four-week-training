using LibraryManagement.Models;
using LibraryManagement.Repository.IRepository;

namespace LibraryManagement.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly List<Book> _books;
        public BookRepository(List<Book> book) : base(book)
        {
            _books = book;
        }

        public void Update(int index, Book entity)
        {
            _books[index] = entity;
        }
    }
}
