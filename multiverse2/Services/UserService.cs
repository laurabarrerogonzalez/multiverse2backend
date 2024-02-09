using Data;
using Entities;
using Multiverse.IServices;

namespace Multiverse.Services
{
    public class UserService : BaseContextService, IUserService
    {
        public UserService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertUser(UserItem userItem)
        {
            // Asigna el IdRol predeterminado (2) al nuevo usuario
            userItem.IdRol = 2;

            _serviceContext.UserItem.Add(userItem);
            _serviceContext.SaveChanges();

            return userItem.Id;
        }

        public bool DeleteUserById(int userId)
        {
            var userToDelete = _serviceContext.UserItem.FirstOrDefault(u => u.Id == userId);

            if (userToDelete != null)
            {
                _serviceContext.UserItem.Remove(userToDelete);
                _serviceContext.SaveChanges();
                return true;
            }

            return false;
        }


    }
}