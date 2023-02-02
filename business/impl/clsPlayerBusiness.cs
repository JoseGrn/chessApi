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

    // public Task<clsPlayer<TI>> getPlayer()
    // {

    //     return new 
    // }

    // public List<clsPlayer<TI>> getPlayers()
    // {
    //     //var x = playerRepository.getPlayers().ConfigureAwait(false);
    //     List<clsPlayer<TI>> players = new List<clsPlayer<TI>>();
    //     //players.Add(new clsPlayer<TI>(x,"mail"));
    //     return new List<clsPlayer<TI>>();
    // }
}