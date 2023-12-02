using DreamTeam.Application.Common.Interfaces;
using DreamTeam.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DreamTeam.Infrastructure.Data;

public class DreamTeamContext : DreamTeamGeneratedContext, IApplicationDbContext
{
    public DreamTeamContext(DbContextOptions<DreamTeamGeneratedContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }
    
    
}
