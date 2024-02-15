namespace Proceedings.EFCore.Repositories.Repositories.Identity
{
    public class RepositoryUsers
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RepositoryUsers(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<List<ApplicationUser>> GetAllUsersExceptedCurrentUser(ClaimsPrincipal user)
        {
            var currentUser = await _userManager.GetUserAsync(user);
            var allUsersExceptCurrentUser = await _userManager.Users.Where(a => a.Id != currentUser.Id).ToListAsync();
            return allUsersExceptCurrentUser;
        }
    }
}
