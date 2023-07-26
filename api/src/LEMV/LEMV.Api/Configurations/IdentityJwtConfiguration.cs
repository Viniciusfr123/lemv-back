using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LEMV.Api.Configurations
{
    public static class IdentityJwtConfiguration
    {
        public static IServiceCollection AddIdentityJwt(this IServiceCollection services)
        {
            //services.AddIdentity<AppUser, IdentityRole<Guid>>()
            //        .AddRoles<IdentityRole<Guid>>()
            //        .AddEntityFrameworkStores<ApplicationDbContext>();

            //JWT
            var key = Encoding.ASCII.GetBytes("TESTESUPERSECRETO");
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}