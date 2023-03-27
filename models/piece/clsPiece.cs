namespace chessAPI.models.piece;

public sealed class clsPiece<TI>
    where TI : struct, IEquatable<TI>
{
    public clsPiece(TI id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public TI id { get; set; }
    public string name { get; set; }
}