using Moonlay.ELibrary.Application.Models.Request;
using Moonlay.ELibrary.Application.Models.Response;
using System.Threading.Tasks;

namespace Moonlay.ELibrary.Application.Interfaces
{
    public interface IRentBookService
    {
        Task<RentBookResponse> PaymentAsync(RentBookRequest request);
    }
}
