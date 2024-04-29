using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Ytsoob.Shared.Core.Extensions;

namespace Ytsoob.Shared.Auth0;

public static class Extensions
{
    public static WebApplicationBuilder AddAuth0(this WebApplicationBuilder builder)
    {
        var optionsConf = builder.Configuration.BindOptions<Auth0Options>();
        builder.Services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = optionsConf.Authority;
                options.Audience = optionsConf.Audience;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier
                };
            });
        builder.Services.AddAuthorization();
        return builder;
    }
}
