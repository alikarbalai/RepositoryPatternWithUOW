using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;


namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {
        public BooksRepository(ApplicationDbContext context):base(context)
        {
        }
        public IEnumerable<Book> GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}
