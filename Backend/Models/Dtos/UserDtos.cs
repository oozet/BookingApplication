namespace BookingApplication.Models.Dtos;

public class SignInUserRequest : IRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class RegisterUserRequest : IRequest
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
}

public class EditUserRequest : IRequest
{
    public required Guid Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
}
