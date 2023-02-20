using Library.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Models.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public void DeleteBook(int id)
        {
            Book? book = _context.Books.Where(x => x.Id == id).FirstOrDefault();

            if(book != null)
            {
                _context.Books.Remove(book);
            }

            _context.SaveChanges();
        }

        public int SaveBook(Book book)
        {
            throw new NotImplementedException();
        }

        public int SaveRating(int id)
        {
            throw new NotImplementedException();
        }

        public int SaveReview(int id)
        {
            throw new NotImplementedException();
        }
    }
}
