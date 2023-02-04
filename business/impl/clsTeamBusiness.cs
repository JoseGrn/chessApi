using System.Collections.Generic;
using chessAPI.business.interfaces;
using chessAPI.dataAccess.repositores;
using chessAPI.models.team;

namespace chessAPI.business.impl;

public sealed class clsTeamBusiness<TI, TC> : ITeamBusiness<TI> 
    where TI : struct, IEquatable<TI>
    where TC : struct
{
    internal readonly ITeamRepository<TI, TC> TeamRepository;

    public clsTeamBusiness(ITeamRepository<TI, TC> TeamRepository)
    {
        this.TeamRepository = TeamRepository;
    }

    public async Task<clsTeam<TI>> addTeam(clsNewTeam newTeam)
    {
        var x = await TeamRepository.addTeam(newTeam).ConfigureAwait(false);
        return new clsTeam<TI>(x, newTeam.name, newTeam.created_at);
    }

    public async Task<List<clsTeam<TI>>> getTeams()
    {
        List<clsTeam<TI>> Teams = new List<clsTeam<TI>>();
        var x = await TeamRepository.getTeams().ConfigureAwait(false);
        foreach(var value in x){
            clsTeam<TI> Team = new clsTeam<TI>(value.id,value.name, value.created_at);
            Teams.Add(Team);
        }
        return Teams;
    }

    public async Task<clsTeam<TI>> updateTeam(clsUpdateTeam updateTeam)
    {
        var x = await TeamRepository.updateTeams(updateTeam.id, updateTeam.name, updateTeam.created_at).ConfigureAwait(false);
        return new clsTeam<TI>(x, updateTeam.name, updateTeam.created_at);
    }
}