//using Data;
//using Entities;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Authentication;
//using System.Web.Http.Cors;
//using Multiverse.IServices;
//using Multiverse.Services;
//using Microsoft.Extensions.Logging;


//namespace Multiverse.Controllers
//{
//    [ApiController]
//    [Route("[controller]/[action]")]
//    [EnableCors(origins: "*", headers: "*", methods: "*")]


//    public class CategoriesController : ControllerBase
//    {
//        private readonly ICategoriesService _categoriesService;
//        private readonly ServiceContext _serviceContext;
//        private readonly ILogger<CategoriesController> _logger;

//        public CategoriesController(ICategoriesService categoriesService, ServiceContext serviceContext, ILogger<CategoriesController> logger)
//        {
//            _categoriesService = categoriesService;
//            _serviceContext = serviceContext;
//            _logger = logger;
//        }

//        [HttpGet(Name = "GetCategories")]
//        public IActionResult GetCategories(string categoriesName = null)
//        {
//            IQueryable<Categories> categoriesQuery = _serviceContext.Set<Categories>();

//            if (!string.IsNullOrEmpty(categoriesName))
//            {
//                categoriesQuery = categoriesQuery.Where(categories => categories.CategoriesName == categoriesName);
//            }

//            var categories = categoriesQuery.ToList();
//            return Ok(categories);
//        }

//        [HttpPost]
//        public ActionResult<int> Post([FromQuery] string userUser_Name, [FromQuery] string userPassword, [FromBody] Categories categories)
//        {
//            var selectedUser = _serviceContext.Set<UserItem>()
//                .Where(u => u.UserName == userUser_Name
//                    && u.Password == userPassword
//                    && u.IdRol == 1)
//                .FirstOrDefault();

//            if (selectedUser == null)
//            {
//                throw new InvalidCredentialException("Usuario no permitido");
//            }

//            if (categories == null)
//            {
//                return BadRequest("Los datos de la categoría son nulos.");
//            }

//            int categoryId = _categoriesService.insertCategories(categories);
//            return Ok(categoryId);
//        }

//        [HttpPut("{id}")]
//        public IActionResult Put(int id, [FromQuery] string userUser_Name, [FromQuery] string userPassword, [FromBody] Categories categories)
//        {
//            var selectedUser = _serviceContext.Set<UserItem>()
//                .Where(u => u.UserName == userUser_Name
//                    && u.Password == userPassword
//                    && u.IdRol == 1)
//                .FirstOrDefault();

//            if (selectedUser == null)
//            {
//                throw new InvalidCredentialException("Usuario no permitido");
//            }

//            if (categories == null)
//            {
//                return BadRequest("Los datos de la categoría son nulos.");
//            }

//            if (id != categories.IdCategories)
//            {
//                return BadRequest("El ID de la categoría en los datos no coincide con el ID proporcionado.");
//            }

//            try
//            {
//                _categoriesService.UpdateCategories(categories);
//                return NoContent();
//            }
//            catch
//            {
//                return NotFound($"La categoría con ID {id} no existe.");
//            }
//        }

//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id, [FromQuery] string userUser_Name, [FromQuery] string userPassword)
//        {
//            var selectedUser = _serviceContext.Set<UserItem>()
//                .Where(u => u.UserName == userUser_Name
//                    && u.Password == userPassword
//                    && u.IdRol == 1)
//                .FirstOrDefault();

//            if (selectedUser == null)
//            {
//                throw new InvalidCredentialException("Usuario no permitido");
//            }

//            try
//            {
//                _categoriesService.DeleteCategories(id);
//                return NoContent();
//            }
//            catch (InvalidOperationException ex)
//            {
//                return NotFound(ex.Message);
//            }
//        }

//    }

//}




