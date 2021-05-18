using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moonlay.ELibrary.Application.Interfaces;
using Moonlay.ELibrary.Application.Models;
using Moonlay.ELibrary.Application.Models.Request;
using Moonlay.ELibrary.Domain.Interfaces;

namespace Moonlay.ELibrary.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentController : ControllerBase
    {
        #region Private Members

        private readonly IRentBookService bookService;
        private readonly ILibraryRepository repository;
        private readonly ILogger<CustomersController> logger;

        #endregion

        #region Constructor

        public PaymentController(ILogger<CustomersController> logger, IRentBookService bookService, ILibraryRepository repository)
        {
            this.logger = logger;
            this.bookService = bookService;
            this.repository = repository;
        }

        #endregion

        [HttpGet, Route("{id}")]
        public ActionResult Get(int id)
        {
            var cust = repository.GetCustomer(id);
            return Ok(cust);
        }

        [HttpPost]
        public ActionResult Add([FromBody] RentBookRequest request)
        {
            var response = bookService.PaymentAsync(request);

            return Ok(response.Result);
        }


    }
}
