using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Shared.User;
using Domain;


namespace Repositories.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserRepository(
            DataContext context,
            IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    private IQueryable<AppUser> GetUserById(string id) => _context.Users
       .AsNoTracking()
       .Where(a => a.Id == id);

    public async Task<UserResponse.Edit> EditAsync(UserRequest.Edit request)
    {
        UserResponse.Edit response = new();
        AppUser user = await GetUserById(request.User.Id).SingleOrDefaultAsync();

        if (user != null)
        {
            _mapper.Map(request.User, user);

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            response.User = new()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName= user.LastName,
            };

        }

        return response;
    }

    public async Task<UserResponse.Detail> GetUserDetailAsync(UserRequest.Detail request)
    {
        throw new NotImplementedException();
    }
}
