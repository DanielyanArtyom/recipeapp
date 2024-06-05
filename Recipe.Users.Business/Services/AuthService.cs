using AutoMapper;
using Recipe.Users.Business.Dtoes;
using Recipe.Users.Business.Interfaces;
using Recipe.Users.Data.Entity;
using Recipe.Users.Data.Interfaces;

namespace Recipe.Users.Business.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;

    public AuthService(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
    {
        this._mapper = mapper;
        this._unitOfWork = unitOfWork;
        this._tokenService = tokenService;
    }
    public async Task<UserResponse> Registration(UserRegistrationRequest requestedUser)
    {
        try
        {
            var dupilcateUser = this._unitOfWork.Users.GetBy(x => x.Email == requestedUser.Email);

            if(dupilcateUser is not null)
            {
                throw new Exception("User already exists!");
            }

            requestedUser.Password = BCrypt.Net.BCrypt.HashPassword(requestedUser.Password);

            var mappedUser = this._mapper.Map<User>(requestedUser);

            this._unitOfWork.Users.Add(mappedUser);

            await this._unitOfWork.Complete();

            var getUser = this._unitOfWork.Users.GetBy(x => x.Email == requestedUser.Email);

            var user = this._mapper.Map<UserDTO>(getUser);

            var token = this._tokenService.CreateToken(user);

            return new UserResponse()
            {
                Email = user.Email,
                Name = user.Name,
                Token = token,
                UserId = user.UserId,
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Something went wrong");
        }

    }

    public UserResponse Login(UserLoginRequest request)
    {
        var user = this._unitOfWork.Users.GetBy(x => x.Email == request.Email);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.password))
        {
            throw new Exception("Email or password was wrong");
        }
        var mappedUser = this._mapper.Map<UserDTO>(user);

        var token = this._tokenService.CreateToken(mappedUser);



        return new UserResponse()
        {
            Email = user.Email,
            Name = user.Name,
            Token = token,
            UserId = user.UserId,
        };

    }
}