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
//    public class OrderController : ControllerBase
//    {
//        private readonly IOrderService _orderService;
//        private readonly ServiceContext _serviceContext;
//        private readonly ILogger<OrderController> _logger;

//        public OrderController(IOrderService orderService, ServiceContext serviceContext, ILogger<OrderController> logger)
//        {
//            _orderService = orderService;
//            _serviceContext = serviceContext;
//            _logger = logger;
//        }


//        [HttpGet(Name = "GetOrdersByCustomerName")]
//        public IActionResult GetOrdersByCustomerName(string userName, [FromQuery] string userUser_Name, [FromQuery] string userPassword)
//        {
//            var selectedUser = _serviceContext.Set<UserItem>()
//                .Where(u => u.UserName == userUser_Name
//                    && u.Password == userPassword
//                    && (u.IdRol == 1 || u.IdRol == 2))
//                .FirstOrDefault();

//            if (selectedUser == null)
//            {
//                throw new InvalidCredentialException("Usuario no permitido");
//            }

//            if (string.IsNullOrEmpty(userName))
//            {
//                return BadRequest("El nombre del cliente no puede estar vacío");
//            }

//            var orders = _serviceContext.Orders
//                .Where(order => order.UserName == userName)
//                .ToList();

//            return Ok(orders);
//        }


//        [HttpPost(Name = "CreateOrder")]
//        public int CreateOrder([FromQuery] string userUser_Name, [FromQuery] string userPassword, [FromBody] OrderItem orderItem)
//        {
//            var selectedUser = _serviceContext.Set<UserItem>()
//                .Where(u => u.UserName == userUser_Name
//                    && u.Password == userPassword
//                    && u.IdRol == 1)
//                .FirstOrDefault();

//            if (selectedUser != null)
//            {
//                return _orderService.insertOrder(orderItem);
//            }
//            else
//            {
//                throw new InvalidCredentialException("Usuario no permitido");
//            }
//        }

//        [HttpPut("{id}", Name = "UpdateOrder")]
//        public IActionResult UpdateOrder(int id, [FromBody] OrderItem updatedOrder, [FromQuery] string userUser_Name, [FromQuery] string userPassword)
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

//            var existingOrder = _serviceContext.Orders.FirstOrDefault(o => o.IdOrder == id);

//            if (existingOrder == null)
//            {
//                return NotFound();
//            }
//            else
//            {
//                try
//                {

//                    existingOrder.UserName = updatedOrder.UserName;
//                    existingOrder.OrderDate = updatedOrder.OrderDate;
//                    existingOrder.Delivered = updatedOrder.Delivered;
//                    existingOrder.Charged = updatedOrder.Charged;


//                    _orderService.UpdateOrder(existingOrder);

//                    return Ok(existingOrder);
//                }
//                catch (Exception ex)
//                {
//                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
//                }
//            }
//        }

//        // Métodos DELETE para eliminar un pedido
//        [HttpDelete("{orderId}", Name = "DeleteOrder")]
//        public IActionResult DeleteOrder(int orderId, [FromQuery] string userUser_Name, [FromQuery] string userPassword)
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

//            if (orderId > 0)
//            {
//                _orderService.DeleteOrder(orderId);

//                return Ok(new { message = "Pedido eliminado exitosamente" });
//            }
//            else
//            {
//                return BadRequest("El orderId no es válido");
//            }
//        }
//    }
//}
