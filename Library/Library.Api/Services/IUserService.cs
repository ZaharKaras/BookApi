using Library.Api.Models;

namespace Library.Api.Services
{
    public interface IUserService
    {
        string GetMyName();
        string CreateToken(User use);
    }
}
