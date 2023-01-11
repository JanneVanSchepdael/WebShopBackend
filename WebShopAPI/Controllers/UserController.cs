using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Repositories;
using Shared;
using Shared.Cart;
using Shared.Order;
using Shared.Token;
using Shared.User;
using Swashbuckle.AspNetCore.Annotations;


namespace WebShopAPI.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenRepository _tokenRepository;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenRepository tokenRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenRepository = tokenRepository;
            _mapper = mapper;
        }

        [SwaggerOperation("Registers a new user.")]
        [HttpPost("register")]
        public async Task<UserResponse.Register> Register([FromBody] UserRequest.Register request)
        {
            //if (await UserExists(request.Email)) return BadRequest("Username is taken");

            var user = _mapper.Map<AppUser>(request);
            user.UserName = request.Email.ToLower();

            var result = await _userManager.CreateAsync(user, request.Password);
            //if(!result.Succeeded) return BadRequest(result.Errors);

            return new UserResponse.Register
            {
                Email = user.Email,
                Token = await _tokenRepository.CreateToken(
                        new TokenRequest {Id = user.Id.ToString(), Email = user.Email}
                    )
            };
        }

        [SwaggerOperation("Logs in a user.")]
        [HttpPost("login")]
        public async Task<UserResponse.Login> LoginAsync(UserRequest.Login request)
        {
            var user = await _userManager.Users
                    .SingleOrDefaultAsync(x => x.UserName == request.Email.ToLower());

            //if (user == null) return Unauthorized("Invalid Username");

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, request.Password, false);

            //if (!result.Succeeded) return Unauthorized();

            return new UserResponse.Login
            {
                Email = user.Email,
                Token = await _tokenRepository.CreateToken( new TokenRequest {Id = user.Id.ToString(), Email = user.Email })
        };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users
                .AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
