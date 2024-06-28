using Microsoft.EntityFrameworkCore;
using Network.Api.Entites;

namespace Network.Api.Data;

public class NetworkContext :  DbContext
{
    public NetworkContext(DbContextOptions<NetworkContext> options)
        : base(options)
    {
    }

    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<Organization> Organizations => Set<Organization>();

}
