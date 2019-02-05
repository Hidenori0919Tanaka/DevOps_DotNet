using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevOps_DotNet
{
    public class MyUserStore : IUserStore<IdentityUser>, IUserPasswordStore<IdentityUser>
    {
        private static readonly List<IdentityUser> InMemoryStore = new List<IdentityUser>();

        public void Dispose() { }

        public async Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken)
            => user.Id;

        public async Task<string> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
            => user.UserName;

        public async Task SetUserNameAsync(IdentityUser user, string userName, CancellationToken cancellationToken)
            => user.UserName = userName;

        public async Task<string> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
            => user.NormalizedUserName;

        public async Task SetNormalizedUserNameAsync(IdentityUser user, string normalizedName, CancellationToken cancellationToken)
            => user.NormalizedUserName = normalizedName;

        public async Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            InMemoryStore.Add(user);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            var index = InMemoryStore.FindIndex(a => a.Id == user.Id);
            InMemoryStore[index] = user;
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            var index = InMemoryStore.FindIndex(a => a.Id == user.Id);
            InMemoryStore.RemoveAt(index);
            return IdentityResult.Success;
        }

        public async Task<IdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken) =>
            InMemoryStore.FirstOrDefault(a => a.Id == userId);

        public async Task<IdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken) =>
            InMemoryStore.FirstOrDefault(a => a.NormalizedUserName == normalizedUserName);

        public async Task SetPasswordHashAsync(IdentityUser user, string passwordHash, CancellationToken cancellationToken)
            => user.PasswordHash = passwordHash;

        public async Task<string> GetPasswordHashAsync(IdentityUser user, CancellationToken cancellationToken)
            => user.PasswordHash;

        public async Task<bool> HasPasswordAsync(IdentityUser user, CancellationToken cancellationToken)
            => true;
    }
}
