using chessAPI.dataAccess.models;
using chessAPI.models.playerpiece;

namespace chessAPI.dataAccess.repositores;

public interface IPlayerPieceRepository<TI, TC>
        where TI : struct, IEquatable<TI>
        where TC : struct
{
    Task<TI> addPlayerPiece(clsNewPlayerPiece playerPiece);
    Task<IEnumerable<clsPlayerPieceEntityModel<TI, TC>>> addPlayerPieces(IEnumerable<clsNewPlayerPiece> playerPieces);
    Task<IEnumerable<clsPlayerPieceEntityModel<TI, TC>>> getPlayerPieces();
    Task<TI> updatePlayerPieces(int id, DateTime created_at, DateTime removed_on);
    Task<IEnumerable<clsPlayerPieceEntityModel<TI, TC>>> getPlayerPiecesByPlayerPiece(TI playerPieceId);
    Task updatePlayerPiece(clsPlayerPiece<TI> updatedPlayerPiece);
    Task deletePlayerPiece(TI id);
}