using chessAPI.business.interfaces;
using chessAPI.dataAccess.repositores;
using chessAPI.models.playerpiece;

namespace chessAPI.business.impl;

public sealed class clsPlayerPieceBusiness<TI, TC> : IPlayerPieceBusiness<TI> 
    where TI : struct, IEquatable<TI>
    where TC : struct
{
    internal readonly IPlayerPieceRepository<TI, TC> PlayerPieceRepository;

    public clsPlayerPieceBusiness(IPlayerPieceRepository<TI, TC> PlayerPieceRepository)
    {
        this.PlayerPieceRepository = PlayerPieceRepository;
    }

    public async Task<clsPlayerPiece<TI>> addPlayerPiece(clsNewPlayerPiece newPlayerPiece)
    {
        var x = await PlayerPieceRepository.addPlayerPiece(newPlayerPiece).ConfigureAwait(false);
        return new clsPlayerPiece<TI>(x, newPlayerPiece.created_at, newPlayerPiece.removed_on);
    }

    public async Task<List<clsPlayerPiece<TI>>> getPlayerPieces()
    {
        List<clsPlayerPiece<TI>> PlayerPieces = new List<clsPlayerPiece<TI>>();
        var x = await PlayerPieceRepository.getPlayerPieces().ConfigureAwait(false);
        foreach(var value in x){
            clsPlayerPiece<TI> player = new clsPlayerPiece<TI>(value.id,value.created_at, value.removed_on);
            PlayerPieces.Add(player);
        }
        return PlayerPieces;
    }

    public async Task<clsPlayerPiece<TI>> updatePlayerPiece(clsUpdatePlayerPiece updatePlayerPiece)
    {
        var x = await PlayerPieceRepository.updatePlayerPieces(updatePlayerPiece.id, updatePlayerPiece.created_at, updatePlayerPiece.removed_on).ConfigureAwait(false);
        return new clsPlayerPiece<TI>(x, updatePlayerPiece.created_at, updatePlayerPiece.removed_on);
    }
}