using System.Data.Common;

namespace DreamTeam.Application.FunctionalTests;

public interface ITestDatabase
{
    Task InitialiseAsync();

    DbConnection GetConnection();

    Task ResetAsync();

    Task DisposeAsync();
}
