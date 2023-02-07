namespace chessAPI.models.teamplayer;

public sealed class clsUpdateTeamPlayer
{
    public clsUpdateTeamPlayer()
    {
        id = 0;
        team_id = 0;
        player_id = 0;
    }

    public int id { get; set; }
    public int team_id { get; set; }
    public int player_id { get; set; }
}