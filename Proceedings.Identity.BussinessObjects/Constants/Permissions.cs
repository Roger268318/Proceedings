namespace Proceedings.Identity.BussinessObjects.Constans
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
        {
            $"Permissions.{module}.Crear",
            $"Permissions.{module}.Ver",
            $"Permissions.{module}.Editar",
            $"Permissions.{module}.Borrar",
        };
        }

        public static class Users
        {
            public const string View = "Permissions.Usuarios.Ver";
            public const string Create = "Permissions.Usuarios.Crear";
            public const string Edit = "Permissions.Usuarios.Editar";
            public const string Delete = "Permissions.Usuarios.Borrar";
        }

    }
}