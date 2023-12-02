using System;
using System.Collections.Generic;
using DreamTeam.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace DreamTeam.Infrastructure.Context;

public partial class DreamTeamContext : DbContext
{
    public DreamTeamContext()
    {
    }

    public DreamTeamContext(DbContextOptions<DreamTeamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole>? AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim>? AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser>? AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim>? AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin>? AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken>? AspNetUserTokens { get; set; }

    public virtual DbSet<Field>? Fields { get; set; }

    public virtual DbSet<Match>? Matches { get; set; }

    public virtual DbSet<MatchUser>? MatchUsers { get; set; }

    public virtual DbSet<Pitch>? Pitches { get; set; }

    public virtual DbSet<PitchSchedule>? PitchSchedules { get; set; }

    public virtual DbSet<PitchType>? PitchTypes { get; set; }

    public virtual DbSet<RoleType>? RoleTypes { get; set; }

    public virtual DbSet<SportType>? SportTypes { get; set; }

    public virtual DbSet<Squad>? Squads { get; set; }

    public virtual DbSet<Team>? Teams { get; set; }

    public virtual DbSet<TodoItem>? TodoItems { get; set; }

    public virtual DbSet<TodoList>? TodoLists { get; set; }

    public virtual DbSet<User>? Users { get; set; }

    public virtual DbSet<UserAccount>? UserAccounts { get; set; }

    public virtual DbSet<UserRanking>? UserRankings { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Hebrew_CI_AI");

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Field>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Field_pk");

            entity.ToTable("Field");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.District).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ZipCode).HasMaxLength(50);

            entity.HasOne(d => d.Manager).WithMany(p => p.Fields)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Field_fk_ManagerId");
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Match_pk");

            entity.ToTable("Match");

            entity.Property(e => e.CompletedDate).HasColumnType("datetime");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatorNavigation).WithMany(p => p.MatchCreatorNavigations)
                .HasForeignKey(d => d.Creator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Match_Creator_fk");

            entity.HasOne(d => d.ModifierNavigation).WithMany(p => p.MatchModifierNavigations)
                .HasForeignKey(d => d.Modifier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Match_Modifier_fk");

            entity.HasOne(d => d.Pitch).WithMany(p => p.Matches)
                .HasForeignKey(d => d.PitchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Match_FieldId_fk");

            entity.HasOne(d => d.Team).WithMany(p => p.Matches)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Match_TeamId_fk");
        });

        modelBuilder.Entity<MatchUser>(entity =>
        {
            entity.HasKey(e => new { e.MatchId, e.UserId }).HasName("MatchUsers_pk");

            entity.ToTable("Match_Users");

            entity.HasOne(d => d.Match).WithMany(p => p.MatchUsers)
                .HasForeignKey(d => d.MatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MatchId_fk");
        });

        modelBuilder.Entity<Pitch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pitch_pk");

            entity.ToTable("Pitch");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Field).WithMany(p => p.Pitches)
                .HasForeignKey(d => d.FieldId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Pitch_fk_FieldId");

            entity.HasOne(d => d.PitchType).WithMany(p => p.Pitches)
                .HasForeignKey(d => d.PitchTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pitch_PitchTypeId");

            entity.HasOne(d => d.SportType).WithMany(p => p.Pitches)
                .HasForeignKey(d => d.SportTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pitch_SportTypeId");
        });

        modelBuilder.Entity<PitchSchedule>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PitchSchedule");
        });

        modelBuilder.Entity<PitchType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PitchTypes_pk");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<RoleType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("RoleTypes_pk");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<SportType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SportTypes_pk");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Squad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Squad_pk");

            entity.ToTable("Squad");

            entity.HasOne(d => d.Match).WithMany(p => p.Squads)
                .HasForeignKey(d => d.MatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Squad_MatchId_fk");

            entity.HasMany(d => d.Users).WithMany(p => p.Squads)
                .UsingEntity<Dictionary<string, object>>(
                    "SquadUser",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("SquadPlayers_UserId_fk"),
                    l => l.HasOne<Squad>().WithMany()
                        .HasForeignKey("SquadId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("SquadPlayers_SquadId_fk"),
                    j =>
                    {
                        j.HasKey("SquadId", "UserId").HasName("SquadPlayers_pk");
                        j.ToTable("Squad_Users");
                    });
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Teams_pk");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.CreatorNavigation).WithMany(p => p.TeamCreatorNavigations)
                .HasForeignKey(d => d.Creator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Creator_fk");

            entity.HasOne(d => d.ModifierNavigation).WithMany(p => p.TeamModifierNavigations)
                .HasForeignKey(d => d.Modifier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Modifier_fk");

            entity.HasOne(d => d.SportType).WithMany(p => p.Teams)
                .HasForeignKey(d => d.SportTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SportTypes_fk_SportTypeId");

            entity.HasMany(d => d.Users).WithMany(p => p.Teams)
                .UsingEntity<Dictionary<string, object>>(
                    "TeamsUser",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("UserId_fk"),
                    l => l.HasOne<Team>().WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("TeamId_fk"),
                    j =>
                    {
                        j.HasKey("TeamId", "UserId").HasName("TeamsPlayers_pk");
                        j.ToTable("Teams_Users");
                    });
        });

        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasIndex(e => e.ListId, "IX_TodoItems_ListId");

            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.List).WithMany(p => p.TodoItems).HasForeignKey(d => d.ListId);
        });

        modelBuilder.Entity<TodoList>(entity =>
        {
            entity.Property(e => e.ColourCode).HasColumnName("Colour_Code");
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0735093D6E");

            entity.HasIndex(e => e.UserAccountId, "UQ__Users__DA6C709B325780EE").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.ZipCode).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Users_fk_RoleId");

            entity.HasOne(d => d.UserAccount).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.UserAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Users_fk_UserAccountId");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserAcco__3214EC070753D665");

            entity.ToTable("UserAccount");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.HashedPassword)
                .HasMaxLength(64)
                .IsFixedLength();
            entity.Property(e => e.Salt)
                .HasMaxLength(64)
                .IsFixedLength();
        });

        modelBuilder.Entity<UserRanking>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.TeamId }).HasName("UserRankings_pk");

            entity.Property(e => e.RankAverage)
                .HasComputedColumnSql("(isnull([RankSum]/[NumberOfRankers],(0)))", false)
                .HasColumnType("decimal(29, 11)");
            entity.Property(e => e.RankSum).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.User).WithMany(p => p.UserRankings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserRankings_fk_UserId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
