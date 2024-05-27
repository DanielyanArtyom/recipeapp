using AutoMapper;
using Recipe.Users.Business.Dtoes;
using Recipe.Users.Data.Entity;
using Recipe.Users.Data.Interfaces;

namespace Recipe.Users.Business.Services;

public class AuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    AuthService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._userRepository = unitOfWork.UserRepository;
        this._mapper = mapper;
        this._unitOfWork = unitOfWork;
    }
    public async Task<UserResponse> Registration(UserRegistration requestedUser)
    {
        requestedUser.Password = BCrypt.Net.BCrypt.HashPassword(requestedUser.Password);
        var mappedUser = this._mapper.Map<User>(requestedUser);
        this._userRepository.AddUser(mappedUser);
        await this._unitOfWork.SaveAsync();
        var getUser = this._userRepository.GetUserByEmail(requestedUser.Email);
        return this._mapper.Map<UserResponse>(getUser);
    }
    
    public UserResponse Login(UserLogin request)
    {
        var user = this._userRepository.GetUserByEmail(request.Email);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.password))
        {
            throw new Exception("Email or password was wrong");
        }
        
        return this._mapper.Map<UserResponse>(user);
    }
}