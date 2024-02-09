using Entities;

namespace Multiverse.IServices
{
    public interface IUserService
    {
       
        int InsertUser(UserItem userItem);
        bool DeleteUserById(int userId);

    }
}
