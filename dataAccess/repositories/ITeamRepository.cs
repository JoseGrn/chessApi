using chessAPI.dataAccess.models;
using chessAPI.models.team;

namespace chessAPI.dataAccess.repositores;

public interface ITeamRepository<TI, TC>
        where TI : struct, IEquatable<TI>
        where TC : struct
{
    Task<TI> addTeam(clsNewTeam Team);
    Task<IEnumerable<clsTeamEntityModel<TI, TC>>> addTeams(IEnumerable<clsNewTeam> Teams);
    Task<IEnumerable<clsTeamEntityModel<TI, TC>>> getTeams();
    Task<TI> updateTeams(int id, string mail, DateTime created_date);
    Task<IEnumerable<clsTeamEntityModel<TI, TC>>> getTeamsByTeam(TI TeamId);
    Task updateTeam(clsTeam<TI> updatedTeam);
    Task deleteTeam(TI id);
}