using Moonlay.ELibrary.Domain.Interfaces;
using System.Linq;
using Moonlay.ELibrary.Data.Models;
using Moonlay.ELibrary.Domain.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Moonlay.ELibrary.Data.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        #region Private Members

        private readonly ELibraryContext context;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LibraryRepository(ELibraryContext context)
        {
            this.context = context;
        }

        #endregion


        #region Employee

        public Admin GetEmployee(int id)
        {
            return context.Admin.Where(x => x.Id == id)
                .SingleOrDefault();
        }

        #endregion

        #region Customers

        public IEnumerable<Customer> GetCustomer() => context.Customer;

        public Customer GetCustomer(int id)
        {
            return context.Customer.Where(x => x.Id == id)
                .SingleOrDefault();
        }

        public void AddCustomer(Customer customer)
        {
            context.Customer.Add(customer);
            context.SaveChanges();
        }

        #endregion

        #region Books

        public IEnumerable<Book> GetBook() => context.Book;

        public Book GetBook(int id)
        {
            return context.Book.Where(x => x.Id == id)
                .SingleOrDefault();
        }

        #endregion

        #region Rental

        public List<dynamic> GetInvoice(int paymentID)
        {
            var data = (from rd in context.RentDetail 
                        join b in context.Book on rd.BookId equals b.Id
                        join p in context.Publisher on b.PublisherId equals p.Id
                        where rd.PaymentId == paymentID select new
                        {
                            Cost = rd.Cost,
                            DateOfReturn = rd.DateOfReturn,
                            DateOfBorrow = rd.DateOfBorrow,
                            CreatedBy = rd.CreatedBy,
                            CreatedDate = rd.CreatedDate,
                            Book = new Book()
                            {
                                Id = b.Id,
                                Author = b.Author,
                                Isbn = b.Isbn,
                                Title = b.Title,
                                ReleaseDate = b.ReleaseDate,
                                CreatedDate = b.CreatedDate,
                                CreatedBy = b.CreatedBy,
                                Publisher = p
                            }
                        }).ToList();

            return data.ToList<dynamic>();

        }

        public void AddRental(RentDetail rental)
        {
            context.RentDetail.Add(rental);
            context.SaveChanges();
        }

        public async Task<int> AddRentalAsync(RentDetail rental)
        {
            await context.RentDetail.AddAsync(rental);
            return await context.SaveChangesAsync();
        }

        #endregion

        #region Invoice

        public int CreateInvoice(Payment item)
        {
            context.Payment.Add(item);
            context.SaveChanges();

            return item.Id;

        }

        #endregion
    }
}
