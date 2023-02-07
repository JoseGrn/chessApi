using chessAPI.business.interfaces;
using chessAPI.dataAccess.repositores;
using chessAPI.models.teamplayer;

namespace chessAPI.business.impl;

public sealed class clsTeamPlayerBusiness<TI, TC> : ITeamPlayerBusiness<TI> 
    where TI : struct, IEquatable<TI>
    where TC : struct
{
    internal readonly ITeamPlayerRepository<TI, TC> TeamPlayerRepository;

    public clsTeamPlayerBusiness(ITeamPlayerRepository<TI, TC> TeamPlayerRepository)
    {
        this.TeamPlayerRepository = TeamPlayerRepository;
    }

    public async Task<clsTeamPlayer<TI>> addTeamPlayer(clsNewTeamPlayer newTeamPlayer)
    {
        var x = await TeamPlayerRepository.addTeamPlayer(newTeamPlayer).ConfigureAwait(false);
        return new clsTeamPlayer<TI>(x, newTeamPlayer.team_id, newTeamPlayer.player_id);
    }

    public async Task<List<clsTeamPlayer<TI>>> getTeamPlayers()
    {
        List<clsTeamPlayer<TI>> TeamPlayers = new List<clsTeamPlayer<TI>>();
        var x = await TeamPlayerRepository.getTeamPlayers().ConfigureAwait(false);
        foreach(var value in x){
            clsTeamPlayer<TI> player = new clsTeamPlayer<TI>(value.id,value.team_id, value.player_id);
            TeamPlayers.Add(player);
        }
        return TeamPlayers;
    }

    public async Task<clsTeamPlayer<TI>> updateTeamPlayer(clsUpdateTeamPlayer updateTeamPlayer)
    {
        var x = await TeamPlayerRepository.updateTeamPlayers(updateTeamPlayer.id, updateTeamPlayer.team_id, updateTeamPlayer.player_id).ConfigureAwait(false);
        return new clsTeamPlayer<TI>(x, updateTeamPlayer.team_id, updateTeamPlayer.player_id);
    }
}