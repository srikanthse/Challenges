using System.Threading.Tasks;
using Challenges.API.Response;

namespace Challenges.Application.Services
{
    public interface IUserService
    {
        Task<UserResponse> GetUserDetails();
    }
}
