using CRM.API.Data;
using CRM.Shared.DTOs;
using CRM.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CRM.API.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly DataContext _context;
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Users> _signInManager;
        public UserHelper(DataContext context, UserManager<Users> userManager, RoleManager<IdentityRole> roleManager, 
            SignInManager<Users> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> AddUserAsync(Users user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
        public async Task AddUserToRoleAsync(Users user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }
        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }
        public async Task<Users> GetUserAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user!;
        }

        public async Task<bool> IsUserInRoleAsync(Users user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }
        public async Task<SignInResult> LoginAsync(LoginDTO model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<Users> GetUserAsync(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId.ToString());
            return user!;
        }
        public async Task<IdentityResult> ChangePasswordAsync(Users user, string currentPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }
        public async Task<IdentityResult> UpdateUserAsync(Users user)
        {
            return await _userManager.UpdateAsync(user);
        }


    }
}
