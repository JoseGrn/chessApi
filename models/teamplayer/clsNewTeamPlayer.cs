namespace chessAPI.models.teamplayer;

public sealed class clsNewTeamPlayer
{
    public clsNewTeamPlayer()
    {
        team_id = 0;
        player_id = 0;
    }

    public int? team_id { get; set; }
    public int? player_id { get; set; }
}