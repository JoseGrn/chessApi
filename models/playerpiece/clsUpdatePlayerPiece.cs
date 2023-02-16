namespace chessAPI.models.playerpiece;

public sealed class clsUpdatePlayerPiece
{
    public clsUpdatePlayerPiece()
    {
        id = 0;
        created_at = DateTime.Now;
        removed_on = DateTime.Now;
    }

    public int id { get; set; }
    public DateTime created_at { get; set; }
    public DateTime removed_on { get; set; }
}