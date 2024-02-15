namespace Proceedings.EFCore.Repositories.Repositories.Identity
{
    public class RepositoryRoles
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RepositoryRoles(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<List<IdentityRole>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }


        public async Task<Task> AddRole(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return Task.CompletedTask;
        }
    }
}
