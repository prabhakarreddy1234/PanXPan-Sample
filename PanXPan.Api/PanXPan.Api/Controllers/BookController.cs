using Marvin.JsonPatch;
using PanXPan.Api.Interfaces;
using PanXPan.Api.Mappings;
using PanXPan.Api.Representations;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace PanXPan.Api.Controllers
{
    public class BookController : ApiController
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository BookRepository)
        {
            _bookRepository = BookRepository;
        }

        /// <summary>
        ///     Get Books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Books", Name = "GetBooks")]
        public async Task<IHttpActionResult> Get()
        {
            var result = await _bookRepository.Get();
            return Ok(result.ToRepresentation());
        }

        /// <summary>
        ///     Get Book by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Book/{id:guid}", Name = "GetBookById")]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var result = await _bookRepository.GetById(id);
            return Ok(result.ToRepresentation());
        }

        /// <summary>
        ///     Update Book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Book"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Book/{id:guid}", Name = "UpdateBook")]
        public async Task<IHttpActionResult> UpdateBook([FromUri]Guid id, [FromBody] BookRepresentation Book)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _bookRepository.Update(id, Book.ToEntity());
            return Ok();
        }

        /// <summary>
        ///     Add Book
        /// </summary>
        /// <param name="Book"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Book", Name = "AddBook")]
        public async Task<IHttpActionResult> AddBook([FromBody] BookRepresentation Book)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _bookRepository.Add(Book.ToEntity());
            return Ok(result.ToRepresentation());
        }

        /// <summary>
        ///     Update Book partially
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Book"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("Book/{id:guid}", Name = "PatchBook")]
        public async Task<IHttpActionResult> PatchBook(Guid id, [FromBody] JsonPatchDocument<BookRepresentation> Book)
        {
            //used this library -  https://github.com/KevinDockx/JsonPatch

            var result = await _bookRepository.Patch(id, Book.ToEntity());
            return Ok(result.ToRepresentation());
        }

        /// <summary>
        ///     Delete Book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Book/{id:guid}", Name = "DeleteBook")]
        public async Task<IHttpActionResult> DeleteBook(Guid id)
        {
            return Ok(await _bookRepository.Delete(id));
        }
    }
}
