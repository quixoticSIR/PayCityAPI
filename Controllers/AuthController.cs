using Microsoft.AspNetCore.Mvc;
using PayCityAPI.Models;

namespace PayCityAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // In-memory user store for demo purposes
        private static List<UserModel> users = new List<UserModel>();

        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class ForgotPasswordRequest
        {
            public string Email { get; set; }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            var user = users.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);
            if (user == null)
                return Unauthorized("Invalid credentials");
            return Ok("Login successful");
        }

        [HttpPost("signup")]
        public IActionResult Signup([FromBody] UserModel signup)
        {
            if (users.Any(u => u.Email == signup.Email))
                return BadRequest("Email already exists");
            if (signup.Password != signup.ConfirmPassword)
                return BadRequest("Passwords do not match");
            users.Add(signup);
            return Ok("Signup successful");
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var user = users.FirstOrDefault(u => u.Email == request.Email);
            if (user == null)
                return NotFound("User not found");
            // In a real app, send email or SMS here
            return Ok($"Password reset link sent to {user.Email ?? "your email"}");
        }
    }
} 