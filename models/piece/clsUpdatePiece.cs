namespace chessAPI.models.piece;

public sealed class clsUpdatePiece
{
    public clsUpdatePiece()
    {
        id = 0;
        name = "";
    }

    public int id { get; set; }
    public string name { get; set; }
}