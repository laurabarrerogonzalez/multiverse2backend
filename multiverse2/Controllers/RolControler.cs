using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Multiverse.IServices;
using Multiverse.Services;
using System.Security.Authentication;
using System.Web.Http.Cors;

namespace SoundofSilence.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class RolController : ControllerBase
    {

        private readonly Multiverse.IServices.IRolService _rolService;
        private readonly ServiceContext _serviceContext;

        public RolController(IRolService rolService, ServiceContext serviceContext)
        {
            _rolService = rolService;
            _serviceContext = serviceContext;

        }


        [HttpGet(Name = "GetAllRoles")]
        public IActionResult Get()
        {
            var roles = _serviceContext.Set<RolItem>().ToList();
            return Ok(roles);
        }



        [HttpPost(Name = "InsertRol")]
        public IActionResult Post([FromQuery] string userName, [FromQuery] string userPassword, [FromBody] RolItem rol)
        {
            var selectedUser = _serviceContext.Set<UserItem>()
                                   .Where(u => u.UserName == userName
                                       && u.Password == userPassword
                                       && u.IdRol == 1)
                                    .FirstOrDefault();

            if (selectedUser != null)
            {
                var existingWithNameRol = _serviceContext.Set<RolItem>()
                    .FirstOrDefault(u => u.RolName == rol.RolName);

                if (existingWithNameRol != null)
                {
                    return StatusCode(404, "A role with the same name already exists.");
                }
                else
                {
                    return Ok(_rolService.InsertRol(rol));
                }
            }
            else
            {
                return StatusCode(404, "The user is not authorised or does not exist");
            }
        }

    }
}
