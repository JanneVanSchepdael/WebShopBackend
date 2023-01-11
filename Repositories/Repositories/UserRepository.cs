using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Shared.Token;
using Shared.User;

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

    public async Task<UserResponse.Edit> EditAsync(UserRequest.Edit request)
    {
        //_context.Entry(user).State = EntityState.Modified;
        throw new NotImplementedException();
    }

    public async Task<UserResponse.Detail> GetUserDetailAsync(UserRequest.Detail request)
    {
        throw new NotImplementedException();
    }
}
