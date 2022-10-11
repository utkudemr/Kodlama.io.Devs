using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.LoginUser
{
    
     public class LoginUserCommand : IRequest<LoginUserDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public String IpAddress { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly IAuthService _authService;
            private readonly UserBusinessRules _userBusinessRules;

            public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthService authService, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _authService = authService;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<LoginUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {

                var userData = await _userRepository.GetAsync(p => p.Email == request.UserForLoginDto.Email);
                 _userBusinessRules.UserShouldExistWhenRequested(userData);
                await _userBusinessRules.PasswordCheck(userData, request.UserForLoginDto.Password);


                AccessToken createdAccessToken = await _authService.CreateAccessToken(userData);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(userData, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                LoginUserDto loginUser = new LoginUserDto() {
                    AccessToken= createdAccessToken,
                    RefreshToken= addedRefreshToken
                };

                return loginUser;

            }
        }
    }
}
