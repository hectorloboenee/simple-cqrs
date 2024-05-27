using Microsoft.Extensions.Configuration;

namespace Simple.Cqrs.Common.infrastructure.Auth;

public class AuthSettings
{
    public const string ConfigurationSectionName = "AUTH";

    [ConfigurationKeyName("CORS_ORIGINS")]
    public string CorsOrigins { get; set; }
}
