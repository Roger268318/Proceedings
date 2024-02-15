namespace Proceedings.EFCore.Repositories.Repositories.Identity
{
    public class RepositoryPermissions
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RepositoryPermissions(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<PermissionViewModel> GetClaims(string roleId)
        {
            var model = new PermissionViewModel();
            var allPermissions = new List<RoleClaimsViewModel>();

            // ESTO ES UN Helper en Carpeta /Helpers
            // Este método incluye una lista de permisos disponibles, el tipo de permiso
            // que se agregará y el ID.
            // Luego agrega todas las propiedades mencionadas en Productpermissions usando Reflection
            allPermissions.GetPermissions(typeof(Permissions.Users), roleId);
            var role = await _roleManager.FindByIdAsync(roleId);
            model.RoleId = roleId;
            var claims = await _roleManager.GetClaimsAsync(role);
            var allClaimValues = allPermissions.Select(a => a.Value).ToList();
            var roleClaimValues = claims.Select(a => a.Value).ToList();
            var authorizedClaims = allClaimValues.Intersect(roleClaimValues).ToList();
            foreach (var permission in allPermissions)
            {
                if (authorizedClaims.Any(a => a == permission.Value))
                {
                    permission.Selected = true;
                }
            }
            model.RoleClaims = allPermissions;
            return model;
        }
        public async Task<Task> UpdateClaims(PermissionViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            var claims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }
            var selectedClaims = model.RoleClaims.Where(a => a.Selected).ToList();
            foreach (var claim in selectedClaims)
            {
                // Agrega lo seleccionado en la interfaz de usuario al Rol de usuario
                // 
                await _roleManager.AddPermissionClaim(role, claim.Value);
            }
            return Task.CompletedTask;
            //return RedirectToAction("Index", new { roleId = model.RoleId });
        }
    }
}
