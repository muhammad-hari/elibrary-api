using Moonlay.ELibrary.Domain.Models;
using System.Threading.Tasks;

namespace Moonlay.ELibrary.Domain.Interfaces
{
    public interface ILibraryRepository
    {
        #region Employee

        Admin GetEmployee(int id);

        #endregion

        #region Customers

        Customer GetCustomer(int id);
        void AddCustomer(Customer customer);

        #endregion

        #region Books

        Book GetBook(int id);

        #endregion

        #region Rental

        void AddRental(RentDetail rental);
        Task<int> AddRentalAsync(RentDetail rental);


        #endregion

        #region Invoice 

        int CreateInvoice(Payment item);

        #endregion
    }
}
