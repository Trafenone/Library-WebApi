using AutoMapper;
using Library.Data;
using Library.Models.DTO;
using Library.Models.Repository;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Text.Json;

namespace Library.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookController> _logger;

        public BookController(IConfiguration configuration, IRepository repository, IMapper mapper, ILogger<BookController> logger)
        {
            _configuration = configuration;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [Route("books")]
        [HttpGet]
        public async Task<IActionResult> Books(string order)
        {
            _logger.LogInformation("Executing [HttpGet] {Action} with parameters: {Parameters}",
                nameof(Books), JsonSerializer.Serialize(order));

            var books = await _repository.GetBooks();

            var booksOrdered = _mapper.Map<List<BookOrdered>>(books);

            if (order.ToLower() == "author")
                return Ok(booksOrdered.OrderBy(x => x.Author));
            else if (order.ToLower() == "title")
                return Ok(booksOrdered.OrderBy(x => x.Title));

            return BadRequest("Order is not valid");
        }

        [Route("recommended")]
        [HttpGet]
        public async Task<IActionResult> GetBookByGenre(string? genre)
        {
            _logger.LogInformation("Executing [HttpGet] {Action} with parameters: {Parameters}",
                nameof(GetBookByGenre), JsonSerializer.Serialize(genre));

            var books = await _repository.GetBooks();

            var booksDTO = _mapper.Map<List<BookOrdered>>(books);

            if (genre == null)
            {
                var result = booksDTO.OrderByDescending(x => x.Rating)
                    .Where(x => x.ReviewsNumber > 10)
                    .Take(10);

                return result != null ? Ok(result) : NotFound("There are no books");
            }
            else
            {
                books = books.Where(x => x.Genre.ToLower() == genre.ToLower()).ToList();

                booksDTO = _mapper.Map<List<BookOrdered>>(books);

                var result = booksDTO.OrderByDescending(x => x.Rating).ToList();

                return result != null ? Ok(result) : NotFound("This genre does not exist");
            }
        }

        [Route("books/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetBookDetails(int id)
        {
            _logger.LogInformation("Executing [HttpGet] {Action} with parameters: {Parameters}",
                nameof(GetBookDetails), JsonSerializer.Serialize(id));

            var books = await _repository.GetBooks();

            var booksDTO = _mapper.Map<List<BookDetail>>(books);

            var result = booksDTO.FirstOrDefault(x => x.Id == id);

            return result != null ? Ok(result) : NotFound("There are not books");
        }

        [Route("books/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id, string secret)
        {
            _logger.LogInformation("Executing [HttpDelete] {Action} with parameters: {Parameters}, {Secret}",
                nameof(Delete), JsonSerializer.Serialize(id), JsonSerializer.Serialize(secret));

            if (secret != _configuration["SecretKey"])
                return BadRequest();

            await _repository.DeleteBook(id);

            return Ok();
        }

        [Route("books/save")]
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(BookDto book)
        {
            _logger.LogInformation("Executing [HttpPost] {Action} with parameters: {Parameters}",
                nameof(CreateOrUpdate), JsonSerializer.Serialize(book));

            if (!ModelState.IsValid)
                return BadRequest();

            var input = _mapper.Map<Book>(book);

            if (book.Id == 0)
                return Ok(await _repository.SaveBook(input));
            else
                return Ok(await _repository.UpdateBook(input));
        }

        [Route("books/{id}/review")]
        [HttpPut]
        public async Task<IActionResult> SaveReview(int id, ReviewDto review)
        {
            _logger.LogInformation("Executing [HttpPut] {Action} with parameters: id: {Parameters}, Review: {review}",
                nameof(SaveReview), JsonSerializer.Serialize(id), JsonSerializer.Serialize(review));

            if (!ModelState.IsValid)
                return BadRequest();

            var input = _mapper.Map<Review>(review);
            input.BookId = id;

            int result = await _repository.SaveReview(input);

            return Ok(result);
        }

        [Route("books/{id}/rate")]
        [HttpPut]
        public async Task<IActionResult> SaveRating(int id, RatingDto rating)
        {
            _logger.LogInformation("Executing [HttpPut] {Action} with parameters: id: {Parameters}, Rating: {review}",
                nameof(SaveReview), JsonSerializer.Serialize(id), JsonSerializer.Serialize(rating));

            if (!ModelState.IsValid)
                return BadRequest();

            var input = _mapper.Map<Rating>(rating);
            input.BookId = id;

            int result = await _repository.SaveRating(input);

            return Ok(result);
        }
    }
}
