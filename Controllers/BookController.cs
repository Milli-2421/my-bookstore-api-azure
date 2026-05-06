using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDeploymentLab.Models;
using WebAPIDeploymentLab.Repos.Interface;

namespace WebAPIDeploymentLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRrepos _bookRepo;

        public BookController(IBookRrepos bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var books = await _bookRepo.GetAllAsync();
            return Ok(books);
        }

        [HttpPost]

        public async Task<ActionResult<Book>>  CreateBook(Book book)
        { 
        var created = await _bookRepo.AddAsync(book);
            return CreatedAtAction(nameof(GetBooks), new { id = created.Id }, created);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, Book book)
        {
            var updatedBook = await _bookRepo.UpdateAsync(id, book);

            if (updatedBook == null)
            {
                return NotFound();
            }

            return Ok(updatedBook);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBook(int id)
        //{
        //    var deleted = await _bookRepo.DeleteAsync(id);

        //    if (!deleted)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}
    }
}
