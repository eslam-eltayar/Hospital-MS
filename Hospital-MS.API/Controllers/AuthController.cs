﻿using Hospital_MS.Core.Contracts.Auth;
using Hospital_MS.Core.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_MS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var authResult = await _authService.LoginAsync(request, cancellationToken);

            return authResult.IsSuccess
                ? Ok(authResult.Value)
                : Unauthorized(authResult.Error);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
        {
            var authResult = await _authService.RegisterAsync(request, cancellationToken);

            return authResult.IsSuccess
                ? Ok()
                : BadRequest(authResult.Error);
        }
    }
}
