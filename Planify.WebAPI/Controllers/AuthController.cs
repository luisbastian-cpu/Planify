using Microsoft.AspNetCore.Mvc;
using Planify.Application.Common.Interfaces;
using Planify.Domain.Entities;

namespace Planify.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public AuthController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var existing = await _userRepository.GetByEmailAsync(request.Email);
        if (existing != null)
            return BadRequest(new { message = "El correo ya está registrado" });

        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        await _userRepository.AddAsync(user);
        return Ok(new { message = "Usuario registrado exitosamente" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null)
            return Unauthorized(new { message = "Credenciales incorrectas" });

        bool validPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
        if (!validPassword)
            return Unauthorized(new { message = "Credenciales incorrectas" });

        return Ok(new { message = "Login exitoso", userId = user.Id, name = user.Name });
    }

    [HttpGet("usuarios")]
    public async Task<IActionResult> GetUsuarios()
    {
        var usuarios = await _userRepository.GetAllAsync();
        return Ok(usuarios);
    }

}

public record RegisterRequest(string Name, string Email, string Password);
public record LoginRequest(string Email, string Password);