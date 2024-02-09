using Entities;
using Microsoft.AspNetCore.Mvc;
using Multiverse.IServices;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] UserItem userItem)
    {
        try
        {
            int userId = _userService.InsertUser(userItem);

            // Cambia "GetUser" al nombre de la acción que realmente devuelve un usuario por su ID
            return Ok(userId);
        }
        catch (Exception ex)
        {
            // Muestra más detalles sobre la excepción interna
            return BadRequest($"Error: {ex.Message}. Inner Exception: {ex.InnerException?.Message}");
        }
    }





    [HttpDelete("{id}")]
    public IActionResult DeleteUserById(int id)
    {
        try
        {
            bool userDeleted = _userService.DeleteUserById(id);

            if (userDeleted)
            {
                return Ok($"User with ID {id} deleted successfully.");
            }
            else
            {
                return NotFound($"User with ID {id} not found.");
            }
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}. Inner Exception: {ex.InnerException?.Message}");
        }
    }
}
