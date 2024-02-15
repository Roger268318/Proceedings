using Proceedings.EFCore.Repositories.Repositories.Identity;
using Proceedings.EFCore.Repositories.Security;
using Proceedings.Identity.BussinessObjects.Interfaces.Repositories.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
var connectionString = builder.Configuration.GetConnectionString("DBConnection");
builder.Services.AddDbContext<ProceedingsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
//*******************************************************************************************************
builder.Services.AddControllers(opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});
//*******************************************************************************************************
builder.Services.AddScoped<IJwtGenerador, JwtGenerador>();
builder.Services.AddScoped<IUserSesion, UserSesion>();
builder.Services.AddTransient(typeof(IRepositoryUserAccess), typeof(RepositoryUserAccess));
//*******************************************************************************************************
//Add Identity
builder.Services.AddIdentityCore<ApplicationUser>()
    .AddSignInManager<SignInManager<ApplicationUser>>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ProceedingsDbContext>();
builder.Services.AddSingleton(TimeProvider.System);
//builder.Services.TryAddSingleton<ISystemClock, SystemClock>();
//*******************************************************************************************************
//*******************************************************************************************************
var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        //ValidateIssuerSigningKey = true,
        //IssuerSigningKey = key,
        //ValidateAudience = false,
        //ValidateIssuer = false,

        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});
//builder.Services.AddRazorPages();
//*******************************************************************************************************

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(Program));
//*******************************************************************************************************
//***********************   MIDDLEWARE  *****************************************************************
//*******************************************************************************************************
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//DbInitializer.Initialize(app);

app.UseHsts();
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
//    var logger = loggerFactory.CreateLogger("app");

//    try
//    {
//        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
//        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
//        await Proceedings.EFCore.Repositories.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
//        await Proceedings.EFCore.Repositories.Seeds.DefaultUsers.SeedBasicUserAsync(userManager, roleManager);
//        await Proceedings.EFCore.Repositories.Seeds.DefaultUsers.SeedSuperAdminAsync(userManager, roleManager);
//        logger.LogInformation("Finished Seeding Default Data");
//        logger.LogInformation("Application Starting");
//    }
//    catch (Exception ex)
//    {
//        logger.LogWarning(ex, "An error occurred seeding the DB");
//    }
//}

app.Run();

/*

public async static Task Main(string[] args)
{
    var host = CreateHostBuilder(args).Build();
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger("app");
        try
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            await Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
            await Seeds.DefaultUsers.SeedBasicUserAsync(userManager, roleManager);
            await Seeds.DefaultUsers.SeedSuperAdminAsync(userManager, roleManager);
            logger.LogInformation("Finished Seeding Default Data");
            logger.LogInformation("Application Starting");
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "An error occurred seeding the DB");
        }
    }
    host.Run();
}

 * */