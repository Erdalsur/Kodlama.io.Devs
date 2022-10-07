using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Mail already exists");
        }
        public async Task NoRegisteredUsers(User user)
        {
            if (user == null) throw new BusinessException("No registered users");
        }

        public void UserCredentialsMustMatchBeforeLogin(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            bool Ok = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!Ok) throw new BusinessException("Incorrect password");
        }
    }
}
