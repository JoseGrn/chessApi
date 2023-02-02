using chessAPI.dataAccess.common;
namespace chessAPI.dataAccess.models;

public sealed class clsGameEntityModel<TI, TC> : relationalEntity<TI, TC>
        where TC : struct
        where TI : struct, IEquatable<TI>
{
    public clsGameEntityModel()
    {
        email = "";
    }

    public TI id { get; set; }
    public string email { get; set; }
    public override TI key { get => id; set => id = value; }
}