namespace chessAPI.dataAccess.queries.postgreSQL;

public sealed class qTeamPlayer : IQTeamPlayer
{
    private const string _selectAll = @"
    SELECT id, team_id, player_id 
    FROM public.team_player";
    private const string _selectOne = @"
    SELECT id, team_id, player_id
    FROM public.team_player
    WHERE id=@ID";
    private const string _add = @"
    INSERT INTO public.team_player(team_id, player_id)
	VALUES (@TEAM_ID, @PLAYER_ID) RETURNING id";
    private const string _delete = @"
    DELETE FROM public.team_player 
    WHERE id = @ID";
    private const string _update = @"
    UPDATE public.team_player
	SET team_id = @TEAM_ID, player_id = @PLAYER_ID
	WHERE id=@ID";

    public string SQLGetAll => _selectAll;

    public string SQLDataEntity => _selectOne;

    public string NewDataEntity => _add;

    public string DeleteDataEntity => _delete;

    public string UpdateWholeEntity => _update;
}