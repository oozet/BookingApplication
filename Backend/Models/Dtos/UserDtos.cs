namespace BookingApplication.Models;

public class SignInRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class RegisterRequest
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
}
