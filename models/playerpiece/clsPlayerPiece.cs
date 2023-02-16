namespace chessAPI.models.playerpiece;

public sealed class clsPlayerPiece<TI>
    where TI : struct, IEquatable<TI>
{
    public clsPlayerPiece(TI id, DateTime created_at, DateTime? removed_on)
    {
        this.id = id;
        this.created_at = created_at;
        this.removed_on = removed_on;
    }

    public TI id { get; set; }
    public DateTime created_at { get; set; }
    public DateTime? removed_on { get; set; }
}