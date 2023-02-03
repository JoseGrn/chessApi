using chessAPI.models.player;

namespace chessAPI.business.interfaces;

public interface IPlayerBusiness<TI> 
    where TI : struct, IEquatable<TI>
{
    Task<clsPlayer<TI>> addPlayer(clsNewPlayer newPlayer);
    Task<List<clsPlayer<TI>>> getPlayers();
    Task<clsPlayer<TI>> updatePlayer(clsUpdatePlayer updatePlayer);
}