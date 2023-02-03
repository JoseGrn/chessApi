using System.Collections.Generic;
using chessAPI.business.interfaces;
using chessAPI.dataAccess.repositores;
using chessAPI.models.player;

namespace chessAPI.business.impl;

public sealed class clsPlayerBusiness<TI, TC> : IPlayerBusiness<TI> 
    where TI : struct, IEquatable<TI>
    where TC : struct
{
    internal readonly IPlayerRepository<TI, TC> playerRepository;

    public clsPlayerBusiness(IPlayerRepository<TI, TC> playerRepository)
    {
        this.playerRepository = playerRepository;
    }

    public async Task<clsPlayer<TI>> addPlayer(clsNewPlayer newPlayer)
    {
        var x = await playerRepository.addPlayer(newPlayer).ConfigureAwait(false);
        return new clsPlayer<TI>(x, newPlayer.email);
    }

    public async Task<List<clsPlayer<TI>>> getPlayers()
    {
        List<clsPlayer<TI>> players = new List<clsPlayer<TI>>();
        var x = await playerRepository.getPlayers().ConfigureAwait(false);
        foreach(var value in x){
            clsPlayer<TI> player = new clsPlayer<TI>(value.id,value.email);
            players.Add(player);
        }
        return players;
    }

    public async Task<clsPlayer<TI>> updatePlayer(clsUpdatePlayer updatePlayer)
    {
        try{
            var x = await playerRepository.updatePlayers(updatePlayer.id, updatePlayer.email).ConfigureAwait(false);
            return new clsPlayer<TI>(x, updatePlayer.email);
        }catch(Exception e){
            throw;
        }
    }
}