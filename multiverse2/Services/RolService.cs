using Data;
using Entities;
using Multiverse.Services;
using Multiverse.IServices;

namespace Multiverse.Services
{
    public class RolService : BaseContextService, IRolService
    {

        public RolService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertRol(Rol rol)
        {
            _serviceContext.Rol.Add(rol);
            _serviceContext.SaveChanges();
            return rol.Id_rol;
        }

    }
}
