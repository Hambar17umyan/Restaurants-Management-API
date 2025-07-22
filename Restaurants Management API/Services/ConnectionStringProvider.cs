using Domain.Infrastructure.Contracts;

namespace Restaurants_Management_API.Services;

public class ConnectionStringProvider(IConfiguration configuration) : IConnectionStringProvider
{
    private readonly IConfiguration _configuration = configuration;

    public string GetConnectionString()
    {
        var connectionString = this._configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
        }

        return connectionString;
    }
}
