using chessAPI.dataAccess.models;
using chessAPI.models.piece;

namespace chessAPI.dataAccess.repositores;

public interface IPieceRepository<TI, TC>
        where TI : struct, IEquatable<TI>
        where TC : struct
{
    Task<TI> addPiece(clsNewPiece Piece);
    Task<IEnumerable<clsPieceEntityModel<TI, TC>>> addPieces(IEnumerable<clsNewPiece> Pieces);
    Task<IEnumerable<clsPieceEntityModel<TI, TC>>> getPieces();
    Task<TI> updatePieces(int id, string name);
    Task<IEnumerable<clsPieceEntityModel<TI, TC>>> getPiecesByPiece(TI PieceId);
    Task updatePiece(clsPiece<TI> updatedPiece);
    Task deletePiece(TI id);
}