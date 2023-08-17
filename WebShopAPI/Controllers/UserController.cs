using AutoMapper;
using Azure;
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


namespace WebShopAPI.Controllers;

public class UserController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [SwaggerOperation("Registers a new user.")]
    [HttpPost("register")]
    public async Task<UserResponse.Register> Register([FromBody] UserRequest.Register request)
    {
        return await _unitOfWork.UserRepository.RegisterAsync(request);
    }

    [SwaggerOperation("Logs in a user.")]
    [HttpPost("login")]
    public async Task<UserResponse.Login> LoginAsync(UserRequest.Login request)
    {
       return await _unitOfWork.UserRepository.LoginAsync(request);
    }

    [SwaggerOperation("Edits an existing user.")]
    [HttpPut]
    public async Task<UserResponse.Edit> Edit([FromBody] UserRequest.Edit request)
    {
        var response = await _unitOfWork.UserRepository.EditAsync(request);
        await _unitOfWork.Complete();
        return response;
    }
}
