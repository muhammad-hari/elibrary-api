using Moonlay.ELibrary.Application.Interfaces;
using Moonlay.ELibrary.Application.Models;
using Moonlay.ELibrary.Application.Models.Request;
using Moonlay.ELibrary.Application.Models.Response;
using Moonlay.ELibrary.Domain.Interfaces;
using Moonlay.ELibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moonlay.ELibrary.Application.Services
{
    public class RentBookService : IRentBookService
    {

        #region Private Members

        private readonly ILibraryRepository repository;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RentBookService(ILibraryRepository repository)
        {
            this.repository = repository;
        }

        #endregion

        public async Task<RentBookResponse> PaymentAsync(RentBookRequest request)
        {
           List<RentalDto> rentList = new List<RentalDto>();

           int invoiceID = repository.CreateInvoice(new Payment()
            {
                AdminId = request.AdminID,
                CustomerId = request.CustomerID,
                Date = request.CreatedDate,
                TotalCost = request.BookItems.Sum(x => x.Cost),
                CreatedDate = request.CreatedDate,
            });


            foreach (var item in request.BookItems)
            {
                await repository.AddRentalAsync(new RentDetail()
                {
                    BookId = item.BookID,
                    Cost = item.Cost,
                    PaymentId = invoiceID,
                    DateOfReturn = item.DateOfReturn,
                    DateOfBorrow = item.DateOfBorrow,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                });

                var book = repository.GetBook(item.BookID);

                rentList.Add(new RentalDto()
                {
                    Cost = item.Cost,
                    DateOfReturn = item.DateOfReturn,
                    DateOfBorrow = item.DateOfBorrow,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    Book = new BookDto()
                    {
                        ID = book.Id,
                        Author = book.Author,
                        ISBN = book.Isbn,
                        Title = book.Title,
                        ReleaseDate = book.ReleaseDate,
                        CreatedDate = book.CreatedDate,
                        CreatedBy = book.CreatedBy,

                    },
                });

            }


            return await Task.FromResult(new RentBookResponse()
            {
               InvoiceID = invoiceID,
               EmployeeName = repository.GetEmployee(request.AdminID).FirstName,
               CustomerName = repository.GetCustomer(request.CustomerID).FirstName,
               TotalCost = request.BookItems.Sum(x => x.Cost),
               Data = rentList,
               TransactionDate = request.CreatedDate
            });
        }



    }
}
