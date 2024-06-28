using Microsoft.EntityFrameworkCore;
using MyBlog.Business.Abstract;
using MyBlog.Business.Utilities.Security.JWT;
using MyBlog.Core.Utilities.Helpers;
using MyBlog.Core.Utilities.Results;
using MyBlog.Entities;

namespace MyBlog.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;

        public AuthManager(IUserService userService, ITokenHandler tokenHandler)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
        }

        public async Task<Token> Login(string email, string password)
        {
            var users = _userService.GetAllQueryable().Include(x=>x.Role);
            var user = await users.FirstOrDefaultAsync(x=>x.Email == email);
            if (user == null)
                return null;

            var result = HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
            if (result)
            {
                var token = new Token();
                token = _tokenHandler.CreateToken(user, user.Role);
                return token;
            }

            return null;
        }

        public async Task<IDataResult> Register(string email, string password)
        {
            try
            {
                if (_userService.Any(x => x.Email == email))
                {
                    return new ErrorResult("Bu mail adresi daha önce kullanılmış, farklı bir mail adresi deneyiniz!");
                }

                await _userService.AddAsync(GetAddedUser(email, password));
            }
            catch
            {
                return new ErrorResult("Kullanıcı eklenirken hata oluştu!");
            }


            return new SuccessResult("Kullanıcı başarıyla eklendi.");
        }

        private User GetAddedUser(string email, string password)
        {
            HashingHelper.CreatePassword(password, out var passwordHash, out var passwordSalt);
            return new User()
            {
                Email = email,
                RoleId = 2,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreateDate = DateTime.Now,
            };
        }
    }
}
