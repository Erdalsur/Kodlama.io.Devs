using AutoMapper;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.Application.Features.AppAuthorizations.Dtos;
using Kodlama.Application.Features.AppAuthorizations.Rules;
using Kodlama.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.AppAuthorizations.Commands.RegisterUser
{
    public class RegisterUserCommand:IRequest<UserDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly AppAuthorizationBusinessRules _appAuthorizationBusinessRules;

            public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, AppAuthorizationBusinessRules appAuthorizationBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _appAuthorizationBusinessRules = appAuthorizationBusinessRules;
            }

            public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                // Email Controls Add
                await _appAuthorizationBusinessRules.ThisEmailAddressAlreadyHasAnAccount(request.Email);
                
                byte[] _passwordHash, _passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out _passwordHash, out _passwordSalt);
                User user = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PasswordHash = _passwordHash,
                    PasswordSalt = _passwordSalt,
                    Status = true,
                    AuthenticatorType = AuthenticatorType.Email
                };
                User createdUser = await _userRepository.AddAsync(user);
                List<OperationClaim> operationClaims = _userRepository.GetOperationClaims(createdUser).ToList();
                AccessToken accessToken=_tokenHelper.CreateToken(user, operationClaims);
                UserDto result = _mapper.Map<UserDto>(createdUser);
                result.AccessToken = accessToken;
                return result;
                
            }
        }

    }
}
