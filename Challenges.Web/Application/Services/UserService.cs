using System.Threading.Tasks;
using Challenges.API.Response;
using Challenges.Application.Utils;

namespace Challenges.Application.Services
{
    public class UserService : IUserService
    {
        public Task<UserResponse> GetUserDetails()
        {
            var userResponse = new UserResponse { Name = Constants.DevName, Token = Constants.Token };
            return Task.FromResult(userResponse);
        }
    }
}
