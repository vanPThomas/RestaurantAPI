using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.DTOs;
using RestaurantAPI.Mappers;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/user/1
        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetUser(int id)
        {
            User user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            UserDTO userDTO = MapToDTO(user);

            return Ok(userDTO);
        }

        // POST api/user
        [HttpPost]
        public ActionResult<UserDTO> CreateUser([FromBody] UserDTO userDTO)
        {
            User user = MapToDataLayer(userDTO);
            _userService.AddUser(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.UserID }, MapToDTO(user));
        }

        // PUT api/user/1
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserDTO userDTO)
        {
            if (id != userDTO.UserId)
            {
                return BadRequest();
            }
            User existingUser = _userService.GetUserById(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            User updatedUser = MapToDataLayer(userDTO);
            _userService.UpdateUser(updatedUser);

            return NoContent();
        }

        // DELETE api/user/1
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            User user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.RemoveUser(user);

            return NoContent();
        }

        private UserDTO MapToDTO(User user)
        {
            return ReverseModelMapper.MapToDTO(user);
        }

        private User MapToDataLayer(UserDTO userDTO)
        {
            return ModelMapper.MapToBusinessModel(userDTO);
        }
    }
}
