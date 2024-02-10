using Entities;

namespace Multiverse.IServices
{
    public interface IUsersService
    {
        int InsertUsers(Users users);
        int GetRoleIdByName(string roleName);
        bool DeleteUser(int userId);
    }
}
