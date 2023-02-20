using Library.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository _repository;

        public BookController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Books(string orderBy)
        {
            return Ok(await _repository.GetBooks());
        }
    }
}
