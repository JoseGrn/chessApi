using chessAPI.dataAccess.common;
using chessAPI.dataAccess.interfaces;
using chessAPI.dataAccess.models;
using chessAPI.models.team;
using Dapper;

namespace chessAPI.dataAccess.repositores;

public sealed class clsTeamRepository<TI, TC> : clsDataAccess<clsTeamEntityModel<TI, TC>, TI, TC>, ITeamRepository<TI, TC>
        where TI : struct, IEquatable<TI>
        where TC : struct
{
    public clsTeamRepository(IRelationalContext<TC> rkm,
                               ISQLData queries,
                               ILogger<clsTeamRepository<TI, TC>> logger) : base(rkm, queries, logger)
    {
    }

    public async Task<TI> addTeam(clsNewTeam Team)
    {
        var p = new DynamicParameters();
        p.Add("NAME", Team.name);
        p.Add("CREATED_AT", Team.created_at);
        return await add<TI>(p).ConfigureAwait(false);
    }

    public async Task<IEnumerable<clsTeamEntityModel<TI, TC>>> addTeams(IEnumerable<clsNewTeam> Teams)
    {
        var r = new List<clsTeamEntityModel<TI, TC>>(Teams.Count());
        foreach (var Team in Teams)
        {
            TI TeamId = await addTeam(Team).ConfigureAwait(false);
            r.Add(new clsTeamEntityModel<TI, TC>() { id = TeamId, name = Team.name, created_at = DateTime.Now });
        }
        return r;
    }

    public Task deleteTeam(TI id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<clsTeamEntityModel<TI, TC>>> getTeams()
    {
        var p = new DynamicParameters();
        return await getALL(p).ConfigureAwait(false);
    }

    public Task<IEnumerable<clsTeamEntityModel<TI, TC>>> getTeamsByTeam(TI gameId)
    {
        throw new NotImplementedException();
    }

    public Task updateTeam(clsTeam<TI> updatedTeam)
    {
        throw new NotImplementedException();
    }

    public async Task<TI> updateTeams(int id, string name, DateTime created_at)
    {
        var p = new DynamicParameters();
        p.Add("ID", id);
        p.Add("NAME", name);
        p.Add("CREATED_AT", created_at);
        return await setRow<TI>(p).ConfigureAwait(false); 
    }

    protected override DynamicParameters fieldsAsParams(clsTeamEntityModel<TI, TC> entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var p = new DynamicParameters();
        p.Add("ID", entity.id);
        p.Add("NAME", entity.name);
        p.Add("CREATED_AT", entity.created_at);
        return p;
    }

    protected override DynamicParameters keyAsParams(TI key)
    {
        var p = new DynamicParameters();
        p.Add("ID", key);
        return p;
    }
}