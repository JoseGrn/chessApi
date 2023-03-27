namespace chessAPI.dataAccess.queries.postgreSQL;

public sealed class qPiece : IQPiece
{
    private const string _selectAll = @"
    SELECT id, name
    FROM public.piece";

    private const string _selectOne = @"
    SELECT id, name
    FROM public.piece
    WHERE id=@ID";

    private const string _add = @"
    INSERT INTO public.piece(name)
	VALUES (@NAME) RETURNING id";

    private const string _delete = @"
    DELETE FROM public.piece
    WHERE id = @ID";
    
    private const string _update = @"
    UPDATE public.piece
	SET name=@NAME
	WHERE id = @ID";

    public string SQLGetAll => _selectAll;

    public string SQLDataEntity => _selectOne;

    public string NewDataEntity => _add;

    public string DeleteDataEntity => _delete;

    public string UpdateWholeEntity => _update;
}