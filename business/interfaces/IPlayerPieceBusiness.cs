using chessAPI.models.playerpiece;

namespace chessAPI.business.interfaces;

public interface IPlayerPieceBusiness<TI> 
    where TI : struct, IEquatable<TI>
{
    Task<clsPlayerPiece<TI>> addPlayerPiece(clsNewPlayerPiece newPlayerPiece);
    Task<List<clsPlayerPiece<TI>>> getPlayerPieces();
    Task<clsPlayerPiece<TI>> updatePlayerPiece(clsUpdatePlayerPiece updatePlayerPiece);
}