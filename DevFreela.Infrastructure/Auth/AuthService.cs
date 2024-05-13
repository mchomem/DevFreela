namespace DevFreela.Infrastructure.Auth;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
        => _configuration = configuration;

    public string ComputeSha256Hash(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
                builder.Append(bytes[i].ToString("x2")); // x2 faz com a string seja convertida em representado em hexadecimal.

            return builder.ToString();
        }
    }

    public string GenerateJwtToken(string email, string role)
    {
        var key = _configuration.GetSection("Jwt:key").Value;
        var issuer = _configuration.GetSection("Jwt:Issuer").Value;
        var audience = _configuration.GetSection("Jwt:Audience").Value;
        var secutiryKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(secutiryKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("userEmail", email),
            new Claim(ClaimTypes.Role, role)
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            expires: DateTime.Now.AddHours(8),
            signingCredentials: credentials,
            claims: claims
            );

        var tokenHandler = new JwtSecurityTokenHandler();

        var stringToken = tokenHandler.WriteToken(token);

        return stringToken;
    }
}
