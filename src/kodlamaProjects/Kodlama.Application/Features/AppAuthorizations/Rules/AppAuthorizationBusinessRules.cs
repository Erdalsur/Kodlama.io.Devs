using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.AppAuthorizations.Rules
{
    public class AppAuthorizationBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AppAuthorizationBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ThisEmailAddressAlreadyHasAnAccount(string email)
        {
            IPaginate<User> result = await _userRepository.GetListAsync(u => u.Email == email);
            if (result.Items.Any()) throw new BusinessException("This Email Address Already Has An Account");
        }



    }
}
