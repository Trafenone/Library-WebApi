using AutoMapper;
using Library.Data;
using Library.Models.DTO;
using Library.Models.Repository;
using Library.Task3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Task3
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public TaskController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Route("save")]
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(BookDto book)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var input = _mapper.Map<Book>(book);

            if (book.Id == 0)
                return Ok(await _repository.SaveBook(input));
            else
                return Ok(await _repository.UpdateBook(input));
        }

        [Route("book/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetBook(int id)
        {
            var books = await _repository.GetBooks();

            var booksDto = _mapper.Map<List<BookDto>>(books);

            var result = booksDto.FirstOrDefault(x => x.Id == id);

            return result != null ? Ok(result) : NotFound("There are not books");
        }

        [Route("books")]
        [HttpGet]
        public async Task<IActionResult> GetBooks(string rule)
        {
            var books = await _repository.GetBooks();

            var booksDto = _mapper.Map<List<BookTask>>(books);

            if (rule != "all")
            {
                var result = booksDto.OrderByDescending(x => x.Rating)
                    .Where(x => x.ReviewsNumber > 10)
                    .Take(10);

                return result != null ? Ok(result) : NotFound("There are no books");
            }
            else
                return Ok(booksDto);
        }

        [Route("bookDetail/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetBookDetail(int id)
        {
            var books = await _repository.GetBooks();

            var booksDto = _mapper.Map<List<BookTaskDetail>>(books);

            var result = booksDto.FirstOrDefault(x => x.Id == id);

            return result != null ? Ok(result) : NotFound("There are not books");
        }
    }
}
