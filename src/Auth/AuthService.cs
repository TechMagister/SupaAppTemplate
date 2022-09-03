using SupabaseAuth;

namespace TechMagister.Starter.Auth;

public interface IAuthService
{
    Task<Session?> SignInAsync(string email, string password);
    Task SignOutAsync(string accessToken);
    Task<Session?> SignUpAsync(string email, string password);
}

public class AuthService : IAuthService
{
    private readonly IAuthClient _client;

    public AuthService(IAuthClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task<Session?> SignUpAsync(string email, string password)
    {
        return await _client.SignUpAsync(email, password);
    }

    public async Task<Session?> SignInAsync(string email, string password)
    {
        return await _client.SignInAsync(email, password);
    }

    public async Task SignOutAsync(string accessToken)
    {
        await _client.SignOutAsync(accessToken);
    }
}
