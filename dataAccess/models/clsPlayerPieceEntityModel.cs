using chessAPI.dataAccess.common;
namespace chessAPI.dataAccess.models;

public sealed class clsPlayerPieceEntityModel<TI, TC> : relationalEntity<TI, TC>
        where TC : struct
        where TI : struct, IEquatable<TI>
{
    public clsPlayerPieceEntityModel()
    {
        created_at = DateTime.Now;
        removed_on = null;
    }

    public TI id { get; set; }
    public DateTime created_at { get; set; }
    public DateTime? removed_on { get; set; }
    public override TI key { get => id; set => id = value; }
}