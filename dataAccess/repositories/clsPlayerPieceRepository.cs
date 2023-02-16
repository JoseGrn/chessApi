using chessAPI.dataAccess.common;
using chessAPI.dataAccess.interfaces;
using chessAPI.dataAccess.models;
using chessAPI.models.playerpiece;
using Dapper;

namespace chessAPI.dataAccess.repositores;

public sealed class clsPlayerPieceRepository<TI, TC> : clsDataAccess<clsPlayerPieceEntityModel<TI, TC>, TI, TC>, IPlayerPieceRepository<TI, TC>
        where TI : struct, IEquatable<TI>
        where TC : struct
{
    public clsPlayerPieceRepository(IRelationalContext<TC> rkm,
                               ISQLData queries,
                               ILogger<clsPlayerPieceRepository<TI, TC>> logger) : base(rkm, queries, logger)
    {
    }

    public async Task<TI> addPlayerPiece(clsNewPlayerPiece playerPiece)
    {
        var p = new DynamicParameters();
        p.Add("@CREATED_AT", playerPiece.created_at);
        p.Add("@REMOVED_ON", playerPiece.removed_on);
        return await add<TI>(p).ConfigureAwait(false);
    }

    public async Task<IEnumerable<clsPlayerPieceEntityModel<TI, TC>>> addPlayerPieces(IEnumerable<clsNewPlayerPiece> playerPieces)
    {
        var r = new List<clsPlayerPieceEntityModel<TI, TC>>(playerPieces.Count());
        foreach (var PlayerPiece in playerPieces)
        {
            TI PlayerPieceId = await addPlayerPiece(PlayerPiece).ConfigureAwait(false);
            r.Add(new clsPlayerPieceEntityModel<TI, TC>() { id = PlayerPieceId, created_at = PlayerPiece.created_at, removed_on = PlayerPiece.removed_on});
        }
        return r;
    }

    public Task deletePlayerPiece(TI id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<clsPlayerPieceEntityModel<TI, TC>>> getPlayerPiecesByPlayerPiece(TI playerPieceId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<clsPlayerPieceEntityModel<TI, TC>>> getPlayerPieces()
    {
        var p = new DynamicParameters();
        return await getALL(p).ConfigureAwait(false);
    }

    public Task updatePlayerPiece(clsPlayerPiece<TI> updatedPlayerPiece)
    {
        throw new NotImplementedException();
    }

    protected override DynamicParameters fieldsAsParams(clsPlayerPieceEntityModel<TI, TC> entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var p = new DynamicParameters();
        p.Add("ID", entity.id);
        p.Add("@CREATED_AT", entity.created_at);
        p.Add("@REMOVED_ON", entity.removed_on);
        return p;
    }

    protected override DynamicParameters keyAsParams(TI key)
    {
        var p = new DynamicParameters();
        p.Add("ID", key);
        return p;
    }

    public async Task<TI> updatePlayerPieces(int id, DateTime created_at, DateTime removed_on)
    {
        var p = new DynamicParameters();
        p.Add("ID", id);
        p.Add("@CREATED_AT", created_at);
        p.Add("@REMOVED_ON", removed_on);
        return await setRow<TI>(p).ConfigureAwait(false); 
    }
}