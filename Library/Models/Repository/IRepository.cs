using Library.Data;

namespace Library.Models.Repository
{
    public interface IRepository
    {
        public Task<List<Book>> GetBooks();
        public Task<int> SaveBook(Book book);
        public Task DeleteBook(int id);
        public Task<int> UpdateBook(Book book);
        public Task<int> SaveReview(Review review);
        public Task<int> SaveRating(Rating rating);
    }
}
