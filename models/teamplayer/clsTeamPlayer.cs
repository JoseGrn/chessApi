namespace chessAPI.models.teamplayer;

public sealed class clsTeamPlayer<TI>
    where TI : struct, IEquatable<TI>
{
    public clsTeamPlayer(TI id, int? team_id, int? player_id)
    {
        this.id = id;
        this.team_id = team_id;
        this.player_id = player_id;
    }

    public TI id { get; set; }
    public int? team_id { get; set; }
    public int? player_id { get; set; }
}