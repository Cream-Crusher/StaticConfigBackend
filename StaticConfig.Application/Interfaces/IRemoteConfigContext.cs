using Microsoft.EntityFrameworkCore;

namespace StaticConfig.Application.Interfaces;

public interface IRemoteConfigContext
{
        DbSet<Domain.Config> Configs { get; set; }

        Task<int> SaveChangesAsync(CancellationToken token);
}