namespace Shared.User;

public interface IUserRepository
{
    Task<UserResponse.Edit> EditAsync(UserRequest.Edit request);
    Task<UserResponse.Login> LoginAsync(UserRequest.Login request);
    Task<UserResponse.Register> RegisterAsync(UserRequest.Register request);
}
