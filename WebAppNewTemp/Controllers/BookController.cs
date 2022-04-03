using Microsoft.AspNetCore.Mvc;
using WebAppNewTemp.Models;
using WebAppNewTemp.Models.Servises;

namespace WebAppNewTemp.Controllers
{
    public class BookController : Controller
    {
        private IBookSerivce _bookSerivce;

        public BookController(IBookSerivce bookSerivce)
        {
            _bookSerivce=bookSerivce;
        }

        [HttpGet("[controller]/")]
        public IActionResult GetAll()
        {
            return View(_bookSerivce.GetAll());
        }

        [HttpDelete("[controller]/")]
        public void DeleteBook(int id)
        {
            _bookSerivce.Delete(id);
        }

        [HttpPost("[controller]/")]
        public int AddBook([FromBody]Book book)
        {
            var id=_bookSerivce.Add(book);
            return id;
        }


        public IActionResult Index()
        {
            
            return View();
        }

    }
}
