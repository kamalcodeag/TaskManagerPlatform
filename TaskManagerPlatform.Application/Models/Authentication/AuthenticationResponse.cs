using System;

namespace TaskManagerPlatform.Application.Models.Authentication
{
    public class AuthenticationResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}