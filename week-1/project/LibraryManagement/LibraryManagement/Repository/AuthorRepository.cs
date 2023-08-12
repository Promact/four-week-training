using LibraryManagement.Models;
using LibraryManagement.Repository.IRepository;

namespace LibraryManagement.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly List<Author> _author;
        public AuthorRepository(List<Author> author) : base(author)
        {
            _author = author;
        }

        public void Update(int index, Author entity)
        {
            _author[index] = entity;
        }
    }
}
