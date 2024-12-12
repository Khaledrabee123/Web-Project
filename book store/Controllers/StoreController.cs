using AutoMapper;
using book_store.models.database;
using book_store.models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using store.Models.DTO;

namespace book_store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private Ibook _bookDB ;
        private readonly IMapper _mapper;
       
     
        public StoreController(Ibook ibook, IMapper mapper)
        {
            _bookDB = ibook;
            _mapper = mapper;
           
        }

        [HttpGet("AllBooks")]
        public IActionResult Books()
        {
                  

            return Ok(_bookDB.GetAllBooks());
        }
        [HttpPost("AddBook")]
        public IActionResult AddBook(BookDTO bookDTO)
        {
           if (ModelState.IsValid)
            {
                Book book = _mapper.Map<Book>(bookDTO);
                _bookDB.AddBock(book);
                return Created();
            }

            return BadRequest();
           
        }

        [HttpGet("GetBook")]
        public IActionResult GetBook(int id )
        {
            return Ok(_mapper.Map<BookDTO>(_bookDB.Getbook(id)));

        }

        [HttpPut("UpdateBook")]
        public IActionResult UpdateBook(BookDTO book)
        {
            if (ModelState.IsValid)
            {
                _bookDB.updateBook(_mapper.Map<Book>(book));
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("DeleteBook")]
        public IActionResult DeleteBook(int id )
        {
            if (ModelState.IsValid)
            {
                _bookDB.Deletebook(id);
                return Ok();
            }
            return BadRequest();
        }

    }
}
