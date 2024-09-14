using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _userService.GetUsers();
        return Ok(products);
    }

      [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserInput user)
    {
        _userService.CreateUser(user);
        return Ok();
    }

}
