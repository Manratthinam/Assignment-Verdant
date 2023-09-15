

using Application.Common;
using Infrastructure.CurrentUserService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationService();
builder.Services.AddHttpContextAccessor();

builder.Services.AddInfrastructureService(builder.Configuration);

builder.Services.AddAuthentication(option =>
{
    option.DefaultScheme = "JWT_OR_Cookie";
})
    .AddCookie(option =>
    {
        option.SlidingExpiration = true;
        option.Cookie.Name = "TCourt_Cookie";
        option.ExpireTimeSpan = TimeSpan.FromDays(1);
    })
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "TCourt",
            ValidAudience = "Tcourt",
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("250992e1-67ce-4f4e-b00c-5ff858fabfed"))
        };
    })
    .AddPolicyScheme("JWT_OR_Cookie", "JWT_OR_Cookie", option =>
    {
        option.ForwardDefaultSelector = context =>
        {
            string auth = context.Request.Headers[HeaderNames.Authorization];
            if (!string.IsNullOrEmpty(auth) && auth.StartsWith("Bearer "))
                return JwtBearerDefaults.AuthenticationScheme;
            return CookieAuthenticationDefaults.AuthenticationScheme;
        };
    })
    ;


builder.Services.AddScoped<ICurrentUser, CurrentUser>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<TCourtContext>();
        db.Database.Migrate();
    }
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
