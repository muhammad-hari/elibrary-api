using Moonlay.ELibrary.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moonlay.ELibrary.Domain.Interfaces
{
    public interface ILibraryRepository
    {
        #region Employee

        Admin GetEmployee(int id);

        #endregion

        #region Customers
        IEnumerable<Customer> GetCustomer();
        Customer GetCustomer(int id);
        void AddCustomer(Customer customer);

        #endregion

        #region Books

        IEnumerable<Book> GetBook();
        Book GetBook(int id);

        #endregion

        #region Rental

        void AddRental(RentDetail rental);
        Task<int> AddRentalAsync(RentDetail rental);


        #endregion

        #region Invoice 

        int CreateInvoice(Payment item);
        List<dynamic> GetInvoice(int paymentID);

        #endregion
    }
}
