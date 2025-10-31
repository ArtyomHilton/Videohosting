namespace Videohosting.Host.Options;

/// <summary>
/// Настройка параметров JWT токена. 
/// </summary>
public class JwtOptions
{
    public string Audience { get; set; } = string.Empty;
    public bool ValidateAudience { get; set; } = true;
    public string Issuer { get; set; } = string.Empty;
    public bool ValidateIssuer { get; set; } = true;
    public bool ValidateLifetime { get; set; } = true;
    public string Key { get; set; } = string.Empty;
    public bool ValidateIssuerSigningKey { get; set; } = true;
    public int ClockSkewMinute { get; set; } = 0;
}