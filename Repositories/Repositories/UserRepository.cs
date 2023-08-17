using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Shared.User;
using Domain;
using Microsoft.AspNetCore.Identity;
using Shared.Token;
using Domain.Exceptions;
using System.Security.Authentication;

namespace Repositories.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenRepository _tokenRepository;
    private readonly IMapper _mapper;

    public UserRepository(
            DataContext context,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenRepository tokenRepository,
            IMapper mapper)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenRepository = tokenRepository;
        _mapper = mapper;
    }

    private IQueryable<AppUser> GetUserById(string id) => _context.Users
       .AsNoTracking()
       .Where(a => a.Id == id);

    public async Task<UserResponse.Login> LoginAsync(UserRequest.Login request)
    {
        var user = await _userManager.Users
               .SingleOrDefaultAsync(x => x.UserName == request.Email.ToLower()) ?? throw new UserNotFoundException("User not found");
        var result = await _signInManager
            .CheckPasswordSignInAsync(user, request.Password, false);

        if (!result.Succeeded) throw new InvalidCredentialsException("Invalid password");

        var token = await _tokenRepository.CreateToken(new TokenRequest { Id = user.Id.ToString(), Email = user.Email });

        return new UserResponse.Login
        {
            Id = user.Id.ToString(),
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Token = token
        };
    }

    public async Task<UserResponse.Register> RegisterAsync(UserRequest.Register request)
    {
        if (await UserExists(request.Email)) throw new UserExistsException("Username is taken");

        var user = _mapper.Map<AppUser>(request);
        user = new AppUser(user.Email, user.FirstName, user.LastName)
        {
            UserName = request.Email.ToLower()
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded) throw new InvalidCredentialsException("Invalid credentials");

        var token = await _tokenRepository.CreateToken(new TokenRequest { Id = user.Id.ToString(), Email = user.Email });

        return new UserResponse.Register
        {
            Id = user.Id.ToString(),
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Token = token
        };
    }



    public async Task<UserResponse.Edit> EditAsync(UserRequest.Edit request)
    {
        UserResponse.Edit response = new();
        AppUser user = await GetUserById(request.User.Id).SingleOrDefaultAsync() ?? throw new UserNotFoundException("User not found");

        _mapper.Map(request.User, user);

        _context.Entry(user).State = EntityState.Modified;
        response.User = new()
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName= user.LastName,
        };

        return response;
    }

    private async Task<bool> UserExists(string email)
    {
        return await _userManager.Users.AnyAsync(x => x.UserName == email.ToLower());
    }
}
