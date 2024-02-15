namespace Proceedings.EFCore.Repositories.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Manager.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Employee.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Lawyer.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Guest.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));

        }
    }
}