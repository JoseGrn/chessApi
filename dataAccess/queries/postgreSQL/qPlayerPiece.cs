namespace chessAPI.dataAccess.queries.postgreSQL;

public sealed class qPlayerPiece : IQPlayerPiece
{
    private const string _selectAll = @"
    SELECT id, created_at, removed_on 
    FROM public.player_piece";
    private const string _selectOne = @"
    SELECT id, created_at, removed_on
    FROM public.player_piece
    WHERE id=@ID";
    private const string _add = @"
    INSERT INTO public.player_piece(created_at, removed_on)
	VALUES (@CREATED_AT, @REMOVED_ON) RETURNING id";
    private const string _delete = @"
    DELETE FROM public.player_piece 
    WHERE id = @ID";
    private const string _update = @"
    UPDATE public.player_piece
	SET created_at = @CREATED_AT, removed_on = @REMOVED_ON
	WHERE id=@ID";

    public string SQLGetAll => _selectAll;

    public string SQLDataEntity => _selectOne;

    public string NewDataEntity => _add;

    public string DeleteDataEntity => _delete;

    public string UpdateWholeEntity => _update;
}