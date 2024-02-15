using Proceedings.Entities;

namespace Proceedings.WebApi
{
    public static class DbInitializer
    {
        public static void Initialize(IApplicationBuilder app)  //, UserManager<Usuario> _userManager)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ProceedingsDbContext>();
                context.Database.EnsureCreated();

                var dep1 = new Departamento()
                {
                    TipoDepartamento = "Penal",
                    Descripcion = "Departamento penal",
                    Responsable = "Javier Sánchez"

                };
                context.Departamentos.Add(dep1);

                var dep2 = new Departamento()
                {
                    TipoDepartamento = "Laboral",
                    Descripcion = "Departamento laboral",
                    Responsable = "Antonio Botella"

                };
                context.Departamentos.Add(dep2);

                var dep3 = new Departamento()
                {
                    TipoDepartamento = "Administración",
                    Descripcion = "Administración General",
                    Responsable = "Florentina López"

                };
                context.Departamentos.Add(dep3);

                var dep4 = new Departamento()
                {
                    TipoDepartamento = "Informática",
                    Descripcion = "Departamento de Medios",
                    Responsable = "Rogelio Moreno"

                };
                context.Departamentos.Add(dep4);
                context.SaveChanges();

                //var _userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var _userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var _roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!context.Users.Any(usr => usr.UserName == "rogelio.borondo@gmail.com"))
                {
                    var user = new ApplicationUser()
                    {
                        UserAccess = "Rogelio",
                        Nombre = "Rogelio",
                        Apellidos = "Moreno Borondo",
                        UserName = "rogelio.borondo@gmail.com",
                        Email = "rogelio.borondo@gmail.com",
                        EmailConfirmed = true,
                        DepartamentoId = 4,
                    };

                    var userResult = _userManager.CreateAsync(user, "Nhc268318$").Result;
                }

                if (!context.Users.Any(usr => usr.UserName == "abotella@gmail.com"))
                {
                    var user = new ApplicationUser()
                    {
                        UserAccess = "ABotella",
                        Nombre = "Antonio",
                        Apellidos = "Botella Antón",
                        UserName = "abotella@gmail.com",
                        Email = "abotella@gmail.com",
                        EmailConfirmed = true,
                        DepartamentoId = 2,
                    };

                    var userResult = _userManager.CreateAsync(user, "Nhc268318$").Result;
                }

                if (!context.Users.Any(usr => usr.UserName == "manager@test.com"))
                {
                    var user = new ApplicationUser()
                    {
                        UserAccess = "JuanLopez",
                        UserName = "manager@test.com",
                        Email = "manager@test.com",
                        EmailConfirmed = true,
                        DepartamentoId = 3,
                    };

                    var userResult = _userManager.CreateAsync(user, "P@ssw0rd").Result;
                }

                if (!context.Users.Any(usr => usr.UserName == "employee@test.com"))
                {
                    var user = new ApplicationUser()
                    {
                        UserAccess = "PepaGil",
                        UserName = "employee@test.com",
                        Email = "employee@test.com",
                        EmailConfirmed = true,
                        DepartamentoId = 3,
                    };

                    var userResult = _userManager.CreateAsync(user, "P@ssw0rd").Result;
                }

                if (!_roleManager.RoleExistsAsync("SuperAdmin").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" }).Result;
                }

                if (!_roleManager.RoleExistsAsync("Admin").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "Admin" }).Result;
                }

                if (!_roleManager.RoleExistsAsync("Manager").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "Manager" }).Result;
                }

                if (!_roleManager.RoleExistsAsync("Employee").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "Employee" }).Result;
                }

                if (!_roleManager.RoleExistsAsync("Guest").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "Guest" }).Result;
                }

                var superadminUser = _userManager.FindByNameAsync("rogelio.borondo@gmail.com").Result;
                var superadminRole = _userManager.AddToRolesAsync(superadminUser, new string[] { "SuperAdmin" }).Result;

                var adminUser = _userManager.FindByNameAsync("abotella@gmail.com").Result;
                var adminrRole = _userManager.AddToRolesAsync(adminUser, new string[] { "Admin" }).Result;

                var managerUser = _userManager.FindByNameAsync("manager@test.com").Result;
                var managerRole = _userManager.AddToRolesAsync(managerUser, new string[] { "Manager" }).Result;

                var employeeUser = _userManager.FindByNameAsync("employee@test.com").Result;
                var userRole = _userManager.AddToRolesAsync(employeeUser, new string[] { "Employee" }).Result;

                var permissions = GetPermissions();
                foreach (var item in permissions)
                {
                    if (!context.NavigationMenu.Any(n => n.Name == item.Name))
                    {
                        context.NavigationMenu.Add(item);
                    }
                }

                var _superadminRole = _roleManager.Roles.Where(x => x.Name == "SuperAdmin").FirstOrDefault();
                var _adminRole = _roleManager.Roles.Where(x => x.Name == "Admin").FirstOrDefault();
                var _managerRole = _roleManager.Roles.Where(x => x.Name == "Manager").FirstOrDefault();
                var _employeeRole = _roleManager.Roles.Where(x => x.Name == "Employee").FirstOrDefault();
                var _guestRole = _roleManager.Roles.Where(x => x.Name == "Guest").FirstOrDefault();

                if (!context.RoleMenuPermission.Any(x => x.RoleId == _adminRole.Id && x.NavigationMenuId == new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0")))
                {
                    context.RoleMenuPermission.Add(new RoleMenuPermission() { RoleId = _adminRole.Id, NavigationMenuId = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0") });
                }

                if (!context.RoleMenuPermission.Any(x => x.RoleId == _adminRole.Id && x.NavigationMenuId == new Guid("283264d6-0e5e-48fe-9d6e-b1599aa0892c")))
                {
                    context.RoleMenuPermission.Add(new RoleMenuPermission() { RoleId = _adminRole.Id, NavigationMenuId = new Guid("283264d6-0e5e-48fe-9d6e-b1599aa0892c") });
                }

                if (!context.RoleMenuPermission.Any(x => x.RoleId == _adminRole.Id && x.NavigationMenuId == new Guid("7cd0d373-c57d-4c70-aa8c-22791983fe1c")))
                {
                    context.RoleMenuPermission.Add(new RoleMenuPermission() { RoleId = _adminRole.Id, NavigationMenuId = new Guid("7cd0d373-c57d-4c70-aa8c-22791983fe1c") });
                }

                if (!context.RoleMenuPermission.Any(x => x.RoleId == _adminRole.Id && x.NavigationMenuId == new Guid("F704BDFD-D3EA-4A6F-9463-DA47ED3657AB")))
                {
                    context.RoleMenuPermission.Add(new RoleMenuPermission() { RoleId = _adminRole.Id, NavigationMenuId = new Guid("F704BDFD-D3EA-4A6F-9463-DA47ED3657AB") });
                }

                if (!context.RoleMenuPermission.Any(x => x.RoleId == _adminRole.Id && x.NavigationMenuId == new Guid("913BF559-DB46-4072-BD01-F73F3C92E5D5")))
                {
                    context.RoleMenuPermission.Add(new RoleMenuPermission() { RoleId = _adminRole.Id, NavigationMenuId = new Guid("913BF559-DB46-4072-BD01-F73F3C92E5D5") });
                }

                if (!context.RoleMenuPermission.Any(x => x.RoleId == _adminRole.Id && x.NavigationMenuId == new Guid("3C1702C5-C34F-4468-B807-3A1D5545F734")))
                {
                    context.RoleMenuPermission.Add(new RoleMenuPermission() { RoleId = _adminRole.Id, NavigationMenuId = new Guid("3C1702C5-C34F-4468-B807-3A1D5545F734") });
                }

                if (!context.RoleMenuPermission.Any(x => x.RoleId == _adminRole.Id && x.NavigationMenuId == new Guid("94C22F11-6DD2-4B9C-95F7-9DD4EA1002E6")))
                {
                    context.RoleMenuPermission.Add(new RoleMenuPermission() { RoleId = _adminRole.Id, NavigationMenuId = new Guid("94C22F11-6DD2-4B9C-95F7-9DD4EA1002E6") });
                }

                if (!context.RoleMenuPermission.Any(x => x.RoleId == _managerRole.Id && x.NavigationMenuId == new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0")))
                {
                    context.RoleMenuPermission.Add(new RoleMenuPermission() { RoleId = _managerRole.Id, NavigationMenuId = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0") });
                }

                if (!context.RoleMenuPermission.Any(x => x.RoleId == _managerRole.Id && x.NavigationMenuId == new Guid("283264d6-0e5e-48fe-9d6e-b1599aa0892c")))
                {
                    context.RoleMenuPermission.Add(new RoleMenuPermission() { RoleId = _managerRole.Id, NavigationMenuId = new Guid("283264d6-0e5e-48fe-9d6e-b1599aa0892c") });
                }

                var dateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat;

                var cliente1 = new Cliente()
                {
                    DNI = "33478735TG",
                    Nombre = "Rogelio",
                    Apellidos = "Moreno Borondo",
                    Domicilio = "Eugenio D'Ors nº 5",
                    Poblacion = "Elche",
                    Provincia = "Alicante",
                    CP = "03203",
                    Nacionalidad = "Española",
                    Pais = "España",
                    Telefono = "966670534",
                    Movil = "613869595",
                    Email = "rogelio.borondo@gmail.com",
                    FechaAlta = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", dateTimeFormat),
                    UserAccess = "Rogelio"
                };

                context.Clientes.Add(cliente1);

                var cliente2 = new Cliente()
                {
                    DNI = "33444555G",
                    Nombre = "David",
                    Apellidos = "Martorell Moreno",
                    Domicilio = "Eugenio D'Ors nº 5",
                    Poblacion = "Elche",
                    Provincia = "Alicante",
                    CP = "03203",
                    Nacionalidad = "Española",
                    Pais = "España",
                    Telefono = "966685544",
                    Movil = "613869595",
                    Email = "david.martorell@gmail.com",
                    FechaAlta = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", dateTimeFormat),
                    UserAccess = "Rogelio"
                };
                context.Clientes.Add(cliente2);

                //**************************************************************************************************

                var expediente1 = new Expediente()
                {
                    AnyoExpediente = 2021,
                    NumeroExpediente = "1",
                    DNI = "33478735TG",
                    Nombre = "Rogelio",
                    Apellidos = "Moreno Borondo",
                    Descripcion = "Compra casa",
                    Domicilio = "Eugenio d'ors",
                    Poblacion = "Elche",
                    Provincia = "Alicante",
                    Nacionalidad = "Española",
                    Pais = "España",
                    FechaAlta = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", dateTimeFormat),
                    Telefono = "966685544",
                    Movil = "613869595",
                    Fax = "",
                    Email = "rogelio.borondo@gmail.com",
                    UserAccess = "Rogelio",
                    ClienteId = 1,
                    DepartamentoId = 1

                };
                context.Expedientes.Add(expediente1);

                var expediente2 = new Expediente()
                {
                    AnyoExpediente = 2021,
                    NumeroExpediente = "2",
                    DNI = "33478735TG",
                    Nombre = "Rogelio",
                    Apellidos = "Moreno Borondo",
                    Descripcion = "Juicio penal",
                    Domicilio = "Eugenio d'ors",
                    Poblacion = "Elche",
                    Provincia = "Alicante",
                    Nacionalidad = "Española",
                    Pais = "España",
                    FechaAlta = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", dateTimeFormat),
                    Telefono = "966685544",
                    Movil = "613869595",
                    Fax = "",
                    Email = "rogelio.borondo@gmail.com",
                    UserAccess = "Rogelio",
                    ClienteId = 1,
                    DepartamentoId = 2

                };
                context.Expedientes.Add(expediente2);

                var expediente3 = new Expediente()
                {
                    AnyoExpediente = 2021,
                    NumeroExpediente = "3",
                    DNI = "33444555G",
                    Nombre = "David",
                    Apellidos = "Martorell Moreno",
                    Descripcion = "Herencia",
                    Domicilio = "Eugenio d'ors",
                    Poblacion = "Elche",
                    Provincia = "Alicante",
                    Nacionalidad = "Española",
                    Pais = "España",
                    FechaAlta = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", dateTimeFormat),
                    Telefono = "966685544",
                    Movil = "613869595",
                    Fax = "",
                    Email = "david.martorell@gmail.com",
                    UserAccess = "Rogelio",
                    ClienteId = 2,
                    DepartamentoId = 1

                };
                context.Expedientes.Add(expediente3);



                context.SaveChanges();

                //context.Clientes = new List<Cliente>();

            }
        }

        private static List<NavigationMenu> GetPermissions()
        {
            return new List<NavigationMenu>()
            {
                new NavigationMenu()
                {
                    Id = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
                    Name = "Admin",
                    ControllerName = "",
                    ActionName = "",
                    ParentMenuId = null,
                    DisplayOrder=1,
                    Visible = true,
                },
                new NavigationMenu()
                {
                    Id = new Guid("283264d6-0e5e-48fe-9d6e-b1599aa0892c"),
                    Name = "Roles",
                    ControllerName = "Admin",
                    ActionName = "Roles",
                    ParentMenuId = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
                    DisplayOrder=1,
                    Visible = true,
                },
                new NavigationMenu()
                {
                    Id = new Guid("7cd0d373-c57d-4c70-aa8c-22791983fe1c"),
                    Name = "Users",
                    ControllerName = "Admin",
                    ActionName = "Users",
                    ParentMenuId = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
                    DisplayOrder=3,
                    Visible = true,
                },
                new NavigationMenu()
                {
                    Id = new Guid("F704BDFD-D3EA-4A6F-9463-DA47ED3657AB"),
                    Name = "External Google Link",
                    ControllerName = "",
                    ActionName = "",
                    IsExternal = true,
                    ExternalUrl = "https://www.google.com/",
                    ParentMenuId = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
                    DisplayOrder=2,
                    Visible = true,
                },
                new NavigationMenu()
                {
                    Id = new Guid("913BF559-DB46-4072-BD01-F73F3C92E5D5"),
                    Name = "Create Role",
                    ControllerName = "Admin",
                    ActionName = "CreateRole",
                    ParentMenuId = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
                    DisplayOrder=3,
                    Visible = true,
                },
                new NavigationMenu()
                {
                    Id = new Guid("3C1702C5-C34F-4468-B807-3A1D5545F734"),
                    Name = "Edit User",
                    ControllerName = "Admin",
                    ActionName = "EditUser",
                    ParentMenuId = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
                    DisplayOrder=3,
                    Visible = false,
                },
                new NavigationMenu()
                {
                    Id = new Guid("94C22F11-6DD2-4B9C-95F7-9DD4EA1002E6"),
                    Name = "Edit Role Permission",
                    ControllerName = "Admin",
                    ActionName = "EditRolePermission",
                    ParentMenuId = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
                    DisplayOrder=3,
                    Visible = false,
                },
            };
        }
    }
}