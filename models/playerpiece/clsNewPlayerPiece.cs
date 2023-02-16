namespace chessAPI.models.playerpiece;

public sealed class clsNewPlayerPiece
{
    public clsNewPlayerPiece()
    {
        created_at = DateTime.Now;
        removed_on = null;
    }

    public DateTime created_at { get; set; }
    public DateTime? removed_on { get; set; }
}