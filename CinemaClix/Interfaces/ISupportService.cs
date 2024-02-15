using CinemaClix.Models;
using CinemaClix.Services;

namespace CinemaClix.Interfaces
{
    public interface ISupportService
    {

        Task SendSupportEmailAsync(Support support);
    }
}
