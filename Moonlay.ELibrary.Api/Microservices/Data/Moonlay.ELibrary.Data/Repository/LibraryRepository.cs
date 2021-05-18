using Moonlay.ELibrary.Domain.Interfaces;
using System.Linq;
using Moonlay.ELibrary.Data.Models;
using Moonlay.ELibrary.Domain.Models;
using System.Threading.Tasks;

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

        public Book GetBook(int id)
        {
            return context.Book.Where(x => x.Id == id)
                .SingleOrDefault();
        }

        #endregion

        #region Rental

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
