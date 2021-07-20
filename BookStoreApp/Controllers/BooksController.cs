using BookStore.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices _bookServices;
        public BooksController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }


        IMongoClient mongoClient = new MongoClient("mongodb://127.0.0.1:27017");

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookServices.GetBooks());
        }

        [HttpGet("single")]
        public IActionResult GetBook(string _id)
        {
            return Ok(_bookServices.GetBook(_id));
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            return Ok(_bookServices.PostBook(book));
        }

        [HttpPut]
        public IActionResult Put(Book book)
        {
            return Ok(_bookServices.UpdateBook(book));
        }

        [HttpDelete]
        public IActionResult Delete(string _id)
        {
            return Ok(_bookServices.DeleteBook(_id));
        }
    }
}
