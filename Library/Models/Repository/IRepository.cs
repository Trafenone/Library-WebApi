using Library.Data;

namespace Library.Models.Repository
{
    public interface IRepository
    {
        public Task<List<Book>> GetBooks();
        public int SaveBook(Book book);
        public void DeleteBook(int id);
        public int SaveReview(int id);
        public int SaveRating(int id);
    }
}
