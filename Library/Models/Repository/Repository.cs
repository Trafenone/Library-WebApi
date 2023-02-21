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
            return await _context.Books
                .Include(b => b.Reviews)
                .Include(b => b.Ratings)
                .ToListAsync();
        }

        public async Task DeleteBook(int id)
        {
            Book? book = _context.Books.Where(x => x.Id == id).FirstOrDefault();

            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<int> SaveBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task<int> UpdateBook(Book book)
        {
            if (!_context.Books.Any(x => x.Id == book.Id))
                return 0;

            _context.Update(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task<int> SaveRating(Rating rating)
        {
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();

            return rating.Id;
        }

        public async Task<int> SaveReview(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();

            return review.Id;
        }
    }
}
