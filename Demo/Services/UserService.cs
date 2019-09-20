using AutoMapper;
using Demo.Exceptions;
using Demo.Helpers;
using Demo.Models.Users;
using Demo.Services.Interfaces;
using Entity.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Services
{
    public class UserService : IUserService
    {
        private readonly IWrapperRepository _wrapperRepository;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public UserService(IOptions<AppSettings> appSettings, IWrapperRepository wrapperRepository, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _wrapperRepository = wrapperRepository;
            _mapper = mapper;
        }

        public UserModel Authenticate(string username, string password)
        {
            var user = _wrapperRepository.User.FindByCondition(x => x.Username == username).FirstOrDefault();

            if (user == null)
                throw new DemoException("Username is not valid.");

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return _mapper.Map<UserModel>(user);
        }

        public UserModel Create(UserRegisterModel userRegisterModel)
        {
            var user = _mapper.Map<Entity.Models.User>(userRegisterModel);
            // validation
            if (string.IsNullOrWhiteSpace(userRegisterModel.Password))
                throw new DemoException("Password is required");

            if (string.IsNullOrWhiteSpace(userRegisterModel.Username))
                throw new DemoException("UserName is required");

            if (_wrapperRepository.User.FindByCondition(x => x.Username == userRegisterModel.Username).FirstOrDefault() != null)
                throw new DemoException("Username \"" + userRegisterModel.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userRegisterModel.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _wrapperRepository.User.Create(user);
            _wrapperRepository.SaveChanges();
            return _mapper.Map<UserModel>(user);
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _mapper.Map<List<UserModel>>(_wrapperRepository.User.FindAll());
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
