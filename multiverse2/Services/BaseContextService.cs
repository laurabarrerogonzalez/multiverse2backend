using Data;

namespace Multiverse.Services
{
    public class BaseContextService
    {
        protected readonly ServiceContext _serviceContext;
        protected BaseContextService(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;

        }
    }
}
