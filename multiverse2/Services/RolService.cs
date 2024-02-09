using Data;
using Entities;
using Multiverse.IServices;
using Multiverse.Services;


namespace Multiverse.Services
{
    public class RolService : BaseContextService, IRolService
    {

        public RolService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertRol(RolItem rol)
        {
            _serviceContext.RolItem.Add(rol);
            _serviceContext.SaveChanges();
            return rol.IdRol;
        }

       
    }
}
