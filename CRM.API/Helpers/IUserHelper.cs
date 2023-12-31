﻿using CRM.Shared.DTOs;
using CRM.Shared.Entities;
using Microsoft.AspNetCore.Identity;

namespace CRM.API.Helpers
{
    public interface IUserHelper
    {
        Task<Users> GetUserAsync(string email);
        Task<IdentityResult> AddUserAsync(Users user, string password);
        Task CheckRoleAsync(string roleName);
        Task AddUserToRoleAsync(Users user, string roleName);
        Task<bool> IsUserInRoleAsync(Users user, string roleName);
        Task<SignInResult> LoginAsync(LoginDTO model);
        Task LogoutAsync();
        Task<IdentityResult> ChangePasswordAsync(Users user, string currentPassword, string newPassword);
        Task<IdentityResult> UpdateUserAsync(Users user);
        Task<Users> GetUserAsync(Guid userId);

    }
}
