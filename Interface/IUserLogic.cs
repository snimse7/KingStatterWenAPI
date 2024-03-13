using KingStatterWenAPI.Models;
using static KingStatterWenAPI.Models.Responses;

namespace KingStatterWenAPI.Interface
{
    public interface IUserLogic
    {
        Task<InsertDocumentResponse> newUser(User user);
        Task<User> GetUser(string userName);
        Task<SignInResponse> signInUser(string userName, string password);
        Task<bool> checkUserPresent(string userName);
    }
}
