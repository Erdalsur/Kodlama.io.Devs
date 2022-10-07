using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.Application.Features.AppAuthorizations.Rules;
using Kodlama.Application.Features.Auths.Dtos;
using Kodlama.Application.Features.Auths.Rules;
using Kodlama.Application.Services.AuthService;
using Kodlama.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.Auths.Commands.Login
{
    public class LoginCommand:IRequest<LoginDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }

        public class LoginCommandHandler:IRequestHandler<LoginCommand,LoginDto>
        {
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;

            public LoginCommandHandler(AuthBusinessRules authBusinessRules, IUserRepository userRepository, IAuthService authService)
            {
                _userRepository = userRepository;
                _authBusinessRules = authBusinessRules;
                _authService = authService;
            }

            public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                _authService.IsAuthenticatorCodeStatus(request.UserForLoginDto.AuthenticatorCode);

                User? registeredUser =await _userRepository.GetAsync(a => a.Email == request.UserForLoginDto.Email);

                
                await _authBusinessRules.NoRegisteredUsers(registeredUser);
                _authBusinessRules.UserCredentialsMustMatchBeforeLogin(request.UserForLoginDto.Password, registeredUser.PasswordHash, registeredUser.PasswordSalt);
                
                AccessToken accessToken =await _authService.CreateAccessToken(registeredUser);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(registeredUser, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                LoginDto loginDto = new() { RefreshToken = addedRefreshToken, AccessToken = accessToken };

                return loginDto;
            }
        }
    }
}
