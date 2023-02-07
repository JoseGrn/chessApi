using chessAPI.dataAccess.models;
using chessAPI.models.teamplayer;

namespace chessAPI.dataAccess.repositores;

public interface ITeamPlayerRepository<TI, TC>
        where TI : struct, IEquatable<TI>
        where TC : struct
{
    Task<TI> addTeamPlayer(clsNewTeamPlayer teamPlayer);
    Task<IEnumerable<clsTeamPlayerEntityModel<TI, TC>>> addTeamPlayers(IEnumerable<clsNewTeamPlayer> teamPlayers);
    Task<IEnumerable<clsTeamPlayerEntityModel<TI, TC>>> getTeamPlayers();
    Task<TI> updateTeamPlayers(int id, int team_id, int player_id);
    Task<IEnumerable<clsTeamPlayerEntityModel<TI, TC>>> getTeamPlayersByTeamPlayer(TI teamPlayerId);
    Task updateTeamPlayer(clsTeamPlayer<TI> updatedTeamPlayer);
    Task deleteTeamPlayer(TI id);
}