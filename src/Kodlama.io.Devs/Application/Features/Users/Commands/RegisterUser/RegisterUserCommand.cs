using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<RegisterUserDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAddress { get; set; }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserDto>
        {
            private UserBusinessRules _userBusinessRules;
            private IUserRepository _userRepository;
            private IAuthService _authService;

            public RegisterUserCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules, IAuthService authService)
            {
                _userRepository = userRepository;
                _userBusinessRules = userBusinessRules;
                _authService = authService;
            }

            public async Task<RegisterUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.MailCanNotBeDuplicatedWhenInserted(request.UserForRegisterDto.Email);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

                User newUser = new User()
                {
                    Email = request.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    Status = true
                };

                User createdUser = await _userRepository.AddAsync(newUser);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                RegisterUserDto registeredDto = new RegisterUserDto()
                {
                    RefreshToken = addedRefreshToken,
                    AccessToken = createdAccessToken,
                };
                return registeredDto;
            }
        }
    }
}
