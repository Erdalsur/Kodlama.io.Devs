using AutoMapper;
using Core.Security.Entities;
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

namespace Kodlama.Application.Features.AppAuthorizations.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<UserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly AppAuthorizationBusinessRules _appAuthorizationBusinessRules;
            private readonly ITokenHelper _tokenHelper;

            public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, AppAuthorizationBusinessRules appAuthorizationBusinessRules, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _appAuthorizationBusinessRules = appAuthorizationBusinessRules;
                _tokenHelper = tokenHelper;
            }

            public async Task<UserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {

                User user = await _userRepository.GetAsync(a => a.Email == request.Email);
                await _appAuthorizationBusinessRules.VerifyPassword(request.Password, user);

                List<OperationClaim> operationClaims = (List<OperationClaim>)_userRepository.GetOperationClaims(user);
                UserDto result = _mapper.Map<UserDto>(user);
                result.AccessToken=_tokenHelper.CreateToken(user, operationClaims);
                return result;
            }
        }
    }
}
