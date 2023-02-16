using chessAPI.dataAccess.common;
using chessAPI.dataAccess.interfaces;
using chessAPI.dataAccess.models;
using chessAPI.models.teamplayer;
using Dapper;

namespace chessAPI.dataAccess.repositores;

public sealed class clsTeamPlayerRepository<TI, TC> : clsDataAccess<clsTeamPlayerEntityModel<TI, TC>, TI, TC>, ITeamPlayerRepository<TI, TC>
        where TI : struct, IEquatable<TI>
        where TC : struct
{
    public clsTeamPlayerRepository(IRelationalContext<TC> rkm,
                               ISQLData queries,
                               ILogger<clsTeamPlayerRepository<TI, TC>> logger) : base(rkm, queries, logger)
    {
    }

    public async Task<TI> addTeamPlayer(clsNewTeamPlayer teamPlayer)
    {
        var p = new DynamicParameters();
        p.Add("@TEAM_ID", teamPlayer.team_id);
        p.Add("@PLAYER_ID", teamPlayer.player_id);
        return await add<TI>(p).ConfigureAwait(false);
    }

    public async Task<IEnumerable<clsTeamPlayerEntityModel<TI, TC>>> addTeamPlayers(IEnumerable<clsNewTeamPlayer> teamPlayers)
    {
        var r = new List<clsTeamPlayerEntityModel<TI, TC>>(teamPlayers.Count());
        foreach (var TeamPlayer in teamPlayers)
        {
            TI teamPlayerId = await addTeamPlayer(TeamPlayer).ConfigureAwait(false);
            r.Add(new clsTeamPlayerEntityModel<TI, TC>() { id = teamPlayerId, team_id = TeamPlayer.team_id, player_id = TeamPlayer.player_id});
        }
        return r;
    }

    public Task deleteTeamPlayer(TI id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<clsTeamPlayerEntityModel<TI, TC>>> getTeamPlayersByTeamPlayer(TI TeamPlayerId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<clsTeamPlayerEntityModel<TI, TC>>> getTeamPlayers()
    {
        var p = new DynamicParameters();
        return await getALL(p).ConfigureAwait(false);
    }

    public Task updateTeamPlayer(clsTeamPlayer<TI> updatedTeamPlayer)
    {
        throw new NotImplementedException();
    }

    protected override DynamicParameters fieldsAsParams(clsTeamPlayerEntityModel<TI, TC> entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var p = new DynamicParameters();
        p.Add("ID", entity.id);
        p.Add("@TEAM_ID", entity.team_id);
        p.Add("@PLAYER_ID", entity.player_id);
        return p;
    }

    protected override DynamicParameters keyAsParams(TI key)
    {
        var p = new DynamicParameters();
        p.Add("ID", key);
        return p;
    }

    public async Task<TI> updateTeamPlayers(int id, int team_id, int player_id)
    {
        var p = new DynamicParameters();
        p.Add("ID", id);
        p.Add("@TEAM_ID", team_id);
        p.Add("@PLAYER_ID", player_id);
        return await setRow<TI>(p).ConfigureAwait(false); 
    }
}