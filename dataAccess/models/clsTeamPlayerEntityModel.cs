using chessAPI.dataAccess.common;
namespace chessAPI.dataAccess.models;

public sealed class clsTeamPlayerEntityModel<TI, TC> : relationalEntity<TI, TC>
        where TC : struct
        where TI : struct, IEquatable<TI>
{
    public clsTeamPlayerEntityModel()
    {
        team_id = 0;
        player_id = 0;
    }

    public TI id { get; set; }
    public int? team_id { get; set; }
    public int? player_id { get; set; }
    public override TI key { get => id; set => id = value; }
}