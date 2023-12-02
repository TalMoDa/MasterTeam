using DreamTeam.Domain.Entities;

namespace DreamTeam.Application.Common.Interfaces;

public interface IApplicationDbContext
{


    DbSet<Field> Fields { get; set; }

    DbSet<Match> Matches { get; set; }

    DbSet<MatchUser> MatchUsers { get; set; }

    DbSet<Pitch> Pitches { get; set; }
    DbSet<PitchSchedule> PitchSchedules { get; set; }
    DbSet<PitchType> PitchTypes { get; set; }

    DbSet<RoleType> RoleTypes { get; set; }

    DbSet<SportType> SportTypes { get; set; }

    DbSet<Squad> Squads { get; set; }

    DbSet<Team> Teams { get; set; }

    DbSet<User> Users { get; set; }

    DbSet<UserAccount> UserAccounts { get; set; }

    DbSet<UserRanking> UserRankings { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
