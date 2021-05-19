using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moonlay.ELibrary.Application.Interfaces;
using Moonlay.ELibrary.Application.Models;
using Moonlay.ELibrary.Domain.Interfaces;

namespace Moonlay.ELibrary.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BooksController : ControllerBase
    {
        #region Private Members

        private readonly IRentBookService bookService;
        private readonly ILibraryRepository repository;
        private readonly ILogger<BooksController> logger;

        #endregion

        #region Constructor

        public BooksController(ILogger<BooksController> logger, IRentBookService bookService, ILibraryRepository repository)
        {
            this.logger = logger;
            this.bookService = bookService;
            this.repository = repository;
        }

        #endregion

        [HttpGet]
        public ActionResult Get()
        {
            var book = repository.GetBook();
            return Ok(book);
        }

        [HttpGet, Route("{id}")]
        public ActionResult Get(int id)
        {
            var book = repository.GetBook(id);
            return Ok(book);
        }

       


    }
}
