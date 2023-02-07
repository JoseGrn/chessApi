using chessAPI.models.teamplayer;

namespace chessAPI.business.interfaces;

public interface ITeamPlayerBusiness<TI> 
    where TI : struct, IEquatable<TI>
{
    Task<clsTeamPlayer<TI>> addTeamPlayer(clsNewTeamPlayer newTeamPlayer);
    Task<List<clsTeamPlayer<TI>>> getTeamPlayers();
    Task<clsTeamPlayer<TI>> updateTeamPlayer(clsUpdateTeamPlayer updateTeamPlayer);
}