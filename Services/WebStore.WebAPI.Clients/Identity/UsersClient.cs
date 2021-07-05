using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSrore.Interfaces;
using WebSrore.Interfaces.Services.Identity;
using WebStore.Domain.Entities.Identity;
using WebStore.WebAPI.Clients.Base;

namespace WebStore.WebAPI.Clients.Identity
{
    public class UsersClient : BaseClient, IUsersClient
    {
        public UsersClient(HttpClient Client) : base(Client, WebAPIAddress.Identity.Users) { }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task AddClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task AddLoginAsync(User user, UserLoginInfo login, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(User user, string RoleName, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(User user, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Claim>> GetClaimsAsync(User user, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(User user, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(User user, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(User user, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedEmailAsync(User user, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPhoneNumberAsync(User user, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(User user, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(User user, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetUsersForClaimAsync(Claim claim, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(User user, string roleName, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(User user, string loginProvider, string providerKey, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task ReplaceClaimAsync(User user, Claim claim, Claim newClaim, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(User user, string email, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(User user, string NormalizedName, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task SetPhoneNumberAsync(User user, string phoneNumber, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task SetPhoneNumberConfirmedAsync(User user, bool confirmed, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(User user, string UserName, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken Cancel)
        {
            throw new NotImplementedException();
        }
    }
}
