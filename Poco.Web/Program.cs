using Poco.Dal.EF;
using Microsoft.EntityFrameworkCore;
using Poco.Model.Models;

using Microsoft.AspNetCore.Identity;

using Microsoft.OpenApi.Models;
// using WebStore.DAL.EF;
// using WebStore.Model.DataModels;
// using Poco.Services.ConcreteServices;

// using Poco.Services.Configuration.Profiles;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using WebStore.Services.Interfaces;
// using Microsoft.IdentityModel.Tokens;
using System.Text;



var builder = WebApplication.CreateBuilder(args);
// Add services to the container. 
// builder.Services.AddAutoMapper(typeof(MainProfile));
builder.Services.AddDbContext<Entity>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("default")) //here you can define a database type. 
);
// builder.Services.Configure<JwtOptionsVm>(options => builder.Configuration.GetSection("JwtOptions").Bind(options));
builder.Services.AddIdentity<User, IdentityRole<int>>(o =>
{
    o.Password.RequireDigit = false;
    o.Password.RequireUppercase = false;
    o.Password.RequireLowercase = false;
    o.Password.RequireNonAlphanumeric = false;
    o.User.RequireUniqueEmail = false;
}).AddRoleManager<RoleManager<IdentityRole<int>>>()
        .AddUserManager<UserManager<User>>()
        .AddEntityFrameworkStores<Entity>()
        .AddDefaultTokenProviders();
builder.Services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
builder.Services.AddTransient(typeof(ILogger), typeof(Logger<Program>));

// builder.Services.AddAuthentication(options =>
//         {
//             options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//             options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//         })
//         .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
//         {

//             options.TokenValidationParameters = new TokenValidationParameters

//             {

//                 ValidateAudience = false,
//                 ValidateIssuer = false,
//                 ValidateIssuerSigningKey = true,
//                 IssuerSigningKey = new
// SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:SecretKey"])),

//                 ValidateLifetime = true,
//                 ClockSkew = TimeSpan.FromMinutes(5)

//             };

//         });

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore

            );

// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebStore API", Version = "v1" });
// });
var app = builder.Build();
// app.UseSwagger();
// app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebStore API v1"));
// Configure the HTTP request pipeline. 
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}
// app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllerRoute(

    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");



app.MapFallbackToFile("index.html"); ;
app.Run();
