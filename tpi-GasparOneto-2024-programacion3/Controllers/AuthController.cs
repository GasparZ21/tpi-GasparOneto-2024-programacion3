using Application.Models;
using Application.Services;
using Domain.Entities;
using Infraestructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;

namespace tpi_GasparOneto_2024_programacion3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
       
            private readonly ApplicationDbContext _context;
            private readonly JwtService _jwtService;

            public AuthController(ApplicationDbContext context, JwtService jwtService)
            {
                _context = context;
                _jwtService = jwtService;
            }

            [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            if (await _context.Users.AnyAsync(u => u.Name == request.Name))
                return BadRequest("Usuario ya registrado.");

            var user = new User(0, request.Name, request.Rol)
            {
                Password = HashPassword(request.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Usuario registrado exitosamente.");
        }

        [HttpPost("login")]
            public async Task<IActionResult> Login(LoginDto request)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == request.Name);
                if (user == null || user.Password != HashPassword(request.Password))
                    return Unauthorized("Credenciales inválidas.");

                var token = _jwtService.GenerateToken(user.Id, user.Name, user.Rol);

                return Ok(new { Token = token });
            }
            private static string HashPassword(string password)
            {
                var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
    }
}
